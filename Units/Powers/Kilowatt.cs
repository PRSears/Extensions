namespace Extender.Units.Powers;

public sealed class Kilowatt : Power
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("kilowatt", "kW", to => to * 1e3, from => from / 1e3); }
    }

    public Kilowatt() { }
    public Kilowatt(double value) { Value   = value; }
    public Kilowatt(int    value) { Value   = value; }
    public Kilowatt(Power  value) { SiValue = value.SiValue; }

    public static implicit operator Watt(Kilowatt     x) { return new Watt(x); }
    public static implicit operator Megawatt(Kilowatt x) { return new Megawatt(x); }

    public static explicit operator ElectricalHorsepower(Kilowatt x)
    {
        return new ElectricalHorsepower(x);
    }
}