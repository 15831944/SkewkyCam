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
        public bool bInitFilesInprocess = false;
        public int iCurIndex = 0;
        public int iFaild = 0;
        public int iTotal = 0;
        public bool bOprFilesInprocess = false;
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
            bInitFilesInprocess = true;
            getAllSubFiles(cfsetttings.rootDirArr, ref fileArr);
            bInitFilesInprocess = false;

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
        public void copyFiles(List<string> files, string trgRootFolder)
        {
            iCurIndex = 0;
            iFaild = 0;
            iTotal = files.Count;
            bOprFilesInprocess = true;
            foreach (string filePath in files)
            {
                string oldRoot = fileTool.getRootDirByPath(filePath);
                string destPath = filePath.Replace(oldRoot, trgRootFolder);
                checkOrCreateFolder(destPath);
                try
                {
                    System.IO.File.Copy(filePath, destPath, false);
                    iCurIndex++;
                }
                catch (Exception e)
                {
                    iFaild++;

                }
            }
            bOprFilesInprocess = false;

        }
        public void moveFiles(List<string> files, string trgRootFolder)
        {
            iCurIndex = 0;
            iFaild = 0;
            iTotal = files.Count;
            bOprFilesInprocess = true;
            foreach (string filePath in files)
            {
                string oldRoot = fileTool.getRootDirByPath(filePath);
                string destPath = filePath.Replace(oldRoot, trgRootFolder);
                checkOrCreateFolder(destPath);
                try
                {
                    System.IO.File.Move(filePath, destPath);
                    fileArr.Remove(filePath);
                    if (cfsetttings.rootDirArr.Contains(trgRootFolder))
                        fileArr.Add(destPath);
                    iCurIndex++;
                }
                catch (Exception e)
                {
                    iFaild++;
                }
            }
            bOprFilesInprocess = false;

        }
        public void delFiles(List<string> files)
        {
            iCurIndex = 0;
            iFaild = 0;
            iTotal = files.Count;
            bOprFilesInprocess = true;
            foreach (string filePath in files)
            {
                string oldRoot = fileTool.getRootDirByPath(filePath);
                try
                {
                    System.IO.File.Delete(filePath);
                    fileArr.Remove(filePath);
                    iCurIndex++;
                }
                catch (Exception e)
                {
                    iFaild++;
                }
            }
            bOprFilesInprocess = false;

        }
        private void checkOrCreateFolder(string filePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));
                directoryInfo.Create();
            }
        }
        public bool newFolderValid(string folder, bool canBeTheSame = true)
        {
            foreach (string fd in cfsetttings.rootDirArr)
            {
                if (fd == folder && canBeTheSame)
                    return true;
                if (fd.Contains(folder) || folder.Contains(fd))
                    return false;
            }
            return true;
        }
    }
}
