using System;
using System.Collections.Generic;
using System.Text;

namespace EifelMono.QuickButDirty.Extension
{
    public static class ConvertExtension {

	public static (bool Error, bool Value) ToBoolean(this string value)
	    => bool.TryParse(value, out bool Value) ? (false, Value) : (true, false);

	public static (bool Error, double Value) ToDouble(this string value) 
	    => double.TryParse(value, out double Value) ? (false, Value) : (true, 0);

	public static (bool Error, int Value) ToInt(this string value)
	    => int.TryParse(value, out int Value) ? (false, Value) : (true, 0);
    } 
}
