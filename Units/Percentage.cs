namespace Extender.Units;

public class Percentage : Measure
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("percentage", "%", to => to, from => from); }
    }

    public Percentage() { }

    public Percentage(double value, bool fromDecimal = false)
    {
        Value = fromDecimal ? value * 100 : value;
    }

    public Percentage(float value, bool fromDecimal = false)
    {
        Value = fromDecimal ? value * 100 : value;
    }

    public Percentage(int value) { Value = value; }
    
    public override TOut ConvertTo<TOut>() { return base.ConvertTo<TOut, Percentage>(); }
}