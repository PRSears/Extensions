namespace Extender.Units.Data;

public sealed class Petabit : Datum
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("petabit", "Pb", to => to * 1e15, from => from / 1e15); }
    }

    public Petabit() { }
    public Petabit(double value) { Value   = value; }
    public Petabit(int    value) { Value   = value; }
    public Petabit(long   value) { Value   = value; }
    public Petabit(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(Petabit      x) { return new Bit(x); }
    public static implicit operator Byte(Petabit     x) { return new Byte(x); }
    public static implicit operator Gibibit(Petabit  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(Petabit x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(Petabit  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(Petabit x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(Petabit  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(Petabit x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(Petabit  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(Petabit x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(Petabit  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(Petabit x) { return new Mebibyte(x); }
    public static implicit operator Megabit(Petabit  x) { return new Megabit(x); }
    public static implicit operator Megabyte(Petabit x) { return new Megabyte(x); }
    public static implicit operator Pebibit(Petabit  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(Petabit x) { return new Pebibyte(x); }
    public static implicit operator PetaByte(Petabit x) { return new PetaByte(x); }
    public static implicit operator Tebibit(Petabit  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(Petabit x) { return new Tebibyte(x); }
    public static implicit operator Terabit(Petabit  x) { return new Terabit(x); }
    public static implicit operator Terabyte(Petabit x) { return new Terabyte(x); }
}