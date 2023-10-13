namespace Extender.Units.Energies;

public sealed class Btu : Energy
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("british thermal unit", "BTU", to => to * 1055.1, from => from / 1055.1);
        }
    }

    public Btu() { }
    public Btu(double value) { Value   = value; }
    public Btu(int    value) { Value   = value; }
    public Btu(Energy value) { SiValue = value.SiValue; }

    public static implicit operator FootPoundForce(Btu x) { return new FootPoundForce(x); }
    public static implicit operator GigaJoule(Btu      x) { return new GigaJoule(x); }
    public static implicit operator Joule(Btu          x) { return new Joule(x); }
    public static implicit operator KilowattHour(Btu   x) { return new KilowattHour(x); }
    public static implicit operator MegaJoule(Btu      x) { return new MegaJoule(x); }
    public static implicit operator MilliwattHour(Btu  x) { return new MilliwattHour(x); }

    public static implicit operator ThermochemicalCalorie(Btu x)
    {
        return new ThermochemicalCalorie(x);
    }

    public static implicit operator TonsOfTnt(Btu x) { return new TonsOfTnt(x); }
    public static implicit operator WattHour(Btu  x) { return new WattHour(x); }
}