namespace Extender.Units.DataRates;

public sealed class KilobitsPerSecond : DataRate
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo("kilobits per second", "kbps", to => to * 1e3, from => from / 1e3);
        }
    }

    public KilobitsPerSecond() { }
    public KilobitsPerSecond(double   value) { Value   = value; }
    public KilobitsPerSecond(int      value) { Value   = value; }
    public KilobitsPerSecond(long     value) { Value   = value; }
    public KilobitsPerSecond(DataRate value) { SiValue = value.SiValue; }

    public static implicit operator BitsPerSecond(KilobitsPerSecond x)
    {
        return new BitsPerSecond(x);
    }

    public static implicit operator BytesPerSecond(KilobitsPerSecond x)
    {
        return new BytesPerSecond(x);
    }

    public static implicit operator GigabitsPerSecond(KilobitsPerSecond x)
    {
        return new GigabitsPerSecond(x);
    }

    public static implicit operator GigabytesPerSecond(KilobitsPerSecond x)
    {
        return new GigabytesPerSecond(x);
    }

    public static implicit operator KilobytesPerSecond(KilobitsPerSecond x)
    {
        return new KilobytesPerSecond(x);
    }

    public static implicit operator MegabitsPerSecond(KilobitsPerSecond x)
    {
        return new MegabitsPerSecond(x);
    }

    public static implicit operator MegabytesPerSecond(KilobitsPerSecond x)
    {
        return new MegabytesPerSecond(x);
    }

    public static implicit operator TerabytesPerSecond(KilobitsPerSecond x)
    {
        return new TerabytesPerSecond(x);
    }
}