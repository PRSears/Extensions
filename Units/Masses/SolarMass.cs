namespace Extender.Units.Masses
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SolarMass : Mass
    {
        /// <summary>
        /// Gets information pertaining to the units of this Measure.
        /// </summary>
        public override UnitInfo Unit
        {
            get
            {
                return new UnitInfo
                (
                    "solar mass",
                    "S\u2609",
                    solarMasses => solarMasses * 1.98855E+30,
                    kilograms   => kilograms / 1.98855E+30
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SolarMass()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public SolarMass(double value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public SolarMass(Mass value)
        {
            SiValue = value.SiValue;
        }

        #region //Operator overloads

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Gram(SolarMass x)
        {
            return new Gram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator MetricTonne(SolarMass x)
        {
            return new MetricTonne(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Milligram(SolarMass x)
        {
            return new Milligram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Ounce(SolarMass x)
        {
            return new Ounce(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Pound(SolarMass x)
        {
            return new Pound(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Slug(SolarMass x)
        {
            return new Slug(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Kilogram(SolarMass x)
        {
            return new Kilogram(x);
        }

        #endregion
    }
}
