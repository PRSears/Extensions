namespace Extender.UnitConversion.Lengths
{
    /// <summary>
    /// Helper class for storing and converting a length/distance in miles.
    /// </summary>
    public sealed class Mile : Length
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
                    "mile",
                    "mi",
                    (miles) => { return miles * 1609.344m; },
                    (meters) => { return meters / 1609.344m; }
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Mile()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Mile(decimal value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Mile(double value)
        {
            Value = (decimal)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Mile(int value)
        {
            Value = (decimal)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Mile(Length value)
        {
            SIValue = value.SIValue;
        }

        #region //Operator overloads

        /// <summary>
        /// Implicit conversion from Mile to Kilometer
        /// </summary>
        public static explicit operator Kilometer(Mile x)
        {
            return new Kilometer(x);
        }

        /// <summary>
        /// Implicit conversion from Mile to Centimeter
        /// </summary>
        public static explicit operator Centimeter(Mile x)
        {
            return new Centimeter(x);
        }

        /// <summary>
        /// Implicit conversion from Mile to Millimeter
        /// </summary>
        public static explicit operator Millimeter(Mile x)
        {
            return new Millimeter(x);
        }
        /// <summary>
        /// Implicit conversion from Mile to Mile
        /// </summary>
        public static explicit operator Meter(Mile x)
        {
            return new Meter(x);
        }

        /// <summary>
        /// Implicit conversion from Mile to Micron
        /// </summary>
        public static explicit operator Micron(Mile x)
        {
            return new Micron(x);
        }

        /// <summary>
        /// Implicit conversion from Mile to Inch
        /// </summary>
        public static implicit operator Inch(Mile x)
        {
            return new Inch(x);
        }

        /// <summary>
        /// Implicit conversion from Mile to Thou
        /// </summary>
        public static implicit operator Thou(Mile x)
        {
            return new Thou(x);
        }

        /// <summary>
        /// Implicit conversion from Mile to Yard
        /// </summary>
        public static implicit operator Yard(Mile x)
        {
            return new Yard(x);
        }

        /// <summary>
        /// Implicit conversion from Mile to Mile
        /// </summary>
        public static implicit operator Foot(Mile x)
        {
            return new Foot(x);
        }


        #endregion
    }
}