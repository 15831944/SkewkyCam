using System;
using System.Collections.Generic;

namespace Com.Skewky.Cam
{
    public abstract class FileParseBase
    {
        protected CheckedBuffer CheckedDays = new CheckedBuffer();
        protected CheckedBuffer CheckedHours = new CheckedBuffer();
        protected CheckedBuffer CheckedMinute = new CheckedBuffer();
        protected MarkFileMgr MkFileMgr = new MarkFileMgr();
        protected List<string> RootDirs = new List<string>();


        protected abstract bool InitMarkFiles();

        protected abstract string GetDayPath(DateTime dt);
        protected abstract string GetHourPath(DateTime dt);
        protected abstract string GetMinutePath(DateTime dt);

        protected abstract bool IsDayBlod(DateTime dt);
        protected abstract bool IsHourBlod(DateTime dt);
        protected abstract bool IsMinuteBlod(DateTime dt);

        internal abstract string GetRootDirByPath(string path);
        internal abstract DateTime GetDtMinByPath(string path);

        #region public methonds

        public void SetRootDir(List<string> RootDirs)
        {
            this.RootDirs.Clear();
            this.RootDirs.AddRange(RootDirs);
            CheckedDays.Clear();
            CheckedHours.Clear();
            CheckedMinute.Clear();
            InitMarkFiles();
        }

        public string DayPath(DateTime dt)
        {
            if (CheckedDays.IsDateChecked(dt))
            {
                return CheckedDays.GetCheckedPath(dt);
            }
            var dayPath = GetDayPath(dt);
            var bExist = IsDayBlod(dt);
            CheckedDays.AddCheckedDt(dt, bExist, dayPath);
            return dayPath;
        }

        public string HourPath(DateTime dt)
        {
            if (CheckedHours.IsDateChecked(dt))
            {
                return CheckedHours.GetCheckedPath(dt);
            }
            var hourPath = GetHourPath(dt);
            var bExist = IsHourBlod(dt);
            CheckedHours.AddCheckedDt(dt, bExist, hourPath);
            return hourPath;
        }

        public string MinutePath(DateTime dt)
        {
            if (CheckedMinute.IsDateChecked(dt))
            {
                return CheckedMinute.GetCheckedPath(dt);
            }
            var minutePath = GetMinutePath(dt);
            var bExist = IsMinuteBlod(dt);
            CheckedMinute.AddCheckedDt(dt, bExist, minutePath);
            return minutePath;
        }

        public bool DayBlod(DateTime dt)
        {
            if (CheckedDays.IsDateChecked(dt))
            {
                return CheckedDays.GetCheckedStatus(dt);
            }
            var dayPath = GetDayPath(dt);
            var bExist = IsDayBlod(dt);
            CheckedDays.AddCheckedDt(dt, bExist, dayPath);
            return bExist;
        }

        public bool HourBlod(DateTime dt)
        {
            if (CheckedHours.IsDateChecked(dt))
            {
                return CheckedHours.GetCheckedStatus(dt);
            }
            var hourPath = GetHourPath(dt);
            var bExist = IsHourBlod(dt);
            CheckedHours.AddCheckedDt(dt, bExist, hourPath);
            return bExist;
        }

        public bool MinuteBlod(DateTime dt)
        {
            if (CheckedMinute.IsDateChecked(dt))
            {
                return CheckedMinute.GetCheckedStatus(dt);
            }
            var minutePath = GetMinutePath(dt);
            var bExist = IsMinuteBlod(dt);
            CheckedMinute.AddCheckedDt(dt, bExist, minutePath);
            return bExist;
        }

        public abstract bool FindNextDt(DateTime dt, ref DateTime nextDt);

        public abstract bool SaveMarkFiles();

        public bool GetMarkData(DateTime dt, ref MarkData mk)
        {
            return MkFileMgr.GetMarkData(dt, ref mk);
        }

        public bool SetMarkData(DateTime dt, MarkData mk)
        {
            if (MkFileMgr.SetMarkData(dt, mk))
                return true;
            var rootDir = GetRootDirByPath(GetMinutePath(dt));
            return MkFileMgr.AddMarkData(dt, mk, rootDir);
        }

        #endregion
    }
}