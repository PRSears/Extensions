namespace Extender.Units.Data;

public sealed class PetaByte : Datum
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("petabyte", "PB", to => to * 1e15 * 8, from => from / 1e15 / 8); }
    }

    public PetaByte() { }
    public PetaByte(double value) { Value   = value; }
    public PetaByte(int    value) { Value   = value; }
    public PetaByte(long   value) { Value   = value; }
    public PetaByte(Datum  value) { SiValue = value.SiValue; }

    public static implicit operator Bit(PetaByte      x) { return new Bit(x); }
    public static implicit operator Byte(PetaByte     x) { return new Byte(x); }
    public static implicit operator Gibibit(PetaByte  x) { return new Gibibit(x); }
    public static implicit operator Gibibyte(PetaByte x) { return new Gibibyte(x); }
    public static implicit operator Gigabit(PetaByte  x) { return new Gigabit(x); }
    public static implicit operator Gigabyte(PetaByte x) { return new Gigabyte(x); }
    public static implicit operator Kibibit(PetaByte  x) { return new Kibibit(x); }
    public static implicit operator Kibibyte(PetaByte x) { return new Kibibyte(x); }
    public static implicit operator Kilobit(PetaByte  x) { return new Kilobit(x); }
    public static implicit operator Kilobyte(PetaByte x) { return new Kilobyte(x); }
    public static implicit operator Mebibit(PetaByte  x) { return new Mebibit(x); }
    public static implicit operator Mebibyte(PetaByte x) { return new Mebibyte(x); }
    public static implicit operator Megabit(PetaByte  x) { return new Megabit(x); }
    public static implicit operator Megabyte(PetaByte x) { return new Megabyte(x); }
    public static implicit operator Pebibit(PetaByte  x) { return new Pebibit(x); }
    public static implicit operator Pebibyte(PetaByte x) { return new Pebibyte(x); }
    public static implicit operator Petabit(PetaByte  x) { return new Petabit(x); }
    public static implicit operator Tebibit(PetaByte  x) { return new Tebibit(x); }
    public static implicit operator Tebibyte(PetaByte x) { return new Tebibyte(x); }
    public static implicit operator Terabit(PetaByte  x) { return new Terabit(x); }
    public static implicit operator Terabyte(PetaByte x) { return new Terabyte(x); }
}