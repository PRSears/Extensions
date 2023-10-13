namespace Extender.Units.Energies;

public sealed class Joule : Energy
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("joule", "J", si => si, joule => joule); }
    }

    public Joule() { }
    public Joule(double value) { Value   = value; }
    public Joule(int    value) { Value   = value; }
    public Joule(Energy value) { SiValue = value.SiValue; }

    public static implicit operator Btu(Joule            x) { return new Btu(x); }
    public static implicit operator FootPoundForce(Joule x) { return new FootPoundForce(x); }
    public static implicit operator GigaJoule(Joule      x) { return new GigaJoule(x); }
    public static implicit operator KilowattHour(Joule   x) { return new KilowattHour(x); }
    public static implicit operator MegaJoule(Joule      x) { return new MegaJoule(x); }
    public static implicit operator MilliwattHour(Joule  x) { return new MilliwattHour(x); }

    public static implicit operator ThermochemicalCalorie(Joule x)
    {
        return new ThermochemicalCalorie(x);
    }

    public static implicit operator TonsOfTnt(Joule x) { return new TonsOfTnt(x); }
    public static implicit operator WattHour(Joule  x) { return new WattHour(x); }
}