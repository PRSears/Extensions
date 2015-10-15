namespace Extender.UnitConversion.Masses
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MetricTonne : Mass
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
                    "tonne",
                    "t",
                    tonnes => tonnes * 1000d,
                    kilograms => kilograms / 1000d
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MetricTonne()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public MetricTonne(double value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public MetricTonne(Mass value)
        {
            SiValue = value.SiValue;
        }

        #region //Operator overloads

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Kilogram(MetricTonne x)
        {
            return new Kilogram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Gram(MetricTonne x)
        {
            return new Gram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Milligram(MetricTonne x)
        {
            return new Milligram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Ounce(MetricTonne x)
        {
            return new Ounce(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Pound(MetricTonne x)
        {
            return new Pound(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Slug(MetricTonne x)
        {
            return new Slug(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator SolarMass(MetricTonne x)
        {
            return new SolarMass(x);
        }

        #endregion
    }
}
