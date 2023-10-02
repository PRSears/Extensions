namespace Extender.Units.Powers;

public sealed class ElectricalHorsepower : Power
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("horsepower", "hp", to => to * 746, from => from / 746); }
    }

    public ElectricalHorsepower() { }
    public ElectricalHorsepower(double value) { Value   = value; }
    public ElectricalHorsepower(int    value) { Value   = value; }
    public ElectricalHorsepower(Power  value) { SiValue = value.SiValue; }

    public static explicit operator Watt(ElectricalHorsepower     x) { return new Watt(x); }
    public static explicit operator Kilowatt(ElectricalHorsepower x) { return new Kilowatt(x); }
    public static explicit operator Megawatt(ElectricalHorsepower x) { return new Megawatt(x); }
}