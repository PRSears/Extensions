namespace Extender.Units.DataRates;

public sealed class BytesPerSecond : DataRate
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("bytes per second", "Bps", to => to * 8, from => from / 8); }
    }

    public BytesPerSecond() { }
    public BytesPerSecond(double   value) { Value   = value; }
    public BytesPerSecond(int      value) { Value   = value; }
    public BytesPerSecond(long     value) { Value   = value; }
    public BytesPerSecond(DataRate value) { SiValue = value.SiValue; }

    public static implicit operator BitsPerSecond(BytesPerSecond x) { return new BitsPerSecond(x); }

    public static implicit operator GigabitsPerSecond(BytesPerSecond x)
    {
        return new GigabitsPerSecond(x);
    }

    public static implicit operator GigabytesPerSecond(BytesPerSecond x)
    {
        return new GigabytesPerSecond(x);
    }

    public static implicit operator KilobitsPerSecond(BytesPerSecond x)
    {
        return new KilobitsPerSecond(x);
    }

    public static implicit operator KilobytesPerSecond(BytesPerSecond x)
    {
        return new KilobytesPerSecond(x);
    }

    public static implicit operator MegabitsPerSecond(BytesPerSecond x)
    {
        return new MegabitsPerSecond(x);
    }

    public static implicit operator MegabytesPerSecond(BytesPerSecond x)
    {
        return new MegabytesPerSecond(x);
    }

    public static implicit operator TerabytesPerSecond(BytesPerSecond x)
    {
        return new TerabytesPerSecond(x);
    }
}