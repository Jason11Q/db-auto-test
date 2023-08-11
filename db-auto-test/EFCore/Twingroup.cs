using System;
using System.Collections.Generic;

namespace db_auto_test.EFCore;

/// <summary>
/// 孪生体组表
/// </summary>
public partial class Twingroup
{
    /// <summary>
    /// 分类ID
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// 分类名称
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 所属项目ID
    /// </summary>
    public string ProjectId { get; set; } = null!;

    public string? ProjectId1 { get; set; }

    public virtual Twinproject? ProjectId1Navigation { get; set; }

    public virtual ICollection<Twincategory> Twincategories { get; set; } = new List<Twincategory>();
}
