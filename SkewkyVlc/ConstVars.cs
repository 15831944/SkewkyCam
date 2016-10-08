using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Vlc
{
    public static class ConstVars
    {
        public static double[] dPlaySpeeds = new double[7]{ 0.1,0.5, 1, 2, 4, 8, 16 };
        public static int iDbClickIntervel = 200;

        public static double getDoubleSpeed(int iPlaySpeed)
        {
            iPlaySpeed = Math.Max(iPlaySpeed, 0);
            iPlaySpeed = Math.Min(iPlaySpeed, 6);
            return dPlaySpeeds[iPlaySpeed];
        }
        

    }
}
