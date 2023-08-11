using System;
using System.Collections.Generic;

namespace db_auto_test.EFCore;

/// <summary>
/// 孪生体属性表
/// </summary>
public partial class Twinproperty
{
    /// <summary>
    /// ID
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// 孪生体类别名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 数据json
    /// </summary>
    public string ContentData { get; set; } = null!;

    /// <summary>
    /// 孪生体类别ID
    /// </summary>
    public string CategoryId { get; set; } = null!;

    /// <summary>
    /// 属性排序
    /// </summary>
    public int SortIndex { get; set; }

    public string? TwinCategoryId { get; set; }

    public virtual Twincategory? TwinCategory { get; set; }
}
