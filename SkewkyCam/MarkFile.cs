using System;
using System.Collections.Generic;

namespace Com.Skewky.Cam
{
    [Serializable]
    public class MarkFile
    {
        public DateTime DtMonth; //to identify the MarkData file name (every month have on mark file)
        public string FilePath; //maybe in different roots
        private readonly Dictionary<DateTime, MarkData> _mkDatas = new Dictionary<DateTime, MarkData>();

        public MarkFile()
        {
            DtMonth = DateTime.Now;
        }

        public MarkFile(DateTime dt)
        {
            DtMonth = new DateTime(dt.Year, dt.Month, 1);
        }

        public void InitLoadFaildValues() //version update caused some parameters are Deserialize error.
        {
        }

        public string GetMarkFileName()
        {
            var fileName = string.Format("{0:D4}-{1:D2}.mrk", DtMonth.Year, DtMonth.Month);
            return fileName;
        }

        public bool GetMarkData(DateTime dt, ref MarkData md)
        {
            if (_mkDatas.ContainsKey(dt))
            {
                md = _mkDatas[dt];
                return true;
            }
            return false;
        }

        public bool SetMarkData(DateTime dt, MarkData md)
        {
            if (!_mkDatas.ContainsKey(dt))
            {
                _mkDatas.Add(dt, md);
                return true;
            }
            _mkDatas[dt] = md;
            return true;
        }

        public void ClearUseslessMarkData()
        {
            foreach (var pr in _mkDatas)
            {
                var mk = pr.Value;
                if (!mk.Favourite &&
                    !mk.ToDelete &&
                    !mk.Private &&
                    !mk.Describ)
                {
                    _mkDatas.Remove(pr.Key);
                }
            }
        }
    }
}