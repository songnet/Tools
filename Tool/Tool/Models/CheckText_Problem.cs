namespace Tool.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CheckText_Problem
    {
        [Key]
        public Guid TextId { get; set; }

        public string Content { get; set; }
    }
}
