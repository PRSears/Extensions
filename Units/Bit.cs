namespace Extender.Units;

// This one's gonna get a wee bit complicated
// Bits, bytes, 1024 / 1000 ... and rate versions for each one.
public abstract class Bit : Measure
{
    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, Bit>(); }
}