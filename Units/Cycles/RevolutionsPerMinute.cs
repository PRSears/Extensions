namespace Extender.Units.Cycles;

public sealed class RevolutionsPerMinute : Frequency
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("revolutions per minute", "rpm", to => to / 60d, from => from * 60d);
        }
    }

    public RevolutionsPerMinute() { }
    public RevolutionsPerMinute(double    value) { Value   = value; }
    public RevolutionsPerMinute(int       value) { Value   = value; }
    public RevolutionsPerMinute(Frequency value) { SiValue = value.SiValue; }

    public static implicit operator RadiansPerSecond(RevolutionsPerMinute x)
    {
        return new RadiansPerSecond(x);
    }

    public static implicit operator RevolutionsPerSecond(RevolutionsPerMinute x)
    {
        return new RevolutionsPerSecond(x);
    }

    public static implicit operator RevolutionsPerHour(RevolutionsPerMinute x)
    {
        return new RevolutionsPerHour(x);
    }

    public static implicit operator RevolutionsPerDay(RevolutionsPerMinute x)
    {
        return new RevolutionsPerDay(x);
    }

    public static implicit operator RevolutionsPerYear(RevolutionsPerMinute x)
    {
        return new RevolutionsPerYear(x);
    }

    public static explicit operator Hertz(RevolutionsPerMinute x) { return new Hertz(x); }

    public static explicit operator KiloHertz(RevolutionsPerMinute x) { return new KiloHertz(x); }

    public static explicit operator MegaHertz(RevolutionsPerMinute x) { return new MegaHertz(x); }

    public static explicit operator GigaHertz(RevolutionsPerMinute x) { return new GigaHertz(x); }

    public static explicit operator TeraHertz(RevolutionsPerMinute x) { return new TeraHertz(x); }
}