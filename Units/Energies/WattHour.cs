namespace Extender.Units.Energies;

public sealed class WattHour : Energy
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("watt-hour", "wh", to => to * 3600, from => from * 2.777777777777778e-4);
        }
    }

    public WattHour() { }
    public WattHour(double value) { Value   = value; }
    public WattHour(int    value) { Value   = value; }
    public WattHour(long   value) { Value   = value; }
    public WattHour(Energy value) { SiValue = value.SiValue; }

    public static implicit operator Btu(WattHour            x) { return new Btu(x); }
    public static implicit operator FootPoundForce(WattHour x) { return new FootPoundForce(x); }
    public static implicit operator GigaJoule(WattHour      x) { return new GigaJoule(x); }
    public static implicit operator Joule(WattHour          x) { return new Joule(x); }
    public static implicit operator KilowattHour(WattHour   x) { return new KilowattHour(x); }
    public static implicit operator MegaJoule(WattHour      x) { return new MegaJoule(x); }
    public static implicit operator MilliwattHour(WattHour  x) { return new MilliwattHour(x); }

    public static implicit operator ThermochemicalCalorie(WattHour x)
    {
        return new ThermochemicalCalorie(x);
    }

    public static implicit operator TonsOfTnt(WattHour x) { return new TonsOfTnt(x); }
}