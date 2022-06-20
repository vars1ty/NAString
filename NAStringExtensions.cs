/// <summary>
/// Extensions for <see cref="NAString"/>.
/// </summary>
public static class NAStringExtensions
{
    /// <summary>
    /// Checks if the value is found in the <see cref="NAString"/> cache, if not, it will be added and then returned.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="format"></param>
    /// <returns>The cached value if found, otherwise it will be added and returned.</returns>
    public static string ToNAString(this float value, string format = "")
    {
        if (NAString.IsCached(value)) return NAString.Borrow(value);
        NAString.Allocate(value, format);
        return NAString.Borrow(value);
    }

    /// <summary>
    /// Checks if the value is found in the <see cref="NAString"/> cache, if not, it will be added and then returned.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="format"></param>
    /// <returns>The cached value if found, otherwise it will be added and returned.</returns>
    public static string ToNAString(this int value, string format = "")
    {
        if (NAString.IsCached(value)) return NAString.Borrow(value);
        NAString.Allocate(value, format);
        return NAString.Borrow(value);
    }

    /// <summary>
    /// Checks if the value is found in the <see cref="NAString"/> cache, if not, it will be added and then returned.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="format"></param>
    /// <returns>The cached value if found, otherwise it will be added and returned.</returns>
    public static string ToNAString(this double value, string format = "")
    {
        if (NAString.IsCached(value)) return NAString.Borrow(value);
        NAString.Allocate(value, format);
        return NAString.Borrow(value);
    }
}
