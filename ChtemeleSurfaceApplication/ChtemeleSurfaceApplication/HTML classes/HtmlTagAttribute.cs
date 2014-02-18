using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    class HtmlTagAttribute
    {
        private string _key;
        private string _value;

        public HtmlTagAttribute(string key, string value)
        {
            _key = key;
            _value = value;
        }

        public string getKey() { return _key; }
        public string getValue() { return _value; }
    }
}
