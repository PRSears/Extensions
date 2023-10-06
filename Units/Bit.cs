namespace Extender.Units;

public abstract class Bit : Measure
{
    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, Bit>(); }
}