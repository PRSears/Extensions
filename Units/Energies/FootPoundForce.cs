namespace Extender.Units.Energies;

public sealed class FootPoundForce : Energy
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
            (
                "foot pound-force",
                "ft\u22c5lbf",
                to => to     * 1.3558179483314004,
                from => from / 1.3558179483314004
            );
        }
    }

    public FootPoundForce() { }
    public FootPoundForce(double value) { Value   = value; }
    public FootPoundForce(int    value) { Value   = value; }
    public FootPoundForce(Energy value) { SiValue = value.SiValue; }

    public static implicit operator Btu(FootPoundForce           x) { return new Btu(x); }
    public static implicit operator GigaJoule(FootPoundForce     x) { return new GigaJoule(x); }
    public static implicit operator Joule(FootPoundForce         x) { return new Joule(x); }
    public static implicit operator KilowattHour(FootPoundForce  x) { return new KilowattHour(x); }
    public static implicit operator MegaJoule(FootPoundForce     x) { return new MegaJoule(x); }
    public static implicit operator MilliwattHour(FootPoundForce x) { return new MilliwattHour(x); }

    public static implicit operator ThermochemicalCalorie(FootPoundForce x)
    {
        return new ThermochemicalCalorie(x);
    }

    public static implicit operator TonsOfTnt(FootPoundForce x) { return new TonsOfTnt(x); }
    public static implicit operator WattHour(FootPoundForce  x) { return new WattHour(x); }
}