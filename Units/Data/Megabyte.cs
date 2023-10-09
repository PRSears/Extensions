namespace Extender.Units.Data;

public sealed class Megabyte : Datum
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("megabyte", "MB", to => to * 1e6 * 8, from => from / 1e6 / 8); }
    }

    public Megabyte() { }
    public Megabyte(double value) { Value   = value; }
    public Megabyte(int    value) { Value   = value; }
    public Megabyte(long   value) { Value   = value; }
    public Megabyte(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Megabyte      x) { return new Bit(x); }
    public static implicit operator Byte(Megabyte     x) { return new Byte(x); }
    public static implicit operator Gibibit(Megabyte  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Megabyte x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Megabyte  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Megabyte x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Megabyte  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Megabyte x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Megabyte  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Megabyte x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Megabyte  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Megabyte x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Megabyte  x) { return new Megabit(x); }
    public static implicit operator Pebibit(Megabyte  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Megabyte x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Megabyte  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Megabyte x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Megabyte  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Megabyte x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Megabyte  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Megabyte x) { return new Terabyte(x); }
}