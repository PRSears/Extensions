namespace Extender.Units.DataRates;

public sealed class TerabytesPerSecond : DataRate
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("terabytes per second", "TBps", to => to * 1e12 * 8, from => from / 1e12 / 8);
        }
    }

    public TerabytesPerSecond() { }
    public TerabytesPerSecond(double   value) { Value   = value; }
    public TerabytesPerSecond(int      value) { Value   = value; }
    public TerabytesPerSecond(long     value) { Value   = value; }
    public TerabytesPerSecond(DataRate value) { SiValue = value.SiValue; }

    public static implicit operator BitsPerSecond(TerabytesPerSecond x)
    {
        return new BitsPerSecond(x);
    }

    public static implicit operator BytesPerSecond(TerabytesPerSecond x)
    {
        return new BytesPerSecond(x);
    }

    public static implicit operator GigabitsPerSecond(TerabytesPerSecond x)
    {
        return new GigabitsPerSecond(x);
    }

    public static implicit operator GigabytesPerSecond(TerabytesPerSecond x)
    {
        return new GigabytesPerSecond(x);
    }

    public static implicit operator KilobitsPerSecond(TerabytesPerSecond x)
    {
        return new KilobitsPerSecond(x);
    }

    public static implicit operator KilobytesPerSecond(TerabytesPerSecond x)
    {
        return new KilobytesPerSecond(x);
    }

    public static implicit operator MegabitsPerSecond(TerabytesPerSecond x)
    {
        return new MegabitsPerSecond(x);
    }

    public static implicit operator MegabytesPerSecond(TerabytesPerSecond x)
    {
        return new MegabytesPerSecond(x);
    }
}