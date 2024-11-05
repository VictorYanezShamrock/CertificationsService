using System;
using System.Collections.Generic;

namespace CertsService.Models.SIF;

public partial class PmxItri
{
    public int InternalKey { get; set; }

    public string Canceled { get; set; } = null!;

    public int? UserSign { get; set; }

    public DateTime CreateDate { get; set; }

    public short CreateTime { get; set; }

    public DateTime? UpdateDate { get; set; }

    public short? UpdateTime { get; set; }

    public int Version { get; set; }

    public string? BatchNumber { get; set; }

    public string? InternalBatchNumber { get; set; }

    public string? InternalBatchNumberOriginal { get; set; }

    public DateTime? BestBeforeDate { get; set; }

    public DateTime? BestBeforeDateOrginal { get; set; }

    public string ItemCode { get; set; } = null!;

    public string? CountryOfOrigin { get; set; }

    public DateTime? ManufacturingDate { get; set; }
}
