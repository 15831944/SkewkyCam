using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Cam
{
    [Serializable]
    class ConfigSettings
    {
        public List<string> rootDirArr;
        public bool bAutoPalyNext;
        public int iPlaySpeed;
        public int iRecType;
        public int iValume;
        public ConfigSettings()
        {
            rootDirArr = new List<string>();
            rootDirArr.Add(@"E:\Meida\XM");
            bAutoPalyNext = true;
            iPlaySpeed = 10;
            iRecType = 0;
            iValume = 80;
        }
    }
}
