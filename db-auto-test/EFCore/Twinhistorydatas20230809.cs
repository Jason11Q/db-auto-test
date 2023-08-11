using System;
using System.Collections.Generic;

namespace db_auto_test.EFCore;

public partial class Twinhistorydatas20230809
{
    /// <summary>
    /// 数据id，主键
    /// </summary>
    public string HistoryDataId { get; set; } = null!;

    /// <summary>
    /// 批号 主键
    /// </summary>
    public string? GroupId { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 经度
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// 纬度
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// 高度
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// 旋转
    /// </summary>
    public float Yaw { get; set; }

    /// <summary>
    /// 俯仰
    /// </summary>
    public float Pitch { get; set; }

    /// <summary>
    /// 翻滚
    /// </summary>
    public float Roll { get; set; }

    /// <summary>
    /// 缩放X
    /// </summary>
    public float ScaleX { get; set; }

    /// <summary>
    /// 缩放Y
    /// </summary>
    public float ScaleY { get; set; }

    /// <summary>
    /// 缩放Z
    /// </summary>
    public float ScaleZ { get; set; }

    /// <summary>
    /// 时间（列名固定）
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    /// 标签Id，与回放数据标签表关联
    /// </summary>
    public string TagId { get; set; } = null!;

    /// <summary>
    /// 扩展字段，用于扩展字段历史的存储
    /// </summary>
    public string? Extended { get; set; }
}
