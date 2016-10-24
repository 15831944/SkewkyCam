using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Vlc
{
    public class PlayInfo
    {
        public string FilePath;
        public double CurTime;
        public VlcSta PlayStatus = VlcSta.LibvlcStopped;
        public double DPlayingSpeed = 1;
        public int DValume = 80;
    }
}
