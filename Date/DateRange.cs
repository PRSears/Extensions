using System;

namespace Extender.Date;

public class DateRange
{
    public DateTime Start { get; set; }
    public DateTime End   { get; set; }

    public TimeSpan Span => End - Start;

    public DateRange()
    {
        Start = DateTime.MinValue;
        End   = DateTime.MaxValue;
    }

    public DateRange(DateTime start, DateTime end)
    {
        Start = start;
        End   = end;
    }

    public bool Overlaps(DateTime date) { return date >= Start && date <= End; }

    public bool Inside(DateRange outerRange)
    {
        return outerRange.Start <= Start && outerRange.End >= End;
    }

    public bool Inside(DateTime start, DateTime end) { return Inside(new DateRange(start, end)); }

    public bool Intersects(DateRange other)
    {
        return (other.Start <= Start && other.End >= End) || // this falls completely inside other
               (Start >= other.Start &&
                Start <= other.End) || // this starts inside other, but continues past
               (End <= other.End &&
                End >= other.Start); // this ends inside other, but starts before it
    }

    public bool Intersects(DateTime start, DateTime end)
    {
        return Intersects(new DateRange(start, end));
    }

    public override string ToString()
    {
        return $"({Start.ToString("YYYY-MM-dd HH:mm:ss")}) ==> " +
               $"({End.ToString("YYYY-MM-dd HH:mm:ss")})";
    }

    public override bool Equals(object obj)
    {
        if (!(obj is DateRange))
            return false;

        var other = (DateRange) obj;

        return Start == other.Start && End == other.End;
    }

    public override int GetHashCode()
    {
        byte[][] blocks = new byte[2][];

        blocks[0] = BitConverter.GetBytes(Start.Ticks);
        blocks[1] = BitConverter.GetBytes(End.Ticks);

        return BitConverter.ToInt32(ObjectUtils.Hashing.GenerateHashCode(blocks), 0);
    }
}