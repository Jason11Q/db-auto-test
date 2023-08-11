using System.ComponentModel;
using System.Runtime.Serialization;

namespace db_auto_test.Dto
{
    public class GenerateHistoryRequest
    {
        /// <summary>
        /// 生成数据起始日期
        /// </summary>
        public DateTime StartTime { get; set; } = DateTime.Now.Date;

        /// <summary>
        /// 生成天数
        /// </summary>
        [DefaultValue(10)]
        [DataMember(Name = "days", EmitDefaultValue = true)]
        public int Days { get; set; } = 10;

        /// <summary>
        /// 每天生成数据数量
        /// </summary>
        [DefaultValue(100)]
        [DataMember(Name = "dayCount", EmitDefaultValue = true)]
        public int DayCount { get; set; } = 100;

        /// <summary>
        /// 每条数据间隔时间，单位（s）
        /// </summary>
        [DefaultValue(35)]
        [DataMember(Name = "interval", EmitDefaultValue = true)]
        public int Interval { get; set; } = 35;
    }
}
