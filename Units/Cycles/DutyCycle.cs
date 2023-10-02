namespace Extender.Units.Cycles;

public class DutyCycle : Measure
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("duty cycle", "%", x => x, y => y); }
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