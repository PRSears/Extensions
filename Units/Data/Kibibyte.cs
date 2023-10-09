namespace Extender.Units.Data;

public sealed class Kibibyte : Datum
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("kibibyte", "kiB", to => to * ((2L << 9) * 8), from => from / ((2L << 9) * 8));
        }
    }

    public Kibibyte() { }
    public Kibibyte(double value) { Value   = value; }
    public Kibibyte(int    value) { Value   = value; }
    public Kibibyte(long   value) { Value   = value; }
    public Kibibyte(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Kibibyte      x) { return new Bit(x); }
    public static implicit operator Byte(Kibibyte     x) { return new Byte(x); }
    public static implicit operator Gibibit(Kibibyte  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Kibibyte x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Kibibyte  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Kibibyte x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Kibibyte  x) { return new Kibibit(x); }
    public static implicit operator Kilobit(Kibibyte  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Kibibyte x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Kibibyte  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Kibibyte x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Kibibyte  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Kibibyte x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Kibibyte  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Kibibyte x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Kibibyte  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Kibibyte x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Kibibyte  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Kibibyte x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Kibibyte  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Kibibyte x) { return new Terabyte(x); }
}