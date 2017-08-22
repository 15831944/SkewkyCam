using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Vlc
{
    public enum VlcSta
    {
        LibvlcNothingSpecial=0,
        LibvlcOpening,
        LibvlcBuffering,
        LibvlcPlaying,
        LibvlcPaused,
        LibvlcStopped,
        LibvlcEnded,
        LibvlcError
    };
}
