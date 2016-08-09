using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Cam
{
    class CheckedDt
    {
        DateTime dt;
        bool bExist;
        public CheckedDt()
        {
            dt = new DateTime();
            bExist = false;
        }
        public System.DateTime Dt
        {
            get { return dt; }
            set { dt = value; }
        }
        public bool Exist
        {
            get { return bExist; }
            set { bExist = value; }
        }
        //这个方法会被调用
        public bool Equals(CheckedDt that)
        {
            if (this.dt == that.dt&&
                this.bExist == that.bExist)
            {
                return true;
            }
            return false;
        }
    }
}
