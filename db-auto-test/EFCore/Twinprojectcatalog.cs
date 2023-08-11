using System;
using System.Collections.Generic;

namespace db_auto_test.EFCore;

/// <summary>
/// 类别结构表
/// </summary>
public partial class Twinprojectcatalog
{
    /// <summary>
    /// 类别ID
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// 类别名称
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 父级Id
    /// </summary>
    public string ParentId { get; set; } = null!;

    /// <summary>
    /// 创建用户ID
    /// </summary>
    public string CreateBy { get; set; } = null!;

    public virtual ICollection<Twinproject> Twinprojects { get; set; } = new List<Twinproject>();
}
