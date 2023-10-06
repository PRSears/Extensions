namespace Extender.Units;

public abstract class Bitrate : Measure
{
    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, Bitrate>(); }
}