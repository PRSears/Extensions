namespace Extender.Units.Masses
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Ounce : Mass
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
                    "ounces",
                    "oz",
                    ouncess   => ouncess * 0.028349523125d,
                    kilograms => kilograms / 0.028349523125d
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Ounce()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Ounce(double value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Ounce(Mass value)
        {
            SiValue = value.SiValue;
        }

        #region //Operator overloads

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Gram(Ounce x)
        {
            return new Gram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator MetricTonne(Ounce x)
        {
            return new MetricTonne(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Milligram(Ounce x)
        {
            return new Milligram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Kilogram(Ounce x)
        {
            return new Kilogram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Pound(Ounce x)
        {
            return new Pound(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Slug(Ounce x)
        {
            return new Slug(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator SolarMass(Ounce x)
        {
            return new SolarMass(x);
        }

        #endregion
    }
}
