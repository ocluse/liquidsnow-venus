namespace Ocluse.LiquidSnow.Venus
{

    public static class Extensions
    {
        public static string ParseThicknessValues(this string value)
        {
            var values = value
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            if (values.Count == 1)
            {
                return values[0].ToRem();
            }
            else if (values.Count == 2)
            {
                return $"{values[1].ToRem()} {values[0].ToRem()}";
            }
            else if (values.Count == 4)
            {
                return $"{values[1].ToRem()} {values[2].ToRem()} {values[3].ToRem()} {values[0].ToRem()} {values[1].ToRem()}";
            }
            else
            {
                throw new FormatException($"Cannot format {value}. Illegal number of elements");
            }
        }

        public static string ToRem(this double value)
        {
            return $"{value / 2}rem";
        }
    }
}
