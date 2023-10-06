namespace Extender.Units.Cycles;

public sealed class DutyCycle : Percentage
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("duty cycle", "%", to => to, from => from); }
    }

    public DutyCycle() { }

    public DutyCycle(double value, bool fromDecimal = false)
    {
        Value = fromDecimal ? value * 100 : value;
    }

    public DutyCycle(float value, bool fromDecimal = false)
    {
        Value = fromDecimal ? value * 100 : value;
    }

    public DutyCycle(int value) { Value = value; }
}