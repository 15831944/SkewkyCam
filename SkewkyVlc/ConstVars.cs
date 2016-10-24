using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Vlc
{
    public static class ConstVars
    {
        internal static double[] DPlaySpeeds = new double[7]{ 0.1,0.5, 1, 2, 4, 8, 16 };
        public static int DbClickIntervel = 200;

        public static double GetDoubleSpeed(int iPlaySpeed)
        {
            iPlaySpeed = Math.Max(iPlaySpeed, 0);
            iPlaySpeed = Math.Min(iPlaySpeed, 6);
            return DPlaySpeeds[iPlaySpeed];
        }
        

    }
}
