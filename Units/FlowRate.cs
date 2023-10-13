namespace Extender.Units;

public abstract class FlowRate : Measure
{
    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, FlowRate>(); }
}