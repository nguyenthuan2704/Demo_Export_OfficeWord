using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Demo_Export_OfficeWord.Models
{
    public class DemoExportDBContext : DbContext
    {
        public DemoExportDBContext(): base("name=StrConnect") { }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}