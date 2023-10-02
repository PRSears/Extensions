using Extender.Units.Electricity;

namespace Extender.Units.Powers;

public sealed class Megawatt : Power
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("megawatt", "MW", to => to * 1e6, from => from / 1e6); }
    }

    public Megawatt() { }
    public Megawatt(double value) { Value   = value; }
    public Megawatt(int    value) { Value   = value; }
    public Megawatt(Power  value) { SiValue = value.SiValue; }

    public static implicit operator Watt(Megawatt     x) { return new Watt(x); }
    public static implicit operator Kilowatt(Megawatt x) { return new Kilowatt(x); }

    public static explicit operator ElectricalHorsepower(Megawatt x)
    {
        return new ElectricalHorsepower(x);
    }
}