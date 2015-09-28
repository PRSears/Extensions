namespace Extender.UnitConversion.Lengths
{
    /// <summary>
    /// Helper class for storing and converting a length/distance in microns.
    /// </summary>
    public sealed class Micron : Length
    {
        /// <summary>
        /// Gets information pertaining to the units of this Length.
        /// </summary>
        public override UnitInfo Unit
        {
            get
            {
                return new UnitInfo
                (
                    "Micron",
                    "\u00B5m",
                    (microns) => { return microns * 0.000001m; },
                    (meters) => { return meters / 0.000001m; }
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Micron()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Micron(decimal value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Micron(double value)
        {
            Value = (decimal)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Micron(int value)
        {
            Value = (decimal)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Micron(Length value)
        {
            SIValue = value.SIValue;
        }

        #region //Operator overloads

        /// <summary>
        /// Implicit conversion from Micron to Meter
        /// </summary>
        public static implicit operator Meter(Micron x)
        {
            return new Meter(x);
        }

        /// <summary>
        /// Implicit conversion from Micron to Centimeter
        /// </summary>
        public static implicit operator Centimeter(Micron x)
        {
            return new Centimeter(x);
        }

        /// <summary>
        /// Implicit conversion from Micron to Millimeter
        /// </summary>
        public static implicit operator Millimeter(Micron x)
        {
            return new Millimeter(x);
        }

        /// <summary>
        /// Implicit conversion from Micron to Kilometer
        /// </summary>
        public static implicit operator Kilometer(Micron x)
        {
            return new Kilometer(x);
        }

        /// <summary>
        /// Implicit conversion from Micron to Inch
        /// </summary>
        public static explicit operator Inch(Micron x)
        {
            return new Inch(x);
        }

        /// <summary>
        /// Implicit conversion from Micron to Thou
        /// </summary>
        public static explicit operator Thou(Micron x)
        {
            return new Thou(x);
        }

        /// <summary>
        /// Implicit conversion from Micron to Foot
        /// </summary>
        public static explicit operator Foot(Micron x)
        {
            return new Foot(x);
        }

        /// <summary>
        /// Implicit conversion from Micron to Mile
        /// </summary>
        public static explicit operator Mile(Micron x)
        {
            return new Mile(x);
        }

        /// <summary>
        /// Implicit conversion from Micron to Yard
        /// </summary>
        public static explicit operator Yard(Micron x)
        {
            return new Yard(x);
        }

        #endregion
    }
}