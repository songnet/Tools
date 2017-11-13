using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebUploader
{
    /// <summary>
    /// UploaderHandler 的摘要说明
    /// </summary>
    public class UploaderHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.ContentEncoding = Encoding.UTF8;
            if (context.Request["REQUEST_METHOD"] == "OPTIONS")
            {
                context.Response.End();
            }
            SaveFile();
        }

        /// <summary>
        /// 文件保存操作
        /// </summary>
        /// <param name="basePath"></param>
        private void SaveFile(string basePath = "~/Upload/Images/")
        {
            var name = string.Empty;
            basePath = (basePath.IndexOf("~") > -1) ? HttpContext.Current.Server.MapPath(basePath) :
            basePath;
            HttpFileCollection files = HttpContext.Current.Request.Files;

            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);

            var suffix = files[0].ContentType.Split('/');
            var _suffix = suffix[1].Equals("jpeg", StringComparison.CurrentCultureIgnoreCase) ? "" : suffix[1];
            var _temp = HttpContext.Current.Request["name"];

            if (!string.IsNullOrEmpty(_temp))
            {
                name = _temp;
            }
            else
            {
                Random rand = new Random(24 * (int)DateTime.Now.Ticks);
                name = rand.Next() + "." + _suffix;
            }

            var full = basePath + name;
            files[0].SaveAs(full);
            var _result = "{\"jsonrpc\" : \"2.0\", \"result\" : null, \"id\" : \"" + name + "\"}";
            System.Web.HttpContext.Current.Response.Write(_result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}