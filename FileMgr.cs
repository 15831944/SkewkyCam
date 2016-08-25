using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Com.Skewky.Cam
{
    public class FileMgr
    {
        ConfigSettings cfsetttings;
        public FileParseBase fileTool;
        public List<string> fileArr = new List<string>();
        public bool bInprocess = false;
        public FileMgr(ConfigSettings cf)
        {
            cfsetttings = cf;
            if (cf.iRecType == 0)
                fileTool = new FileParseXiaoMi();
            else
                fileTool = new FileParseXiaoMi();
            fileTool.setRootDir(cf.rootDirArr);
         }
        public void initAllFiles()
        {
            bInprocess = true;
            getAllSubFiles(cfsetttings.rootDirArr, ref fileArr);
            bInprocess = false;
           
        }
        public void getAllSubFiles(List<string> folders, ref List<string> paths)
        {
             foreach (string folder in folders)
            {
                List<string> subFolders = new List<string>();
                subFolders.AddRange(Directory.GetDirectories(folder));
                paths.AddRange(Directory.GetFiles(folder, "*.mp4"));
                getAllSubFiles(subFolders, ref paths);                
            }

        }

    }
}
