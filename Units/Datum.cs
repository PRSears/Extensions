namespace Extender.Units;

public abstract class Datum : Measure
{
    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, Datum>(); }
}