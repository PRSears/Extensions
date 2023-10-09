namespace Extender.Units.Data;

public sealed class Kilobit : Datum
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("kilobit", "kb", to => to * 1e3, from => from / 1e3); }
    }

    public Kilobit() { }
    public Kilobit(double value) { Value   = value; }
    public Kilobit(int    value) { Value   = value; }
    public Kilobit(long   value) { Value   = value; }
    public Kilobit(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Kilobit      x) { return new Bit(x); }
    public static implicit operator Byte(Kilobit     x) { return new Byte(x); }
    public static implicit operator Gibibit(Kilobit  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Kilobit x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Kilobit  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Kilobit x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Kilobit  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Kilobit x) { return new Kibibyte(x); }
    public static implicit operator Kilobyte(Kilobit x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Kilobit  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Kilobit x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Kilobit  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Kilobit x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Kilobit  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Kilobit x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Kilobit  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Kilobit x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Kilobit  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Kilobit x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Kilobit  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Kilobit x) { return new Terabyte(x); }
}