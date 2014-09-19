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
        private Color color_ = Color.FromRgb(0, 0, 0);

        public XmlColor() { }
        public XmlColor(Color c) { color_ = c; }
        public XmlColor(string value) { this.Web = value; }


        public Color ToColor()
        {
            return color_;
        }

        public void FromColor(Color c)
        {
            color_ = c;
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
                        color_.A,
                        color_.R,
                        color_.G,
                        color_.B
                    );
            }
            set
            {
                try
                {
                    color_ = (Color)ColorConverter.ConvertFromString(value);
                }
                catch (Exception)
                {
                    color_ = Color.FromRgb(0, 0, 0);
                }
            }
        }
    }
}
