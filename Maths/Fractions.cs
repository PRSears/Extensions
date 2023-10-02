namespace Extender.Maths;

/// <summary>
/// Simple struct for storing a fractional representation of a number.
/// </summary>
public struct Fraction
{
    /// <summary>
    /// 
    /// </summary>
    public int Numerator { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int Denominator { get; private set; }

    /// <summary>
    /// The Whole (integer) part of a mixed fraction.
    /// </summary>
    public int WholePart { get; private set; }

    /// <summary>
    /// Constructs a new fraction struct from an integer numerator and denominator.
    /// </summary>
    /// <param name="numerator"></param>
    /// <param name="denominator"></param>
    public Fraction(int numerator, int denominator)
    {
        if (numerator > denominator)
        {
            WholePart   = (int) Math.Floor((double) numerator / denominator);
            Numerator   = numerator - denominator * WholePart;
            Denominator = denominator;
        }
        else
        {
            WholePart   = 0;
            Numerator   = numerator;
            Denominator = denominator;
        }
    }

    /// <summary>
    /// Converts to a human-readable string.
    /// </summary>
    /// <returns>A string of the form 'Numerator/Denominator'.</returns>
    public override string ToString()
    {
        if (WholePart == 0)
            return $"{Numerator}/{Denominator}";
        else
            return $"{WholePart} {Numerator}/{Denominator}";
    }
}

public static class Fractions
{
    // Courtesy of Kay Zed from StackOverflow: http://stackoverflow.com/a/32903747/344541
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="marginOfError"></param>
    /// <returns></returns>
    public static Fraction RealToFraction(double value, double marginOfError)
    {
        if (marginOfError <= 0.0 || marginOfError >= 1.0)
            throw new ArgumentOutOfRangeException
                (nameof(marginOfError), "Must be between 0 and 1 (exclusive).");

        int sign = Math.Sign(value);

        if (sign == -1) value = Math.Abs(value);

        if (sign != 0)
            // marginOfError is the maximum relative marginOfError; convert to absolute
            marginOfError *= value;

        int n = (int) Math.Floor(value);
        value -= n;

        if (value < marginOfError) return new Fraction(sign * n, 1);

        if (1 - marginOfError < value) return new Fraction(sign * (n + 1), 1);

        // The lower fraction is 0/1
        int lowerN = 0;
        int lowerD = 1;

        // The upper fraction is 1/1
        int upperN = 1;
        int upperD = 1;

        while (true)
        {
            // The middle fraction is (lower_n + upper_n) / (lower_d + upper_d)
            int middleN = lowerN + upperN;
            int middleD = lowerD + upperD;

            if (middleD * (value + marginOfError) < middleN)
            {
                // real + marginOfError < middle : middle is our new upper
                upperN = middleN;
                upperD = middleD;
            }
            else if (middleN < (value - marginOfError) * middleD)
            {
                // middle < real - marginOfError : middle is our new lower
                lowerN = middleN;
                lowerD = middleD;
            }
            else
            {
                // Middle is our best fraction
                return new Fraction((n * middleD + middleN) * sign, middleD);
            }
        }
    }
}