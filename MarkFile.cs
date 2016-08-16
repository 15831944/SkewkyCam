using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Cam
{
    class MarkFile
    {
        DateTime dtMonth;       //to identify the MarkData file name
        Dictionary<DateTime, MarkData> mkDatas;

        MarkFile(DateTime dt)
        {
            dtMonth = new DateTime(dt.Year, dt.Month, 0, 0, 0, 0);
        }
        public string getMarkFileName()
        {
            string fileName = string.Format("{0:D4}-{1:D2}", dtMonth.Year, dtMonth.Month);
            return fileName;
        }
    }
}
