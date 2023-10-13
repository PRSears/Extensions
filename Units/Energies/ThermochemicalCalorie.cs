namespace Extender.Units.Energies;

public sealed class ThermochemicalCalorie : Energy
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("thermochemical calorie", "calth", to => to * 4.184, from => from / 4.184);
        }
    }

    public ThermochemicalCalorie() { }
    public ThermochemicalCalorie(double value) { Value   = value; }
    public ThermochemicalCalorie(int    value) { Value   = value; }
    public ThermochemicalCalorie(Energy value) { SiValue = value.SiValue; }

    public static implicit operator Btu(ThermochemicalCalorie x) { return new Btu(x); }

    public static implicit operator FootPoundForce(ThermochemicalCalorie x)
    {
        return new FootPoundForce(x);
    }

    public static implicit operator GigaJoule(ThermochemicalCalorie x) { return new GigaJoule(x); }
    public static implicit operator Joule(ThermochemicalCalorie     x) { return new Joule(x); }

    public static implicit operator KilowattHour(ThermochemicalCalorie x)
    {
        return new KilowattHour(x);
    }

    public static implicit operator MegaJoule(ThermochemicalCalorie x) { return new MegaJoule(x); }

    public static implicit operator MilliwattHour(ThermochemicalCalorie x)
    {
        return new MilliwattHour(x);
    }

    public static implicit operator TonsOfTnt(ThermochemicalCalorie x) { return new TonsOfTnt(x); }
    public static implicit operator WattHour(ThermochemicalCalorie  x) { return new WattHour(x); }
}