namespace Extender.Units.Cycles;

public sealed class Hertz : Frequency
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("hertz", "Hz", si => si, hertz => hertz); }
    }

    public Hertz() { }

    public Hertz(double value) { Value = value; }

    public Hertz(float value) { Value = value; }

    public Hertz(int value) { Value = value; }

    public Hertz(Frequency value) { SiValue = value.SiValue; }

    public static implicit operator KiloHertz(Hertz x) { return new KiloHertz(x); }

    public static implicit operator MegaHertz(Hertz x) { return new MegaHertz(x); }

    public static implicit operator GigaHertz(Hertz x) { return new GigaHertz(x); }

    public static implicit operator TeraHertz(Hertz x) { return new TeraHertz(x); }
}