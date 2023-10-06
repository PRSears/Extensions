namespace Extender.Units.Cycles;

public sealed class RevolutionsPerHour : Frequency
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("revolutions per hour", "rph", to => to / 3600, from => from * 3600);
        }
    }

    public RevolutionsPerHour() { }
    public RevolutionsPerHour(double    value) { Value   = value; }
    public RevolutionsPerHour(int       value) { Value   = value; }
    public RevolutionsPerHour(Frequency value) { SiValue = value.SiValue; }

    public static implicit operator RadiansPerSecond(RevolutionsPerHour x)
    {
        return new RadiansPerSecond(x);
    }

    public static implicit operator RevolutionsPerSecond(RevolutionsPerHour x)
    {
        return new RevolutionsPerSecond(x);
    }

    public static implicit operator RevolutionsPerMinute(RevolutionsPerHour x)
    {
        return new RevolutionsPerMinute(x);
    }

    public static implicit operator RevolutionsPerDay(RevolutionsPerHour x)
    {
        return new RevolutionsPerDay(x);
    }

    public static implicit operator RevolutionsPerYear(RevolutionsPerHour x)
    {
        return new RevolutionsPerYear(x);
    }

    public static explicit operator Hertz(RevolutionsPerHour x) { return new Hertz(x); }

    public static explicit operator KiloHertz(RevolutionsPerHour x) { return new KiloHertz(x); }

    public static explicit operator MegaHertz(RevolutionsPerHour x) { return new MegaHertz(x); }

    public static explicit operator GigaHertz(RevolutionsPerHour x) { return new GigaHertz(x); }

    public static explicit operator TeraHertz(RevolutionsPerHour x) { return new TeraHertz(x); }
}