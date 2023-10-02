namespace Extender.Units.Lengths
{
    /// <summary>
    /// Helper class for storing and converting a length/distance in feet.
    /// </summary>
    public sealed class Foot : Length
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
                    "foot",
                    "ft",
                    feet => { return feet * 0.3048d; },
                    meters => { return meters / 0.3048d ; }
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Foot()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Foot(double value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Foot(int value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Foot(Length value)
        {
            SiValue = value.SiValue;
        }

        #region //Operator overloads

        /// <summary>
        /// Implicit conversion from Foot to Kilometer
        /// </summary>
        public static explicit operator Kilometer(Foot x)
        {
            return new Kilometer(x);
        }

        /// <summary>
        /// Implicit conversion from Foot to Centimeter
        /// </summary>
        public static explicit operator Centimeter(Foot x)
        {
            return new Centimeter(x);
        }

        /// <summary>
        /// Implicit conversion from Foot to Millimeter
        /// </summary>
        public static explicit operator Millimeter(Foot x)
        {
            return new Millimeter(x);
        }
        /// <summary>
        /// Implicit conversion from Foot to Foot
        /// </summary>
        public static explicit operator Meter(Foot x)
        {
            return new Meter(x);
        }

        /// <summary>
        /// Implicit conversion from Foot to Micron
        /// </summary>
        public static explicit operator Micron(Foot x)
        {
            return new Micron(x);
        }

        /// <summary>
        /// Implicit conversion from Foot to Inch
        /// </summary>
        public static implicit operator Inch(Foot x)
        {
            return new Inch(x);
        }

        /// <summary>
        /// Implicit conversion from Foot to Thou
        /// </summary>
        public static implicit operator Thou(Foot x)
        {
            return new Thou(x);
        }

        /// <summary>
        /// Implicit conversion from Foot to Yard
        /// </summary>
        public static implicit operator Yard(Foot x)
        {
            return new Yard(x);
        }

        /// <summary>
        /// Implicit conversion from Foot to Mile
        /// </summary>
        public static implicit operator Mile(Foot x)
        {
            return new Mile(x);
        }


        #endregion
    }
}
