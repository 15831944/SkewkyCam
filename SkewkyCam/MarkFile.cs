using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Cam
{
    [Serializable]
    public class MarkFile
    {
        public DateTime dtMonth;       //to identify the MarkData file name (every month have on mark file)
        public string filePath;    //maybe in different roots
        Dictionary<DateTime, MarkData> mkDatas = new Dictionary<DateTime, MarkData>();
        public MarkFile()
        {
            dtMonth = DateTime.Now;
        }
        public MarkFile(DateTime dt)
        {
            dtMonth = new DateTime(dt.Year, dt.Month, 1);
        }
        public void initLoadFaildValues()       //version update caused some parameters are Deserialize error.
        {
        
        }

        public string getMarkFileName()
        {
            string fileName = string.Format("{0:D4}-{1:D2}.mrk", dtMonth.Year, dtMonth.Month);
            return fileName;
        }
        public bool getMarkData(DateTime dt,ref MarkData md)
        {
            if(mkDatas.ContainsKey(dt))
            {
                md = mkDatas[dt];
                return true;
            }
            return false;
        }
        public bool setMarkData(DateTime dt, MarkData md)
        {
            if(!mkDatas.ContainsKey(dt))
            {
                mkDatas.Add(dt, md);
                return true;
            }
            else 
            {
                mkDatas[dt] = md;
                return true;
            }
        }
        
        public void clearUseslessMarkData()
        {
            foreach(var pr in mkDatas)
            {
                MarkData mk = pr.Value;
                if(!mk.Favourite&&
                    !mk.ToDelete&&
                    !mk.Private&&
                    !mk.Describ)
                {
                    mkDatas.Remove(pr.Key);
                }
            }
        }

    }
}
