using System;
using System.Collections.Generic;

namespace Com.Skewky.Cam
{
    [Serializable]
    public class ConfigSettings
    {
        public bool BAutoPalyNext;
        public double[] DPlaySpeeds;
        public ThemeColors MyColors = new ThemeColors();
        public int PlaySpeed;
        public int RecType;
        public List<string> RootDirArr;
        public int Valume;

        public ConfigSettings()
        {
            RootDirArr = new List<string>();
            //RootDirArr.Add(@"E:\Meida\XM");
            BAutoPalyNext = true;
            DPlaySpeeds = new double[7] {0.1, 0.5, 1, 2, 4, 8, 16};
            PlaySpeed = 2;
            RecType = 0;
            Valume = 80;
        }

        public double GetDoubleSpeed()
        {
            PlaySpeed = Math.Max(PlaySpeed, 0);
            PlaySpeed = Math.Min(PlaySpeed, 6);
            return DPlaySpeeds[PlaySpeed];
        }

        public bool InitLoadFaildValues()
        {
            try
            {
                if (RootDirArr == null)
                    RootDirArr = new List<string>();
                //if (RootDirArr.Count == 0)
                //    RootDirArr.Add(@"E:\Meida\XM");
                if (DPlaySpeeds == null)
                    DPlaySpeeds = new double[7] {0.1, 0.5, 1, 2, 4, 8, 16};
                PlaySpeed = Math.Max(PlaySpeed, 0);
                PlaySpeed = Math.Min(PlaySpeed, 6);

                if (MyColors == null)
                    MyColors = new ThemeColors();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}