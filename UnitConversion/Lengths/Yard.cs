namespace Extender.UnitConversion.Lengths
{
    /// <summary>
    /// Helper class for storing and converting a length/distance in yards.
    /// </summary>
    public sealed class Yard : Length
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
                    "Yard",
                    "yd",
                    (yards) => yards * 0.9144m,
                    (meters) => meters / 0.9144m
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Yard()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Yard(decimal value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Yard(double value)
        {
            Value = (decimal)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Yard(int value)
        {
            Value = (decimal)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Yard(Length value)
        {
            SIValue = value.SIValue;
        }



        #region //Operator overloads

        /// <summary>
        /// Implicit conversion from Yard to Kilometer
        /// </summary>
        public static explicit operator Kilometer(Yard x)
        {
            return new Kilometer(x);
        }

        /// <summary>
        /// Implicit conversion from Yard to Centimeter
        /// </summary>
        public static explicit operator Centimeter(Yard x)
        {
            return new Centimeter(x);
        }

        /// <summary>
        /// Implicit conversion from Yard to Millimeter
        /// </summary>
        public static explicit operator Millimeter(Yard x)
        {
            return new Millimeter(x);
        }
        /// <summary>
        /// Implicit conversion from Yard to Yard
        /// </summary>
        public static explicit operator Meter(Yard x)
        {
            return new Meter(x);
        }

        /// <summary>
        /// Implicit conversion from Yard to Micron
        /// </summary>
        public static explicit operator Micron(Yard x)
        {
            return new Micron(x);
        }

        /// <summary>
        /// Implicit conversion from Yard to Inch
        /// </summary>
        public static implicit operator Inch(Yard x)
        {
            return new Inch(x);
        }

        /// <summary>
        /// Implicit conversion from Yard to Thou
        /// </summary>
        public static implicit operator Thou(Yard x)
        {
            return new Thou(x);
        }

        /// <summary>
        /// Implicit conversion from Yard to Foot
        /// </summary>
        public static implicit operator Foot(Yard x)
        {
            return new Foot(x);
        }

        /// <summary>
        /// Implicit conversion from Yard to Mile
        /// </summary>
        public static implicit operator Mile(Yard x)
        {
            return new Mile(x);
        }


        #endregion        
    }
}