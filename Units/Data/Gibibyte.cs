namespace Extender.Units.Data;

public sealed class Gibibyte : Datum
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("gibibyte", "GiB", to => to * ((2L << 29) * 8), from => from / ((2L << 29) * 8));
        }
    }

    public Gibibyte() { }
    public Gibibyte(double value) { Value   = value; }
    public Gibibyte(int    value) { Value   = value; }
    public Gibibyte(long   value) { Value   = value; }
    public Gibibyte(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Gibibyte      x) { return new Bit(x); }
    public static implicit operator Byte(Gibibyte     x) { return new Byte(x); }
    public static implicit operator Gibibit(Gibibyte  x) { return new Gibibit(x); }
    public static implicit operator Gigabit(Gibibyte  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Gibibyte x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Gibibyte  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Gibibyte x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Gibibyte  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Gibibyte x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Gibibyte  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Gibibyte x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Gibibyte  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Gibibyte x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Gibibyte  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Gibibyte x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Gibibyte  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Gibibyte x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Gibibyte  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Gibibyte x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Gibibyte  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Gibibyte x) { return new Terabyte(x); }
}