namespace Extender.Units.Cycles;

public sealed class RevolutionsPerDay : Frequency
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("revolutions per day", "rpd", to => to / 86400, from => from * 86400);
        }
    }

    public RevolutionsPerDay() { }
    public RevolutionsPerDay(double    value) { Value   = value; }
    public RevolutionsPerDay(int       value) { Value   = value; }
    public RevolutionsPerDay(Frequency value) { SiValue = value.SiValue; }

    public static implicit operator RadiansPerSecond(RevolutionsPerDay x)
    {
        return new RadiansPerSecond(x);
    }

    public static implicit operator RevolutionsPerSecond(RevolutionsPerDay x)
    {
        return new RevolutionsPerSecond(x);
    }

    public static implicit operator RevolutionsPerMinute(RevolutionsPerDay x)
    {
        return new RevolutionsPerMinute(x);
    }

    public static implicit operator RevolutionsPerHour(RevolutionsPerDay x)
    {
        return new RevolutionsPerHour(x);
    }

    public static implicit operator RevolutionsPerYear(RevolutionsPerDay x)
    {
        return new RevolutionsPerYear(x);
    }

    public static explicit operator Hertz(RevolutionsPerDay x) { return new Hertz(x); }

    public static explicit operator KiloHertz(RevolutionsPerDay x) { return new KiloHertz(x); }

    public static explicit operator MegaHertz(RevolutionsPerDay x) { return new MegaHertz(x); }

    public static explicit operator GigaHertz(RevolutionsPerDay x) { return new GigaHertz(x); }

    public static explicit operator TeraHertz(RevolutionsPerDay x) { return new TeraHertz(x); }
}