namespace Extender.Units.DataRates;

public sealed class GigabytesPerSecond : DataRate
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("gigabytes per second", "GBps", to => to * 1e9 * 8, from => from / 1e9 / 8);
        }
    }

    public GigabytesPerSecond() { }
    public GigabytesPerSecond(double   value) { Value   = value; }
    public GigabytesPerSecond(int      value) { Value   = value; }
    public GigabytesPerSecond(long     value) { Value   = value; }
    public GigabytesPerSecond(DataRate value) { SiValue = value.SiValue; }

    public static implicit operator BitsPerSecond(GigabytesPerSecond x)
    {
        return new BitsPerSecond(x);
    }

    public static implicit operator BytesPerSecond(GigabytesPerSecond x)
    {
        return new BytesPerSecond(x);
    }

    public static implicit operator GigabitsPerSecond(GigabytesPerSecond x)
    {
        return new GigabitsPerSecond(x);
    }

    public static implicit operator KilobitsPerSecond(GigabytesPerSecond x)
    {
        return new KilobitsPerSecond(x);
    }

    public static implicit operator KilobytesPerSecond(GigabytesPerSecond x)
    {
        return new KilobytesPerSecond(x);
    }

    public static implicit operator MegabitsPerSecond(GigabytesPerSecond x)
    {
        return new MegabitsPerSecond(x);
    }

    public static implicit operator MegabytesPerSecond(GigabytesPerSecond x)
    {
        return new MegabytesPerSecond(x);
    }

    public static implicit operator TerabytesPerSecond(GigabytesPerSecond x)
    {
        return new TerabytesPerSecond(x);
    }
}