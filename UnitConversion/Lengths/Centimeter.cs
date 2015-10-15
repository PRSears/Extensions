namespace Extender.UnitConversion.Lengths
{
    /// <summary>
    /// Helper class for storing and converting a length/distance in centimeters.
    /// </summary>
    public sealed class Centimeter : Length
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
                    "Centimeter",
                    "cm",
                    centimeters => centimeters * 0.01d,
                    meters      => meters / 0.01d
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Centimeter()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Centimeter(double value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Centimeter(int value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Centimeter(Length value)
        {
            SiValue = value.SiValue;
        }

        #region //Operator overloads

        /// <summary>
        /// Implicit conversion from Centimeter to Meter
        /// </summary>
        public static implicit operator Meter(Centimeter x)
        {
            return new Meter(x);
        }

        /// <summary>
        /// Implicit conversion from Centimeter to Kilometer
        /// </summary>
        public static implicit operator Kilometer(Centimeter x)
        {
            return new Kilometer(x);
        }

        /// <summary>
        /// Implicit conversion from Centimeter to Millimeter
        /// </summary>
        public static implicit operator Millimeter(Centimeter x)
        {
            return new Millimeter(x);
        }

        /// <summary>
        /// Implicit conversion from Centimeter to Micron
        /// </summary>
        public static implicit operator Micron(Centimeter x)
        {
            return new Micron(x);
        }

        /// <summary>
        /// Implicit conversion from Centimeter to Inch
        /// </summary>
        public static explicit operator Inch(Centimeter x)
        {
            return new Inch(x);
        }

        /// <summary>
        /// Implicit conversion from Centimeter to Thou
        /// </summary>
        public static explicit operator Thou(Centimeter x)
        {
            return new Thou(x);
        }

        /// <summary>
        /// Implicit conversion from Centimeter to Foot
        /// </summary>
        public static explicit operator Foot(Centimeter x)
        {
            return new Foot(x);
        }

        /// <summary>
        /// Implicit conversion from Centimeter to Mile
        /// </summary>
        public static explicit operator Mile(Centimeter x)
        {
            return new Mile(x);
        }

        /// <summary>
        /// Implicit conversion from Centimeter to Yard
        /// </summary>
        public static explicit operator Yard(Centimeter x)
        {
            return new Yard(x);
        }

        #endregion
    }
}