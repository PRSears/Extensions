namespace Extender.UnitConversion.Temperatures
{
    /// <summary>
    /// Helper class for storing and converting a temperature in Kelvin.
    /// </summary>
    public sealed class Kelvin : Temperature
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
                    "Kelvin",
                    "K",
                    (k) => { return k; },
                    (k) => { return k; }
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Kelvin()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Kelvin(decimal value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Kelvin(double value)
        {
            Value = (decimal)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Kelvin(int value)
        {
            Value = (decimal)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Kelvin(Temperature value)
        {
            SIValue = value.SIValue;
        }

        #region //Operator overloads
        

        #endregion
    }
}