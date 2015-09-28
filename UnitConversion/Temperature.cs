namespace Extender.UnitConversion
{
    /// <summary>
    /// Abstract representation of a temperature.
    /// </summary>
    public abstract class Temperature : Measure
    {
        /// <summary>
        /// Converts this Temperature to the specified type.
        /// </summary>
        /// <typeparam name="TOut">Type of Temperature to cast this object to.</typeparam>
        /// <returns>
        /// Converted object of type Tout.
        /// </returns>
        public override TOut ConvertTo<TOut>()
        {
            return base.ConvertTo<TOut, Temperature>();
        }
    }
}
