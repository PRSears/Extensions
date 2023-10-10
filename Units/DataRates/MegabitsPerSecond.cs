namespace Extender.Units.DataRates;

public sealed class MegabitsPerSecond : DataRate
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo("megabits per second", "Mbps", to => to * 1e6, from => from / 1e6);
        }
    }

    public MegabitsPerSecond() { }
    public MegabitsPerSecond(double   value) { Value   = value; }
    public MegabitsPerSecond(int      value) { Value   = value; }
    public MegabitsPerSecond(long     value) { Value   = value; }
    public MegabitsPerSecond(DataRate value) { SiValue = value.SiValue; }

    public static implicit operator BitsPerSecond(MegabitsPerSecond x)
    {
        return new BitsPerSecond(x);
    }

    public static implicit operator BytesPerSecond(MegabitsPerSecond x)
    {
        return new BytesPerSecond(x);
    }

    public static implicit operator GigabitsPerSecond(MegabitsPerSecond x)
    {
        return new GigabitsPerSecond(x);
    }

    public static implicit operator GigabytesPerSecond(MegabitsPerSecond x)
    {
        return new GigabytesPerSecond(x);
    }

    public static implicit operator KilobitsPerSecond(MegabitsPerSecond x)
    {
        return new KilobitsPerSecond(x);
    }

    public static implicit operator KilobytesPerSecond(MegabitsPerSecond x)
    {
        return new KilobytesPerSecond(x);
    }

    public static implicit operator MegabytesPerSecond(MegabitsPerSecond x)
    {
        return new MegabytesPerSecond(x);
    }

    public static implicit operator TerabytesPerSecond(MegabitsPerSecond x)
    {
        return new TerabytesPerSecond(x);
    }
}