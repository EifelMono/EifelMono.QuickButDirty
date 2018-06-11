﻿using System;
using System.Collections.Generic;
using System.Linq;
using EifelMono.QuickButDirty.Log;
using Newtonsoft;
using Newtonsoft.Json;

namespace EifelMono.QuickButDirty.Extension
{
    public static class GenericExtension
    {
        #region In
        public static bool In<T>(this T value, IEnumerable<T> choices)
        {
            foreach (var choice in choices)
                if (choice.Equals(value))
                    return true;
            return false;
        }

        public static bool In<T>(this T value, params T[] choices)
        {
            return In(value, choices as IEnumerable<T>);
        }

        #endregion

        #region Out
        public static bool Out<T>(this T value, IEnumerable<T> choices)
        {
            return !In(value, choices);
        }

        public static bool Out<T>(this T value, params T[] choices)
        {
            return !In(value, choices);
        }
        #endregion

        #region InRange
        public static bool InRange<T>(this T value, T minChoice, T maxChoise) where T : IComparable
        {
            return value.CompareTo(minChoice) >= 0 && value.CompareTo(maxChoise) <= 0;
        }
        #endregion

        #region OutRange
        public static bool OutRange<T>(this T value, T minChoice, T maxChoise) where T : IComparable
        {
            return !InRange(value, minChoice, maxChoise);
        }

        #endregion

        #region PositionOf
        public static int PositionOf<T>(this T value, IEnumerable<T> compareValues)
        {
            int index = -1;
            foreach (var compareValue in compareValues)
            {
                index++;
                if (compareValue.Equals(value))
                    return index;
            }
            return -1;
        }

        public static int PositionOf<T>(this T value, params T[] compareValues)
        {
            return PositionOf(value, compareValues as IEnumerable<T>);
        }
        #endregion

        public static IEnumerable<T> Inverse<T>(this IList<T> list)
        {
            int count = list.Count;
            for (int i = count - 1; i >= 0; --i)
                yield return list[i];
        }

        public static IEnumerable<T> Inverse<T>(this T[] array)
        {
            int length = array.Length;
            for (int i = length - 1; i >= 0; --i)
                yield return array[i];
        }

        public static IEnumerable<T> Inverse<T>(this Array array)
        {
            int length = array.Length;
            for (int i = length - 1; i >= 0; --i)
                yield return (T)array.GetValue(i);
        }

        public static IEnumerable<T> Inverse<T>(this IEnumerable<T> elements)
        {
            var list = elements.ToList();
            return list.Inverse();
        }

        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0)
                return min;
            if (val.CompareTo(max) > 0)
                return max;
            return val;
        }

        #region Json/Clone
        public static T JsonClone<T>(this T value, T defaultValue = default(T))
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(value));
            }
            catch (Exception ex)
            {
                ex.LogException();
                return defaultValue;
            }
        }

        public static string ToJsonString(this object value)
        {
            try
            {
                return JsonConvert.SerializeObject(value, Formatting.Indented);
            }
            catch (Exception ex)
            {
                ex.LogException(); 
                return ex.ToString();
            }
        }
        #endregion
    }
}
