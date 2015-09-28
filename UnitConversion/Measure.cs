using System;
using System.Text;

namespace Extender.UnitConversion
{
    /// <summary>
    /// Abstract representation of a qualitative property with a unit.
    /// </summary>
    public abstract class Measure
    {
        /// <summary>
        /// Gets or sets the actual stored value, in appropriate SI units.
        /// </summary>
        public decimal SIValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the converted value for this specific implementation of measure.
        /// </summary>
        public virtual decimal Value
        {
            get
            {
                return Unit.Converter.ConvertFromSI(SIValue);
            }
            set
            {
                SIValue = Unit.Converter.ConvertToSI(value);
            }
        }

        /// <summary>
        /// Gets information pertaining to the units of this Measure.
        /// </summary>
        public abstract UnitInfo Unit
        {
            get;
        }

        /// <summary>
        /// Gets or sets the acceptable margin of error for equality comparison. 
        /// </summary>
        public decimal Sigma
        {
            get;
            set;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Measure()
        {
            Sigma = 0.000001m;
        }

        /// <summary>
        /// Converts this Measure to the specified type.
        /// </summary>
        /// <typeparam name="TOut">Type of Measure to cast this object to.</typeparam>
        /// <returns>
        /// Converted object of type TOut.
        /// </returns>
        public virtual TOut ConvertTo<TOut>()
            where TOut : Measure, new()
        {
            TOut converted = new TOut();
            converted.SIValue = this.SIValue;

            return converted;
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
        protected TOut ConvertTo<TOut, TVerify>()
            where TOut : Measure, new()
            where TVerify : Measure
        {
            TOut converted = new TOut();

            if(converted.IsNotA<TVerify>())
                throw new Exceptions.TypeArgumentException($"TOut must be a type of {typeof(TVerify).ToString()}.", "TOut");

            converted.SIValue = this.SIValue;

            return converted;
        }

        /// <returns>
        /// Hash of the value and unit.
        /// </returns>
        public override int GetHashCode()
        {
            byte[][] blocks = new byte[2][];

            blocks[0] = BitConverterEx.GetBytes(SIValue);
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

            Measure b = (Measure)obj;

            return Math.Abs(this.SIValue - b.SIValue) < Sigma;
        }

        /// <summary>
        /// Checks for equality within the provided tolerance.
        /// </summary>
        public bool Equals(object obj, decimal tolerance)
        {
            if (!(obj is Measure))
                return false;

            Measure b = (Measure)obj;

            return Math.Abs(this.SIValue - b.SIValue) < tolerance;
        }

        /// <returns>
        /// String representation of this Measure.
        /// </returns>
        public override string ToString()
        {
            return $"{Value}{Unit.Symbol}";
        }

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
        public string Label
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the symbol of this unit used in short form (abbreviation).
        /// </summary>
        public string Symbol
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the converter object.
        /// </summary>
        public Converter Converter
        {
            get;
            protected set;
        }

        /// <summary>
        /// Constructs a new UnitInfo object.
        /// </summary>
        /// <param name="label">The name of this unit.</param>
        /// <param name="symbol">The symbol of this unit used in short forms or abbreviations.</param>
        /// <param name="toSI">Function for converting this unit to SI base unit.</param>
        /// <param name="fromSI">Function for converting SI base units to this unit.</param>
        public UnitInfo(string label, string symbol, Func<decimal, decimal> toSI, Func<decimal, decimal> fromSI)
        {
            this.Label      = label;
            this.Symbol     = symbol;
            this.Converter  = new Converter(toSI, fromSI);
        }

        /// <returns>
        /// This unit's label.
        /// </returns>
        public override string ToString()
        {
            return Label;
        }

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
            if (!(obj is UnitInfo))
                return false;

            return this.GetHashCode().Equals((obj as UnitInfo).GetHashCode());
        }
    }

    /// <summary>
    /// Wrapper object for functions converting to and from SI units.
    /// </summary>
    public class Converter
    {
        private Func<decimal, decimal> ToSI;
        private Func<decimal, decimal> FromSI;

        /// <summary>
        /// Constructs a new Converter object.
        /// </summary>
        /// <param name="convertToSI">Function for converting to SI units.</param>
        /// <param name="convertFromSI">Function for converting from SI units. </param>
        public Converter(Func<decimal, decimal> convertToSI, Func<decimal, decimal> convertFromSI)
        {
            ToSI    = convertToSI;
            FromSI  = convertFromSI;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public decimal ConvertToSI(decimal value)
        {
            decimal? tmpVal = ToSI?.Invoke(value);

            return tmpVal.HasValue ? tmpVal.Value : value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public decimal ConvertFromSI(decimal value)
        {
            decimal? tmpVal = FromSI?.Invoke(value);

            return tmpVal.HasValue ? tmpVal.Value : value;
        }
    }
}
