namespace Extender.Units.Energies;

public sealed class MilliwattHour : Energy
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("milli-watt hour", "mWh", to => to * 3.6, from => from * 2.777777777777778e-1);
        }
    }

    public MilliwattHour() { }
    public MilliwattHour(double value) { Value   = value; }
    public MilliwattHour(int    value) { Value   = value; }
    public MilliwattHour(long   value) { Value   = value; }
    public MilliwattHour(Energy value) { SiValue = value.SiValue; }

    public static implicit operator Btu(MilliwattHour x) { return new Btu(x); }

    public static implicit operator FootPoundForce(MilliwattHour x)
    {
        return new FootPoundForce(x);
    }

    public static implicit operator GigaJoule(MilliwattHour    x) { return new GigaJoule(x); }
    public static implicit operator Joule(MilliwattHour        x) { return new Joule(x); }
    public static implicit operator KilowattHour(MilliwattHour x) { return new KilowattHour(x); }
    public static implicit operator MegaJoule(MilliwattHour    x) { return new MegaJoule(x); }

    public static implicit operator ThermochemicalCalorie(MilliwattHour x)
    {
        return new ThermochemicalCalorie(x);
    }

    public static implicit operator TonsOfTnt(MilliwattHour x) { return new TonsOfTnt(x); }
    public static implicit operator WattHour(MilliwattHour  x) { return new WattHour(x); }
}