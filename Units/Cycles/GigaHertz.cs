namespace Extender.Units.Cycles;

public sealed class GigaHertz : Frequency
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("gigahertz", "GHz", gigahertz => gigahertz * 1e9, hertz => hertz / 1e9);
        }
    }

    public GigaHertz() { }

    public GigaHertz(double value) { Value = value; }

    public GigaHertz(float value) { Value = value; }

    public GigaHertz(int value) { Value = value; }

    public GigaHertz(Frequency value) { SiValue = value.SiValue; }

    public static implicit operator Hertz(GigaHertz x) { return new Hertz(x); }

    public static implicit operator KiloHertz(GigaHertz x) { return new KiloHertz(x); }

    public static implicit operator MegaHertz(GigaHertz x) { return new MegaHertz(x); }

    public static implicit operator TeraHertz(GigaHertz x) { return new TeraHertz(x); }
}