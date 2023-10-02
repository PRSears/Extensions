namespace Extender.Units.Masses
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Milligram : Mass
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
                    "milligram",
                    "mg",
                    milligrams => milligrams * 0.000001d,
                    kilograms  => kilograms  / 0.000001d
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Milligram()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Milligram(double value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Milligram(Mass value)
        {
            SiValue = value.SiValue;
        }

        #region //Operator overloads

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Gram(Milligram x)
        {
            return new Gram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator MetricTonne(Milligram x)
        {
            return new MetricTonne(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Kilogram(Milligram x)
        {
            return new Kilogram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Ounce(Milligram x)
        {
            return new Ounce(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Pound(Milligram x)
        {
            return new Pound(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Slug(Milligram x)
        {
            return new Slug(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator SolarMass(Milligram x)
        {
            return new SolarMass(x);
        }

        #endregion
    }
}
