namespace Extender.Units.DataRates;

public sealed class MegabytesPerSecond : DataRate
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("megabytes per second", "MBps", to => to * 1e6 * 8, from => from / 1e6 / 8);
        }
    }

    public MegabytesPerSecond() { }
    public MegabytesPerSecond(double   value) { Value   = value; }
    public MegabytesPerSecond(int      value) { Value   = value; }
    public MegabytesPerSecond(long     value) { Value   = value; }
    public MegabytesPerSecond(DataRate value) { SiValue = value.SiValue; }

    public static implicit operator BitsPerSecond(MegabytesPerSecond x)
    {
        return new BitsPerSecond(x);
    }

    public static implicit operator BytesPerSecond(MegabytesPerSecond x)
    {
        return new BytesPerSecond(x);
    }

    public static implicit operator GigabitsPerSecond(MegabytesPerSecond x)
    {
        return new GigabitsPerSecond(x);
    }

    public static implicit operator GigabytesPerSecond(MegabytesPerSecond x)
    {
        return new GigabytesPerSecond(x);
    }

    public static implicit operator KilobitsPerSecond(MegabytesPerSecond x)
    {
        return new KilobitsPerSecond(x);
    }

    public static implicit operator KilobytesPerSecond(MegabytesPerSecond x)
    {
        return new KilobytesPerSecond(x);
    }

    public static implicit operator MegabitsPerSecond(MegabytesPerSecond x)
    {
        return new MegabitsPerSecond(x);
    }

    public static implicit operator TerabytesPerSecond(MegabytesPerSecond x)
    {
        return new TerabytesPerSecond(x);
    }
}