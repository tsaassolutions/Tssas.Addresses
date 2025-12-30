namespace Tssas.Addresses.Formatting
{
    /// <summary>
    /// Provides formatting utilities for address components.
    /// </summary>
    public static class AddressFormatter
    {
        /// <summary>
        /// Formats a Brazilian ZIP code to the pattern xxxxx-xxx.
        /// </summary>
        /// <param name="zipCode">The ZIP code without formatting.</param>
        /// <returns>The formatted ZIP code.</returns>
        public static string FormatBrazilianZipCode(string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
                return zipCode;

            var cleanZipCode = CleanZipCode(zipCode);

            if (cleanZipCode.Length == 8)
                return $"{cleanZipCode.Substring(0, 5)}-{cleanZipCode.Substring(5, 3)}";

            return cleanZipCode;
        }

        /// <summary>
        /// Removes formatting characters from a ZIP code.
        /// </summary>
        /// <param name="zipCode">The ZIP code with or without formatting.</param>
        /// <returns>The ZIP code with only digits.</returns>
        public static string CleanZipCode(string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
                return string.Empty;

            return zipCode.Replace("-", "").Replace(".", "").Replace(" ", "").Trim();
        }

        /// <summary>
        /// Formats the street display by combining type and street name.
        /// </summary>
        /// <param name="type">The street type (e.g., "Rua", "Avenida").</param>
        /// <param name="street">The street name.</param>
        /// <returns>The formatted street display.</returns>
        public static string FormatStreetDisplay(string? type, string street)
        {
            if (string.IsNullOrWhiteSpace(type))
                return street;

            return $"{type} {street}";
        }

        /// <summary>
        /// Builds a full formatted address string.
        /// </summary>
        /// <param name="type">The street type.</param>
        /// <param name="street">The street name.</param>
        /// <param name="number">The address number.</param>
        /// <param name="complement">The address complement.</param>
        /// <param name="district">The district.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="country">The country.</param>
        /// <param name="zipCode">The ZIP code.</param>
        /// <returns>The full formatted address.</returns>
        public static string BuildFullAddress(
            string? type,
            string street,
            string? number,
            string? complement,
            string district,
            string city,
            string state,
            string country,
            string zipCode)
        {
            var address = FormatStreetDisplay(type, street);

            if (!string.IsNullOrWhiteSpace(number))
                address += $", {number}";
            else
                address += ", S/N";

            if (!string.IsNullOrWhiteSpace(complement))
                address += $" - {complement}";

            address += $", {district}, {city} - {state}, {country}, CEP: {FormatBrazilianZipCode(zipCode)}";

            return address;
        }

        /// <summary>
        /// Normalizes a country code to uppercase (ISO 3166-1 alpha-2).
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>The normalized country code in uppercase.</returns>
        public static string NormalizeCountryCode(string countryCode)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
                return string.Empty;

            return countryCode.ToUpperInvariant().Trim();
        }
    }
}
