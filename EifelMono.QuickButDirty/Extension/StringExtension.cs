using EifelMono.QuickButDirty.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace EifelMono.QuickButDirty.Extension {
    public static class StringExtension {
	#region ...
	public static bool IsNullOrEmpty(this string value) =>
	    string.IsNullOrEmpty(value);

	public static bool IsNull(this string value) =>
	    value == null;

	public static bool IsEmpty(this string value) =>
	    value != null ? value == "" : false;
	#endregion 

	#region InContains
	public static bool InContains(this string value, IEnumerable<string> choices)
	{
	    foreach (var choice in choices)
		if (value.Contains(choice))
		    return true;
	    return false;
	}

	public static bool InContains(this string value, params string[] choices)
	{
	    return InContains(value, choices as IEnumerable<string>);
	}
	#endregion

	#region InStartsWith
	public static bool InStartsWith(this string value, IEnumerable<string> choices)
	{
	    foreach (string choice in choices)
		if (value.StartsWith(choice))
		    return true;
	    return false;
	}

	public static bool InStartsWith(this string value, params string[] choices)
	{
	    return InStartsWith(value, choices as IEnumerable<string>);
	}
	#endregion

	#region InEndsWith
	public static bool InEndsWith(this string value, IEnumerable<string> choices)
	{
	    foreach (var choice in choices)
		if (value.EndsWith(choice, StringComparison.Ordinal))
		    return true;
	    return false;
	}

	public static bool InEndsWith(this string value, params string[] choices)
	{
	    return InEndsWith(value, choices as IEnumerable<string>);
	}
	#endregion

	#region Dot...
	public static string DotPart(this string value, bool dir = true, int index = 0, int range = 1)
	{
	    if (string.IsNullOrEmpty(value))
		return "";
	    var items = value.Split('.');

	    string result = "";
	    int pos = dir ? 0 + index : items.Length - index - range;
	    for (int i = index; i < index + range; i++) {
		if (pos.InRange(0, items.Length - 1))
		    result += (result.Length == 0 ? "" : ".") + items[pos];
		pos++;
	    }
	    return result;
	}

	public static string DotFirst(this string value, int range = 1)
	{
	    return value.DotPart(true, 0, range);
	}

	public static string DotLast(this string value, int range = 1)
	{
	    return value.DotPart(false, 0, range);
	}

	#endregion

	#region SubString
	public static string Before(this string value, string search)
	{
	    int pos = value.IndexOf(search, StringComparison.Ordinal);
	    return pos != -1 ? value.Substring(0, pos) : "";
	}

	public static string LastBefore(this string value, string search)
	{
	    int pos = value.LastIndexOf(search, StringComparison.Ordinal);
	    return pos != -1 ? value.Substring(0, pos) : "";
	}

	public static string After(this string value, string search)
	{
	    int pos = value.IndexOf(search, StringComparison.Ordinal);
	    return pos != -1 ? value.Substring(pos + search.Length) : "";
	}

	public static string LastAfter(this string value, string search)
	{
	    int pos = value.LastIndexOf(search, StringComparison.Ordinal);
	    return pos != -1 ? value.Substring(pos + search.Length) : "";
	}
	#endregion

	#region Url
	public static string UrlCombine(this string url, params string[] paths)
	{
	    return url.TrimEnd('/') + '/' + paths.Aggregate(
		(furl, path) => string.Format("{0}/{1}", furl.TrimEnd('/'), path.TrimStart('/').TrimEnd('/'))).TrimStart('/').TrimEnd('/');
	}
	#endregion
    }
}

