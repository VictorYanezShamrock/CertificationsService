using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CertsService.Models.SIF;

public partial class SifContext : DbContext
{
    public SifContext()
    {
    }

    public SifContext(DbContextOptions<SifContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ordr> Ordrs { get; set; }

    public virtual DbSet<PmxItri> PmxItris { get; set; }

    public virtual DbSet<Rdr1> Rdr1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sint-sap-20;Database=SIF;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP850_CI_AS");

        modelBuilder.Entity<Ordr>(entity =>
        {
            entity.HasKey(e => e.DocEntry).HasName("ORDR_PRIMARY");

            entity.ToTable("ORDR");

            entity.HasIndex(e => new { e.NumAtCard, e.CardCode }, "ORDR_AT_CARD");

            entity.HasIndex(e => e.CardCode, "ORDR_CUSTOMER");

            entity.HasIndex(e => new { e.DocDate, e.Pindicator }, "ORDR_DATE_PIND");

            entity.HasIndex(e => new { e.DocStatus, e.Canceled }, "ORDR_DOC_STATUS");

            entity.HasIndex(e => new { e.Eseries, e.EdocNum }, "ORDR_ESERIES");

            entity.HasIndex(e => new { e.FatherCard, e.FatherType }, "ORDR_FTHR_CARD");

            entity.HasIndex(e => new { e.DocNum, e.Instance, e.Segment, e.DocSubType, e.Pindicator }, "ORDR_NUM").IsUnique();

            entity.HasIndex(e => e.OwnerCode, "ORDR_OWNER_CODE");

            entity.HasIndex(e => e.Series, "ORDR_SERIES");

            entity.HasIndex(e => new { e.CardName, e.DocSubType }, "SINT_IX_ORDR:CardName,DocSubType,ObjType,Series");

            entity.HasIndex(e => e.DocType, "SINT_IX_ORDR:Doc,Status,Date,Due,Card,Num,ShipTo,Sample");

            entity.HasIndex(e => new { e.DocDueDate, e.CardCode }, "SINT_IX_ORDR:Due,Card,Doc,Canc,CName,NumAtCard,ShipTo");

            entity.HasIndex(e => e.DocStatus, "SINT_IX_ORDR:Status,Doc,Date,Due,Cust");

            entity.HasIndex(e => new { e.DocType, e.DocStatus }, "SINT_IX_ORDR:Type,Status,Num,Date,Slp");

            entity.Property(e => e.DocEntry).ValueGeneratedNever();
            entity.Property(e => e.AddLegIn).HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(254);
            entity.Property(e => e.Address2).HasMaxLength(254);
            entity.Property(e => e.AgentCode).HasMaxLength(32);
            entity.Property(e => e.AggregDoc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AqcsTax).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.AqcsTaxFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("AqcsTaxFC");
            entity.Property(e => e.AqcsTaxSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("AqcsTaxSC");
            entity.Property(e => e.AssetDate).HasColumnType("datetime");
            entity.Property(e => e.AtDocType).HasMaxLength(2);
            entity.Property(e => e.Attachment).HasColumnType("ntext");
            entity.Property(e => e.AuthCode).HasMaxLength(250);
            entity.Property(e => e.AutoCrtFlw)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BankCode).HasMaxLength(30);
            entity.Property(e => e.BaseAmnt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.BaseAmntFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("BaseAmntFC");
            entity.Property(e => e.BaseAmntSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("BaseAmntSC");
            entity.Property(e => e.BaseDisc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.BaseDiscFc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.BaseDiscPr).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.BaseDiscSc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.BaseVtAt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.BaseVtAtFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("BaseVtAtFC");
            entity.Property(e => e.BaseVtAtSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("BaseVtAtSC");
            entity.Property(e => e.BillToOw)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BillToOW");
            entity.Property(e => e.BlkCredMmo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BlockDunn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BnkAccount).HasMaxLength(50);
            entity.Property(e => e.BnkBranch).HasMaxLength(50);
            entity.Property(e => e.BnkCntry).HasMaxLength(3);
            entity.Property(e => e.BoeReserev)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Box1099).HasMaxLength(20);
            entity.Property(e => e.BpchCntc).HasColumnName("BPChCntc");
            entity.Property(e => e.BpchCode)
                .HasMaxLength(15)
                .HasColumnName("BPChCode");
            entity.Property(e => e.Bplid).HasColumnName("BPLId");
            entity.Property(e => e.Bplname)
                .HasMaxLength(100)
                .HasColumnName("BPLName");
            entity.Property(e => e.BpnameOw)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BPNameOW");
            entity.Property(e => e.BuildDesc).HasMaxLength(50);
            entity.Property(e => e.CancelDate).HasColumnType("datetime");
            entity.Property(e => e.Canceled)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CANCELED");
            entity.Property(e => e.CardCode).HasMaxLength(15);
            entity.Property(e => e.CardName).HasMaxLength(100);
            entity.Property(e => e.CashDiscFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("CashDiscFC");
            entity.Property(e => e.CashDiscPr).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.CashDiscSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("CashDiscSC");
            entity.Property(e => e.CashDiscnt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Ccdentry).HasColumnName("CCDEntry");
            entity.Property(e => e.Ceecflag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CEECFlag");
            entity.Property(e => e.CertNum).HasMaxLength(31);
            entity.Property(e => e.CertifNum).HasMaxLength(50);
            entity.Property(e => e.CheckDigit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cig).HasColumnName("CIG");
            entity.Property(e => e.ClsDate).HasColumnType("datetime");
            entity.Property(e => e.CntrlBnk).HasMaxLength(15);
            entity.Property(e => e.ComTrade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ComTradeRt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Comments).HasMaxLength(254);
            entity.Property(e => e.Confirmed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CorrExt).HasMaxLength(25);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateTran)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreateTs).HasColumnName("CreateTS");
            entity.Property(e => e.CtActTax).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.CtActTaxFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("CtActTaxFC");
            entity.Property(e => e.CtActTaxSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("CtActTaxSC");
            entity.Property(e => e.CtlAccount).HasMaxLength(15);
            entity.Property(e => e.Cup).HasColumnName("CUP");
            entity.Property(e => e.CurSource)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CustOffice).HasMaxLength(60);
            entity.Property(e => e.DanfelgTxt)
                .HasColumnType("ntext")
                .HasColumnName("DANFELgTxt");
            entity.Property(e => e.DataSource)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DateReport).HasColumnType("datetime");
            entity.Property(e => e.DeferrTax)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DiscSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DiscSumFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("DiscSumFC");
            entity.Property(e => e.DiscSumSy).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DmpTransId)
                .HasMaxLength(20)
                .HasColumnName("DmpTransID");
            entity.Property(e => e.DocCur).HasMaxLength(3);
            entity.Property(e => e.DocDate).HasColumnType("datetime");
            entity.Property(e => e.DocDlvry)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DocDueDate).HasColumnType("datetime");
            entity.Property(e => e.DocManClsd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DocRate).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DocStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DocSubType).HasMaxLength(2);
            entity.Property(e => e.DocTaxId)
                .HasMaxLength(32)
                .HasColumnName("DocTaxID");
            entity.Property(e => e.DocTotal).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DocTotalFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("DocTotalFC");
            entity.Property(e => e.DocTotalSy).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DocType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DpmAmnt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DpmAmntFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("DpmAmntFC");
            entity.Property(e => e.DpmAmntSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("DpmAmntSC");
            entity.Property(e => e.DpmAppVat).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DpmAppVatF).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DpmAppVatS).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DpmAppl).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DpmApplFc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DpmApplSc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DpmAsDscnt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DpmDrawn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DpmPrcnt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DpmStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DpmVat).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DpmVatFc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DpmVatSc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Dppstatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DPPStatus");
            entity.Property(e => e.DraftKey).HasColumnName("draftKey");
            entity.Property(e => e.DutyStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EcomerGstn)
                .HasMaxLength(15)
                .HasColumnName("EComerGSTN");
            entity.Property(e => e.EcommerBp)
                .HasMaxLength(15)
                .HasColumnName("ECommerBP");
            entity.Property(e => e.EdocCancel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EDocCancel");
            entity.Property(e => e.EdocCntnt)
                .HasColumnType("ntext")
                .HasColumnName("EDocCntnt");
            entity.Property(e => e.EdocErrCod)
                .HasMaxLength(50)
                .HasColumnName("EDocErrCod");
            entity.Property(e => e.EdocErrMsg)
                .HasColumnType("ntext")
                .HasColumnName("EDocErrMsg");
            entity.Property(e => e.EdocExpFrm).HasColumnName("EDocExpFrm");
            entity.Property(e => e.EdocGenTyp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EDocGenTyp");
            entity.Property(e => e.EdocNum)
                .HasMaxLength(50)
                .HasColumnName("EDocNum");
            entity.Property(e => e.EdocPrefix)
                .HasMaxLength(10)
                .HasColumnName("EDocPrefix");
            entity.Property(e => e.EdocProces)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EDocProces");
            entity.Property(e => e.EdocStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EDocStatus");
            entity.Property(e => e.EdocTest)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EDocTest");
            entity.Property(e => e.EdocType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EDocType");
            entity.Property(e => e.ElCoMsg).HasMaxLength(254);
            entity.Property(e => e.ElCoStatus).HasMaxLength(10);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EnBnkAcct).HasColumnType("ntext");
            entity.Property(e => e.EncryptIv)
                .HasMaxLength(100)
                .HasColumnName("EncryptIV");
            entity.Property(e => e.EndDlvDate).HasColumnType("datetime");
            entity.Property(e => e.EnvTypeNfe).HasColumnName("EnvTypeNFe");
            entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Eseries).HasColumnName("ESeries");
            entity.Property(e => e.EwbgenType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EWBGenType");
            entity.Property(e => e.ExcDocDate).HasColumnType("datetime");
            entity.Property(e => e.ExcRefDate).HasColumnType("datetime");
            entity.Property(e => e.ExcRmvTime).HasMaxLength(8);
            entity.Property(e => e.Excised)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ExclTaxRep)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ExepAmnt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ExepAmntFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("ExepAmntFC");
            entity.Property(e => e.ExepAmntSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("ExepAmntSC");
            entity.Property(e => e.ExepCuAmnt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ExepCuFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("ExepCuFC");
            entity.Property(e => e.ExepCuSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("ExepCuSC");
            entity.Property(e => e.ExpAnFrgn).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ExpAnSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ExpAnSys).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ExpAppl).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ExpApplFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("ExpApplFC");
            entity.Property(e => e.ExpApplSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("ExpApplSC");
            entity.Property(e => e.Exported)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ExptVat)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("ExptVAt");
            entity.Property(e => e.ExptVatFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("ExptVAtFC");
            entity.Property(e => e.ExptVatSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("ExptVAtSC");
            entity.Property(e => e.FatherCard).HasMaxLength(15);
            entity.Property(e => e.FatherType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FcepmnMean)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FCEPmnMean");
            entity.Property(e => e.Fci)
                .HasMaxLength(36)
                .HasColumnName("FCI");
            entity.Property(e => e.Filler).HasMaxLength(8);
            entity.Property(e => e.FiscDocNum).HasMaxLength(100);
            entity.Property(e => e.FlwRefDate).HasColumnType("datetime");
            entity.Property(e => e.FlwRefNum).HasMaxLength(100);
            entity.Property(e => e.FoCfrght)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("FoCFrght");
            entity.Property(e => e.FoCfrghtFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("FoCFrghtFC");
            entity.Property(e => e.FoCfrghtSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("FoCFrghtSC");
            entity.Property(e => e.FoCtax)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("FoCTax");
            entity.Property(e => e.FoCtaxFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("FoCTaxFC");
            entity.Property(e => e.FoCtaxSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("FoCTaxSC");
            entity.Property(e => e.FolioPref).HasMaxLength(4);
            entity.Property(e => e.Footer).HasColumnType("ntext");
            entity.Property(e => e.FreeChrg).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.FreeChrgFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("FreeChrgFC");
            entity.Property(e => e.FreeChrgSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("FreeChrgSC");
            entity.Property(e => e.FrmBpDate).HasColumnType("datetime");
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.GrosProfFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("GrosProfFC");
            entity.Property(e => e.GrosProfSy).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.GrosProfit).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.GsttranTyp)
                .HasMaxLength(2)
                .HasColumnName("GSTTranTyp");
            entity.Property(e => e.Gtsrlvnt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GTSRlvnt");
            entity.Property(e => e.Handwrtten)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Header).HasColumnType("ntext");
            entity.Property(e => e.IgnRelDoc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IndFinal)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Indicator).HasMaxLength(2);
            entity.Property(e => e.InsurOp347)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InvntDirec)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InvntSttus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsAlt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsCrin)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isCrin");
            entity.Property(e => e.IsIct)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IsICT");
            entity.Property(e => e.IsIns)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isIns");
            entity.Property(e => e.IsPaytoBnk)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsReuseNfn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IsReuseNFN");
            entity.Property(e => e.IsReuseNum)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsrcodLine)
                .HasMaxLength(53)
                .HasColumnName("ISRCodLine");
            entity.Property(e => e.JrnlMemo).HasMaxLength(254);
            entity.Property(e => e.Kvvatcode)
                .HasColumnType("ntext")
                .HasColumnName("KVVATCode");
            entity.Property(e => e.LastPmnTyp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Letter)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LetterNum).HasMaxLength(50);
            entity.Property(e => e.LicTradNum).HasMaxLength(32);
            entity.Property(e => e.LpgFolioN).HasColumnName("LPgFolioN");
            entity.Property(e => e.LypmtAt)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("LYPmtAt");
            entity.Property(e => e.LypmtAtFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("LYPmtAtFC");
            entity.Property(e => e.LypmtAtSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("LYPmtAtSC");
            entity.Property(e => e.ManualNum).HasMaxLength(20);
            entity.Property(e => e.Max1099).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.MaxDscn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MinvDate)
                .HasColumnType("datetime")
                .HasColumnName("MInvDate");
            entity.Property(e => e.MinvNum).HasColumnName("MInvNum");
            entity.Property(e => e.Model).HasMaxLength(6);
            entity.Property(e => e.Myftype)
                .HasMaxLength(2)
                .HasColumnName("MYFtype");
            entity.Property(e => e.NbSbAmntFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("NbSbAmntFC");
            entity.Property(e => e.NbSbVatFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("NbSbVAtFC");
            entity.Property(e => e.NcorrInv).HasColumnName("NCorrInv");
            entity.Property(e => e.NetProc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NfeValue).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.NnSbAmnt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.NnSbAmntSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("NnSbAmntSC");
            entity.Property(e => e.NnSbCuAmnt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.NnSbCuFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("NnSbCuFC");
            entity.Property(e => e.NnSbCuSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("NnSbCuSC");
            entity.Property(e => e.NnSbVat)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("NnSbVAt");
            entity.Property(e => e.NnSbVatSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("NnSbVAtSC");
            entity.Property(e => e.NotRel4Mi)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NotRel4MI");
            entity.Property(e => e.Notify)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NtsapprNo)
                .HasMaxLength(50)
                .HasColumnName("NTSApprNo");
            entity.Property(e => e.Ntsapprov)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NTSApprov");
            entity.Property(e => e.NtseTaxNo)
                .HasMaxLength(50)
                .HasColumnName("NTSeTaxNo");
            entity.Property(e => e.NtswebSite).HasColumnName("NTSWebSite");
            entity.Property(e => e.NumAtCard).HasMaxLength(100);
            entity.Property(e => e.ObjType).HasMaxLength(20);
            entity.Property(e => e.OnlineQuo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.OpenForLaC)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Ordered)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.OriginType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PaidDpm).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.PaidDpmF).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.PaidDpmS).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.PaidFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("PaidFC");
            entity.Property(e => e.PaidSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.PaidSumFc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.PaidSumSc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.PaidSys).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.PaidToDate).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.PartSupply)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PayBlock)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PayDuMonth)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PayToCode).HasMaxLength(50);
            entity.Property(e => e.PaymentRef).HasMaxLength(27);
            entity.Property(e => e.PermitNo).HasMaxLength(20);
            entity.Property(e => e.PeyMethod).HasMaxLength(15);
            entity.Property(e => e.Pick)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PickRmrk).HasMaxLength(254);
            entity.Property(e => e.PickStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Pindicator)
                .HasMaxLength(10)
                .HasColumnName("PIndicator");
            entity.Property(e => e.PoDropPrss)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PoPrss)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PoscashN).HasColumnName("POSCashN");
            entity.Property(e => e.PoseqNum)
                .HasMaxLength(20)
                .HasColumnName("POSEqNum");
            entity.Property(e => e.PosmanufSn)
                .HasMaxLength(20)
                .HasColumnName("POSManufSN");
            entity.Property(e => e.PosrcptNo).HasColumnName("POSRcptNo");
            entity.Property(e => e.PostPmntWt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PostPmntWT");
            entity.Property(e => e.Posted)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PqtgrpHw)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PQTGrpHW");
            entity.Property(e => e.PqtgrpNum).HasColumnName("PQTGrpNum");
            entity.Property(e => e.PqtgrpSer).HasColumnName("PQTGrpSer");
            entity.Property(e => e.PriceMode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PrintSepa)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PrintSEPA");
            entity.Property(e => e.Printed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Project).HasMaxLength(20);
            entity.Property(e => e.Pticode)
                .HasMaxLength(5)
                .HasColumnName("PTICode");
            entity.Property(e => e.QrcodeSpgn)
                .HasColumnType("ntext")
                .HasColumnName("QRCodeSPGn");
            entity.Property(e => e.QrcodeSrc)
                .HasColumnType("ntext")
                .HasColumnName("QRCodeSrc");
            entity.Property(e => e.Ref1).HasMaxLength(11);
            entity.Property(e => e.Ref2).HasMaxLength(11);
            entity.Property(e => e.Rel4Pptax)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Rel4PPTax");
            entity.Property(e => e.ReopManCls)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ReopOriDoc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RepSection).HasMaxLength(3);
            entity.Property(e => e.ReqCode).HasMaxLength(50);
            entity.Property(e => e.ReqDate).HasColumnType("datetime");
            entity.Property(e => e.ReqName).HasMaxLength(155);
            entity.Property(e => e.Requester).HasMaxLength(25);
            entity.Property(e => e.Reserve)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ResidenNum)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RetInvoice)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RevCreRefD).HasColumnType("datetime");
            entity.Property(e => e.RevCreRefN).HasMaxLength(100);
            entity.Property(e => e.RevRefDate).HasColumnType("datetime");
            entity.Property(e => e.RevRefNo).HasMaxLength(100);
            entity.Property(e => e.Revision)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RevisionPo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RoundDif).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.RoundDifFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("RoundDifFC");
            entity.Property(e => e.RoundDifSy).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Rounding)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Sappassprt)
                .HasColumnType("ntext")
                .HasColumnName("SAPPassprt");
            entity.Property(e => e.SelfInv)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("selfInv");
            entity.Property(e => e.SelfPosted)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SeriesStr).HasMaxLength(3);
            entity.Property(e => e.ShipPlace).HasMaxLength(60);
            entity.Property(e => e.ShipState).HasMaxLength(3);
            entity.Property(e => e.ShipToCode).HasMaxLength(50);
            entity.Property(e => e.ShipToOw)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ShipToOW");
            entity.Property(e => e.ShowScn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ShowSCN");
            entity.Property(e => e.SignDigest).HasColumnType("ntext");
            entity.Property(e => e.SignMsg).HasColumnType("ntext");
            entity.Property(e => e.SoiwizId).HasColumnName("SOIWizId");
            entity.Property(e => e.SpecDate).HasColumnType("datetime");
            entity.Property(e => e.SplitPmnt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SplitTax).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.SplitTaxFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("SplitTaxFC");
            entity.Property(e => e.SplitTaxSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("SplitTaxSC");
            entity.Property(e => e.SrvGpPrcnt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.SrvTaxRule)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Ssiexmpt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SSIExmpt");
            entity.Property(e => e.StDlvDate).HasColumnType("datetime");
            entity.Property(e => e.StampNum).HasMaxLength(16);
            entity.Property(e => e.StationId).HasColumnName("StationID");
            entity.Property(e => e.SubStr).HasMaxLength(3);
            entity.Property(e => e.Submitted)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("submitted");
            entity.Property(e => e.SumRptDate).HasColumnType("datetime");
            entity.Property(e => e.SummryType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SupplCode).HasMaxLength(254);
            entity.Property(e => e.Supplier).HasMaxLength(15);
            entity.Property(e => e.SysRate).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.TaxDate).HasColumnType("datetime");
            entity.Property(e => e.TaxInvNo).HasMaxLength(100);
            entity.Property(e => e.TaxOnExAp).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.TaxOnExApF).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.TaxOnExApS).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.TaxOnExp).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.TaxOnExpFc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.TaxOnExpSc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ToBinCode).HasMaxLength(228);
            entity.Property(e => e.ToDate).HasColumnType("datetime");
            entity.Property(e => e.ToWhsCode).HasMaxLength(8);
            entity.Property(e => e.TotalExpFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("TotalExpFC");
            entity.Property(e => e.TotalExpSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("TotalExpSC");
            entity.Property(e => e.TotalExpns).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.TrackNo).HasMaxLength(30);
            entity.Property(e => e.Transfered)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TxInvRptDt).HasColumnType("datetime");
            entity.Property(e => e.TxInvRptNo).HasMaxLength(10);
            entity.Property(e => e.UA1wmsAdj).HasColumnName("U_A1WMS_ADJ");
            entity.Property(e => e.UA1wmsOshipPayAcc)
                .HasMaxLength(40)
                .HasColumnName("U_A1WMS_OShipPayAcc");
            entity.Property(e => e.UA1wmsOshipPayType).HasColumnName("U_A1WMS_OShipPayType");
            entity.Property(e => e.UA1wmsRmaseq).HasColumnName("U_A1WMS_RMASEQ");
            entity.Property(e => e.UPmx3plp)
                .HasColumnType("datetime")
                .HasColumnName("U_PMX_3PLP");
            entity.Property(e => e.UPmxCmrn)
                .HasMaxLength(20)
                .HasColumnName("U_PMX_CMRN");
            entity.Property(e => e.UPmxDdta)
                .HasMaxLength(2)
                .HasColumnName("U_PMX_DDTA");
            entity.Property(e => e.UPmxDdth).HasColumnName("U_PMX_DDTH");
            entity.Property(e => e.UPmxDdtm).HasColumnName("U_PMX_DDTM");
            entity.Property(e => e.UPmxDrna)
                .HasMaxLength(100)
                .HasColumnName("U_PMX_DRNA");
            entity.Property(e => e.UPmxEx3p)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("U_PMX_EX3P");
            entity.Property(e => e.UPmxInfc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("U_PMX_INFC");
            entity.Property(e => e.UPmxIsmp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("U_PMX_ISMP");
            entity.Property(e => e.UPmxLipl)
                .HasMaxLength(100)
                .HasColumnName("U_PMX_LIPL");
            entity.Property(e => e.UPmxPlty)
                .HasMaxLength(50)
                .HasColumnName("U_PMX_PLTY");
            entity.Property(e => e.UPmxPrdr).HasColumnName("U_PMX_PRDR");
            entity.Property(e => e.UPmxPrqy)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("U_PMX_PRQY");
            entity.Property(e => e.UPmxPssd).HasColumnName("U_PMX_PSSD");
            entity.Property(e => e.UPmxReda)
                .HasColumnType("datetime")
                .HasColumnName("U_PMX_REDA");
            entity.Property(e => e.UPmxTrnr)
                .HasMaxLength(100)
                .HasColumnName("U_PMX_TRNR");
            entity.Property(e => e.USifInternComments)
                .HasMaxLength(200)
                .HasColumnName("U_SIF_InternComments");
            entity.Property(e => e.USifPoConfDate)
                .HasColumnType("datetime")
                .HasColumnName("U_SIF_PoConfDate");
            entity.Property(e => e.USifPoConfd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("U_SIF_PoConfd");
            entity.Property(e => e.USifPoPortInco)
                .HasMaxLength(20)
                .HasColumnName("U_SIF_PO_Port_Inco");
            entity.Property(e => e.USifPoSample)
                .HasMaxLength(2)
                .HasColumnName("U_SIF_PO_Sample");
            entity.Property(e => e.USifPocomment)
                .HasColumnType("ntext")
                .HasColumnName("U_SIF_POComment");
            entity.Property(e => e.USifPofinPn)
                .HasMaxLength(15)
                .HasColumnName("U_SIF_POFinPN");
            entity.Property(e => e.USifPymentRecd).HasColumnName("U_SIF_PymentRecd");
            entity.Property(e => e.USifShipInst1)
                .HasMaxLength(100)
                .HasColumnName("U_SIF_ShipInst1");
            entity.Property(e => e.USifShipInst2)
                .HasMaxLength(100)
                .HasColumnName("U_SIF_ShipInst2");
            entity.Property(e => e.USifStName)
                .HasMaxLength(30)
                .HasColumnName("U_SIF_ST_Name");
            entity.Property(e => e.USintEstDueDate)
                .HasColumnType("datetime")
                .HasColumnName("U_SINT_Est_Due_Date");
            entity.Property(e => e.USintInTransit)
                .HasMaxLength(10)
                .HasColumnName("U_SINT_In_Transit");
            entity.Property(e => e.UTwbsContNo)
                .HasMaxLength(100)
                .HasColumnName("U_TWBS_Cont_No");
            entity.Property(e => e.UpdCardBal)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UpdInvnt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateTs).HasColumnName("UpdateTS");
            entity.Property(e => e.UseBilAddr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UseCorrVat)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UseShpdGd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.VatDate).HasColumnType("datetime");
            entity.Property(e => e.VatJenum).HasColumnName("VatJENum");
            entity.Property(e => e.VatPaid).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.VatPaidFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("VatPaidFC");
            entity.Property(e => e.VatPaidSys).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.VatPercent).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.VatSumFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("VatSumFC");
            entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Vatfirst)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VATFirst");
            entity.Property(e => e.VatregNum)
                .HasMaxLength(32)
                .HasColumnName("VATRegNum");
            entity.Property(e => e.VclPlate).HasMaxLength(20);
            entity.Property(e => e.VersionNum).HasMaxLength(13);
            entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.WddStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Weight).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Wtapplied)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("WTApplied");
            entity.Property(e => e.WtappliedF)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("WTAppliedF");
            entity.Property(e => e.WtappliedS)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("WTAppliedS");
            entity.Property(e => e.Wtdetails)
                .HasMaxLength(100)
                .HasColumnName("WTDetails");
            entity.Property(e => e.Wtsum)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("WTSum");
            entity.Property(e => e.WtsumFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("WTSumFC");
            entity.Property(e => e.WtsumSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("WTSumSC");
        });

        modelBuilder.Entity<PmxItri>(entity =>
        {
            entity.HasKey(e => e.InternalKey);

            entity.ToTable("PMX_ITRI");

            entity.HasIndex(e => new { e.InternalKey, e.BatchNumber, e.InternalBatchNumber, e.BestBeforeDate }, "IX_PMX_ITRI:InternalKey,BatchNumber,InternalBatchNumber#D54024CF");

            entity.HasIndex(e => e.BestBeforeDate, "TWBS_IX_PMX_ITRI_BBD");

            entity.HasIndex(e => e.ItemCode, "TWBS_IX_PMX_ITRI_ItemCode");

            entity.HasIndex(e => new { e.BatchNumber, e.InternalBatchNumber, e.BestBeforeDate, e.ItemCode }, "UQ_PMX_ITRI:BatchNumber,InternalBatchNumber,BestBeforeD#27DC7A99").IsUnique();

            entity.Property(e => e.BatchNumber).HasMaxLength(36);
            entity.Property(e => e.BestBeforeDate).HasColumnType("datetime");
            entity.Property(e => e.BestBeforeDateOrginal).HasColumnType("datetime");
            entity.Property(e => e.Canceled)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CountryOfOrigin).HasMaxLength(20);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.InternalBatchNumber).HasMaxLength(36);
            entity.Property(e => e.InternalBatchNumberOriginal).HasMaxLength(36);
            entity.Property(e => e.ItemCode).HasMaxLength(50);
            entity.Property(e => e.ManufacturingDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Rdr1>(entity =>
        {
            entity.HasKey(e => new { e.DocEntry, e.LineNum }).HasName("RDR1_PRIMARY");

            entity.ToTable("RDR1");

            entity.HasIndex(e => e.AcctCode, "RDR1_ACCOUNT");

            entity.HasIndex(e => new { e.BaseEntry, e.BaseType, e.BaseLine }, "RDR1_BASE_ENTRY");

            entity.HasIndex(e => e.Currency, "RDR1_CURRENCY");

            entity.HasIndex(e => new { e.ItemCode, e.WhsCode, e.OpenQty }, "RDR1_ITM_WHS_OQ");

            entity.HasIndex(e => new { e.ItemCode, e.WhsCode, e.ShipDate }, "RDR1_ITM_WHS_SH");

            entity.HasIndex(e => e.OwnerCode, "RDR1_OWNER_CODE");

            entity.HasIndex(e => e.LineStatus, "RDR1_STATUS");

            entity.HasIndex(e => new { e.DocEntry, e.VisOrder }, "RDR1_VIS_ORDER");

            entity.HasIndex(e => e.LineStatus, "SINT_IX_RDR1:LineStatus");

            entity.HasIndex(e => new { e.LineStatus, e.ShipDate }, "SINT_IX_RDR1:LineStatus,ShipDate,ItemCode,Quantity");

            entity.HasIndex(e => new { e.LineStatus, e.WhsCode }, "SINT_IX_RDR1:Status,Whs,Item,Date,Qty");

            entity.HasIndex(e => e.OpenQty, "SINT_IX_RDR1_Open_Sales_Orders");

            entity.Property(e => e.AcctCode).HasMaxLength(15);
            entity.Property(e => e.ActDelDate).HasColumnType("datetime");
            entity.Property(e => e.Address).HasMaxLength(254);
            entity.Property(e => e.AllocBinC).HasMaxLength(11);
            entity.Property(e => e.AssblValue).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.BackOrdr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BaseAtCard).HasMaxLength(100);
            entity.Property(e => e.BaseCard).HasMaxLength(15);
            entity.Property(e => e.BaseOpnQty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.BasePrice)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BaseQty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.BaseRef).HasMaxLength(16);
            entity.Property(e => e.BlockNum).HasMaxLength(100);
            entity.Property(e => e.Ceecflag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CEECFlag");
            entity.Property(e => e.Cestcode).HasColumnName("CESTCode");
            entity.Property(e => e.Cfopcode)
                .HasMaxLength(6)
                .HasColumnName("CFOPCode");
            entity.Property(e => e.ChgAsmBoMw)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ChgAsmBoMW");
            entity.Property(e => e.Cnjpman)
                .HasMaxLength(14)
                .HasColumnName("CNJPMan");
            entity.Property(e => e.CodeBars).HasMaxLength(254);
            entity.Property(e => e.CogsAcct).HasMaxLength(15);
            entity.Property(e => e.CogsOcrCo2).HasMaxLength(8);
            entity.Property(e => e.CogsOcrCo3).HasMaxLength(8);
            entity.Property(e => e.CogsOcrCo4).HasMaxLength(8);
            entity.Property(e => e.CogsOcrCo5).HasMaxLength(8);
            entity.Property(e => e.CogsOcrCod).HasMaxLength(8);
            entity.Property(e => e.Commission).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ConsumeFct)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ConsumeFCT");
            entity.Property(e => e.CountryOrg).HasMaxLength(3);
            entity.Property(e => e.CredOrigin)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cstcode)
                .HasMaxLength(6)
                .HasColumnName("CSTCode");
            entity.Property(e => e.CstfCofins)
                .HasMaxLength(2)
                .HasColumnName("CSTfCOFINS");
            entity.Property(e => e.CstfIpi)
                .HasMaxLength(2)
                .HasColumnName("CSTfIPI");
            entity.Property(e => e.CstfPis)
                .HasMaxLength(2)
                .HasColumnName("CSTfPIS");
            entity.Property(e => e.CtrSealQty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Currency).HasMaxLength(3);
            entity.Property(e => e.Cusplit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CUSplit");
            entity.Property(e => e.DedVatSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DedVatSumF).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DedVatSumS).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DefBreak).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DeferrTax)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DelivrdQty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DescOw)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DescOW");
            entity.Property(e => e.DetailsOw)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DetailsOW");
            entity.Property(e => e.Diotnat)
                .HasMaxLength(3)
                .HasColumnName("DIOTNat");
            entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DistribExp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DistribIs)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DistribIS");
            entity.Property(e => e.DistribSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.DocDate).HasColumnType("datetime");
            entity.Property(e => e.DropShip)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Dscription).HasMaxLength(200);
            entity.Property(e => e.DstrbSumFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("DstrbSumFC");
            entity.Property(e => e.DstrbSumSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("DstrbSumSC");
            entity.Property(e => e.EnSetCost)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EncryptIv)
                .HasMaxLength(100)
                .HasColumnName("EncryptIV");
            entity.Property(e => e.EquVatPer).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ExLineNo).HasMaxLength(10);
            entity.Property(e => e.Excisable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ExciseAmt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ExpOpType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ExpType).HasMaxLength(4);
            entity.Property(e => e.ExpUuid)
                .HasMaxLength(50)
                .HasColumnName("ExpUUID");
            entity.Property(e => e.ExtTaxRate).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ExtTaxSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ExtTaxSumF).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ExtTaxSumS).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Factor1).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Factor2).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Factor3).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Factor4).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.FisrtBin).HasMaxLength(228);
            entity.Property(e => e.FreeChrgBp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FreeChrgBP");
            entity.Property(e => e.FreeTxt).HasMaxLength(100);
            entity.Property(e => e.FromWhsCod).HasMaxLength(8);
            entity.Property(e => e.GpbefDisc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("GPBefDisc");
            entity.Property(e => e.GpttlBasPr)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("GPTtlBasPr");
            entity.Property(e => e.GrossBuyPr).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.GrssProfFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("GrssProfFC");
            entity.Property(e => e.GrssProfSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("GrssProfSC");
            entity.Property(e => e.GrssProfit).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Gtotal)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("GTotal");
            entity.Property(e => e.GtotalFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("GTotalFC");
            entity.Property(e => e.GtotalSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("GTotalSC");
            entity.Property(e => e.Height1).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Height2).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ImportLog).HasMaxLength(20);
            entity.Property(e => e.IndEscala)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Inmprice)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("INMPrice");
            entity.Property(e => e.InvQty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.InvQtyOnly)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InvntSttus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsAqcuistn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsByPrdct)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsCstmAct)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsPrscGood)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsSrvCall)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isSrvCall");
            entity.Property(e => e.Isdistrb)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("ISDistrb");
            entity.Property(e => e.IsdistrbFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("ISDistrbFC");
            entity.Property(e => e.IsdistrbSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("ISDistrbSC");
            entity.Property(e => e.IsdtCryImp)
                .HasMaxLength(3)
                .HasColumnName("ISDtCryImp");
            entity.Property(e => e.IsdtRgnImp).HasColumnName("ISDtRgnImp");
            entity.Property(e => e.IsorCryExp)
                .HasMaxLength(3)
                .HasColumnName("ISOrCryExp");
            entity.Property(e => e.IsorRgnExp).HasColumnName("ISOrRgnExp");
            entity.Property(e => e.ItemCode).HasMaxLength(50);
            entity.Property(e => e.ItmTaxType).HasMaxLength(2);
            entity.Property(e => e.LegalTcd)
                .HasMaxLength(250)
                .HasColumnName("LegalTCD");
            entity.Property(e => e.LegalText).HasMaxLength(254);
            entity.Property(e => e.LegalTimd)
                .HasMaxLength(250)
                .HasColumnName("LegalTIMD");
            entity.Property(e => e.LegalTtca)
                .HasMaxLength(250)
                .HasColumnName("LegalTTCA");
            entity.Property(e => e.LegalTw)
                .HasMaxLength(250)
                .HasColumnName("LegalTW");
            entity.Property(e => e.Length1).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Length2)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("length2");
            entity.Property(e => e.LicTradNum).HasMaxLength(32);
            entity.Property(e => e.LinManClsd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LinePoPrss)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LineStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LineTotal).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.LineType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LineVat).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.LineVatS).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.LineVatlF).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.LineVendor).HasMaxLength(15);
            entity.Property(e => e.LnExcised)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LstBinmpr)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("LstBINMPr");
            entity.Property(e => e.LstByDsFc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.LstByDsSc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.LstByDsSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Myftype)
                .HasMaxLength(2)
                .HasColumnName("MYFtype");
            entity.Property(e => e.Ncmcode).HasColumnName("NCMCode");
            entity.Property(e => e.NeedQty)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NoInvtryMv)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NumPerMsr).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.NumPerMsr2).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Nvecode)
                .HasMaxLength(6)
                .HasColumnName("NVECode");
            entity.Property(e => e.ObjType).HasMaxLength(20);
            entity.Property(e => e.OcrCode).HasMaxLength(8);
            entity.Property(e => e.OcrCode2).HasMaxLength(8);
            entity.Property(e => e.OcrCode3).HasMaxLength(8);
            entity.Property(e => e.OcrCode4).HasMaxLength(8);
            entity.Property(e => e.OcrCode5).HasMaxLength(8);
            entity.Property(e => e.OpenCreQty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.OpenInvQty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.OpenQty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.OpenRtnQty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.OpenSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.OpenSumFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("OpenSumFC");
            entity.Property(e => e.OpenSumSys).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.OrderedQty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.OriBabsEnt).HasColumnName("OriBAbsEnt");
            entity.Property(e => e.OriBdocTyp).HasColumnName("OriBDocTyp");
            entity.Property(e => e.OriBlinNum).HasColumnName("OriBLinNum");
            entity.Property(e => e.OrigItem).HasMaxLength(50);
            entity.Property(e => e.PackQty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.PartRetire)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PcQuantity).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.PickOty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.PickStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PoNum).HasMaxLength(20);
            entity.Property(e => e.PoTrgEntry).HasMaxLength(11);
            entity.Property(e => e.PostTax)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PqtreqDate)
                .HasColumnType("datetime")
                .HasColumnName("PQTReqDate");
            entity.Property(e => e.PqtreqQty)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("PQTReqQty");
            entity.Property(e => e.Price).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.PriceAfVat)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("PriceAfVAT");
            entity.Property(e => e.PriceBefDi).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.PriceEdit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Project).HasMaxLength(20);
            entity.Property(e => e.QtyToShip).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Quantity).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Rate).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ReleasQtty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.RetCost).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.RetirApcfc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("RetirAPCFC");
            entity.Property(e => e.RetirApcsc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("RetirAPCSC");
            entity.Property(e => e.RetireApc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("RetireAPC");
            entity.Property(e => e.RetireQty).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.RevCharge)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Rg23apart1).HasColumnName("RG23APart1");
            entity.Property(e => e.Rg23apart2).HasColumnName("RG23APart2");
            entity.Property(e => e.Rg23cpart1).HasColumnName("RG23CPart1");
            entity.Property(e => e.Rg23cpart2).HasColumnName("RG23CPart2");
            entity.Property(e => e.SerialNum).HasMaxLength(17);
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.ShipFromCo).HasMaxLength(50);
            entity.Property(e => e.ShipFromDe).HasMaxLength(254);
            entity.Property(e => e.ShipToCode).HasMaxLength(50);
            entity.Property(e => e.ShipToDesc).HasMaxLength(254);
            entity.Property(e => e.Shortages).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.SpecPrice)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StckAppD).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.StckAppDfc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("StckAppDFC");
            entity.Property(e => e.StckAppDsc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("StckAppDSC");
            entity.Property(e => e.StckAppFc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.StckAppSc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.StckDstFc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.StckDstSc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.StckDstSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.StckInmpr)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("StckINMPr");
            entity.Property(e => e.StckSumApp).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.StgDesc).HasMaxLength(100);
            entity.Property(e => e.StockPrice).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.StockSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.StockSumFc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.StockSumSc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.StockValue).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.SubCatNum).HasMaxLength(50);
            entity.Property(e => e.Surpluses).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Sww)
                .HasMaxLength(16)
                .HasColumnName("SWW");
            entity.Property(e => e.TaxAmtSrc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TaxCode).HasMaxLength(8);
            entity.Property(e => e.TaxDistSfc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("TaxDistSFC");
            entity.Property(e => e.TaxDistSsc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("TaxDistSSC");
            entity.Property(e => e.TaxDistSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.TaxOnly)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TaxPerUnit).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.TaxRelev)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TaxStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TaxType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Text).HasColumnType("ntext");
            entity.Property(e => e.ThirdParty)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ToDiff).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.ToStock).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.TotInclTax).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.TotalFrgn).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.TotalSumSy).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.TranType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TreeType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UA1wmsComments)
                .HasMaxLength(254)
                .HasColumnName("U_A1WMS_Comments");
            entity.Property(e => e.UA1wmsRmaqty).HasColumnName("U_A1WMS_RMAQTY");
            entity.Property(e => e.UPcnumb)
                .HasMaxLength(30)
                .HasColumnName("U_PCNumb");
            entity.Property(e => e.UPmxAmba)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("U_PMX_AMBA");
            entity.Property(e => e.UPmxBac1)
                .HasMaxLength(50)
                .HasColumnName("U_PMX_BAC1");
            entity.Property(e => e.UPmxBac2)
                .HasMaxLength(50)
                .HasColumnName("U_PMX_BAC2");
            entity.Property(e => e.UPmxBac3)
                .HasMaxLength(50)
                .HasColumnName("U_PMX_BAC3");
            entity.Property(e => e.UPmxBaen).HasColumnName("U_PMX_BAEN");
            entity.Property(e => e.UPmxBali).HasColumnName("U_PMX_BALI");
            entity.Property(e => e.UPmxBat2)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_BAT2");
            entity.Property(e => e.UPmxBatc)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_BATC");
            entity.Property(e => e.UPmxBaty)
                .HasMaxLength(20)
                .HasColumnName("U_PMX_BATY");
            entity.Property(e => e.UPmxBav1)
                .HasMaxLength(254)
                .HasColumnName("U_PMX_BAV1");
            entity.Property(e => e.UPmxBav2)
                .HasMaxLength(254)
                .HasColumnName("U_PMX_BAV2");
            entity.Property(e => e.UPmxBav3)
                .HasMaxLength(254)
                .HasColumnName("U_PMX_BAV3");
            entity.Property(e => e.UPmxBbdt)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_BBDT");
            entity.Property(e => e.UPmxEx3p)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("U_PMX_EX3P");
            entity.Property(e => e.UPmxFree)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("U_PMX_FREE");
            entity.Property(e => e.UPmxIqty)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("U_PMX_IQTY");
            entity.Property(e => e.UPmxIslc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("U_PMX_ISLC");
            entity.Property(e => e.UPmxIswa)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("U_PMX_ISWA");
            entity.Property(e => e.UPmxLoco)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_LOCO");
            entity.Property(e => e.UPmxLuid)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_LUID");
            entity.Property(e => e.UPmxMlui)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_MLUI");
            entity.Property(e => e.UPmxMqu2)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("U_PMX_MQU2");
            entity.Property(e => e.UPmxPatq)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("U_PMX_PATQ");
            entity.Property(e => e.UPmxPaty)
                .HasMaxLength(20)
                .HasColumnName("U_PMX_PATY");
            entity.Property(e => e.UPmxPqy2)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_PQY2");
            entity.Property(e => e.UPmxPrdb).HasColumnName("U_PMX_PRDB");
            entity.Property(e => e.UPmxPrde).HasColumnName("U_PMX_PRDE");
            entity.Property(e => e.UPmxPrdl).HasColumnName("U_PMX_PRDL");
            entity.Property(e => e.UPmxPrdr).HasColumnName("U_PMX_PRDR");
            entity.Property(e => e.UPmxQty2)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("U_PMX_QTY2");
            entity.Property(e => e.UPmxQuan)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_QUAN");
            entity.Property(e => e.UPmxQysc)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_QYSC");
            entity.Property(e => e.UPmxRipi)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("U_PMX_RIPI");
            entity.Property(e => e.UPmxRlco)
                .HasMaxLength(50)
                .HasColumnName("U_PMX_RLCO");
            entity.Property(e => e.UPmxRsnc)
                .HasMaxLength(8)
                .HasColumnName("U_PMX_RSNC");
            entity.Property(e => e.UPmxSenu)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_SENU");
            entity.Property(e => e.UPmxShlf).HasColumnName("U_PMX_SHLF");
            entity.Property(e => e.UPmxSloc)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_SLOC");
            entity.Property(e => e.UPmxSlui)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_SLUI");
            entity.Property(e => e.UPmxSpnr)
                .HasMaxLength(100)
                .HasColumnName("U_PMX_SPNR");
            entity.Property(e => e.UPmxSqop)
                .HasMaxLength(50)
                .HasColumnName("U_PMX_SQOP");
            entity.Property(e => e.UPmxSqsc)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_SQSC");
            entity.Property(e => e.UPmxSscc)
                .HasColumnType("ntext")
                .HasColumnName("U_PMX_SSCC");
            entity.Property(e => e.UPmxSulr)
                .HasMaxLength(40)
                .HasColumnName("U_PMX_SULR");
            entity.Property(e => e.UPmxU2tu)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("U_PMX_U2TU");
            entity.Property(e => e.UPmxUftx)
                .HasMaxLength(254)
                .HasColumnName("U_PMX_UFTX");
            entity.Property(e => e.UPmxUom2)
                .HasMaxLength(8)
                .HasColumnName("U_PMX_UOM2");
            entity.Property(e => e.USifBidStdNumb)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("U_SIF_BidStdNumb");
            entity.Property(e => e.USifCustPartRev)
                .HasMaxLength(10)
                .HasColumnName("U_SIF_CustPartRev");
            entity.Property(e => e.USifCustPn)
                .HasMaxLength(20)
                .HasColumnName("U_SIF_CustPN");
            entity.Property(e => e.USifCustPnrev)
                .HasMaxLength(10)
                .HasColumnName("U_SIF_CustPNRev");
            entity.Property(e => e.USifCustPo)
                .HasMaxLength(30)
                .HasColumnName("U_SIF_CustPO");
            entity.Property(e => e.USifCustRequ)
                .HasColumnType("datetime")
                .HasColumnName("U_SIF_CustRequ");
            entity.Property(e => e.USifPoCustNumb)
                .HasMaxLength(6)
                .HasColumnName("U_SIF_PO_CustNumb");
            entity.Property(e => e.USifPolineNum).HasColumnName("U_SIF_POLineNum");
            entity.Property(e => e.USifPromShipDt)
                .HasColumnType("datetime")
                .HasColumnName("U_SIF_PromShipDt");
            entity.Property(e => e.USifSinqnumb)
                .HasMaxLength(10)
                .HasColumnName("U_SIF_SINQNumb");
            entity.Property(e => e.USifVendProm)
                .HasColumnType("datetime")
                .HasColumnName("U_SIF_VendProm");
            entity.Property(e => e.USifWhTrnfrCstEa)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("U_SIF_WhTrnfrCstEA");
            entity.Property(e => e.USifWhirlPs)
                .HasMaxLength(10)
                .HasColumnName("U_SIF_WhirlPS");
            entity.Property(e => e.USifWonumb).HasColumnName("U_SIF_WONumb");
            entity.Property(e => e.UTwbsPalletLineUniqueId)
                .HasMaxLength(50)
                .HasColumnName("U_TWBS_PalletLineUniqueID");
            entity.Property(e => e.UffiscBene)
                .HasMaxLength(10)
                .HasColumnName("UFFiscBene");
            entity.Property(e => e.UnitMsr)
                .HasMaxLength(100)
                .HasColumnName("unitMsr");
            entity.Property(e => e.UnitMsr2)
                .HasMaxLength(100)
                .HasColumnName("unitMsr2");
            entity.Property(e => e.UomCode).HasMaxLength(20);
            entity.Property(e => e.UomCode2).HasMaxLength(20);
            entity.Property(e => e.UpdInvntry)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UseBaseUn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.VatAppld).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.VatAppldFc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("VatAppldFC");
            entity.Property(e => e.VatAppldSc)
                .HasColumnType("numeric(19, 6)")
                .HasColumnName("VatAppldSC");
            entity.Property(e => e.VatDscntPr).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.VatExLn).HasColumnName("VatExLN");
            entity.Property(e => e.VatGroup).HasMaxLength(8);
            entity.Property(e => e.VatGrpSrc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.VatPrcnt).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.VatSumFrgn).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.VatWoDpm).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.VatWoDpmFc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.VatWoDpmSc).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.VendorNum).HasMaxLength(50);
            entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Weight1).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Weight2).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.WhsCode).HasMaxLength(8);
            entity.Property(e => e.Width1).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.Width2).HasColumnType("numeric(19, 6)");
            entity.Property(e => e.WtCalced)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.WtLiable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
