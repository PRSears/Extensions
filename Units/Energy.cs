namespace Extender.Units;

public abstract class Energy : Measure
{
    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, Energy>(); }
}