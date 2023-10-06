using System;
using System.Collections.Generic;

namespace Extender.ObjectUtils;

/// <remarks>
/// Author: Alexey Burtsev
/// https://raw.githubusercontent.com/Burtsev-Alexey/net-object-deep-copy/master/ObjectExtensions.cs
/// </remarks>
public class ReferenceEqualityComparer : EqualityComparer<object>
{
    public override bool Equals(object x, object y) { return ReferenceEquals(x, y); }

    public override int GetHashCode(object obj)
    {
        return obj != null ? obj.GetHashCode() : 0;
    }
}