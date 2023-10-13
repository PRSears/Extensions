namespace Extender.Units.Energies;

public sealed class MegaJoule : Energy
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("megajoule", "MJ", to => to * 1e6, from => from / 1e6); }
    }

    public MegaJoule() { }
    public MegaJoule(double value) { Value   = value; }
    public MegaJoule(int    value) { Value   = value; }
    public MegaJoule(Energy value) { SiValue = value.SiValue; }

    public static implicit operator Btu(MegaJoule            x) { return new Btu(x); }
    public static implicit operator FootPoundForce(MegaJoule x) { return new FootPoundForce(x); }
    public static implicit operator GigaJoule(MegaJoule      x) { return new GigaJoule(x); }
    public static implicit operator Joule(MegaJoule          x) { return new Joule(x); }
    public static implicit operator KilowattHour(MegaJoule   x) { return new KilowattHour(x); }
    public static implicit operator MilliwattHour(MegaJoule  x) { return new MilliwattHour(x); }

    public static implicit operator ThermochemicalCalorie(MegaJoule x)
    {
        return new ThermochemicalCalorie(x);
    }

    public static implicit operator TonsOfTnt(MegaJoule x) { return new TonsOfTnt(x); }
    public static implicit operator WattHour(MegaJoule  x) { return new WattHour(x); }
}