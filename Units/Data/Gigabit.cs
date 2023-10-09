namespace Extender.Units.Data;

public sealed class Gigabit : Datum
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("gigabit", "Gb", to => to * 1e9, from => from / 1e9); }
    }

    public Gigabit() { }
    public Gigabit(double value) { Value   = value; }
    public Gigabit(int    value) { Value   = value; }
    public Gigabit(long   value) { Value   = value; }
    public Gigabit(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Gigabit      x) { return new Bit(x); }
    public static implicit operator Byte(Gigabit     x) { return new Byte(x); }
    public static implicit operator Gibibit(Gigabit  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Gigabit x) { return new Gibibyte(x); }
    public static implicit operator Gigabyte(Gigabit x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Gigabit  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Gigabit x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Gigabit  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Gigabit x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Gigabit  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Gigabit x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Gigabit  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Gigabit x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Gigabit  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Gigabit x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Gigabit  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Gigabit x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Gigabit  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Gigabit x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Gigabit  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Gigabit x) { return new Terabyte(x); }
}