using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Vlc
{
    public class PlayInfo
    {
        public string filePath;
        public double curTime;
        public vlc_Sta playStatus = vlc_Sta.libvlc_Stopped;
        public double dPlayingSpeed = 1;
        public int dValume = 80;
    }
}
