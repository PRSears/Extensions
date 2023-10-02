namespace Extender.Units.Electricity;

public sealed class Millivolt : Voltage
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("millivolt", "mV", si => si * 1e-3, volt => volt / 1e-3); }
    }

    public Millivolt() { }
    public Millivolt(double  value) { Value   = value; }
    public Millivolt(float   value) { Value   = value; }
    public Millivolt(int     value) { Value   = value; }
    public Millivolt(Voltage value) { SiValue = value.SiValue; }


    public static implicit operator Volt(Millivolt     x) { return new Volt(x); }
    public static implicit operator Megavolt(Millivolt x) { return new Megavolt(x); }
}