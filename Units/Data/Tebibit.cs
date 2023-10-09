namespace Extender.Units.Data;

public sealed class Tebibit : Datum
{
    public override UnitInfo Unit
    {
        // The bit shifting accomplishes raising 2 to the power of n+1.
        // 2 << 39 == 2^40 == 1024^4
        get
        {
            return new UnitInfo("tebibit", "Tib", to => to * (2L << 39), from => from / (2L << 39));
        }
    }

    public Tebibit() { }
    public Tebibit(double value) { Value   = (long) value; }
    public Tebibit(int    value) { Value   = value; }
    public Tebibit(long   value) { Value   = value; }
    public Tebibit(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Tebibit      x) { return new Bit(x); }
    public static implicit operator Byte(Tebibit     x) { return new Byte(x); }
    public static implicit operator Gibibit(Tebibit  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Tebibit x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Tebibit  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Tebibit x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Tebibit  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Tebibit x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Tebibit  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Tebibit x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Tebibit  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Tebibit x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Tebibit  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Tebibit x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Tebibit  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Tebibit x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Tebibit  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Tebibit x) { return new PetaByte(x); }
    public static implicit operator Tebibyte(Tebibit x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Tebibit  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Tebibit x) { return new Terabyte(x); }
}