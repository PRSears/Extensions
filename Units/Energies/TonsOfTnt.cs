﻿namespace Extender.Units.Energies;

public sealed class TonsOfTnt : Energy
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("tons of tnt", "t", to => to * 4.184e9, from => from / 4.184e9); }
    }

    public TonsOfTnt() { }
    public TonsOfTnt(double value) { Value   = value; }
    public TonsOfTnt(int    value) { Value   = value; }
    public TonsOfTnt(Energy value) { SiValue = value.SiValue; }

    public static implicit operator MegaJoule(TonsOfTnt      x) { return new MegaJoule(x); }
    public static implicit operator GigaJoule(TonsOfTnt      x) { return new GigaJoule(x); }
    public static explicit operator Btu(TonsOfTnt            x) { return new Btu(x); }
    public static explicit operator FootPoundForce(TonsOfTnt x) { return new FootPoundForce(x); }
    public static explicit operator Joule(TonsOfTnt          x) { return new Joule(x); }

    public static explicit operator ThermochemicalCalorie(TonsOfTnt x)
    {
        return new ThermochemicalCalorie(x);
    }
}