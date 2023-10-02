using System.Data;
using System.Net.Http.Headers;

namespace Extender.Units.Electricity;

public sealed class Amp : ElectricCurrent
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("ampere", "A", si => si, amp => amp); }
    }

    public Amp() { }
    public Amp(double          value) { Value   = value; }
    public Amp(float           value) { Value   = value; }
    public Amp(int             value) { Value   = value; }
    public Amp(ElectricCurrent value) { SiValue = value.SiValue; }


    public static implicit operator Milliamp(Amp x) { return new Milliamp(x); }
    public static implicit operator Megaamp(Amp  x) { return new Megaamp(x); }
}