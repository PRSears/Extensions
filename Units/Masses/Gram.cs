namespace Extender.Units.Masses
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Gram : Mass
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
                    "gram",
                    "g",
                    grams     => grams * 0.001d,
                    kilograms => kilograms / 0.001d
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Gram()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Gram(double value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Gram(Mass value)
        {
            SiValue = value.SiValue;
        }

        #region //Operator overloads

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Kilogram(Gram x)
        {
            return new Kilogram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator MetricTonne(Gram x)
        {
            return new MetricTonne(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Milligram(Gram x)
        {
            return new Milligram(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Ounce(Gram x)
        {
            return new Ounce(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Pound(Gram x)
        {
            return new Pound(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator Slug(Gram x)
        {
            return new Slug(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static implicit operator SolarMass(Gram x)
        {
            return new SolarMass(x);
        }

        #endregion
    }
}
