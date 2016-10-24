using System;
using System.Collections.Generic;
using System.IO;

namespace Com.Skewky.Cam
{
    public class FileOpr
    {
        private readonly ConfigSettings _cfsetttings;
        public bool BInitFilesInprocess;
        public bool BOprFilesInprocess;
        public int CurIndex;
        public int FaildCount;
        public List<string> FileArr = new List<string>();
        public FileParseBase FileTool;
        public int TotalCount;

        public FileOpr(ConfigSettings cf)
        {
            _cfsetttings = cf;
            if (cf.RecType == 0)
                FileTool = new FileParseXiaoMi();
            else
                FileTool = new FileParseXiaoMi();
            FileTool.SetRootDir(cf.RootDirArr);
        }

        public void InitAllFiles()
        {
            BInitFilesInprocess = true;
            GetAllSubFiles(_cfsetttings.RootDirArr, ref FileArr);
            BInitFilesInprocess = false;
        }

        public void GetAllSubFiles(List<string> folders, ref List<string> paths)
        {
            foreach (var folder in folders)
            {
                if (!Directory.Exists(folder))
                    continue;

                var subFolders = new List<string>();
                subFolders.AddRange(Directory.GetDirectories(folder));
                paths.AddRange(Directory.GetFiles(folder, "*.mp4"));
                GetAllSubFiles(subFolders, ref paths);
            }
        }

        public void CopyFiles(List<string> files, string trgRootFolder)
        {
            CurIndex = 0;
            FaildCount = 0;
            TotalCount = files.Count;
            BOprFilesInprocess = true;
            foreach (var filePath in files)
            {
                var oldRoot = FileTool.GetRootDirByPath(filePath);
                var destPath = filePath.Replace(oldRoot, trgRootFolder);
                CheckOrCreateFolder(destPath);
                try
                {
                    File.Copy(filePath, destPath, false);
                    CurIndex++;
                }
                catch (Exception)
                {
                    FaildCount++;
                }
            }
            BOprFilesInprocess = false;
        }

        public void MoveFiles(List<string> files, string trgRootFolder)
        {
            CurIndex = 0;
            FaildCount = 0;
            TotalCount = files.Count;
            BOprFilesInprocess = true;
            foreach (var filePath in files)
            {
                var oldRoot = FileTool.GetRootDirByPath(filePath);
                var destPath = filePath.Replace(oldRoot, trgRootFolder);
                CheckOrCreateFolder(destPath);
                try
                {
                    File.Move(filePath, destPath);
                    FileArr.Remove(filePath);
                    if (_cfsetttings.RootDirArr.Contains(trgRootFolder))
                        FileArr.Add(destPath);
                    CurIndex++;
                }
                catch (Exception)
                {
                    FaildCount++;
                }
            }
            BOprFilesInprocess = false;
        }

        public void DelFiles(List<string> files)
        {
            CurIndex = 0;
            FaildCount = 0;
            TotalCount = files.Count;
            BOprFilesInprocess = true;
            foreach (var filePath in files)
            {
                var oldRoot = FileTool.GetRootDirByPath(filePath);
                try
                {
                    File.Delete(filePath);
                    FileArr.Remove(filePath);
                    CurIndex++;
                }
                catch (Exception)
                {
                    FaildCount++;
                }
            }
            BOprFilesInprocess = false;
        }

        private void CheckOrCreateFolder(string filePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                var directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));
                directoryInfo.Create();
            }
        }

        public bool NewFolderValid(string folder, bool canBeTheSame = true)
        {
            foreach (var fd in _cfsetttings.RootDirArr)
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