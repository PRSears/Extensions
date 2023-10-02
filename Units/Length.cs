namespace Extender.Units;

/// <summary>
/// Abstract representation of a length.
/// </summary>
public abstract class Length : Measure
{
    /// <summary>
    /// Converts this Length to the specified type.
    /// </summary>
    /// <typeparam name="TOut">Type of Length to cast this object to.</typeparam>
    /// <returns>
    /// Converted object of type Tout.
    /// </returns>
    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, Length>(); }
}