using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Cam
{
    public abstract class FileParseBase
    {
        protected List<string> rootDirs = new List<string>();
        protected CheckedBuffer checkedDays = new CheckedBuffer();
        protected CheckedBuffer checkedHours = new CheckedBuffer();
        protected CheckedBuffer checkedMinute = new CheckedBuffer();
        protected MarkFileMgr mkFileMgr = new MarkFileMgr();

        #region public methonds
        public FileParseBase()
        {
        }
        public void setRootDir(List<string> RootDirs)
        {
            rootDirs.Clear();
            rootDirs.AddRange(RootDirs);
            checkedDays.clear();
            checkedHours.clear();
            checkedMinute.clear();
            initMarkFiles();
         }
        public string DayPath(DateTime dt)
        {
            if (checkedDays.isDateChecked(dt))
            {
                return checkedDays.getCheckedPath(dt);
            }
            else
            {
                string dayPath = getDayPath(dt);
                bool bExist = isDayBlod(dt);
                checkedDays.addCheckedDt(dt, bExist, dayPath);
                return dayPath;
            }
        }
        public string HourPath(DateTime dt)
        {
            if (checkedHours.isDateChecked(dt))
            {
                return checkedHours.getCheckedPath(dt);
            }
            else
            {
                string hourPath = getHourPath(dt);
                bool bExist = isHourBlod(dt);
                checkedHours.addCheckedDt(dt, bExist, hourPath);
                return hourPath;
            }
        }
        public string MinutePath(DateTime dt)
        {
            if (checkedMinute.isDateChecked(dt))
            {
                return checkedMinute.getCheckedPath(dt);
            }
            else
            {
                string minutePath = getMinutePath(dt);
                bool bExist = isMinuteBlod(dt);
                checkedMinute.addCheckedDt(dt, bExist, minutePath);
                return minutePath;
            }
        }

        public bool DayBlod(DateTime dt)
        {
            if (checkedDays.isDateChecked(dt))
            {
                return checkedDays.getCheckedStatus(dt);
            }
            else
            {
                string dayPath = getDayPath(dt);
                bool bExist = isDayBlod(dt);
                checkedDays.addCheckedDt(dt, bExist, dayPath);
                return bExist;
            }
        }
        public bool HourBlod(DateTime dt)
        {
            if (checkedHours.isDateChecked(dt))
            {
                return checkedHours.getCheckedStatus(dt);
            }
            else
            {
                string hourPath = getHourPath(dt);
                bool bExist = isHourBlod(dt);
                checkedHours.addCheckedDt(dt, bExist, hourPath);
                return bExist;
            }
        }
        public bool MinuteBlod(DateTime dt)
        {
            if (checkedMinute.isDateChecked(dt))
            {
                return checkedMinute.getCheckedStatus(dt);
            }
            else
            {
                string minutePath = getMinutePath(dt);
                bool bExist = isMinuteBlod(dt);
                checkedMinute.addCheckedDt(dt, bExist, minutePath);
                return bExist;
            }
        }
        public abstract bool findNextDt(DateTime dt, ref DateTime nextDt);

        public abstract bool saveMarkFiles();

        public bool GetMarkData(DateTime dt,ref MarkData mk)
        {
            return mkFileMgr.getMarkData(dt,ref mk);
        }
        public bool SetMarkData(DateTime dt,MarkData mk)
        {
            if (mkFileMgr.setMarkData(dt, mk))
                return true;
            else
            {
                string rootDir = getRootDirByPath(getMinutePath(dt));
                return mkFileMgr.addMarkData(dt, mk, rootDir);
            }
        }
        #endregion


        protected abstract bool initMarkFiles();
    
        protected abstract string getDayPath(DateTime dt);
        protected abstract string getHourPath(DateTime dt);
        protected abstract string getMinutePath(DateTime dt);

        protected abstract bool isDayBlod(DateTime dt);
        protected abstract bool isHourBlod(DateTime dt);
        protected abstract bool isMinuteBlod(DateTime dt);

        internal abstract string getRootDirByPath(string path);
        internal abstract DateTime getDtMinByPath(string path);
    }
}
