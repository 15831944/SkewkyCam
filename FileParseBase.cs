using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Cam
{
    public abstract class FileParseBase
    {
        protected string rootDir;
        public void setRootDir(string RootDir)
        {
            rootDir = RootDir;
        }

        public abstract string getDayPath(DateTime dt);
        public abstract string getHourPath(DateTime dt);
        public abstract string getMinutePath(DateTime dt);

        public abstract bool isDayBlod(DateTime dt);
        public abstract bool isHourBlod(DateTime dt);
        public abstract bool isMinuteBlod(DateTime dt);

        public abstract DateTime findNextDt(DateTime dt);


    }
}
