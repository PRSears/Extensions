namespace Extender.Units.Data;

public sealed class Mebibyte : Datum
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("mebibyte", "MiB", to => to * ((2L << 19) * 8), from => from / ((2L << 19) * 8));
        }
    }

    public Mebibyte() { }
    public Mebibyte(double value) { Value   = value; }
    public Mebibyte(int    value) { Value   = value; }
    public Mebibyte(long   value) { Value   = value; }
    public Mebibyte(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Mebibyte      x) { return new Bit(x); }
    public static implicit operator Byte(Mebibyte     x) { return new Byte(x); }
    public static implicit operator Gibibit(Mebibyte  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Mebibyte x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Mebibyte  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Mebibyte x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Mebibyte  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Mebibyte x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Mebibyte  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Mebibyte x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Mebibyte  x) { return new Mebibit(x); }
    public static implicit operator Megabit(Mebibyte  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Mebibyte x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Mebibyte  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Mebibyte x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Mebibyte  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Mebibyte x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Mebibyte  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Mebibyte x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Mebibyte  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Mebibyte x) { return new Terabyte(x); }
}