namespace Extender.Units.Data;

public sealed class Gibibit : Datum
{
    public override UnitInfo Unit
    {
        // The bit shifting accomplishes raising 2 to the power of n+1.
        // 2 << 29 == 2^30 == 1024^3
        get
        {
            return new UnitInfo("gibibit", "Gib", to => to * (2L << 29), from => from / (2L << 29));
        }
    }

    public Gibibit() { }
    public Gibibit(double value) { Value   = value; }
    public Gibibit(int    value) { Value   = value; }
    public Gibibit(long   value) { Value   = value; }
    public Gibibit(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Gibibit      x) { return new Bit(x); }
    public static implicit operator Byte(Gibibit     x) { return new Byte(x); }
    public static implicit operator Gibibyte(Gibibit x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Gibibit  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Gibibit x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Gibibit  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Gibibit x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Gibibit  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Gibibit x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Gibibit  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Gibibit x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Gibibit  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Gibibit x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Gibibit  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Gibibit x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Gibibit  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Gibibit x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Gibibit  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Gibibit x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Gibibit  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Gibibit x) { return new Terabyte(x); }
}