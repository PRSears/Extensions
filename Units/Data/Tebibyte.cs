namespace Extender.Units.Data;

public sealed class Tebibyte : Datum
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("tebibyte", "TiB", to => to * ((2L << 39) * 8), from => from / ((2L << 39) * 8));
        }
    }

    public Tebibyte() { }
    public Tebibyte(double value) { Value   = value; }
    public Tebibyte(int    value) { Value   = value; }
    public Tebibyte(long   value) { Value   = value; }
    public Tebibyte(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Tebibyte      x) { return new Bit(x); }
    public static implicit operator Byte(Tebibyte     x) { return new Byte(x); }
    public static implicit operator Gibibit(Tebibyte  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Tebibyte x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Tebibyte  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Tebibyte x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Tebibyte  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Tebibyte x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Tebibyte  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Tebibyte x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Tebibyte  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Tebibyte x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Tebibyte  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Tebibyte x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Tebibyte  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Tebibyte x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Tebibyte  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Tebibyte x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Tebibyte  x) { return new Tebibit(x); }
    public static implicit operator Terabit(Tebibyte  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Tebibyte x) { return new Terabyte(x); }
}