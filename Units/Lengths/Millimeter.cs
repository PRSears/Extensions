namespace Extender.Units.Lengths
{
    /// <summary>
    /// Helper class for storing and converting a length/distance in millimeters.
    /// </summary>
    public sealed class Millimeter : Length
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
                    "Millimeter",
                    "mm",
                    millimeters => millimeters * 0.001d,
                    meters => meters           / 0.001d
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Millimeter() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Millimeter(double value) { Value = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Millimeter(int value) { Value = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Millimeter(Length value) { SiValue = value.SiValue; }

        #region //Operator overloads

        /// <summary>
        /// Implicit conversion from Millimeter to Meter
        /// </summary>
        public static implicit operator Meter(Millimeter x) { return new Meter(x); }

        /// <summary>
        /// Implicit conversion from Millimeter to Kilometer
        /// </summary>
        public static implicit operator Kilometer(Millimeter x) { return new Kilometer(x); }

        /// <summary>
        /// Implicit conversion from Millimeter to Centimeter
        /// </summary>
        public static implicit operator Centimeter(Millimeter x) { return new Centimeter(x); }

        /// <summary>
        /// Implicit conversion from Millimeter to Micron
        /// </summary>
        public static implicit operator Micron(Millimeter x) { return new Micron(x); }

        /// <summary>
        /// Implicit conversion from Millimeter to Inch
        /// </summary>
        public static explicit operator Inch(Millimeter x) { return new Inch(x); }

        /// <summary>
        /// Implicit conversion from Millimeter to Thou
        /// </summary>
        public static explicit operator Thou(Millimeter x) { return new Thou(x); }

        /// <summary>
        /// Implicit conversion from Millimeter to Foot
        /// </summary>
        public static explicit operator Foot(Millimeter x) { return new Foot(x); }

        /// <summary>
        /// Implicit conversion from Millimeter to Mile
        /// </summary>
        public static explicit operator Mile(Millimeter x) { return new Mile(x); }

        /// <summary>
        /// Implicit conversion from Millimeter to Yard
        /// </summary>
        public static explicit operator Yard(Millimeter x) { return new Yard(x); }

        #endregion
    }
}