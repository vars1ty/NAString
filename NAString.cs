using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// <b>NAString</b> is a structure which is responsible for caching and representing a set of strings, such as float -> string conversion without constant allocations.
/// </summary>
public readonly struct NAString
{
    #region Variables
    /// <summary>
    /// Dictionary which holds a decimal value as a key and a string as the display value.
    /// </summary>
    private static readonly Dictionary<decimal, string> decimalToString = new();

    /// <summary>
    /// Culture used for <c>*.ToString()</c> methods that ask for it.
    /// </summary>
    private static readonly CultureInfo culture = CultureInfo.InvariantCulture;
    #endregion

    /// <summary>
    /// Flushes the entire cache.
    /// </summary>
    public static void FlushCache() => decimalToString.Clear();

    /// <summary>
    /// Adds a new string representation of a <see cref="float"/> value to the cache.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="toStringFormat"></param>
    /// <returns><b>true</b> if added successfully, <b>false</b> if the same value is already present in the cache.</returns>
    public static bool Allocate(float value, string toStringFormat = "")
    {
        var display = string.IsNullOrEmpty(toStringFormat)
            ? value.ToString(culture)
            : value.ToString(toStringFormat);
        return decimalToString.TryAdd((decimal)value, display);
    }

    /// <summary>
    /// Adds a new string representation of a <see cref="int"/> value to the cache.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="toStringFormat"></param>
    /// <returns><b>true</b> if added successfully, <b>false</b> if the same value is already present in the cache.</returns>
    public static bool Allocate(int value, string toStringFormat = "")
    {
        var display = string.IsNullOrEmpty(toStringFormat)
            ? value.ToString(culture)
            : value.ToString(toStringFormat);
        return decimalToString.TryAdd(value, display);
    }

    /// <summary>
    /// Adds a new string representation of a <see cref="double"/> value to the cache.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="toStringFormat"></param>
    /// <returns><b>true</b> if added successfully, <b>false</b> if the same value is already present in the cache.</returns>
    public static bool Allocate(double value, string toStringFormat = "")
    {
        var display = string.IsNullOrEmpty(toStringFormat)
            ? value.ToString(culture)
            : value.ToString(toStringFormat);
        return decimalToString.TryAdd((decimal)value, display);
    }

    /// <summary>
    /// Tries to get a string representation of the specified <see cref="float"/> value from the cache.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>the <see cref="string"/> if found, otherwise <see cref="string.Empty"/>.</returns>
    public static string Borrow(float value) =>
        decimalToString.TryGetValue((decimal)value, out var f) ? f : string.Empty;

    /// <summary>
    /// Tries to get a string representation of the specified <see cref="int"/> value from the cache.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>the <see cref="string"/> if found, otherwise <see cref="string.Empty"/>.</returns>
    public static string Borrow(int value) => decimalToString.TryGetValue(value, out var i) ? i : string.Empty;

    /// <summary>
    /// Tries to get a string representation of the specified <see cref="double"/> value from the cache.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>the <see cref="string"/> if found, otherwise <see cref="string.Empty"/>.</returns>
    public static string Borrow(double value) =>
        decimalToString.TryGetValue((decimal)value, out var d) ? d : string.Empty;

    /// <summary>
    /// Checks if the cache contains a string representation of the specified <see cref="float"/> value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns><b>true</b> if it was found in the cache, <b>false</b> if it weren't.</returns>
    public static bool IsCached(float value) => decimalToString.ContainsKey((decimal)value);

    /// <summary>
    /// Checks if the cache contains a string representation of the specified <see cref="int"/> value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns><b>true</b> if it was found in the cache, <b>false</b> if it weren't.</returns>
    public static bool IsCached(int value) => decimalToString.ContainsKey(value);

    /// <summary>
    /// Checks if the cache contains a string representation of the specified <see cref="double"/> value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns><b>true</b> if it was found in the cache, <b>false</b> if it weren't.</returns>
    public static bool IsCached(double value) => decimalToString.ContainsKey((decimal)value);
}
