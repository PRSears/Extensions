namespace Extender.Units.Lengths
{
    /// <summary>
    /// Helper class for storing and converting a length/distance in kilometers.
    /// </summary>
    public sealed class Kilometer : Length
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
                    "kilometer",
                    "km",
                    kilometers => { return kilometers * 1000d; },
                    meters => { return meters         / 1000d; }
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Kilometer() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Kilometer(double value) { Value = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Kilometer(int value) { Value = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Kilometer(Length value) { SiValue = value.SiValue; }

        #region //Operator overloads

        /// <summary>
        /// Implicit conversion from Kilometer to Meter
        /// </summary>
        public static implicit operator Meter(Kilometer x) { return new Meter(x); }

        /// <summary>
        /// Implicit conversion from Kilometer to Centimeter
        /// </summary>
        public static implicit operator Centimeter(Kilometer x) { return new Centimeter(x); }

        /// <summary>
        /// Implicit conversion from Kilometer to Millimeter
        /// </summary>
        public static implicit operator Millimeter(Kilometer x) { return new Millimeter(x); }

        /// <summary>
        /// Implicit conversion from Kilometer to Micron
        /// </summary>
        public static implicit operator Micron(Kilometer x) { return new Micron(x); }

        /// <summary>
        /// Implicit conversion from Kilometer to Inch
        /// </summary>
        public static explicit operator Inch(Kilometer x) { return new Inch(x); }

        /// <summary>
        /// Implicit conversion from Kilometer to Thou
        /// </summary>
        public static explicit operator Thou(Kilometer x) { return new Thou(x); }

        /// <summary>
        /// Implicit conversion from Kilometer to Foot
        /// </summary>
        public static explicit operator Foot(Kilometer x) { return new Foot(x); }

        /// <summary>
        /// Implicit conversion from Kilometer to Mile
        /// </summary>
        public static explicit operator Mile(Kilometer x) { return new Mile(x); }

        /// <summary>
        /// Implicit conversion from Kilometer to Yard
        /// </summary>
        public static explicit operator Yard(Kilometer x) { return new Yard(x); }

        #endregion
    }
}