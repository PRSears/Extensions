namespace Extender.Units;

public abstract class Frequency : Measure
{
    public override TOut ConvertTo<TOut>()
    {
        return base.ConvertTo<TOut, Frequency>();
    }
}