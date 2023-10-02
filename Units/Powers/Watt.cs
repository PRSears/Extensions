using Extender.Units.Electricity;

namespace Extender.Units.Powers;

public sealed class Watt : Power
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("watt", "W", si => si, watt => watt); }
    }

    public Watt() { }
    public Watt(double value) { Value   = value; }
    public Watt(int    value) { Value   = value; }
    public Watt(Power  value) { SiValue = value.SiValue; }

    public static implicit operator Kilowatt(Watt x) { return new Kilowatt(x); }
    public static implicit operator Megawatt(Watt x) { return new Megawatt(x); }

    public static explicit operator ElectricalHorsepower(Watt x)
    {
        return new ElectricalHorsepower(x);
    }
}