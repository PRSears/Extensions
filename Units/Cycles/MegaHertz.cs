namespace Extender.Units.Cycles;

public sealed class MegaHertz : Frequency
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("megahertz", "MHz", megahertz => megahertz * 1e6, hertz => hertz / 1e6);
        }
    }

    public MegaHertz() { }

    public MegaHertz(double value) { Value = value; }

    public MegaHertz(float value) { Value = value; }

    public MegaHertz(int value) { Value = value; }

    public MegaHertz(Frequency value) { SiValue = value.SiValue; }

    public static implicit operator Hertz(MegaHertz     x) { return new Hertz(x); }
    public static implicit operator KiloHertz(MegaHertz x) { return new KiloHertz(x); }
    public static implicit operator GigaHertz(MegaHertz x) { return new GigaHertz(x); }
    public static implicit operator TeraHertz(MegaHertz x) { return new TeraHertz(x); }

    public static explicit operator RadiansPerSecond(MegaHertz x)
    {
        return new RadiansPerSecond(x);
    }

    public static explicit operator RevolutionsPerSecond(MegaHertz x)
    {
        return new RevolutionsPerSecond(x);
    }

    public static explicit operator RevolutionsPerMinute(MegaHertz x)
    {
        return new RevolutionsPerMinute(x);
    }

    public static explicit operator RevolutionsPerHour(MegaHertz x)
    {
        return new RevolutionsPerHour(x);
    }

    public static explicit operator RevolutionsPerDay(MegaHertz x)
    {
        return new RevolutionsPerDay(x);
    }

    public static explicit operator RevolutionsPerYear(MegaHertz x)
    {
        return new RevolutionsPerYear(x);
    }
}