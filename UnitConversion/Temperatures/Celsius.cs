namespace Extender.UnitConversion.Temperatures
{
    /// <summary>
    /// Helper class for storing and converting a temperature in Celsius.
    /// </summary>
    public sealed class Celsius : Temperature
    {
        /// <summary>
        /// Gets information pertaining to the units of this temperature.
        /// </summary>
        public override UnitInfo Unit
        {
            get
            {
                return new UnitInfo
                (
                    "Celsius",
                    "\u00B0C",
                    (celsius) => { return celsius + 273.15m; },
                    (kelvin) => { return kelvin - 273.15m; }
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Celsius()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Celsius(decimal value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Celsius(double value)
        {
            Value = (decimal)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Celsius(int value)
        {
            Value = (decimal)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Celsius(Temperature value)
        {
            SIValue = value.SIValue;
        }

        #region //Operator overloads
        /// <summary>
        /// Implicit conversion from Celsius to Fahrenheit.
        /// </summary>
        public static implicit operator Fahrenheit(Celsius x)
        {
            return x.ConvertTo<Fahrenheit>();
        }

        /// <summary>
        /// Implicit conversion from Fahrenheit to Celsius.
        /// </summary>
        public static implicit operator Celsius(Fahrenheit x)
        {
            return x.ConvertTo<Celsius>();
        }

        /// <summary>
        /// Implicit conversion from Celsius to Kelvin.
        /// </summary>
        public static implicit operator Kelvin(Celsius x)
        {
            return x.ConvertTo<Kelvin>();
        }

        /// <summary>
        /// Implicit conversion from Kelvin to Celsius.
        /// </summary>
        public static implicit operator Celsius(Kelvin x)
        {
            return x.ConvertTo<Celsius>();
        }

        #endregion
    }
}