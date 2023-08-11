using System;
using System.Collections.Generic;

namespace db_auto_test.EFCore;

/// <summary>
/// 孪生体类型表
/// </summary>
public partial class Twintype
{
    /// <summary>
    /// ID
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// 类型名称
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 属性定义
    /// </summary>
    public string ContentData { get; set; } = null!;

    /// <summary>
    /// 类型Id
    /// </summary>
    public string TypeId { get; set; } = null!;

    /// <summary>
    /// 排序值
    /// </summary>
    public int SortIndex { get; set; }
}
