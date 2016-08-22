using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Cam
{
    [Serializable]
    public class ConfigSettings
    {
        public List<string> rootDirArr;
        public bool bAutoPalyNext;
        public int iPlaySpeed;
        public int iRecType;
        public int iValume;
        public double[] dPlaySpeeds;
        public ConfigSettings()
        {

            rootDirArr = new List<string>();
            rootDirArr.Add(@"E:\Meida\XM");
            bAutoPalyNext = true;
            dPlaySpeeds = new double[7]{ 0.1,0.5, 1, 2, 4, 8, 16 };
            iPlaySpeed = 3;
            iRecType = 0;
            iValume = 80;
        }
        public double getDoubleSpeed()
        {
            return dPlaySpeeds[iPlaySpeed];
        }
        public bool initLoadFaildValues()
        {
            try
            {
                if (rootDirArr == null)
                    rootDirArr = new List<string>();
                if (rootDirArr.Count == 0)
                    rootDirArr.Add(@"E:\Meida\XM");
                if (dPlaySpeeds == null)
                    dPlaySpeeds = new double[7] { 0.1, 0.5, 1, 2, 4, 8, 16 };
                iPlaySpeed = Math.Max(iPlaySpeed, 0);
                iPlaySpeed = Math.Min(iPlaySpeed, 6);
               
               return true;
       }
            catch (System.Exception ex)
            {
            	return false;
            }
           }
    }
}
