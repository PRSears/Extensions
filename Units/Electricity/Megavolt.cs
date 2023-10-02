namespace Extender.Units.Electricity;

public sealed class Megavolt : Voltage
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("megavolt", "MV", si => si * 1e6, volt => volt / 1e6); }
    }

    public Megavolt() { }
    public Megavolt(double  value) { Value   = value; }
    public Megavolt(float   value) { Value   = value; }
    public Megavolt(int     value) { Value   = value; }
    public Megavolt(Voltage value) { SiValue = value.SiValue; }

    public static implicit operator Volt(Megavolt      x) { return new Volt(x); }
    public static implicit operator Millivolt(Megavolt x) { return new Millivolt(x); }
}