namespace Extender.UnitConversion.Lengths
{
    /// <summary>
    /// Helper class for storing and converting a length/distance in inches.
    /// </summary>
    public sealed class Inch : Length
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
                    "inch",
                    "in",
                    inches => inches * 0.0254d,
                    meters => meters / 0.0254d
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Inch()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Inch(double value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Inch(int value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Inch(Length value)
        {
            SiValue = value.SiValue;
        }

        #region //Operator overloads

        /// <summary>
        /// Implicit conversion from Inch to Kilometer
        /// </summary>
        public static explicit operator Kilometer(Inch x)
        {
            return new Kilometer(x);
        }

        /// <summary>
        /// Implicit conversion from Inch to Centimeter
        /// </summary>
        public static explicit operator Centimeter(Inch x)
        {
            return new Centimeter(x);
        }

        /// <summary>
        /// Implicit conversion from Inch to Millimeter
        /// </summary>
        public static explicit operator Millimeter(Inch x)
        {
            return new Millimeter(x);
        }
        /// <summary>
        /// Implicit conversion from Inch to Inch
        /// </summary>
        public static explicit operator Meter(Inch x)
        {
            return new Meter(x);
        }

        /// <summary>
        /// Implicit conversion from Inch to Micron
        /// </summary>
        public static explicit operator Micron(Inch x)
        {
            return new Micron(x);
        }

        /// <summary>
        /// Implicit conversion from Inch to Mile
        /// </summary>
        public static implicit operator Mile(Inch x)
        {
            return new Mile(x);
        }

        /// <summary>
        /// Implicit conversion from Inch to Thou
        /// </summary>
        public static implicit operator Thou(Inch x)
        {
            return new Thou(x);
        }

        /// <summary>
        /// Implicit conversion from Inch to Yard
        /// </summary>
        public static implicit operator Yard(Inch x)
        {
            return new Yard(x);
        }

        /// <summary>
        /// Implicit conversion from Inch to Foot
        /// </summary>
        public static implicit operator Foot(Inch x)
        {
            return new Foot(x);
        }


        #endregion
    }
}
