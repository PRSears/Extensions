namespace Extender.Units.Data;

public sealed class Byte : Datum
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("byte", "B", to => to * 8, from => from / 8); }
    }

    public Byte() { }
    public Byte(double value) { Value   = value; }
    public Byte(int    value) { Value   = value; }
    public Byte(long   value) { Value   = value; }
    public Byte(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Byte      x) { return new Bit(x); }
    public static implicit operator Gibibit(Byte  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Byte x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Byte  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Byte x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Byte  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Byte x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Byte  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Byte x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Byte  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Byte x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Byte  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Byte x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Byte  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Byte x) { return new Pebibyte(x); }
    public static implicit operator Petabit(Byte  x) { return new Petabit(x); }
    public static implicit operator PetaByte(Byte x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Byte  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Byte x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Byte  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Byte x) { return new Terabyte(x); }
}