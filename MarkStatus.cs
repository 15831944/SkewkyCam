using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Cam
{
    class MarkStatus
    {
        bool bFavourite;
        public bool Favourite
        {
            get { return bFavourite; }
            set { bFavourite = value; }
        }
        bool bToDelete;
        public bool ToDelete
        {
            get { return bToDelete; }
            set { bToDelete = value; }
        }
        bool bPrivate;
        public bool Private
        {
            get { return bPrivate; }
            set { bPrivate = value; }
        }
        MarkStatus()
        {
            bFavourite = false;
            bToDelete = false;
            bPrivate = false;
        }
    }
}
