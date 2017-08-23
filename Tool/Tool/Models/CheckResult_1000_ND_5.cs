namespace Tool.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CheckResult_1000_ND_5
    {
        public Guid? TextId { get; set; }

        public double? TotalCopyPercent { get; set; }

        public string Json { get; set; }

        public DateTime? BeginTime { get; set; }

        public DateTime? EndTime { get; set; }

        public long? ElapsedMilliseconds { get; set; }

        [Key]
        public int Order { get; set; }
    }
}
