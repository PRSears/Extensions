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

    public static implicit operator MegaJoule(Btu      x) { return new MegaJoule(x); }
    public static implicit operator GigaJoule(Btu      x) { return new GigaJoule(x); }
    public static explicit operator Joule(Btu          x) { return new Joule(x); }
    public static explicit operator FootPoundForce(Btu x) { return new FootPoundForce(x); }
    public static explicit operator TonsOfTnt(Btu      x) { return new TonsOfTnt(x); }

    public static explicit operator ThermochemicalCalorie(Btu x)
    {
        return new ThermochemicalCalorie(x);
    }
}