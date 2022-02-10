using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Demo_Export_OfficeWord.Models
{
    [Table("Reports")]
    public class Report
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime? Inbox { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Require { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public string Solution { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Links { get; set; }
        //Liên kết khóa ngoại bảng Picture        
        public ICollection<Picture> Pictures { get; set; }

    }
}