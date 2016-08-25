using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Cam
{
    public class FileMgr
    {
        ConfigSettings cfsetttings;
        FileParseBase fileTool;
        public FileMgr(ConfigSettings cf)
        {
            cfsetttings = cf;
            if (cf.iRecType == 0)
                fileTool = new FileParseXiaoMi();
            else
                fileTool = new FileParseXiaoMi();
            fileTool.setRootDir(cf.rootDirArr);
        }


    }
}
