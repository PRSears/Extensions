namespace Extender.Units;

public abstract class AngularFrequency : Measure
{
    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, AngularFrequency>(); }
}