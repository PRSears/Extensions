namespace Extender.UnitConversion.Temperatures
{
    /// <summary>
    /// Helper class for storing and converting a temperature in Fahrenheit.
    /// </summary>
    public sealed class Fahrenheit : Temperature
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
                    "Fahrenheit",
                    "\u00B0F",
                    fahrenheit => ((fahrenheit + 459.67d) * (5d/9d)),
                    kelvin     => ((kelvin * (9d/5d)) - 459.67d));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Fahrenheit()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fahrenheit(double value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fahrenheit(int value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fahrenheit(Temperature value)
        {
            SiValue = value.SiValue;
        }

        #region //Operator overloads

        /// <summary>
        /// Implicit conversion from Kelvin to Fahrenheit.
        /// </summary>
        public static implicit operator Fahrenheit(Kelvin x)
        {
            return x.ConvertTo<Fahrenheit>();
        }

        /// <summary>
        /// Implicit conversion from Fahrenheit to Kelvin.
        /// </summary>
        public static implicit operator Kelvin(Fahrenheit x)
        {
            return x.ConvertTo<Kelvin>();
        }

        #endregion
    }
}