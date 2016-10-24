using System;
using System.Collections.Generic;

namespace Com.Skewky.Cam
{
    public class CheckedBuffer
    {
        private readonly List<DateTime> _checkedDts;
        private readonly Dictionary<DateTime, bool> _dtExists;
        private readonly Dictionary<DateTime, string> _dtPaths;

        public CheckedBuffer()
        {
            _checkedDts = new List<DateTime>();
            _dtExists = new Dictionary<DateTime, bool>();
            _dtPaths = new Dictionary<DateTime, string>();
        }

        /// <summary>
        ///     Clear all the existing checkedDts
        /// </summary>
        public void Clear()
        {
            _checkedDts.Clear();
            _dtExists.Clear();
            _dtPaths.Clear();
        }

        /// <summary>
        ///     make sure if this dt is in buffer or not
        /// </summary>
        /// <param name="dt">dt need be checked</param>
        /// <returns>in buffer or ont</returns>
        public bool IsDateChecked(DateTime dt)
        {
            if (_checkedDts.Contains(dt))
                return true;
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>the status of this dt, exist or not</returns>
        public bool GetCheckedStatus(DateTime dt)
        {
            var bExist = _dtExists[dt];
            return bExist;
        }

        public string GetCheckedPath(DateTime dt)
        {
            var path = _dtPaths[dt];
            return path;
        }

        /// <summary>
        ///     This function only runs after checked this dt is not in Checked buffer
        /// </summary>
        /// <param name="dt">new dt need be added</param>
        /// <param name="bExist">the statu of this new date</param>
        /// <param name="dtPath">The FilePath of this dt</param>
        public void AddCheckedDt(DateTime dt, bool bExist, string dtPath)
        {
            if (!_checkedDts.Contains(dt))
                _checkedDts.Add(dt);
            if (!_dtExists.ContainsKey(dt))
                _dtExists.Add(dt, bExist);
            if (!_dtPaths.ContainsKey(dt))
                _dtPaths.Add(dt, dtPath);
        }
    }
}