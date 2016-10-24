using System;

namespace Com.Skewky.Cam
{
    [Serializable]
    public class MarkData
    {
        private bool _bFavourite;

        private bool _bPrivate;

        private bool _bToDelete;
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool Favourite
        {
            get { return _bFavourite; }
            set { _bFavourite = value; }
        }

        public bool ToDelete
        {
            get { return _bToDelete; }
            set { _bToDelete = value; }
        }

        public bool Private
        {
            get { return _bPrivate; }
            set { _bPrivate = value; }
        }

        public bool Describ
        {
            get { return !string.IsNullOrEmpty(_description); }
        }

        public string MarkDataStr
        {
            get
            {
                var res = "";
                res += _bFavourite ? "L" : " ";
                res += _bToDelete ? "D" : " ";
                res += _bPrivate ? "P" : " ";
                res += Describ ? "N" : " ";
                return res;
            }
        }
    }
}