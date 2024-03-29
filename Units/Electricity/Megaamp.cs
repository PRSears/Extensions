﻿namespace Extender.Units.Electricity;

public sealed class Megaamp : ElectricCurrent
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("megaampere", "MA", megaamp => megaamp * 1e6, amp => amp / 1e6); }
    }

    public Megaamp() { }
    public Megaamp(double          value) { Value   = value; }
    public Megaamp(float           value) { Value   = value; }
    public Megaamp(int             value) { Value   = value; }
    public Megaamp(ElectricCurrent value) { SiValue = value.SiValue; }

    public static implicit operator Milliamp(Megaamp x) { return new Milliamp(x); }
    public static implicit operator Amp(Megaamp      x) { return new Amp(x); }
}