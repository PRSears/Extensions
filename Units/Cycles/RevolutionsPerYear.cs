namespace Extender.Units.Cycles;

/// <summary>
/// Frequency of revolutions per sidereal year. (1 revolution per sidereal year = 31,558,118.4Hz).
/// </summary>
public sealed class RevolutionsPerYear : Frequency
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("revolutions per year", "rpy", to => to / 31558118.4d, from => from * 31558118.4d);
        }
    }

    public RevolutionsPerYear() { }
    public RevolutionsPerYear(double    value) { Value   = value; }
    public RevolutionsPerYear(int       value) { Value   = value; }
    public RevolutionsPerYear(Frequency value) { SiValue = value.SiValue; }

    public static implicit operator RadiansPerSecond(RevolutionsPerYear x)
    {
        return new RadiansPerSecond(x);
    }

    public static implicit operator RevolutionsPerSecond(RevolutionsPerYear x)
    {
        return new RevolutionsPerSecond(x);
    }

    public static implicit operator RevolutionsPerMinute(RevolutionsPerYear x)
    {
        return new RevolutionsPerMinute(x);
    }

    public static implicit operator RevolutionsPerHour(RevolutionsPerYear x)
    {
        return new RevolutionsPerHour(x);
    }

    public static implicit operator RevolutionsPerDay(RevolutionsPerYear x)
    {
        return new RevolutionsPerDay(x);
    }

    public static explicit operator Hertz(RevolutionsPerYear x) { return new Hertz(x); }

    public static explicit operator KiloHertz(RevolutionsPerYear x) { return new KiloHertz(x); }

    public static explicit operator MegaHertz(RevolutionsPerYear x) { return new MegaHertz(x); }

    public static explicit operator GigaHertz(RevolutionsPerYear x) { return new GigaHertz(x); }

    public static explicit operator TeraHertz(RevolutionsPerYear x) { return new TeraHertz(x); }
}