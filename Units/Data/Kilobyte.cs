namespace Extender.Units.Data;

public sealed class Kilobyte : Datum
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("kilobyte", "kB", to => to * 1e3 * 8, from => from / 1e3 / 8); }
    }

    public Kilobyte() { }
    public Kilobyte(double value) { Value   = value; }
    public Kilobyte(int    value) { Value   = value; }
    public Kilobyte(long   value) { Value   = value; }
    public Kilobyte(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Kilobyte      x) { return new Bit(x); }
    public static implicit operator Byte(Kilobyte     x) { return new Byte(x); }
    public static implicit operator Gibibit(Kilobyte  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Kilobyte x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Kilobyte  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Kilobyte x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Kilobyte  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Kilobyte x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Kilobyte  x) { return new Kilobit(x); }
    public static implicit operator Mebibit(Kilobyte  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Kilobyte x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Kilobyte  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Kilobyte x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Kilobyte  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Kilobyte x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Kilobyte  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Kilobyte x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Kilobyte  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Kilobyte x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Kilobyte  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Kilobyte x) { return new Terabyte(x); }
}