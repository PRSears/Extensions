namespace Extender.Units.Data;

public sealed class Kibibit : Datum
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("kibibit", "Kib", to => to * 1024, from => from / 1024); }
    }

    public Kibibit() { }
    public Kibibit(double value) { Value   = value; }
    public Kibibit(int    value) { Value   = value; }
    public Kibibit(long   value) { Value   = value; }
    public Kibibit(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Kibibit      x) { return new Bit(x); }
    public static implicit operator Byte(Kibibit     x) { return new Byte(x); }
    public static implicit operator Gibibit(Kibibit  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Kibibit x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Kibibit  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Kibibit x) { return new Gigabyte(x); }
    public static implicit operator Kibibyte(Kibibit x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Kibibit  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Kibibit x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Kibibit  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Kibibit x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Kibibit  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Kibibit x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Kibibit  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Kibibit x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Kibibit  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Kibibit x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Kibibit  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Kibibit x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Kibibit  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Kibibit x) { return new Terabyte(x); }
}