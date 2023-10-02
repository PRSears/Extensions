namespace Extender.Date;

public static class DateTimes
{
    public static bool InRange(this DateTime date, DateTime rangeStart, DateTime rangeEnd)
    {
        return InRange(date, new Extender.Date.DateRange(rangeStart, rangeEnd));
    }

    public static bool InRange(this DateTime date, Extender.Date.DateRange range)
    {
        return range.Overlaps(date);
    }

    public static bool Elapsed(this TimeSpan span, DateTime startTime)
    {
        return (DateTime.Now - startTime) >= span;
    }

    public static bool TimeSpanElapsedSince(this DateTime startTime, TimeSpan span)
    {
        return (DateTime.Now - startTime) >= span;
    }
}