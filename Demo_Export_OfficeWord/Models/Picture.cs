using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Export_OfficeWord.Models
{
    [Table("Pictures")]
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey("Report")]
        public int Report_Id { get; set; }
        public Report Report { get; set; }
    }
}