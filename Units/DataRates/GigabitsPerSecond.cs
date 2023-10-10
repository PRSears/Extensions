namespace Extender.Units.DataRates;

public sealed class GigabitsPerSecond : DataRate
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo("gigabits per second", "Gbps", to => to * 1e9, from => from / 1e9);
        }
    }

    public GigabitsPerSecond() { }
    public GigabitsPerSecond(double   value) { Value   = value; }
    public GigabitsPerSecond(int      value) { Value   = value; }
    public GigabitsPerSecond(long     value) { Value   = value; }
    public GigabitsPerSecond(DataRate value) { SiValue = value.SiValue; }

    public static implicit operator BitsPerSecond(GigabitsPerSecond x)
    {
        return new BitsPerSecond(x);
    }

    public static implicit operator BytesPerSecond(GigabitsPerSecond x)
    {
        return new BytesPerSecond(x);
    }

    public static implicit operator GigabytesPerSecond(GigabitsPerSecond x)
    {
        return new GigabytesPerSecond(x);
    }

    public static implicit operator KilobitsPerSecond(GigabitsPerSecond x)
    {
        return new KilobitsPerSecond(x);
    }

    public static implicit operator KilobytesPerSecond(GigabitsPerSecond x)
    {
        return new KilobytesPerSecond(x);
    }

    public static implicit operator MegabitsPerSecond(GigabitsPerSecond x)
    {
        return new MegabitsPerSecond(x);
    }

    public static implicit operator MegabytesPerSecond(GigabitsPerSecond x)
    {
        return new MegabytesPerSecond(x);
    }

    public static implicit operator TerabytesPerSecond(GigabitsPerSecond x)
    {
        return new TerabytesPerSecond(x);
    }
}