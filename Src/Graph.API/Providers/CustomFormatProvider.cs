namespace Graph.API.Providers
{
    public class CustomFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object? GetFormat(Type? formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        public string Format(string? format, object? arg, IFormatProvider? formatProvider)
        {
            if (arg == null)
            {
                return string.Empty;
            }

            string argValue = arg.ToString()!;

            if (format == null)
            {
                return argValue;
            }

            return format.ToUpper() switch
            {
                "U" => argValue.ToUpper(),
                "L" => argValue.ToLower(),

                _ => argValue
            };
        }
    }
}
