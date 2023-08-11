using System;
using System.Collections.Generic;

namespace db_auto_test.EFCore;

/// <summary>
/// 项目结构表
/// </summary>
public partial class Twinproject
{
    /// <summary>
    /// 项目ID
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// 项目名称
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 英文名称
    /// </summary>
    public string EnName { get; set; } = null!;

    /// <summary>
    /// CIMServerUrl地址
    /// </summary>
    public string CimserverUrl { get; set; } = null!;

    /// <summary>
    /// 审核状态 0-已通过 1 未通过
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 发布价格
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// 发布时间
    /// </summary>
    public long PublishTime { get; set; }

    /// <summary>
    /// 到期时间
    /// </summary>
    public long ExpTime { get; set; }

    /// <summary>
    /// 今日调用次数
    /// </summary>
    public int VisitsOfToday { get; set; }

    /// <summary>
    /// 发布地址
    /// </summary>
    public string? PublishUrl { get; set; }

    /// <summary>
    /// 总调用次数
    /// </summary>
    public int Visits { get; set; }

    /// <summary>
    /// 项目类别ID
    /// </summary>
    public string CategoryId { get; set; } = null!;

    public string? ProjectCategoryId { get; set; }

    public virtual Twinprojectcatalog? ProjectCategory { get; set; }

    public virtual ICollection<Twingroup> Twingroups { get; set; } = new List<Twingroup>();
}
