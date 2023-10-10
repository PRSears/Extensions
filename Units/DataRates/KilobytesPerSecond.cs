namespace Extender.Units.DataRates;

public sealed class KilobytesPerSecond : DataRate
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("kilobytes per second", "kBps", to => to * 1e3 * 8, from => from / 1e3 / 8);
        }
    }

    public KilobytesPerSecond() { }
    public KilobytesPerSecond(double   value) { Value   = value; }
    public KilobytesPerSecond(int      value) { Value   = value; }
    public KilobytesPerSecond(long     value) { Value   = value; }
    public KilobytesPerSecond(DataRate value) { SiValue = value.SiValue; }

    public static implicit operator BitsPerSecond(KilobytesPerSecond x)
    {
        return new BitsPerSecond(x);
    }

    public static implicit operator BytesPerSecond(KilobytesPerSecond x)
    {
        return new BytesPerSecond(x);
    }

    public static implicit operator GigabitsPerSecond(KilobytesPerSecond x)
    {
        return new GigabitsPerSecond(x);
    }

    public static implicit operator GigabytesPerSecond(KilobytesPerSecond x)
    {
        return new GigabytesPerSecond(x);
    }

    public static implicit operator KilobitsPerSecond(KilobytesPerSecond x)
    {
        return new KilobitsPerSecond(x);
    }

    public static implicit operator MegabitsPerSecond(KilobytesPerSecond x)
    {
        return new MegabitsPerSecond(x);
    }

    public static implicit operator MegabytesPerSecond(KilobytesPerSecond x)
    {
        return new MegabytesPerSecond(x);
    }

    public static implicit operator TerabytesPerSecond(KilobytesPerSecond x)
    {
        return new TerabytesPerSecond(x);
    }
}