namespace Extender.Units.Energies;

public sealed class GigaJoule : Energy
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("gigajoule", "GJ", to => to * 1e9, from => from / 1e9); }
    }

    public GigaJoule() { }
    public GigaJoule(double value) { Value   = value; }
    public GigaJoule(int    value) { Value   = value; }
    public GigaJoule(Energy value) { SiValue = value.SiValue; }

    public static implicit operator MegaJoule(GigaJoule      x) { return new MegaJoule(x); }
    public static implicit operator Joule(GigaJoule          x) { return new Joule(x); }
    public static explicit operator Btu(GigaJoule            x) { return new Btu(x); }
    public static explicit operator FootPoundForce(GigaJoule x) { return new FootPoundForce(x); }
    public static explicit operator TonsOfTnt(GigaJoule      x) { return new TonsOfTnt(x); }

    public static explicit operator ThermochemicalCalorie(GigaJoule x)
    {
        return new ThermochemicalCalorie(x);
    }
}