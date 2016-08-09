using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Cam
{
    class FileParseXiaoMi : FileParseBase
    {
        public override string getDayPath(DateTime dt)
        {
            // E:\Meida\XM\2016年01月11日
           string dayPath = string.Format("{0}\\{1}年{2:D2}月{3:D2}日", rootDir,dt.Year,dt.Month,dt.Day);
           return dayPath;
        }
        public override string getHourPath(DateTime dt)
        {
            string hourPath = string.Format("{0}\\{1:D2}时", getDayPath(dt), dt.Hour);
            return hourPath;
        
        }
        public override string getMinutePath(DateTime dt)
        {
            string minutePath = string.Format("{0}\\{1:D2}分00秒.mp4", getHourPath(dt), dt.Minute);
            return minutePath;
        }
        public override bool isDayBlod(DateTime dt)
        {
            string dayPath = getDayPath(dt);
            if (!System.IO.Directory.Exists(dayPath)) return false;

            return true;
        }
        public override bool isHourBlod(DateTime dt)
        {
            string hourPath = getHourPath(dt);
            if (!System.IO.Directory.Exists(hourPath)) return false;

            return true;
        }
        public override bool isMinuteBlod(DateTime dt)
        {
            string minutePath = getMinutePath(dt);
            if (!System.IO.File.Exists(minutePath)) return false;
            return true;
        }

        public override DateTime findNextDt(DateTime dt)
        {
            return dt;
        }


    }
}
