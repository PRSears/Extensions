namespace Extender.Units.Data;

public sealed class Mebibit : Datum
{
    public override UnitInfo Unit
    {
        // The bit shifting accomplishes raising 2 to the power of n+1.
        // 2 << 19 == 2^20 == 1024^2
        get
        {
            return new UnitInfo("mebibit", "Mib", to => to * (2 << 19), from => from / (2 << 19));
        }
    }

    public Mebibit() { }
    public Mebibit(double value) { Value   = value; }
    public Mebibit(int    value) { Value   = value; }
    public Mebibit(long   value) { Value   = value; }
    public Mebibit(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Mebibit      x) { return new Bit(x); }
    public static implicit operator Byte(Mebibit     x) { return new Byte(x); }
    public static implicit operator Gibibit(Mebibit  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Mebibit x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Mebibit  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Mebibit x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Mebibit  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Mebibit x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Mebibit  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Mebibit x) { return new Kilobyte(x); }
    public static implicit operator Mebibyte(Mebibit x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Mebibit  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Mebibit x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Mebibit  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Mebibit x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Mebibit  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Mebibit x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Mebibit  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Mebibit x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Mebibit  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Mebibit x) { return new Terabyte(x); }
}