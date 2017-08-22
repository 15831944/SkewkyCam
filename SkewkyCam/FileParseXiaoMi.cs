using System;
using System.IO;

namespace Com.Skewky.Cam
{
    internal class FileParseXiaoMi : FileParseBase
    {
        protected override bool InitMarkFiles()
        {
            return MkFileMgr.InitMarkFiles(RootDirs);
        }

        public override bool SaveMarkFiles()
        {
            return MkFileMgr.SaveMarkFiles();
        }

        protected override string GetDayPath(DateTime dt)
        {
            foreach (var rootDir in RootDirs)
            {
                // E:\Meida\XM\2016年01月11日
                var dayPath = string.Format("{0}\\{1}年{2:D2}月{3:D2}日", rootDir, dt.Year, dt.Month, dt.Day);
                if (Directory.Exists(dayPath)) return dayPath;
            }
            return "NotFind";
        }

        protected override string GetHourPath(DateTime dt)
        {
            var hourPath = string.Format("{0}\\{1:D2}时", GetDayPath(dt), dt.Hour);
            return hourPath;
        }

        protected override string GetMinutePath(DateTime dt)
        {
            var minutePath = string.Format("{0}\\{1:D2}分00秒.mp4", GetHourPath(dt), dt.Minute);
            return minutePath;
        }


        internal override string GetRootDirByPath(string path)
        {
            //path = "Z:\\小蚁智能摄像机_B0D59D482E5A\\2016年08月10日\\00时\\01分00秒.mp4"

            var iPos = path.Length - 27;
            iPos = Math.Max(iPos, 0);
            var rootDir = path.Substring(0, iPos);
            return rootDir;
        }

        internal override DateTime GetDtMinByPath(string path)
        {
            var dt = DateTime.Now;
            if (string.IsNullOrEmpty(path)||path.Length < 27)
                return dt;

            //path = "Z:\\小蚁智能摄像机_B0D59D482E5A\\2016年08月10日\\00时\\01分00秒.mp4"
            var iPos = path.Length - 26;
            var iSubLen = 22;
            iPos = Math.Max(iPos, 0);
            iSubLen = Math.Min(path.Length - iPos, iSubLen);

            var dtString = path.Substring(iPos, iSubLen);
            //"2005-11-6 16:11:04"
            dtString = dtString.Replace("\\", "");
            dtString = dtString.Replace("年", "-");
            dtString = dtString.Replace("月", "-");
            dtString = dtString.Replace("日", " ");
            dtString = dtString.Replace("时", ":");
            dtString = dtString.Replace("分", ":");
            dtString = dtString.Replace("秒", " ");
            DateTime.TryParse(dtString, out dt);
            return dt;
        }

        protected override bool IsDayBlod(DateTime dt)
        {
            var dayPath = GetDayPath(dt);
            if (!Directory.Exists(dayPath)) return false;

            return true;
        }

        protected override bool IsHourBlod(DateTime dt)
        {
            var hourPath = GetHourPath(dt);
            if (!Directory.Exists(hourPath)) return false;

            return true;
        }

        protected override bool IsMinuteBlod(DateTime dt)
        {
            var minutePath = GetMinutePath(dt);
            if (!File.Exists(minutePath)) return false;
            return true;
        }

        public override bool FindNextDt(DateTime dt, ref DateTime nextDt)
        {
            var baseDt = dt;
            baseDt = baseDt.AddMinutes(1);
            if (SearchInThisHour(baseDt, ref nextDt))
                return true;
            baseDt = baseDt.AddHours(1);
            if (SearchInNextHour(baseDt, ref nextDt))
                return true;
            baseDt = baseDt.AddDays(1);
            if (SearchInNextDay(baseDt, ref nextDt))
                return true;
            baseDt = baseDt.AddMonths(1);
            if (SearchInNextMonth(baseDt, ref nextDt))
                return true;
            baseDt = baseDt.AddYears(1);
            if (SearchInNextYear(baseDt, ref nextDt))
                return true;
            return false;
        }

        protected bool SearchInThisHour(DateTime dt, ref DateTime nextDt)
        {
            nextDt = dt;
            for (var i = dt.Minute; i < 60; i++)
            {
                if (MinuteBlod(nextDt))
                    return true;
                nextDt = nextDt.AddMinutes(1);
            }
            return false;
        }

        protected bool SearchInNextHour(DateTime dt, ref DateTime nextDt)
        {
            nextDt = dt;
            var baseDt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0);
            for (var i = dt.Hour; i < 24; i++)
            {
                if (!IsHourBlod(baseDt))
                {
                    baseDt = baseDt.AddHours(1);
                    continue;
                }
                if (SearchInThisHour(baseDt, ref nextDt))
                    return true;
                baseDt = baseDt.AddHours(1);
            }
            return false;
        }

        protected bool SearchInNextDay(DateTime dt, ref DateTime nextDt)
        {
            nextDt = dt;
            var baseDt = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);

            for (var i = dt.Day; i < 31; i++)
            {
                if (baseDt.Month != dt.Month)
                    break;
                if (!IsDayBlod(baseDt))
                {
                    baseDt = baseDt.AddDays(1);
                    continue;
                }
                if (SearchInNextHour(baseDt, ref nextDt))
                    return true;
                baseDt = baseDt.AddDays(1);
            }
            return false;
        }

        protected bool SearchInNextMonth(DateTime dt, ref DateTime nextDt)
        {
            nextDt = dt;
            var baseDt = new DateTime(dt.Year, dt.Month, 1, 0, 0, 0);

            for (var i = dt.Month; i < 13; i++)
            {
                if (SearchInNextDay(baseDt, ref nextDt))
                    return true;
                baseDt = baseDt.AddMonths(1);
            }
            return false;
        }

        protected bool SearchInNextYear(DateTime dt, ref DateTime nextDt)
        {
            nextDt = dt;
            var baseDt = new DateTime(dt.Year, 1, 1, 0, 0, 0);
            if (SearchInNextMonth(baseDt, ref nextDt))
                return true;
            return false;
        }
    }
}