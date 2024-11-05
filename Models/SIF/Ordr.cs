using System;
using System.Collections.Generic;

namespace CertsService.Models.SIF;

public partial class Ordr
{
    public int DocEntry { get; set; }

    public int DocNum { get; set; }

    public string? DocType { get; set; }

    public string? Canceled { get; set; }

    public string? Handwrtten { get; set; }

    public string? Printed { get; set; }

    public string? DocStatus { get; set; }

    public string? InvntSttus { get; set; }

    public string? Transfered { get; set; }

    public string? ObjType { get; set; }

    public DateTime? DocDate { get; set; }

    public DateTime? DocDueDate { get; set; }

    public string? CardCode { get; set; }

    public string? CardName { get; set; }

    public string? Address { get; set; }

    public string? NumAtCard { get; set; }

    public decimal? VatPercent { get; set; }

    public decimal? VatSum { get; set; }

    public decimal? VatSumFc { get; set; }

    public decimal? DiscPrcnt { get; set; }

    public decimal? DiscSum { get; set; }

    public decimal? DiscSumFc { get; set; }

    public string? DocCur { get; set; }

    public decimal? DocRate { get; set; }

    public decimal? DocTotal { get; set; }

    public decimal? DocTotalFc { get; set; }

    public decimal? PaidToDate { get; set; }

    public decimal? PaidFc { get; set; }

    public decimal? GrosProfit { get; set; }

    public decimal? GrosProfFc { get; set; }

    public string? Ref1 { get; set; }

    public string? Ref2 { get; set; }

    public string? Comments { get; set; }

    public string? JrnlMemo { get; set; }

    public int? TransId { get; set; }

    public int? ReceiptNum { get; set; }

    public short? GroupNum { get; set; }

    public short? DocTime { get; set; }

    public int? SlpCode { get; set; }

    public short? TrnspCode { get; set; }

    public string? PartSupply { get; set; }

    public string? Confirmed { get; set; }

    public short? GrossBase { get; set; }

    public int? ImportEnt { get; set; }

    public string? CreateTran { get; set; }

    public string? SummryType { get; set; }

    public string? UpdInvnt { get; set; }

    public string? UpdCardBal { get; set; }

    public short Instance { get; set; }

    public int? Flags { get; set; }

    public string? InvntDirec { get; set; }

    public int? CntctCode { get; set; }

    public string? ShowScn { get; set; }

    public string? FatherCard { get; set; }

    public decimal? SysRate { get; set; }

    public string? CurSource { get; set; }

    public decimal? VatSumSy { get; set; }

    public decimal? DiscSumSy { get; set; }

    public decimal? DocTotalSy { get; set; }

    public decimal? PaidSys { get; set; }

    public string? FatherType { get; set; }

    public decimal? GrosProfSy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? IsIct { get; set; }

    public DateTime? CreateDate { get; set; }

    public decimal? Volume { get; set; }

    public short? VolUnit { get; set; }

    public decimal? Weight { get; set; }

    public short? WeightUnit { get; set; }

    public int? Series { get; set; }

    public DateTime? TaxDate { get; set; }

    public string? Filler { get; set; }

    public string? DataSource { get; set; }

    public string? StampNum { get; set; }

    public string? IsCrin { get; set; }

    public int? FinncPriod { get; set; }

    public short? UserSign { get; set; }

    public string? SelfInv { get; set; }

    public decimal? VatPaid { get; set; }

    public decimal? VatPaidFc { get; set; }

    public decimal? VatPaidSys { get; set; }

    public short? UserSign2 { get; set; }

    public string? WddStatus { get; set; }

    public int? DraftKey { get; set; }

    public decimal? TotalExpns { get; set; }

    public decimal? TotalExpFc { get; set; }

    public decimal? TotalExpSc { get; set; }

    public int? DunnLevel { get; set; }

    public string? Address2 { get; set; }

    public int? LogInstanc { get; set; }

    public string? Exported { get; set; }

    public int? StationId { get; set; }

    public string? Indicator { get; set; }

    public string? NetProc { get; set; }

    public decimal? AqcsTax { get; set; }

    public decimal? AqcsTaxFc { get; set; }

    public decimal? AqcsTaxSc { get; set; }

    public decimal? CashDiscPr { get; set; }

    public decimal? CashDiscnt { get; set; }

    public decimal? CashDiscFc { get; set; }

    public decimal? CashDiscSc { get; set; }

    public string? ShipToCode { get; set; }

    public string? LicTradNum { get; set; }

    public string? PaymentRef { get; set; }

    public decimal? Wtsum { get; set; }

    public decimal? WtsumFc { get; set; }

    public decimal? WtsumSc { get; set; }

    public decimal? RoundDif { get; set; }

    public decimal? RoundDifFc { get; set; }

    public decimal? RoundDifSy { get; set; }

    public string? CheckDigit { get; set; }

    public int? Form1099 { get; set; }

    public string? Box1099 { get; set; }

    public string? Submitted { get; set; }

    public string? PoPrss { get; set; }

    public string? Rounding { get; set; }

    public string? RevisionPo { get; set; }

    public short Segment { get; set; }

    public DateTime? ReqDate { get; set; }

    public DateTime? CancelDate { get; set; }

    public string? PickStatus { get; set; }

    public string? Pick { get; set; }

    public string? BlockDunn { get; set; }

    public string? PeyMethod { get; set; }

    public string? PayBlock { get; set; }

    public int? PayBlckRef { get; set; }

    public string? MaxDscn { get; set; }

    public string? Reserve { get; set; }

    public decimal? Max1099 { get; set; }

    public string? CntrlBnk { get; set; }

    public string? PickRmrk { get; set; }

    public string? IsrcodLine { get; set; }

    public decimal? ExpAppl { get; set; }

    public decimal? ExpApplFc { get; set; }

    public decimal? ExpApplSc { get; set; }

    public string? Project { get; set; }

    public string? DeferrTax { get; set; }

    public string? LetterNum { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public decimal? Wtapplied { get; set; }

    public decimal? WtappliedF { get; set; }

    public string? BoeReserev { get; set; }

    public string? AgentCode { get; set; }

    public decimal? WtappliedS { get; set; }

    public decimal? EquVatSum { get; set; }

    public decimal? EquVatSumF { get; set; }

    public decimal? EquVatSumS { get; set; }

    public short? Installmnt { get; set; }

    public string? Vatfirst { get; set; }

    public decimal? NnSbAmnt { get; set; }

    public decimal? NnSbAmntSc { get; set; }

    public decimal? NbSbAmntFc { get; set; }

    public decimal? ExepAmnt { get; set; }

    public decimal? ExepAmntSc { get; set; }

    public decimal? ExepAmntFc { get; set; }

    public DateTime? VatDate { get; set; }

    public string? CorrExt { get; set; }

    public int? CorrInv { get; set; }

    public int? NcorrInv { get; set; }

    public string? Ceecflag { get; set; }

    public decimal? BaseAmnt { get; set; }

    public decimal? BaseAmntSc { get; set; }

    public decimal? BaseAmntFc { get; set; }

    public string? CtlAccount { get; set; }

    public int? Bplid { get; set; }

    public string? Bplname { get; set; }

    public string? VatregNum { get; set; }

    public string? TxInvRptNo { get; set; }

    public DateTime? TxInvRptDt { get; set; }

    public string? Kvvatcode { get; set; }

    public string? Wtdetails { get; set; }

    public int? SumAbsId { get; set; }

    public DateTime? SumRptDate { get; set; }

    public string Pindicator { get; set; } = null!;

    public string? ManualNum { get; set; }

    public string? UseShpdGd { get; set; }

    public decimal? BaseVtAt { get; set; }

    public decimal? BaseVtAtSc { get; set; }

    public decimal? BaseVtAtFc { get; set; }

    public decimal? NnSbVat { get; set; }

    public decimal? NnSbVatSc { get; set; }

    public decimal? NbSbVatFc { get; set; }

    public decimal? ExptVat { get; set; }

    public decimal? ExptVatSc { get; set; }

    public decimal? ExptVatFc { get; set; }

    public decimal? LypmtAt { get; set; }

    public decimal? LypmtAtSc { get; set; }

    public decimal? LypmtAtFc { get; set; }

    public decimal? ExpAnSum { get; set; }

    public decimal? ExpAnSys { get; set; }

    public decimal? ExpAnFrgn { get; set; }

    public string DocSubType { get; set; } = null!;

    public string? DpmStatus { get; set; }

    public decimal? DpmAmnt { get; set; }

    public decimal? DpmAmntSc { get; set; }

    public decimal? DpmAmntFc { get; set; }

    public string? DpmDrawn { get; set; }

    public decimal? DpmPrcnt { get; set; }

    public decimal? PaidSum { get; set; }

    public decimal? PaidSumFc { get; set; }

    public decimal? PaidSumSc { get; set; }

    public string? FolioPref { get; set; }

    public int? FolioNum { get; set; }

    public decimal? DpmAppl { get; set; }

    public decimal? DpmApplFc { get; set; }

    public decimal? DpmApplSc { get; set; }

    public int? LpgFolioN { get; set; }

    public string? Header { get; set; }

    public string? Footer { get; set; }

    public string? Posted { get; set; }

    public int? OwnerCode { get; set; }

    public string? BpchCode { get; set; }

    public int? BpchCntc { get; set; }

    public string? PayToCode { get; set; }

    public string? IsPaytoBnk { get; set; }

    public string? BnkCntry { get; set; }

    public string? BankCode { get; set; }

    public string? BnkAccount { get; set; }

    public string? BnkBranch { get; set; }

    public string? IsIns { get; set; }

    public string? TrackNo { get; set; }

    public string? VersionNum { get; set; }

    public int? LangCode { get; set; }

    public string? BpnameOw { get; set; }

    public string? BillToOw { get; set; }

    public string? ShipToOw { get; set; }

    public string? RetInvoice { get; set; }

    public DateTime? ClsDate { get; set; }

    public int? MinvNum { get; set; }

    public DateTime? MinvDate { get; set; }

    public short? SeqCode { get; set; }

    public int? Serial { get; set; }

    public string? SeriesStr { get; set; }

    public string? SubStr { get; set; }

    public string? Model { get; set; }

    public decimal? TaxOnExp { get; set; }

    public decimal? TaxOnExpFc { get; set; }

    public decimal? TaxOnExpSc { get; set; }

    public decimal? TaxOnExAp { get; set; }

    public decimal? TaxOnExApF { get; set; }

    public decimal? TaxOnExApS { get; set; }

    public string? LastPmnTyp { get; set; }

    public int? LndCstNum { get; set; }

    public string? UseCorrVat { get; set; }

    public string? BlkCredMmo { get; set; }

    public string? OpenForLaC { get; set; }

    public string? Excised { get; set; }

    public DateTime? ExcRefDate { get; set; }

    public string? ExcRmvTime { get; set; }

    public decimal? SrvGpPrcnt { get; set; }

    public int? DepositNum { get; set; }

    public string? CertNum { get; set; }

    public string? DutyStatus { get; set; }

    public string? AutoCrtFlw { get; set; }

    public DateTime? FlwRefDate { get; set; }

    public string? FlwRefNum { get; set; }

    public int? VatJenum { get; set; }

    public decimal? DpmVat { get; set; }

    public decimal? DpmVatFc { get; set; }

    public decimal? DpmVatSc { get; set; }

    public decimal? DpmAppVat { get; set; }

    public decimal? DpmAppVatF { get; set; }

    public decimal? DpmAppVatS { get; set; }

    public string? InsurOp347 { get; set; }

    public string? IgnRelDoc { get; set; }

    public string? BuildDesc { get; set; }

    public string? ResidenNum { get; set; }

    public int? Checker { get; set; }

    public int? Payee { get; set; }

    public int? CopyNumber { get; set; }

    public string? Ssiexmpt { get; set; }

    public int? PqtgrpSer { get; set; }

    public int? PqtgrpNum { get; set; }

    public string? PqtgrpHw { get; set; }

    public string? ReopOriDoc { get; set; }

    public string? ReopManCls { get; set; }

    public string? DocManClsd { get; set; }

    public short? ClosingOpt { get; set; }

    public DateTime? SpecDate { get; set; }

    public string? Ordered { get; set; }

    public string? Ntsapprov { get; set; }

    public short? NtswebSite { get; set; }

    public string? NtseTaxNo { get; set; }

    public string? NtsapprNo { get; set; }

    public string? PayDuMonth { get; set; }

    public short? ExtraMonth { get; set; }

    public short? ExtraDays { get; set; }

    public short? CdcOffset { get; set; }

    public string? SignMsg { get; set; }

    public string? SignDigest { get; set; }

    public string? CertifNum { get; set; }

    public int? KeyVersion { get; set; }

    public string? EdocGenTyp { get; set; }

    public short? Eseries { get; set; }

    public string? EdocNum { get; set; }

    public int? EdocExpFrm { get; set; }

    public string? OnlineQuo { get; set; }

    public string? PoseqNum { get; set; }

    public string? PosmanufSn { get; set; }

    public int? PoscashN { get; set; }

    public string? EdocStatus { get; set; }

    public string? EdocCntnt { get; set; }

    public string? EdocProces { get; set; }

    public string? EdocErrCod { get; set; }

    public string? EdocErrMsg { get; set; }

    public string? EdocCancel { get; set; }

    public string? EdocTest { get; set; }

    public string? EdocPrefix { get; set; }

    public int? Cup { get; set; }

    public int? Cig { get; set; }

    public string? DpmAsDscnt { get; set; }

    public string? Attachment { get; set; }

    public int? AtcEntry { get; set; }

    public string? SupplCode { get; set; }

    public string? Gtsrlvnt { get; set; }

    public decimal? BaseDisc { get; set; }

    public decimal? BaseDiscSc { get; set; }

    public decimal? BaseDiscFc { get; set; }

    public decimal? BaseDiscPr { get; set; }

    public int? CreateTs { get; set; }

    public int? UpdateTs { get; set; }

    public string? SrvTaxRule { get; set; }

    public int? AnnInvDecR { get; set; }

    public string? Supplier { get; set; }

    public int? Releaser { get; set; }

    public int? Receiver { get; set; }

    public string? ToWhsCode { get; set; }

    public DateTime? AssetDate { get; set; }

    public string? Requester { get; set; }

    public string? ReqName { get; set; }

    public short? Branch { get; set; }

    public short? Department { get; set; }

    public string? Email { get; set; }

    public string? Notify { get; set; }

    public int? ReqType { get; set; }

    public string? OriginType { get; set; }

    public string? IsReuseNum { get; set; }

    public string? IsReuseNfn { get; set; }

    public string? DocDlvry { get; set; }

    public decimal? PaidDpm { get; set; }

    public decimal? PaidDpmF { get; set; }

    public decimal? PaidDpmS { get; set; }

    public int? EnvTypeNfe { get; set; }

    public int? AgrNo { get; set; }

    public string? IsAlt { get; set; }

    public int? AltBaseTyp { get; set; }

    public int? AltBaseEnt { get; set; }

    public string? AuthCode { get; set; }

    public DateTime? StDlvDate { get; set; }

    public int? StDlvTime { get; set; }

    public DateTime? EndDlvDate { get; set; }

    public int? EndDlvTime { get; set; }

    public string? VclPlate { get; set; }

    public string? ElCoStatus { get; set; }

    public string? AtDocType { get; set; }

    public string? ElCoMsg { get; set; }

    public string? PrintSepa { get; set; }

    public decimal? FreeChrg { get; set; }

    public decimal? FreeChrgFc { get; set; }

    public decimal? FreeChrgSc { get; set; }

    public decimal? NfeValue { get; set; }

    public string? FiscDocNum { get; set; }

    public int? RelatedTyp { get; set; }

    public int? RelatedEnt { get; set; }

    public int? Ccdentry { get; set; }

    public int? NfePrntFo { get; set; }

    public int? ZrdAbs { get; set; }

    public int? PosrcptNo { get; set; }

    public decimal? FoCtax { get; set; }

    public decimal? FoCtaxFc { get; set; }

    public decimal? FoCtaxSc { get; set; }

    public int? TpCusPres { get; set; }

    public DateTime? ExcDocDate { get; set; }

    public decimal? FoCfrght { get; set; }

    public decimal? FoCfrghtFc { get; set; }

    public decimal? FoCfrghtSc { get; set; }

    public short? InterimTyp { get; set; }

    public string? Pticode { get; set; }

    public string? Letter { get; set; }

    public int? FolNumFrom { get; set; }

    public int? FolNumTo { get; set; }

    public int? FolSeries { get; set; }

    public decimal? SplitTax { get; set; }

    public decimal? SplitTaxFc { get; set; }

    public decimal? SplitTaxSc { get; set; }

    public string? ToBinCode { get; set; }

    public string? PriceMode { get; set; }

    public string? PoDropPrss { get; set; }

    public string? PermitNo { get; set; }

    public string? Myftype { get; set; }

    public string? DocTaxId { get; set; }

    public DateTime? DateReport { get; set; }

    public string? RepSection { get; set; }

    public string? ExclTaxRep { get; set; }

    public int? PosCashReg { get; set; }

    public string? DmpTransId { get; set; }

    public string? EcommerBp { get; set; }

    public string? EcomerGstn { get; set; }

    public string? Revision { get; set; }

    public string? RevRefNo { get; set; }

    public DateTime? RevRefDate { get; set; }

    public string? RevCreRefN { get; set; }

    public DateTime? RevCreRefD { get; set; }

    public string? TaxInvNo { get; set; }

    public DateTime? FrmBpDate { get; set; }

    public string? GsttranTyp { get; set; }

    public int? BaseType { get; set; }

    public int? BaseEntry { get; set; }

    public string? ComTrade { get; set; }

    public string? UseBilAddr { get; set; }

    public short? IssReason { get; set; }

    public string? ComTradeRt { get; set; }

    public string? SplitPmnt { get; set; }

    public int? SoiwizId { get; set; }

    public string? SelfPosted { get; set; }

    public string? EnBnkAcct { get; set; }

    public string? EncryptIv { get; set; }

    public string? Dppstatus { get; set; }

    public string? Sappassprt { get; set; }

    public string? EwbgenType { get; set; }

    public decimal? CtActTax { get; set; }

    public decimal? CtActTaxFc { get; set; }

    public decimal? CtActTaxSc { get; set; }

    public string? EdocType { get; set; }

    public string? QrcodeSrc { get; set; }

    public string? AggregDoc { get; set; }

    public int? DataVers { get; set; }

    public string? ShipState { get; set; }

    public string? ShipPlace { get; set; }

    public string? CustOffice { get; set; }

    public string? Fci { get; set; }

    public decimal? NnSbCuAmnt { get; set; }

    public decimal? NnSbCuSc { get; set; }

    public decimal? NnSbCuFc { get; set; }

    public decimal? ExepCuAmnt { get; set; }

    public decimal? ExepCuSc { get; set; }

    public decimal? ExepCuFc { get; set; }

    public string? AddLegIn { get; set; }

    public int? LegTextF { get; set; }

    public string? IndFinal { get; set; }

    public string? DanfelgTxt { get; set; }

    public string? PostPmntWt { get; set; }

    public string? QrcodeSpgn { get; set; }

    public string? FcepmnMean { get; set; }

    public string? ReqCode { get; set; }

    public string? NotRel4Mi { get; set; }

    public string? Rel4Pptax { get; set; }

    public string? USifShipInst1 { get; set; }

    public string? USifShipInst2 { get; set; }

    public string? USifPocomment { get; set; }

    public string? USifPoPortInco { get; set; }

    public string? USifPoSample { get; set; }

    public string? USifPoConfd { get; set; }

    public DateTime? USifPoConfDate { get; set; }

    public string? USifInternComments { get; set; }

    public short? USifPymentRecd { get; set; }

    public string? USifPofinPn { get; set; }

    public int UA1wmsAdj { get; set; }

    public int? UA1wmsRmaseq { get; set; }

    public int UA1wmsOshipPayType { get; set; }

    public string? UA1wmsOshipPayAcc { get; set; }

    public string? USifStName { get; set; }

    public int? UPmxPrdr { get; set; }

    public decimal? UPmxPrqy { get; set; }

    public string UPmxEx3p { get; set; } = null!;

    public string? UPmxDrna { get; set; }

    public string? UPmxLipl { get; set; }

    public string? UPmxTrnr { get; set; }

    public string? UPmxCmrn { get; set; }

    public string? UPmxInfc { get; set; }

    public DateTime? UPmxReda { get; set; }

    public int? UPmxPssd { get; set; }

    public string? UPmxIsmp { get; set; }

    public string? UPmxPlty { get; set; }

    public int? UPmxDdth { get; set; }

    public int? UPmxDdtm { get; set; }

    public string? UPmxDdta { get; set; }

    public DateTime? UPmx3plp { get; set; }

    public string? UTwbsContNo { get; set; }

    public DateTime? USintEstDueDate { get; set; }

    public string? USintInTransit { get; set; }
}
