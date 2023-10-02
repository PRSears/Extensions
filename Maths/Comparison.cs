namespace Extender.Maths;

public static class Comparison
{
    public static bool RoughEquals(this double a, double b, double s = 1e-6)
    {
        return Math.Abs(a - b) < s;
    }

    public static bool RoughEquals(this int a, double b, double s = 1e-6)
    {
        return Math.Abs(a - b) < s;
    }

    public static bool RoughEquals(this double a, int b, double s = 1e-6)
    {
        return RoughEquals(b, a, s);
    }

    public static bool RoughEquals(this long a, double b, double s = 1e-6)
    {
        return Math.Abs(a - b) < s;
    }

    public static bool RoughEquals(this double a, long b, double s = 1e-6)
    {
        return RoughEquals(b, a, s);
    }

    public static bool RoughEquals(this float a, double b, double s = 1e-6)
    {
        return Math.Abs(a - b) < s;
    }

    public static bool RoughEquals(this double a, float b, double s = 1e-6)
    {
        return RoughEquals(b, a, s);
    }

    public static bool RoughEquals(this float a, float b, double s = 1e-6)
    {
        return Math.Abs(a - b) < s;
    }

    public static bool RoughEquals(this float? a, float? b, double s = 1e-6)
    {
        if (a == null || b == null) return a == null && b == null;

        return RoughEquals((float) a, (float) b, s);
    }

    public static bool RoughEquals(this float? a, double? b, double s = 1e-6)
    {
        if (a == null || b == null) return a == null && b == null;

        return RoughEquals((float) a, (double) b, s);
    }

    public static bool RoughEquals(this double? a, float? b, double s = 1e-6)
    {
        if (a == null || b == null) return a == null && b == null;

        return RoughEquals((double) a, (float) b, s);
    }

    public static bool RoughEquals(this float a, float? b, double s = 1e-6)
    {
        return b != null && RoughEquals(a, (float) b, s);
    }

    public static bool RoughEquals(this float? a, float b, double s = 1e-6)
    {
        return a != null && RoughEquals((float) a, b, s);
    }
}