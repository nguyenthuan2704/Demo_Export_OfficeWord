using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_Export_OfficeWord.Models;
using System.Web.Script.Serialization;
using Aspose.Words.Reporting;
using Aspose.Words;
using GroupDocs.Assembly;

namespace Demo_Export_OfficeWord.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report       
        private DemoExportDBContext db = new DemoExportDBContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Reports.ToList());
        }
        [HttpPost]
        public ActionResult Index(Report report)
        {
            //retrieve the data from table
            var personlist = db.Reports.ToList();

            string jsondata = new JavaScriptSerializer().Serialize(personlist);
            string path = Server.MapPath("~/Public/");
            // Write that JSON to txt file,  
            System.IO.File.WriteAllText(path+"output.json",jsondata);
            TempData["msg"] = "Json file Generated! check this in your Public folder";                    
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Export(object sender,EventArgs e)
        {
            var report = db.Reports.ToList();
            //Document templateReport = new Document("C:/Users/Phuong/source/repos/Demo_Export_OfficeWord/Demo_Export_OfficeWord/template.docx");
            Document templateReport = new Document("C:/Users/Phuong/source/repos/Demo_Export_OfficeWord/Demo_Export_OfficeWord/App_Data/template.docx");            
            foreach (var item in report)
            {                
                templateReport.MailMerge.Execute(new[] { "Reporttime" }, new[] { string.Format("{0:dd/MM/yyyy}", item.Inbox) });                
                templateReport.MailMerge.Execute(new[] { "Inbox" }, new[] { string.Format("{0:HH:mm:ss}", item.Inbox) });
                templateReport.MailMerge.Execute(new[] { "Id" }, new[] { item.Id.ToString() });
                templateReport.MailMerge.Execute(new[] { "Title" }, new[] { item.Title});
                templateReport.MailMerge.Execute(new[] { "Content" }, new[] { item.Content });
                templateReport.MailMerge.Execute(new[] { "Require" }, new[] { item.Require });
                templateReport.MailMerge.Execute(new[] { "Reason" }, new[] { item.Reason });
                templateReport.MailMerge.Execute(new[] { "Solution" }, new[] { item.Solution });
                templateReport.MailMerge.Execute(new[] { "Type" }, new[] { item.Type });
                templateReport.MailMerge.Execute(new[] { "Status" }, new[] { item.Status });
                templateReport.MailMerge.Execute(new[] { "Links" }, new[] { item.Links });                
            }            
            templateReport.Save("C:/Users/Phuong/source/repos/Demo_Export_OfficeWord/Demo_Export_OfficeWord/Public/report.docx");
            TempData["msg"] = "Word file Generated!";
            byte[] fileBytes = System.IO.File.ReadAllBytes("C:/Users/Phuong/source/repos/Demo_Export_OfficeWord/Demo_Export_OfficeWord/Public/report.docx");
            string fileName = "reporemail.docx"; 
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            //return RedirectToAction("Index");
        }

        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
            Report report = db.Reports.Find(id);
            return View(report);
        }

        // GET: Report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Report/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Report report)
        {
            db.Reports.Add(report);
            db.SaveChanges();            
            return RedirectToAction("Index");
        }

        // GET: Report/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Report/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Report/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Report/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
