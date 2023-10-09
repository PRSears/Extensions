namespace Extender.Units.Data;

public sealed class Terabyte : Datum
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("terabyte", "TB", to => to * 1e12 * 8, from => from / 1e12 / 8); }
    }

    public Terabyte() { }
    public Terabyte(double value) { Value   = value; }
    public Terabyte(int    value) { Value   = value; }
    public Terabyte(long   value) { Value   = value; }
    public Terabyte(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Terabyte      x) { return new Bit(x); }
    public static implicit operator Byte(Terabyte     x) { return new Byte(x); }
    public static implicit operator Gibibit(Terabyte  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Terabyte x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Terabyte  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Terabyte x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Terabyte  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Terabyte x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Terabyte  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Terabyte x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Terabyte  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Terabyte x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Terabyte  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Terabyte x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Terabyte  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Terabyte x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Terabyte  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Terabyte x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Terabyte  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Terabyte x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Terabyte  x) { return new Terabit(x); }
}