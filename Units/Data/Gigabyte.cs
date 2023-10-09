namespace Extender.Units.Data;

public sealed class Gigabyte : Datum
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("gigabyte", "GB", to => to * 1e9 * 8, from => from / 1e9 / 8); }
    }

    public Gigabyte() { }
    public Gigabyte(double value) { Value   = value; }
    public Gigabyte(int    value) { Value   = value; }
    public Gigabyte(long   value) { Value   = value; }
    public Gigabyte(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Gigabyte      x) { return new Bit(x); }
    public static implicit operator Byte(Gigabyte     x) { return new Byte(x); }
    public static implicit operator Gibibit(Gigabyte  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Gigabyte x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Gigabyte  x) { return new Gigabit(x); }
    public static implicit operator Kibibit(Gigabyte  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Gigabyte x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Gigabyte  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Gigabyte x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Gigabyte  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Gigabyte x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Gigabyte  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Gigabyte x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Gigabyte  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Gigabyte x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Gigabyte  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Gigabyte x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Gigabyte  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Gigabyte x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Gigabyte  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Gigabyte x) { return new Terabyte(x); }
}