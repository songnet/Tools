using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tool.Models
{
    public class TextModel
    {
        [Key]
        int Id { get; set; }

        Guid TextId { get; set; }

        string Content { get; set; }
    }
}