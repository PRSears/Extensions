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

    public Amp(double value) { Value = value; }

    public Amp(float value) { Value = value; }

    public Amp(int value) { Value = value; }
}