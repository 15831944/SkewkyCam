using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Cam
{
    class FileParseXiaoMi : FileParseBase
    {
        protected override string getDayPath(DateTime dt)
        {
            // E:\Meida\XM\2016年01月11日
            string dayPath = string.Format("{0}\\{1}年{2:D2}月{3:D2}日", rootDir, dt.Year, dt.Month, dt.Day);
            return dayPath;
        }
        protected override string getHourPath(DateTime dt)
        {
            string hourPath = string.Format("{0}\\{1:D2}时", getDayPath(dt), dt.Hour);
            return hourPath;

        }
        protected override string getMinutePath(DateTime dt)
        {
            string minutePath = string.Format("{0}\\{1:D2}分00秒.mp4", getHourPath(dt), dt.Minute);
            return minutePath;
        }


        internal override string getRootDirByPath(string path)
        {
            //path = "Z:\\小蚁智能摄像机_B0D59D482E5A\\2016年08月10日\\00时\\01分00秒.mp4"
            int iPos = path.Length - 27;
            string rootDir = path.Substring(0, iPos);
            return  rootDir;
        }
       
        internal override DateTime getDtMinByPath(string path)
        {
            //path = "Z:\\小蚁智能摄像机_B0D59D482E5A\\2016年08月10日\\00时\\01分00秒.mp4"
            int iPos = path.Length - 26;
            int iSubLen = 22;
            string dtString = path.Substring(iPos, iSubLen);
            //"2005-11-6 16:11:04"
            dtString = dtString.Replace("\\", "");
            dtString = dtString.Replace("年", "-");
            dtString = dtString.Replace("月", "-");
            dtString = dtString.Replace("日", " ");
            dtString = dtString.Replace("时", ":");
            dtString = dtString.Replace("分", ":");
            dtString = dtString.Replace("秒", " ");
            DateTime dt = DateTime.Parse(dtString);
            return  dt;
        }
        protected override bool isDayBlod(DateTime dt)
        {
            string dayPath = getDayPath(dt);
            if (!System.IO.Directory.Exists(dayPath)) return false;

            return true;
        }
        protected override bool isHourBlod(DateTime dt)
        {
            string hourPath = getHourPath(dt);
            if (!System.IO.Directory.Exists(hourPath)) return false;

            return true;
        }
        protected override bool isMinuteBlod(DateTime dt)
        {
            string minutePath = getMinutePath(dt);
            if (!System.IO.File.Exists(minutePath)) return false;
            return true;
        }

        public override bool findNextDt(DateTime dt, ref DateTime nextDt)
        {
            DateTime baseDt = dt;
            baseDt = baseDt.AddMinutes(1);
            if (searchInThisHour(baseDt, ref nextDt))
                return true;
            baseDt = baseDt.AddHours(1);
            if (searchInNextHour(baseDt, ref nextDt))
                return true;
            baseDt = baseDt.AddDays(1);
            if (searchInNextDay(baseDt, ref nextDt))
                return true;
            baseDt = baseDt.AddMonths(1);
            if (searchInNextMonth(baseDt, ref nextDt))
                return true;
            baseDt = baseDt.AddYears(1);
            if (searchInNextYear(baseDt, ref nextDt))
                return true;
            return false;
        }
        protected bool searchInThisHour(DateTime dt, ref DateTime nextDt)
        {
            nextDt = dt;
            for (int i = dt.Minute; i < 60; i++)
            {
                if (MinuteBlod(nextDt))
                    return true;
                nextDt = nextDt.AddMinutes(1);
            }
            return false;
        }
        protected bool searchInNextHour(DateTime dt, ref DateTime nextDt)
        {
            nextDt = dt;
            DateTime baseDt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0);
            for (int i = dt.Hour; i < 24; i++)
            {
                if (!isHourBlod(baseDt))
                {
                    baseDt = baseDt.AddHours(1);
                    continue;
                }
                if (searchInThisHour(baseDt, ref nextDt))
                    return true;
                baseDt = baseDt.AddHours(1);
            }
            return false;
        }
        protected bool searchInNextDay(DateTime dt, ref DateTime nextDt)
        {
            nextDt = dt;
            DateTime baseDt = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);

            for (int i = dt.Day; i < 31; i++)
            {
                if (baseDt.Month != dt.Month)
                    break;
                if (!isDayBlod(baseDt))
                {
                    baseDt = baseDt.AddDays(1);
                    continue;
                }
                if (searchInNextHour(baseDt, ref nextDt))
                    return true;
                baseDt = baseDt.AddDays(1);
            }
            return false;
        }
        protected bool searchInNextMonth(DateTime dt, ref DateTime nextDt)
        {
            nextDt = dt;
            DateTime baseDt = new DateTime(dt.Year, dt.Month, 1, 0, 0, 0);

            for (int i = dt.Month; i < 13; i++)
            {
                if (searchInNextDay(baseDt, ref nextDt))
                    return true;
                baseDt = baseDt.AddMonths(1);
            }
            return false;
        }
        protected bool searchInNextYear(DateTime dt, ref DateTime nextDt)
        {
            nextDt = dt;
            DateTime baseDt = new DateTime(dt.Year, 1, 1, 0, 0, 0);
            if (searchInNextMonth(baseDt, ref nextDt))
                return true;
            return false;
        }
    }
}
