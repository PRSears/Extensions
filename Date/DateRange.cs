using System;

namespace Extender.Date
{
    public class DateRange
    {
        public DateTime Start
        {
            get;
            set;
        }
        public DateTime End
        {
            get;
            set;
        }

        public TimeSpan Span
        {
            get
            {
                return End - Start;
            }
        }

        public DateRange()
        {
            this.Start  = DateTime.MinValue;
            this.End    = DateTime.MaxValue;
        }

        public DateRange(DateTime start, DateTime end)
        {
            this.Start  = start;
            this.End    = end;
        }

        public bool Overlaps(DateTime date)
        {
            return (date >= this.Start && date <= this.End);
        }

        public bool Inside(DateRange outerRange)
        {
            return  outerRange.Start <= this.Start &&
                    outerRange.End   >= this.End;
        }
        public bool Inside(DateTime start, DateTime end)
        {
            return this.Inside(new DateRange(start, end));
        }

        public bool Intersects(DateRange other)
        {
            return  (other.Start <= this.Start && other.End >= this.End) || // this falls completely inside other
                    (Start >= other.Start && Start <= other.End)         || // this starts inside other, but continues past
                    (End <= other.End && End >= other.Start);               // this ends inside other, but starts before it
        }

        public bool Intersects(DateTime start, DateTime end)
        {
            return this.Intersects(new DateRange(start, end));
        }

        public override string ToString()
        {
            return
                $"({this.Start.ToString("YYYY-MM-dd HH:mm:ss")}) ==> " +
                $"({this.End.ToString("YYYY-MM-dd HH:mm:ss")})";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DateRange))
                return false;

            DateRange other = (DateRange)obj;

            return  this.Start == other.Start &&
                    this.End   == other.End;
        }

        public override int GetHashCode()
        {
            byte[][] blocks = new byte[2][];

            blocks[0] = BitConverter.GetBytes(this.Start.Ticks);
            blocks[1] = BitConverter.GetBytes(this.End.Ticks);

            return BitConverter.ToInt32(ObjectUtils.Hashing.GenerateHashCode(blocks), 0);
        }
    }
}
