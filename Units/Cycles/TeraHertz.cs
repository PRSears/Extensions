﻿namespace Extender.Units.Cycles;

public sealed class TeraHertz : Frequency
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("terahertz", "THz", terahertz => terahertz * 1e12, hertz => hertz / 1e12);
        }
    }

    public TeraHertz() { }

    public TeraHertz(double value) { Value = value; }

    public TeraHertz(float value) { Value = value; }

    public TeraHertz(int value) { Value = value; }

    public TeraHertz(Frequency value) { SiValue = value.SiValue; }

    public static implicit operator Hertz(TeraHertz x) { return new Hertz(x); }

    public static implicit operator KiloHertz(TeraHertz x) { return new KiloHertz(x); }

    public static implicit operator MegaHertz(TeraHertz x) { return new MegaHertz(x); }

    public static implicit operator GigaHertz(TeraHertz x) { return new GigaHertz(x); }

    public static explicit operator RadiansPerSecond(TeraHertz x)
    {
        return new RadiansPerSecond(x);
    }

    public static explicit operator RevolutionsPerSecond(TeraHertz x)
    {
        return new RevolutionsPerSecond(x);
    }

    public static explicit operator RevolutionsPerMinute(TeraHertz x)
    {
        return new RevolutionsPerMinute(x);
    }

    public static explicit operator RevolutionsPerHour(TeraHertz x)
    {
        return new RevolutionsPerHour(x);
    }

    public static explicit operator RevolutionsPerDay(TeraHertz x)
    {
        return new RevolutionsPerDay(x);
    }

    public static explicit operator RevolutionsPerYear(TeraHertz x)
    {
        return new RevolutionsPerYear(x);
    }
}