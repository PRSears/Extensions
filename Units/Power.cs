namespace Extender.Units;

public abstract class Power : Measure
{
    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, Power>(); }
}