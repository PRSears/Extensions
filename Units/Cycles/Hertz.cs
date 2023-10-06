namespace Extender.Units.Cycles;

public sealed class Hertz : Frequency
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("hertz", "Hz", si => si, hertz => hertz); }
    }

    public Hertz() { }

    public Hertz(double value) { Value = value; }

    public Hertz(float value) { Value = value; }

    public Hertz(int value) { Value = value; }

    public Hertz(Frequency value) { SiValue = value.SiValue; }

    public static implicit operator KiloHertz(Hertz x) { return new KiloHertz(x); }

    public static implicit operator MegaHertz(Hertz x) { return new MegaHertz(x); }

    public static implicit operator GigaHertz(Hertz x) { return new GigaHertz(x); }

    public static implicit operator TeraHertz(Hertz x) { return new TeraHertz(x); }

    public static explicit operator RadiansPerSecond(Hertz x) { return new RadiansPerSecond(x); }

    public static explicit operator RevolutionsPerSecond(Hertz x)
    {
        return new RevolutionsPerSecond(x);
    }

    public static explicit operator RevolutionsPerMinute(Hertz x)
    {
        return new RevolutionsPerMinute(x);
    }

    public static explicit operator RevolutionsPerHour(Hertz x)
    {
        return new RevolutionsPerHour(x);
    }

    public static explicit operator RevolutionsPerDay(Hertz x) { return new RevolutionsPerDay(x); }

    public static explicit operator RevolutionsPerYear(Hertz x)
    {
        return new RevolutionsPerYear(x);
    }
}