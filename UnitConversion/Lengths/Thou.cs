namespace Extender.UnitConversion.Lengths
{
    /// <summary>
    /// Helper class for storing and converting a length/distance in thous.
    /// </summary>
    public sealed class Thou : Length
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
                    "Thou",
                    "thou",
                    thous => { return thous * 0.0000254d; },
                    meters => { return meters / 0.0000254d; }
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Thou()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Thou(double value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Thou(int value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Thou(Length value)
        {
            SiValue = value.SiValue;
        }

        #region //Operator overloads

        /// <summary>
        /// Implicit conversion from Thou to Kilometer
        /// </summary>
        public static explicit operator Kilometer(Thou x)
        {
            return new Kilometer(x);
        }

        /// <summary>
        /// Implicit conversion from Thou to Centimeter
        /// </summary>
        public static explicit operator Centimeter(Thou x)
        {
            return new Centimeter(x);
        }

        /// <summary>
        /// Implicit conversion from Thou to Millimeter
        /// </summary>
        public static explicit operator Millimeter(Thou x)
        {
            return new Millimeter(x);
        }
        /// <summary>
        /// Implicit conversion from Thou to Thou
        /// </summary>
        public static explicit operator Meter(Thou x)
        {
            return new Meter(x);
        }

        /// <summary>
        /// Implicit conversion from Thou to Micron
        /// </summary>
        public static explicit operator Micron(Thou x)
        {
            return new Micron(x);
        }

        /// <summary>
        /// Implicit conversion from Thou to Inch
        /// </summary>
        public static implicit operator Inch(Thou x)
        {
            return new Inch(x);
        }

        /// <summary>
        /// Implicit conversion from Thou to Foot
        /// </summary>
        public static implicit operator Foot(Thou x)
        {
            return new Foot(x);
        }

        /// <summary>
        /// Implicit conversion from Thou to Yard
        /// </summary>
        public static implicit operator Yard(Thou x)
        {
            return new Yard(x);
        }

        /// <summary>
        /// Implicit conversion from Thou to Mile
        /// </summary>
        public static implicit operator Mile(Thou x)
        {
            return new Mile(x);
        }


        #endregion
    }
}