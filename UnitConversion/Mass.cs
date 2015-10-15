namespace Extender.UnitConversion
{
    /// <summary>
    /// Abstract representation of a length.
    /// </summary>
    public abstract class Mass : Measure
    {
        /// <summary>
        /// Converts this Mass to the specified type.
        /// </summary>
        /// <typeparam name="TOut">Type of Mass to cast this object to.</typeparam>
        /// <returns>
        /// Converted object of type Tout.
        /// </returns>
        public override TOut ConvertTo<TOut>()
        {
            return base.ConvertTo<TOut, Mass>();
        }
    }
}
