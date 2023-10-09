namespace Extender.Units.Data;

public sealed class Pebibyte : Datum
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("pebibyte", "PiB", to => to * ((2L << 49) * 8), from => from / ((2L << 49) * 8));
        }
    }

    public Pebibyte() { }
    public Pebibyte(double value) { Value   = value; }
    public Pebibyte(int    value) { Value   = value; }
    public Pebibyte(long   value) { Value   = value; }
    public Pebibyte(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Pebibyte      x) { return new Bit(x); }
    public static implicit operator Byte(Pebibyte     x) { return new Byte(x); }
    public static implicit operator Gibibit(Pebibyte  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Pebibyte x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Pebibyte  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Pebibyte x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Pebibyte  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Pebibyte x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Pebibyte  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Pebibyte x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Pebibyte  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Pebibyte x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Pebibyte  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Pebibyte x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Pebibyte  x) { return new Pebibit(x); }
    public static implicit operator Petabit(Pebibyte  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Pebibyte x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Pebibyte  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Pebibyte x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Pebibyte  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Pebibyte x) { return new Terabyte(x); }
}