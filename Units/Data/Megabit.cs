namespace Extender.Units.Data;

public sealed class Megabit : Datum
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("megabit", "Mb", to => to * 1e6, from => from / 1e6); }
    }

    public Megabit() { }
    public Megabit(double value) { Value   = value; }
    public Megabit(int    value) { Value   = value; }
    public Megabit(long   value) { Value   = value; }
    public Megabit(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Megabit      x) { return new Bit(x); }
    public static implicit operator Byte(Megabit     x) { return new Byte(x); }
    public static implicit operator Gibibit(Megabit  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Megabit x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Megabit  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Megabit x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Megabit  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Megabit x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Megabit  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Megabit x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Megabit  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Megabit x) { return new Mebibyte(x); }
    public static implicit operator Megabyte(Megabit x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Megabit  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Megabit x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Megabit  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Megabit x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Megabit  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Megabit x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Megabit  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Megabit x) { return new Terabyte(x); }
}