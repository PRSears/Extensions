using System;
using System.Text;

namespace Extender.Units;

// TODO convert to nullable values ... This'll be a real pain in the ass.
// TODO Add new units:
//      - Bits (kilo, mega, giga, tera, peta)
//      - Bytes (kilo, mega, giga, tera, peta, kibi, gibi, tibi, pibi)
//      - bitrates (bps, kbps, Mbps, Gbps, Tbps, Bps, kBps, MBps, GBps, TBps)
//      - ~~Rotations~~
//      - Time (?) Do I really need another abstraction layer for DateTime?
// ... fml

// TODO (bash?) script to generate the casting operator overloads

/// <summary>
/// Abstract representation of a qualitative property with a unit.
/// </summary>
public abstract class Measure
{
    /// <summary>
    /// Gets or sets the actual stored value, in appropriate SI units.
    /// </summary>
    public double SiValue { get; set; }

    /// <summary>
    /// Gets or sets the converted value for this specific implementation of measure.
    /// </summary>
    public double Value
    {
        get => Unit.Converter.ConvertFromSi(SiValue);
        set => SiValue = Unit.Converter.ConvertToSi(value);
    }

    /// <summary>
    /// Gets information pertaining to the units of this Measure.
    /// </summary>
    public abstract UnitInfo Unit { get; }

    /// <summary>
    /// Gets or sets the acceptable margin of error for equality comparison. 
    /// </summary>
    public double Sigma { get; set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public Measure() { Sigma = 0.000001d; }

    /// <summary>
    /// Converts this Measure to the specified type.
    /// </summary>
    /// <typeparam name="TOut">Type of Measure to cast this object to.</typeparam>
    /// <returns>
    /// Converted object of type TOut.
    /// </returns>
    public virtual TOut ConvertTo<TOut>() where TOut : Measure, new()
    {
        return new TOut { SiValue = SiValue };
    }

    /// <summary>
    /// Converts this Measure to the specified type.
    /// </summary>
    /// <typeparam name="TOut">Type of Measure to cast this object to.</typeparam>
    /// <typeparam name="TVerify">
    /// Convert will only be performed if TOut is a type of TVerify.
    /// (Used as a sanity check to make sure a temperature cannot be converted to distance, etc.)
    /// </typeparam>
    /// <returns>Converted object of type TOut.</returns>
    protected TOut ConvertTo<TOut, TVerify>() where TOut : Measure, new() where TVerify : Measure
    {
        var converted = new TOut();

        if (converted.IsNotA<TVerify>())
            throw new Exceptions.TypeArgumentException
                ($"TOut must be a type of {typeof(TVerify)}.", "TOut");

        converted.SiValue = SiValue;

        return converted;
    }

    /// <summary>
    /// Converts a value from one unit to another.
    /// </summary>
    /// <typeparam name="TIn">Type (unit) of measure value starts in.</typeparam>
    /// <typeparam name="TOut">Type (unit) of measure value should be converted to.</typeparam>
    /// <param name="value">The value (in units of TIn) to convert to units of TOut.</param>
    /// <returns>The converted value.</returns>
    public static double Convert<TIn, TOut>(double value)
    where TIn : Measure, new() where TOut : Measure, new()
    {
        var constructed = new TIn { Value = value };

        return constructed.ConvertTo<TOut>().Value;
    }

    /// <summary>
    /// Converts a value from one unit to another.
    /// </summary>
    /// <typeparam name="TIn">Type (unit) of measure value starts in.</typeparam>
    /// <typeparam name="TOut">Type (unit) of measure value should be converted to.</typeparam>
    /// <param name="value">The value (in units of TIn) to convert to units of TOut.</param>
    /// <returns>The converted value.</returns>
    public static double? Convert<TIn, TOut>(double? value)
    where TIn : Measure, new() where TOut : Measure, new()
    {
        if (!value.HasValue) return null;

        var constructed = new TIn { Value = value.Value };

        return constructed.ConvertTo<TOut>().Value;
    }

    /// <returns>
    /// Hash of the value and unit.
    /// </returns>
    public override int GetHashCode()
    {
        byte[][] blocks = new byte[2][];

        blocks[0] = BitConverter.GetBytes(SiValue);
        blocks[1] = BitConverter.GetBytes(Unit.GetHashCode());

        return BitConverter.ToInt32(ObjectUtils.Hashing.GenerateHashCode(blocks), 0);
    }

    /// <summary>
    /// Checks for equality within an acceptable margin of error (this.Sigma).
    /// </summary>
    public override bool Equals(object obj)
    {
        if (!(obj is Measure))
            return false;

        var b = (Measure) obj;

        return Math.Abs(SiValue - b.SiValue) < Sigma;
    }

    /// <summary>
    /// Checks for equality within the provided tolerance.
    /// </summary>
    public bool Equals(object obj, double tolerance)
    {
        if (!(obj is Measure))
            return false;

        var b = (Measure) obj;

        return Math.Abs(SiValue - b.SiValue) < tolerance;
    }

    /// <returns>
    /// String representation of this Measure.
    /// </returns>
    public override string ToString() { return $"{Value}{Unit.Symbol}"; }

    /// <returns>
    /// String representation of this Measure.
    /// </returns>
    public string ToString(string formatSpecifier)
    {
        return $"{Value.ToString(formatSpecifier)}{Unit.Symbol}";
    }
}

/// <summary>
/// Class used to store information about a specific unit of measure.
/// </summary>
public class UnitInfo
{
    /// <summary>
    /// Gets the name of the unit.
    /// </summary>
    public readonly string Label;

    /// <summary>
    /// Gets the symbol of this unit used in short form (abbreviation).
    /// </summary>
    public readonly string Symbol;

    /// <summary>
    /// Gets the converter object.
    /// </summary>
    public readonly Converter Converter;

    /// <summary>
    /// Constructs a new UnitInfo object.
    /// </summary>
    /// <param name="label">The name of this unit.</param>
    /// <param name="symbol">The symbol of this unit used in short forms or abbreviations.</param>
    /// <param name="toSi">Function for converting this unit to SI base unit.</param>
    /// <param name="fromSi">Function for converting SI base units to this unit.</param>
    public UnitInfo
        (string label, string symbol, Func<double, double> toSi, Func<double, double> fromSi)
    {
        Label     = label;
        Symbol    = symbol;
        Converter = new Converter(toSi, fromSi);
    }

    /// <returns>
    /// This unit's label.
    /// </returns>
    public override string ToString() { return Label; }

    /// <returns>
    /// Hash of this TemperatureUnit's properties.
    /// </returns>
    public override int GetHashCode()
    {
        byte[][] blocks = new byte[2][];

        blocks[0] = Encoding.Default.GetBytes(Label);
        blocks[1] = Encoding.Default.GetBytes(Symbol);

        return BitConverter.ToInt32(ObjectUtils.Hashing.GenerateHashCode(blocks), 0);
    }

    /// <summary>
    /// Uses the result of TemperatureUnit.GetHashCode() to check equality with another object.
    /// </summary>
    public override bool Equals(object obj)
    {
        if (obj is not UnitInfo unitInfo)
            return false;

        return GetHashCode().Equals(unitInfo.GetHashCode());
    }
}

/// <summary>
/// Wrapper object for functions converting to and from SI units.
/// </summary>
public class Converter
{
    private readonly Func<double, double> _ToSi;
    private readonly Func<double, double> _FromSi;

    /// <summary>
    /// Constructs a new Converter object.
    /// </summary>
    /// <param name="convertToSi">Function for converting to SI units.</param>
    /// <param name="convertFromSi">Function for converting from SI units. </param>
    public Converter(Func<double, double> convertToSi, Func<double, double> convertFromSi)
    {
        _ToSi   = convertToSi;
        _FromSi = convertFromSi;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public double ConvertToSi(double value)
    {
        double? tmpVal = _ToSi?.Invoke(value);

        return tmpVal ?? value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public double ConvertFromSi(double value)
    {
        double? tmpVal = _FromSi?.Invoke(value);

        return tmpVal ?? value;
    }
}