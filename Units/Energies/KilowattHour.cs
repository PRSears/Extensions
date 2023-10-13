namespace Extender.Units.Energies;

public sealed class KilowattHour : Energy
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("kilowatt-hour", "kWh", to => to * 3600000, from => from * 2.777777777777778e-7);
        }
    }

    public KilowattHour() { }
    public KilowattHour(double value) { Value   = value; }
    public KilowattHour(int    value) { Value   = value; }
    public KilowattHour(long   value) { Value   = value; }
    public KilowattHour(Energy value) { SiValue = value.SiValue; }

    public static implicit operator Btu(KilowattHour            x) { return new Btu(x); }
    public static implicit operator FootPoundForce(KilowattHour x) { return new FootPoundForce(x); }
    public static implicit operator GigaJoule(KilowattHour      x) { return new GigaJoule(x); }
    public static implicit operator Joule(KilowattHour          x) { return new Joule(x); }
    public static implicit operator MegaJoule(KilowattHour      x) { return new MegaJoule(x); }
    public static implicit operator MilliwattHour(KilowattHour  x) { return new MilliwattHour(x); }

    public static implicit operator ThermochemicalCalorie(KilowattHour x)
    {
        return new ThermochemicalCalorie(x);
    }

    public static implicit operator TonsOfTnt(KilowattHour x) { return new TonsOfTnt(x); }
    public static implicit operator WattHour(KilowattHour  x) { return new WattHour(x); }
}