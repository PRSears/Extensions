namespace Extender.Units.Electricity;

public sealed class Milliamp : ElectricCurrent
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo("megaampere", "MA", milliamp => milliamp * 1e-3, amp => amp / 1e-3);
        }
    }

    public Milliamp() { }
    public Milliamp(double          value) { Value   = value; }
    public Milliamp(float           value) { Value   = value; }
    public Milliamp(int             value) { Value   = value; }
    public Milliamp(ElectricCurrent value) { SiValue = value.SiValue; }

    public static implicit operator Megaamp(Milliamp x) { return new Megaamp(x); }
    public static implicit operator Amp(Milliamp     x) { return new Amp(x); }
}