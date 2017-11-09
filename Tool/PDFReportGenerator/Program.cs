using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckUtils;
using static CheckUtils.FileCompress;
using System.IO;

namespace PDFReportGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] FileProperties = new string[2];
            string htmlReportTemplatePath = "D:\\github\\Tools\\Tool\\PDFReportGenerator\\TemplateFiles";//待压缩文件目录
            string zipPath = "D:\\TestFiles\\zip\\a.zip";  //压缩后的目标文件

            string temp = Directory.GetCurrentDirectory();

            string modelValue = "";

            // 读取文件夹、文件，同时替换

            List<ComplexFile> fileList = GetHtmlReportFiles(htmlReportTemplatePath, modelValue);

            byte[] fileBytes = new FileCompress().Compress(fileList);
            File.WriteAllBytes(zipPath, fileBytes);
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
