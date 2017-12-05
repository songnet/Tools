using CheckUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CheckUtils.FileCompress;

namespace WebUploader
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSend_ServerClick(object sender, EventArgs e)
        {
            var emailAcount = ConfigurationManager.AppSettings["EmailAcount"];
            var emailPassword = ConfigurationManager.AppSettings["EmailPassword"];
            var reciver = txt_Reciver.Value;
            var content = rtxt_Content.Value;
            MailMessage message = new MailMessage();
            //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
            MailAddress fromAddr = new MailAddress("15712847805@163.com");
            message.From = fromAddr;
            //设置收件人,可添加多个,添加方法与下面的一样
            message.To.Add(reciver);
            //设置抄送人
            //message.CC.Add("15712847805@163.com");
            //设置邮件标题
            message.Subject = "Test";
            //设置邮件内容
            message.Body = content;
            //设置邮件发送服务器,服务器根据你使用的邮箱而不同,可以到相应的 邮箱管理后台查看,下面是QQ的
            SmtpClient client = new SmtpClient("smtp.163.com", 25);
            //设置发送人的邮箱账号和密码
            client.Credentials = new NetworkCredential(emailAcount, emailPassword);
            //启用ssl,也就是安全发送
            client.EnableSsl = true;
            //发送邮件
            client.Send(message);
        }

        protected void Btn_DownLoad_ServerClick(object sender, EventArgs e)
        {
            string[] FileProperties = new string[2];
            string htmlReportTemplatePath = "D:\\github\\Tools\\Tool\\PDFReportGenerator\\TemplateFiles";//待压缩文件目录
            //string zipPath = "D:\\TestFiles\\zip\\a.zip";  //压缩后的目标文件
            string sFileName = "a.zip";

            string temp = Directory.GetCurrentDirectory();

            string modelValue = "";

            // 读取文件夹、文件，同时替换

            List<ComplexFile> fileList = GetHtmlReportFiles(htmlReportTemplatePath, modelValue);

            byte[] fileBytes = new FileCompress().Compress(fileList);
            //File.WriteAllBytes(zipPath, fileBytes);

            Context.Response.ContentType = "application/octet-stream";
            Context.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(sFileName, Encoding.UTF8));
            Context.Response.AddHeader("Content-Length", fileBytes.Length.ToString());

            Context.Response.BinaryWrite(fileBytes);
            Context.Response.End();
            Context.Response.Close();

        }

        private static List<ComplexFile> GetHtmlReportFiles(string htmlReportTemplatePath, string modelValue)
        {
            List<ComplexFile> complexFiles = new List<ComplexFile>();

            string pathFormat = Path.Combine(htmlReportTemplatePath);
            GetFiles(htmlReportTemplatePath, pathFormat, ref complexFiles);

            return complexFiles;
        }

        private static void GetFiles(string path, string rootPath, ref List<ComplexFile> complexFiles)
        {
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            foreach (var directory in directories)
            {
                ComplexFile complexFile = new ComplexFile();
                complexFile.Name = directory.Replace(rootPath, "");

                // 文件夹
                List<ComplexFile> complexFileChildren = complexFile.Children;
                GetFiles(directory, rootPath, ref complexFileChildren);

                complexFiles.Add(complexFile);
            }

            foreach (var file in files)
            {
                ComplexFile complexFile = new ComplexFile();
                complexFile.Name = file.Replace(rootPath, "");

                // 文件
                byte[] bytes = File.ReadAllBytes(file);
                complexFile.fileBinary = bytes;

                complexFiles.Add(complexFile);
            }
        }
    }
}