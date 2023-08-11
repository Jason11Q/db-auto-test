using System;
using System.Collections.Generic;

namespace db_auto_test.EFCore;

/// <summary>
/// 回放数据标签表
/// </summary>
public partial class Twinhistorydatatag
{
    /// <summary>
    /// ID
    /// </summary>
    public string TagDataId { get; set; } = null!;

    /// <summary>
    /// 标签id，与回放数据关联
    /// </summary>
    public string TagId { get; set; } = null!;

    /// <summary>
    /// 标签
    /// </summary>
    public string? Tag { get; set; }

    /// <summary>
    /// 批号
    /// </summary>
    public string GrouId { get; set; } = null!;

    /// <summary>
    /// 最大时间值
    /// </summary>
    public DateTime? MaxTime { get; set; }

    /// <summary>
    /// 最小时间值
    /// </summary>
    public DateTime? MinTime { get; set; }

    /// <summary>
    /// 历史数据条数
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// 备注，预留字段
    /// </summary>
    public string? Remark { get; set; }
}
