namespace Extender.Units.Masses
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Pound : Mass
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
                    "pounds",
                    "lb",
                    pounds    => pounds * 0.45359237d,
                    kilograms => kilograms / 0.45359237d
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Pound()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Pound(double value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Pound(Mass value)
        {
            SiValue = value.SiValue;
        }

        #region //Operator overloads

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Gram(Pound x)
        {
            return new Gram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator MetricTonne(Pound x)
        {
            return new MetricTonne(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Milligram(Pound x)
        {
            return new Milligram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Ounce(Pound x)
        {
            return new Ounce(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Kilogram(Pound x)
        {
            return new Kilogram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Slug(Pound x)
        {
            return new Slug(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator SolarMass(Pound x)
        {
            return new SolarMass(x);
        }

        #endregion
    }
}
