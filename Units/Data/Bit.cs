namespace Extender.Units.Data;

public sealed class Bit : Datum
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("bit", "b", to => to, from => from); }
    }

    public Bit() { }
    public Bit(double value) { Value   = value; }
    public Bit(int    value) { Value   = value; }
    public Bit(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Byte(Bit     x) { return new Byte(x); }
    public static implicit operator Gibibit(Bit  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Bit x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Bit  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Bit x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Bit  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Bit x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Bit  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Bit x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Bit  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Bit x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Bit  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Bit x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Bit  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Bit x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Bit  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Bit x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Bit  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Bit x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Bit  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Bit x) { return new Terabyte(x); }
}