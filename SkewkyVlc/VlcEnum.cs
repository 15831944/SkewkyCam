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
    public enum NextFileSta
    {
        NfNotFind = 0,  //tried to find next file, but not found the any files
        NfNeedFind,     //Need to find a next file to play
        NfFound         //Already find next file
    };
}
