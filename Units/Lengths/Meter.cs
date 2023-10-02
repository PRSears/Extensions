namespace Extender.Units.Lengths
{
    /// <summary>
    /// Helper class for storing and converting a length/distance in meters.
    /// </summary>
    public sealed class Meter : Length
    {
        /// <summary>
        /// Gets information pertaining to the units of this Length.
        /// </summary>
        public override UnitInfo Unit
        {
            get { return new UnitInfo("meter", "m", si => si, meters => meters); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Meter() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Meter(double value) { Value = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Meter(int value) { Value = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Meter(Length value) { SiValue = value.SiValue; }

        #region //Operator overloads

        /// <summary>
        /// Implicit conversion from Meter to Kilometer
        /// </summary>
        public static implicit operator Kilometer(Meter x) { return new Kilometer(x); }

        /// <summary>
        /// Implicit conversion from Meter to Centimeter
        /// </summary>
        public static implicit operator Centimeter(Meter x) { return new Centimeter(x); }

        /// <summary>
        /// Implicit conversion from Meter to Millimeter
        /// </summary>
        public static implicit operator Millimeter(Meter x) { return new Millimeter(x); }

        /// <summary>
        /// Implicit conversion from Meter to Micron
        /// </summary>
        public static implicit operator Micron(Meter x) { return new Micron(x); }

        /// <summary>
        /// Explicit conversion from Meter to Inch
        /// </summary>
        public static explicit operator Inch(Meter x) { return new Inch(x); }

        /// <summary>
        /// Explicit conversion from Meter to Thou
        /// </summary>
        public static explicit operator Thou(Meter x) { return new Thou(x); }

        /// <summary>
        /// Explicit conversion from Meter to Foot
        /// </summary>
        public static explicit operator Foot(Meter x) { return new Foot(x); }

        /// <summary>
        /// Explicit conversion from Meter to Mile
        /// </summary>
        public static explicit operator Mile(Meter x) { return new Mile(x); }

        /// <summary>
        /// Explicit conversion from Meter to Yard
        /// </summary>
        public static explicit operator Yard(Meter x) { return new Yard(x); }

        #endregion
    }
}