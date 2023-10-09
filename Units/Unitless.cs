namespace Extender.Units;

public class Unitless : Measure
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("unitless", string.Empty, to => to, from => from); }
    }

    public Unitless() { }

    public Unitless(double value) { Value = value; }

    public Unitless(float value) { Value = value; }

    public Unitless(int value) { Value = value; }

    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, Unitless>(); }
}