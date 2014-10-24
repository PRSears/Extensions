using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Extender.Windows
{   
    /// <remarks>
    /// Adapted from code by bvj from StackOverflow.
    /// https://stackoverflow.com/questions/3280362/most-elegant-xml-serialization-of-color-structure
    /// </remarks>
    public class XmlColor
    {
        private Color _color = Color.FromRgb(0, 0, 0);

        public XmlColor() { }
        public XmlColor(Color c) { _color = c; }
        public XmlColor(string value) { this.Web = value; }


        public Color ToColor()
        {
            return _color;
        }

        public void FromColor(Color c)
        {
            _color = c;
        }

        public static implicit operator Color(XmlColor x)
        {
            return x.ToColor();
        }

        public static implicit operator XmlColor(Color c)
        {
            return new XmlColor(c);
        }

        [XmlAttribute]
        public string Web
        {
            get
            {
                return string.Format
                (
                    "#{0:X2}{1:X2}{2:X2}{3:X2}",
                    _color.A,
                    _color.R,
                    _color.G,
                    _color.B
                );
            }
            set
            {
                try
                {
                    _color = (Color)ColorConverter.ConvertFromString(value);
                }
                catch (Exception)
                {
                    _color = Color.FromRgb(0, 0, 0);
                }
            }
        }
    }
}
