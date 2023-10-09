namespace Extender.Units;

public abstract class DataRate : Measure
{
    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, DataRate>(); }
}