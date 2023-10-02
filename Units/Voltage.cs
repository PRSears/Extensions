namespace Extender.Units;

public abstract class Voltage : Measure
{
    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, Voltage>(); }
}