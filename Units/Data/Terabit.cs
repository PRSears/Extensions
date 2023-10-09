namespace Extender.Units.Data;

public sealed class Terabit : Datum
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("terbit", "Tb", to => to * 1e12, from => from / 1e12); }
    }

    public Terabit() { }
    public Terabit(double value) { Value   = value; }
    public Terabit(int    value) { Value   = value; }
    public Terabit(long   value) { Value   = value; }
    public Terabit(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Terabit      x) { return new Bit(x); }
    public static implicit operator Byte(Terabit     x) { return new Byte(x); }
    public static implicit operator Gibibit(Terabit  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Terabit x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Terabit  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Terabit x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Terabit  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Terabit x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Terabit  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Terabit x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Terabit  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Terabit x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Terabit  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Terabit x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Terabit  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Terabit x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Terabit  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Terabit x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Terabit  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Terabit x) { return new Tebibyte(x); }
    public static implicit operator Terabyte(Terabit x) { return new Terabyte(x); }
}