using System;

namespace Com.Skewky.Cam
{
    internal class CheckedDt
    {
        // ReSharper disable once InconsistentNaming

        public CheckedDt()
        {
            Dt = new DateTime();
            Exist = false;
        }

        public DateTime Dt { get; set; }

        public bool Exist { get; set; }

        //这个方法会被调用
        public bool Equals(CheckedDt that)
        {
            if (Dt == that.Dt &&
                Exist == that.Exist)
            {
                return true;
            }
            return false;
        }
    }
}