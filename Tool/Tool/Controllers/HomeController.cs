using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Tool.Models;

namespace Tool.Controllers
{
    public class HomeController : Controller
    {
        private CheckTestModel db = new CheckTestModel();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTextList(string tablename)
        {
            string result = "";

            if (tablename == "CheckText_1000")
            {
                var list = from e in db.CheckText_1000
                           select new { Content = e.Content.Substring(0, 100), TextId = e.TextId };

                //List<CheckText_1000> list;
                //list = db.CheckText_1000.ToList();
                //foreach (var l in list)
                //{
                //    if (l.Content.Length > 100)
                //    {
                //        l.Content = l.Content.Substring(0, 100);
                //    }
                //}

                result = JsonConvert.SerializeObject(list);
            }
            else if (tablename == "CheckText_5000")
            {
                var list = from e in db.CheckText_5000
                           select new { Content = e.Content.Substring(0, 100), TextId = e.TextId };
                //List<CheckText_5000> list;
                //list = db.CheckText_5000.ToList();
                //foreach (var l in list)
                //{
                //    if (l.Content.Length > 100)
                //    {
                //        l.Content = l.Content.Substring(0, 100);
                //    }
                //}
                result = JsonConvert.SerializeObject(list);
            }
            else if (tablename == "CheckText_Problem")
            {
                var list = from e in db.CheckText_Problem
                           select new { Content = e.Content.Substring(0, 100), TextId = e.TextId };
                //List<CheckText_Problem> list;
                //list = db.CheckText_Problem.ToList();
                //foreach (var l in list)
                //{
                //    if (l.Content.Length > 100)
                //    {
                //        l.Content = l.Content.Substring(0, 100);
                //    }
                //}
                result = JsonConvert.SerializeObject(list);
            }


            return Content(result);
        }

        public ActionResult GetDetail()
        {
            return View();
        }

        public JsonResult GetDetailInfo(string TextId, string tablename)
        {
            string Text = "";
            string wfText = "";

            if (tablename == "CheckText_1000")
            {
                CheckResult_1000_ND_5 ndlist;
                CheckResult_1000_WF_5 wflist;

                //南大结果
                ndlist = db.CheckResult_1000_ND_5.SingleOrDefault(a => a.TextId.ToString() == TextId);

                //万方结果
                wflist = db.CheckResult_1000_WF_5.SingleOrDefault(a => a.TextId.ToString() == TextId);

                //全文
                Text = db.CheckText_1000.SingleOrDefault(a => a.TextId.ToString() == TextId).Content;
                wfText = Text;
                Text = Regex.Replace(Text, "[" + (char)0 + "-" + (char)9 + (char)11 + "-" + (char)12 + (char)14 + "-" + (char)31 + "]", "");

                return Json(new { nddata = ndlist, wfdata = wflist, wfText = wfText, txt = Text });
            }
            else if (tablename == "CheckText_5000")
            {
                CheckResult_5000_ND ndlist;
                CheckResult_5000_WF wflist;

                //南大结果
                ndlist = db.CheckResult_5000_ND.SingleOrDefault(a => a.TextId.ToString() == TextId);

                //万方结果
                wflist = db.CheckResult_5000_WF.SingleOrDefault(a => a.TextId.ToString() == TextId);

                //全文
                Text = db.CheckText_5000.SingleOrDefault(a => a.TextId.ToString() == TextId).Content;
                wfText = Text;
                Text = Regex.Replace(Text, "[" + (char)0 + "-" + (char)9 + (char)11 + "-" + (char)12 + (char)14 + "-" + (char)31 + "]", "");

                return Json(new { nddata = ndlist, wfdata = wflist, wfText = wfText, txt = Text });
            }
            else if (tablename == "CheckText_Problem")
            {
                CheckResult_Problem_ND ndlist;
                CheckResult_Problem_WF wflist;

                //南大结果
                ndlist = db.CheckResult_Problem_ND.SingleOrDefault(a => a.TextId.ToString() == TextId);

                //万方结果
                wflist = db.CheckResult_Problem_WF.SingleOrDefault(a => a.TextId.ToString() == TextId);

                //全文
                Text = db.CheckText_Problem.SingleOrDefault(a => a.TextId.ToString() == TextId).Content;
                wfText = Text;
                Text = Regex.Replace(Text, "[" + (char)0 + "-" + (char)9 + (char)11 + "-" + (char)12 + (char)14 + "-" + (char)31 + "]", "");

                return Json(new { nddata = ndlist, wfdata = wflist, wfText = wfText, txt = Text });
            }
            else
            {
                return Json("");
            }

        }

    }
}
