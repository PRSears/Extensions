namespace Extender.Units.Data;

public sealed class Pebibit : Datum
{
    public override UnitInfo Unit
    {
        // The bit shifting accomplishes raising 2 to the power of n+1.
        // 2 << 49 == 2^50 == 1024^5
        get
        {
            return new UnitInfo("pebibit", "Pib", to => to * (2L << 49), from => from / (2L << 49));
        }
    }

    public Pebibit() { }
    public Pebibit(double value) { Value   = value; }
    public Pebibit(int    value) { Value   = value; }
    public Pebibit(long   value) { Value   = value; }
    public Pebibit(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Pebibit      x) { return new Bit(x); }
    public static implicit operator Byte(Pebibit     x) { return new Byte(x); }
    public static implicit operator Gibibit(Pebibit  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Pebibit x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Pebibit  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Pebibit x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Pebibit  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Pebibit x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Pebibit  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Pebibit x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Pebibit  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Pebibit x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Pebibit  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Pebibit x) { return new Megabyte(x); }
    public static implicit operator Pebibyte(Pebibit x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Pebibit  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Pebibit x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Pebibit  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Pebibit x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Pebibit  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Pebibit x) { return new Terabyte(x); }
}