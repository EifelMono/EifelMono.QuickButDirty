using System;

namespace EifelMono.QuickButDirty.Extension {
    public static partial class NumericalExtension
    {
        #region Math Double

        public static double Abs(this double value)
        {
            return Math.Abs(value);
        }

        public static double Min(this double value, double otherValue)
        {
            return Math.Min(value, otherValue);
        }

        public static double Max(this double value, double otherValue)
        {
            return Math.Max(value, otherValue);
        }

        public static bool InRangeOffset(this double value, double baseValue, double offset)
        {
            return value.InRange(baseValue - offset, baseValue + offset);
        }

	#endregion

	#region Math int

	public static double Abs(this int value)
	{
	    return Math.Abs(value);
	}

	public static double Min(this int value, int otherValue)
	{
	    return Math.Min(value, otherValue);
	}

	public static double Max(this int value, int otherValue)
	{
	    return Math.Max(value, otherValue);
	}

	public static bool InRangeOffset(this int value, int baseValue, int offset)
	{
	    return value.InRange(baseValue - offset, baseValue + offset);
	}
	#endregion
    }
}
