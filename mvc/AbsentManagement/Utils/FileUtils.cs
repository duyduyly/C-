using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace AbsentManagement.Utils
{
    public class FileUtils
    {
        private const string ROOT_PATH = "/images/";
        public String addFile(HttpPostedFileBase file, String fileName)
        {

            string pathfile = "";
            if (file!=null&&file.ContentLength>0)
            {
                //get root file from sever
                string rootPath = HostingEnvironment.MapPath(ROOT_PATH);
                this.checkAndCreateFolder(rootPath);
                pathfile=rootPath+fileName+"_"+file.FileName;
                file.SaveAs(pathfile);
            }

            return ROOT_PATH + fileName + "_" + file.FileName;
        }

        public void checkAndCreateFolder(String folderPath)
        {
            // Check if the folder exists
            if (!Directory.Exists(folderPath))
            {
                // Create the folder
                Directory.CreateDirectory(folderPath);
                Console.WriteLine($"Folder created at: {folderPath}");
            }
        }
    }

}