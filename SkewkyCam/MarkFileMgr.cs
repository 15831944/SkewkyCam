using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Com.Skewky.Cam
{
    public class MarkFileMgr
    {
        private const string SkewkyMark = "SkewkyMark\\";
        protected List<MarkFile> MarkFiles = new List<MarkFile>();

        public bool BFindMarkFile(DateTime dt, ref MarkFile mkfile)
        {
            var dtMonth = new DateTime(dt.Year, dt.Month, 1);
            foreach (var mkf in MarkFiles)
            {
                if (mkf.DtMonth == dtMonth)
                {
                    mkfile = mkf;
                    return true;
                }
            }
            return false;
        }

        public bool GetMarkData(DateTime dt, ref MarkData mkDa)
        {
            var dtMonth = new DateTime(dt.Year, dt.Month, 1);

            var mkf = new MarkFile(dtMonth);
            if (BFindMarkFile(dt, ref mkf))
            {
                if (mkf.GetMarkData(dt, ref mkDa))
                    return true;
            }


            return false;
        }

        public bool SetMarkData(DateTime dt, MarkData mkDa)
        {
            try
            {
                var dtMonth = new DateTime(dt.Year, dt.Month, 1);
                var mkf = new MarkFile(dtMonth);
                if (BFindMarkFile(dtMonth, ref mkf)) //need add to mkf list
                {
                    mkf.SetMarkData(dt, mkDa);
                    return true;
                }
            }
            catch (Exception)
            {
                // ignored
            }
            return false;
        }

        public bool AddMarkData(DateTime dt, MarkData mkDa, string mkFileRootDir)
        {
            try
            {
                var dtMonth = new DateTime(dt.Year, dt.Month, 1);
                var mkf = new MarkFile(dtMonth);
                if (!BFindMarkFile(dtMonth, ref mkf)) //need add to mkf list
                {
                    var mkFilePath = Path.Combine(mkFileRootDir, SkewkyMark + mkf.GetMarkFileName());
                    mkf.FilePath = mkFilePath;
                    mkf.SetMarkData(dt, mkDa);
                    MarkFiles.Add(mkf);
                    return true;
                }
            }
            catch (Exception)
            {
                // ignored
            }
            return false;
        }

        #region init&load&save

        public bool InitMarkFiles(List<string> rootDirs)
        {
            try
            {
                MarkFiles.Clear();
                foreach (var rootDir in rootDirs)
                {
                    var markFileFolder = Path.Combine(rootDir, SkewkyMark);
                    LoadMarkFileDir(markFileFolder);
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        private void LoadMarkFileDir(string mkFileRoot)
        {
            try
            {
                var mkFiles = Directory.GetFiles(mkFileRoot, "*.mrk");
                foreach (var mkFilePath in mkFiles)
                {
                    LoadMarkFile(mkFilePath);
                }
            }
            catch (Exception )
            {

            }


        }

        private bool LoadMarkFile(string mkFilePath)
        {
            try
            {
                if (File.Exists(mkFilePath))
                {
                    Stream s = File.Open(mkFilePath, FileMode.Open, FileAccess.Read);
                    var c = new BinaryFormatter();
                    var mkfile = (MarkFile) c.Deserialize(s);
                    mkfile.FilePath = mkFilePath;
                    mkfile.InitLoadFaildValues();
                    s.Close();
                    MarkFiles.Add(mkfile);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                File.Delete(mkFilePath);
                return false;
            }
        }

        public bool SaveMarkFiles()
        {
            try
            {
                foreach (var mk in MarkFiles)
                {
                    try
                    {
                        var filePath = mk.FilePath;
                        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                        {
                            var directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));
                            directoryInfo.Create();
                        }
                        Stream s = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
                        var b = new BinaryFormatter();
                        b.Serialize(s, mk);
                        s.Close();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                return true;
            }
            catch (Exception)
            {
                // ignored
            }
            return false;
        }

        #endregion
    }
}