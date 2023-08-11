using System;
using System.Collections.Generic;

namespace db_auto_test.EFCore;

/// <summary>
/// 孪生体类别表
/// </summary>
public partial class Twincategory
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
    /// 类型ID
    /// </summary>
    public string TypeId { get; set; } = null!;

    /// <summary>
    /// 组ID
    /// </summary>
    public string GroupId { get; set; } = null!;

    public string? TwinGroupId { get; set; }

    public virtual Twingroup? TwinGroup { get; set; }

    public virtual ICollection<Twindatum> Twindata { get; set; } = new List<Twindatum>();

    public virtual ICollection<Twinproperty> Twinproperties { get; set; } = new List<Twinproperty>();
}
