using System;
using System.Collections.Generic;

namespace CertsService.Models.Shamrock;

public partial class IntlInv
{
    public string? Supplier { get; set; }

    public string? Hbl { get; set; }

    public string? Cont { get; set; }

    public string? Po { get; set; }

    public string? MasterPoNew { get; set; }

    public string? ShamPN { get; set; }

    public string? PcsWholeCarton { get; set; }

    public string? OfWholeCartons { get; set; }

    public string? PcsPartialCarton { get; set; }

    public string? OfPartialCarton { get; set; }

    public string? Pieces { get; set; }

    public string? Ctns { get; set; }

    public string? NetKg { get; set; }

    public string? Kg { get; set; }

    public string? Inv { get; set; }

    public string? SupplierLot { get; set; }

    public string? InvDate { get; set; }

    public string? Ii { get; set; }

    public string? Skid { get; set; }

    public string? ShamrockLot { get; set; }

    public string? LineNum { get; set; }

    public Guid? UniqueId { get; set; }

    public string? GrpoStatus { get; set; }
}
