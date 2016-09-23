using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Vlc
{
    public enum vlc_Sta
    {
        libvlc_NothingSpecial=0,
        libvlc_Opening,
        libvlc_Buffering,
        libvlc_Playing,
        libvlc_Paused,
        libvlc_Stopped,
        libvlc_Ended,
        libvlc_Error
    };
}
