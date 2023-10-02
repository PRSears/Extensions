namespace Extender.Units.Electricity;

public sealed class Volt : Voltage
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("volt", "V", si => si, volt => volt); }
    }

    public Volt() { }
    public Volt(double  value) { Value   = value; }
    public Volt(float   value) { Value   = value; }
    public Volt(int     value) { Value   = value; }
    public Volt(Voltage value) { SiValue = value.SiValue; }

    public static implicit operator Megavolt(Volt  x) { return new Megavolt(x); }
    public static implicit operator Millivolt(Volt x) { return new Millivolt(x); }
}