namespace Extender.Units.Cycles;

public sealed class KiloHertz : Frequency
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("kilohertz", "kHz", kilohertz => kilohertz * 1e3, hertz => hertz / 1e3);
        }
    }

    public KiloHertz() { }

    public KiloHertz(double value) { Value = value; }

    public KiloHertz(float value) { Value = value; }

    public KiloHertz(int value) { Value = value; }

    public KiloHertz(Frequency value) { SiValue = value.SiValue; }

    public static implicit operator Hertz(KiloHertz x)
    {
        return new Hertz(x);
    }
    
    public static implicit operator MegaHertz(KiloHertz x)
    {
        return new MegaHertz(x);
    }
    
    public static implicit operator GigaHertz(KiloHertz x)
    {
        return new GigaHertz(x);
    }
    
    public static implicit operator TeraHertz(KiloHertz x)
    {
        return new TeraHertz(x);
    }
}