using System.Globalization;
using System.Numerics;

namespace Ocluse.LiquidSnow.Venus
{
    public static class Extensions
    {
        public static string ToKMB<T>(this T num, CultureInfo? cultureInfo = null) where T : INumber<T>
        {
            T trillion = T.Parse("999999999999", cultureInfo);
            T billion = T.Parse("999999999", cultureInfo);
            T million = T.Parse("999999", cultureInfo);
            T thousand = T.Parse("999", cultureInfo);

            if (num > trillion || num < -trillion)
            {
                return num.ToString("0,,,,.###T", cultureInfo);
            }

            else if (num > billion || num < -billion)
            {
                return num.ToString("0,,,.###B", cultureInfo);
            }
            else
            if (num > million || num < -million)
            {
                return num.ToString("0,,.##M", cultureInfo);
            }
            else
            if (num > thousand || num < -thousand)
            {
                return num.ToString("0,.#K", cultureInfo);
            }
            else
            {
                return num.ToString(format: null, formatProvider: cultureInfo);
            }
        }
    }
}
