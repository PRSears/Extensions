namespace Extender.Units.Signals;

public sealed class Decibel : Measure
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("decibel", "dB", to => to, from => from); }
    }

    public Decibel() { }

    public Decibel(double value) { Value = value; }

    public Decibel(float value) { Value = value; }

    public Decibel(int value) { Value = value; }

    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, Decibel>(); }
}