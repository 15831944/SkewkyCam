using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Cam
{
    public class CheckedBuffer
    {
        List<DateTime> CheckedDts;
        Dictionary<DateTime, bool> dtExists;
        Dictionary<DateTime, string> dtPaths;
        public CheckedBuffer()
        {
            CheckedDts = new List<DateTime>();
            dtExists = new Dictionary<DateTime, bool>();
            dtPaths = new Dictionary<DateTime, string>();
        }
        /// <summary>
        /// Clear all the existing checkedDts
        /// </summary>
        public void clear()
        {
            CheckedDts.Clear();
            dtExists.Clear();
            dtPaths.Clear();
        }
        /// <summary>
        /// make sure if this dt is in buffer or not
        /// </summary>
        /// <param name="dt">dt need be checked</param>
        /// <returns>in buffer or ont</returns>
        public bool isDateChecked(DateTime dt)
        {
            if (CheckedDts.Contains(dt))
                return true;
            return false;
        }
        /// <summary>
        //should call is DateChecked before this function
        //Only return true or false
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>the status of this dt, exist or not</returns>
        public bool getCheckedStatus(DateTime dt)
        {
            bool bExist = dtExists[dt];
            return bExist;
        }
        public string getCheckedPath(DateTime dt)
        {
            string path = dtPaths[dt];
            return path;
        }
        /// <summary>
        /// This function only runs after checked this dt is not in Checked buffer
        /// </summary>
        /// <param name="dt">new dt need be added</param>
        /// <param name="bExist">the statu of this new date</param>
        public void addCheckedDt(DateTime dt, bool bExist,string dtPath)
        {
            CheckedDts.Add(dt);
            dtExists.Add(dt, bExist);
            dtPaths.Add(dt, dtPath);
        }
    }
}
