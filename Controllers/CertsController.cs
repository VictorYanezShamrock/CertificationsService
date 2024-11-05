using CertsService.Models.SIF;
using CertsService.Models.Shamrock;
using CertsService.Functions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CertsController : ControllerBase
{
    private readonly SifContext _sifContext;
    private readonly ShamrockIntContext _shamrockContext;
    public CertsController(SifContext sifContext, ShamrockIntContext shamrockContext)
    {
        _sifContext = sifContext;
        _shamrockContext = shamrockContext;
    }

   [HttpGet("{so}")]
    public async Task<IActionResult> GetCertsDataAsync(int so)
    {
        // Step 1: Get the aggregated data from SifContext (ORDR and RDR1) asynchronously.
        var sifData = await (
            from ordr in _sifContext.Ordrs
            join rdr1 in _sifContext.Rdr1s on ordr.DocEntry equals rdr1.DocEntry
            where ordr.DocNum == so
            group rdr1 by new
            {
                ordr.DocNum,
                ordr.Canceled,
                ordr.ShipToCode,
                ordr.CardCode,
                ordr.CardName,
                ordr.NumAtCard,
                ordr.DocDueDate,
                rdr1.ItemCode
            } into grouped
            select new
            {
                grouped.Key.DocNum,
                grouped.Key.Canceled,
                grouped.Key.ShipToCode,
                grouped.Key.CardCode,
                grouped.Key.CardName,
                grouped.Key.NumAtCard,
                grouped.Key.DocDueDate,
                PartNo = grouped.Key.ItemCode,
                TotalQuantity = grouped.Sum(g => (int?)g.Quantity) ?? 0
            }).ToListAsync();

        // Step 2: Fetch all unique PartNos for PMX_itri data in bulk.
        var partNos = sifData.Select(s => s.PartNo).Distinct().ToList();
        var pmxDataList = await _sifContext.PmxItris
            .Where(pmx => partNos.Contains(pmx.ItemCode))
            .Select(pmx => new
            {
                Product = pmx.ItemCode,
                LotNumber = pmx.BatchNumber
            })
            .Distinct()
            .ToListAsync();

        // Step 3: Get data from ShamrockIntContext in one batch.
        var shamrockData = await _shamrockContext.IntlInvs
            .Where(intlInv => pmxDataList.Select(p => p.Product).Contains(intlInv.ShamPN) &&
                              pmxDataList.Select(p => p.LotNumber).Contains(intlInv.ShamrockLot))
            .Select(intlInv => new
            {
                intlInv.ShamPN,
                intlInv.Po,
                intlInv.Pieces,
                intlInv.Inv,
                intlInv.SupplierLot,
                intlInv.Ii,
                intlInv.ShamrockLot,
                intlInv.InvDate
            })
            .ToListAsync();

        // Step 4: Merge the data in-memory and perform further processing.
        var combinedResults = sifData.SelectMany(sif =>
            pmxDataList
                .Where(pmx => pmx.Product == sif.PartNo)
                .Select(pmx => new
                {
                    sif.DocNum,
                    sif.Canceled,
                    sif.ShipToCode,
                    sif.CardCode,
                    sif.CardName,
                    sif.NumAtCard,
                    sif.DocDueDate,
                    sif.PartNo,
                    sif.TotalQuantity,
                    Product = pmx.Product,
                    LotNumber = pmx.LotNumber,
                    ShamrockData = shamrockData.FirstOrDefault(
                        intl => intl.ShamPN == pmx.Product && intl.ShamrockLot == pmx.LotNumber)
                })
                .Where(result => result.ShamrockData != null)
                .Select(result => new
                {
                    result.DocNum,
                    result.Canceled,
                    result.ShipToCode,
                    result.CardCode,
                    result.CardName,
                    result.NumAtCard,
                    result.DocDueDate,
                    result.PartNo,
                    result.TotalQuantity,
                    Product = result.Product,
                    LotNumber = result.LotNumber,
                    IntlPO = result.ShamrockData.Po ?? string.Empty,
                    IntlPieces = result.ShamrockData.Pieces,
                    IntlINV = result.ShamrockData.Inv ?? string.Empty,
                    IntlSupplierLot = result.ShamrockData.SupplierLot ?? string.Empty,
                    IntlII = result.ShamrockData.Ii ?? string.Empty,
                    IntlShamrockLot = result.ShamrockData.ShamrockLot ?? string.Empty,
                    IntlINVDate = result.ShamrockData.InvDate
                })
        ).ToList();

        // Step 5: Retrieve files for each IntlII only where it's non-empty
        var finalResults = new List<object>();

        foreach (var result in combinedResults)
        {
            if (!string.IsNullOrEmpty(result.IntlII))
            {
                var filesfound = Certs.GetCerts(result.IntlII);
                finalResults.AddRange(filesfound.Select(file => new
                {
                    result.PartNo,
                    result.IntlII,
                    result.LotNumber,
                    file
                }));
            }

        }
        return Ok(finalResults);
    }

}