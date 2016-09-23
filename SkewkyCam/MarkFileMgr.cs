using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Com.Skewky.Cam
{
    public class MarkFileMgr
    {
        protected List<MarkFile> markFiles = new List<MarkFile>();
        const string skewkyMark = "SkewkyMark\\";
        #region init&load&save
        public bool initMarkFiles(List<string> rootDirs)
        {
            try
            {
                markFiles.Clear();
                foreach (string rootDir in rootDirs)
                {
                    string markFileFolder = Path.Combine(rootDir, skewkyMark);
                    loadMarkFileDir(markFileFolder);
                }
                return true;
            }
            catch (System.Exception ex)
            {
            }
            return false;
        }
        private void loadMarkFileDir(string mkFileRoot)
        {
            string[] mkFiles = Directory.GetFiles(mkFileRoot, "*.mrk");
            foreach (string mkFilePath in mkFiles)
            {
                loadMarkFile(mkFilePath);
            }
        }
        private bool loadMarkFile(string mkFilePath)
        {
            try
            {
                if (File.Exists(mkFilePath))
                {
                    MarkFile mkfile = new MarkFile();
                    Stream s = File.Open(mkFilePath, FileMode.Open, FileAccess.Read);
                    BinaryFormatter c = new BinaryFormatter();
                    mkfile = (MarkFile)c.Deserialize(s);
                    mkfile.filePath = mkFilePath;
                    mkfile.initLoadFaildValues();
                    s.Close();
                    markFiles.Add(mkfile);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                File.Delete(mkFilePath);
                return false;
            }
        }
        public bool saveMarkFiles()
        {
            try
            {
                foreach (MarkFile mk in markFiles)
                {
                    try
                    {
                        string filePath = mk.filePath;
                        if (!Directory.Exists( Path.GetDirectoryName(filePath)))
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo( Path.GetDirectoryName(filePath));
                            directoryInfo.Create();
                        }
                        Stream s = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
                        BinaryFormatter b = new BinaryFormatter();
                        b.Serialize(s, mk);
                        s.Close();
                    }
                    catch (Exception e)
                    {

                    }

                }
                return true;
            }
            catch (System.Exception ex)
            {
            }
            return false;
        }
        #endregion
        public bool bFindMarkFile(DateTime dt, ref MarkFile mkfile)
        {
            DateTime dtMonth = new DateTime(dt.Year, dt.Month, 1);
            foreach (MarkFile mkf in markFiles)
            {
                if (mkf.dtMonth == dtMonth)
                {
                    mkfile = mkf;
                    return true;
                }
            }
            return false;
        }
        public bool getMarkData(DateTime dt, ref MarkData mkDa)
        {
            DateTime dtMonth = new DateTime(dt.Year, dt.Month, 1);

            MarkFile mkf = new MarkFile(dtMonth);
            if (bFindMarkFile(dt, ref mkf))
            {
                if (mkf.getMarkData(dt, ref mkDa))
                    return true;
            }


            return false;
        }
        public bool setMarkData(DateTime dt, MarkData mkDa)
        {
            try
            {
                DateTime dtMonth = new DateTime(dt.Year, dt.Month, 1);
                MarkFile mkf = new MarkFile(dtMonth);
                if (bFindMarkFile(dtMonth, ref mkf))  //need add to mkf list
                {
                    mkf.setMarkData(dt, mkDa);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
            }
            return false;
        }
        public bool addMarkData(DateTime dt, MarkData mkDa, string mkFileRootDir)
        {
            try
            {
                DateTime dtMonth = new DateTime(dt.Year, dt.Month, 1);
                MarkFile mkf = new MarkFile(dtMonth);
                if (!bFindMarkFile(dtMonth, ref mkf))  //need add to mkf list
                {
                    string mkFilePath = Path.Combine(mkFileRootDir, skewkyMark+mkf.getMarkFileName());
                    mkf.filePath = mkFilePath;
                    mkf.setMarkData(dt, mkDa);
                    markFiles.Add(mkf);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
            }
            return false;
        }
    }
}
