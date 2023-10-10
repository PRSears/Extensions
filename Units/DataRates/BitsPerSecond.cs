namespace Extender.Units.DataRates;

public sealed class BitsPerSecond : DataRate
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("bits per second", "bps", to => to, from => from); }
    }

    public BitsPerSecond() { }
    public BitsPerSecond(double   value) { Value   = value; }
    public BitsPerSecond(int      value) { Value   = value; }
    public BitsPerSecond(long     value) { Value   = value; }
    public BitsPerSecond(DataRate value) { SiValue = value.SiValue; }

    public static implicit operator BytesPerSecond(BitsPerSecond x)
    {
        return new BytesPerSecond(x);
    }

    public static implicit operator GigabitsPerSecond(BitsPerSecond x)
    {
        return new GigabitsPerSecond(x);
    }

    public static implicit operator GigabytesPerSecond(BitsPerSecond x)
    {
        return new GigabytesPerSecond(x);
    }

    public static implicit operator KilobitsPerSecond(BitsPerSecond x)
    {
        return new KilobitsPerSecond(x);
    }

    public static implicit operator KilobytesPerSecond(BitsPerSecond x)
    {
        return new KilobytesPerSecond(x);
    }

    public static implicit operator MegabitsPerSecond(BitsPerSecond x)
    {
        return new MegabitsPerSecond(x);
    }

    public static implicit operator MegabytesPerSecond(BitsPerSecond x)
    {
        return new MegabytesPerSecond(x);
    }

    public static implicit operator TerabytesPerSecond(BitsPerSecond x)
    {
        return new TerabytesPerSecond(x);
    }
}