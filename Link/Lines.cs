using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Link
{
    public class Lines
    {
        public Lines()
        {
            _IsLink = false;
        }
        public Lines(List<Point> p)
        {
            _IsLink = true;
            _Points = p;
        }
        private bool _IsLink;

        public bool IsLink
        {
            get { return _IsLink; }
            set { _IsLink = value; }
        }

        private List<Point> _Points;

        public List<Point> Points
        {
            get { return _Points; }
            set { _Points = value; }
        }
    }
}
