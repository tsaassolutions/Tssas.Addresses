using Tssas.Addresses.Exceptions;
using Tssas.Addresses.Formatting;

namespace Tssas.ValueObjects.Address
{
    /// <summary>
    /// Value Object representing a complete address.
    /// </summary>
    public sealed class Address : IEquatable<Address>
    {
        /// <summary>
        /// Gets the type of the street (e.g., "Rua", "Avenida").
        /// </summary>
        public string? Type { get; }

        /// <summary>
        /// Gets the street name.
        /// </summary>
        public string Street { get; }

        /// <summary>
        /// Gets the address number.
        /// </summary>
        public string? Number { get; }

        /// <summary>
        /// Gets the district or neighborhood name.
        /// </summary>
        public string District { get; }

        /// <summary>
        /// Gets the complement information (e.g., apartment number, building name).
        /// </summary>
        public string? Complement { get; }

        /// <summary>
        /// Gets the city name.
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Gets the state or province name.
        /// </summary>
        public string State { get; }

        /// <summary>
        /// Gets the country name.
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Gets the ISO 3166-1 alpha-2 country code.
        /// </summary>
        public string CountryCode { get; }

        /// <summary>
        /// Gets the ZIP code or postal code.
        /// </summary>
        public string ZipCode { get; }

        /// <summary>
        /// Gets the IBGE municipality code (Brazilian municipalities).
        /// </summary>
        public string? MunicipalityIbge { get; }

        /// <summary>
        /// Gets the IBGE state code (Brazilian states).
        /// </summary>
        public string? StateIbge { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="street">The street name (required).</param>
        /// <param name="district">The district or neighborhood name (required).</param>
        /// <param name="city">The city name (required).</param>
        /// <param name="state">The state or province name (required).</param>
        /// <param name="country">The country name (required).</param>
        /// <param name="countryCode">The ISO 3166-1 alpha-2 country code (required).</param>
        /// <param name="zipCode">The ZIP code or postal code (required).</param>
        /// <param name="type">The street type (optional).</param>
        /// <param name="number">The address number (optional).</param>
        /// <param name="municipalityIbge">The IBGE municipality code (optional).</param>
        /// <param name="stateIbge">The IBGE state code (optional).</param>
        /// <param name="complement">The complement information (optional).</param>
        /// <exception cref="InvalidAddressException">Thrown when any required field is null or whitespace.</exception>
        public Address(
            string street,
            string district,
            string city,
            string state,
            string country,
            string countryCode,
            string zipCode,
            string? type = null,
            string? number = null,
            string? municipalityIbge = null,
            string? stateIbge = null,
            string? complement = null)
        {
            // Normalize empty strings to null
            type = string.IsNullOrWhiteSpace(type) ? null : type;
            number = string.IsNullOrWhiteSpace(number) ? null : number;
            municipalityIbge = string.IsNullOrWhiteSpace(municipalityIbge) ? null : municipalityIbge;
            stateIbge = string.IsNullOrWhiteSpace(stateIbge) ? null : stateIbge;
            complement = string.IsNullOrWhiteSpace(complement) ? null : complement;

            // Validate required fields
            if (string.IsNullOrWhiteSpace(street))
                throw new InvalidAddressException("Street cannot be empty.", nameof(street));
            if (string.IsNullOrWhiteSpace(district))
                throw new InvalidAddressException("District cannot be empty.", nameof(district));
            if (string.IsNullOrWhiteSpace(city))
                throw new InvalidAddressException("City cannot be empty.", nameof(city));
            if (string.IsNullOrWhiteSpace(state))
                throw new InvalidAddressException("State cannot be empty.", nameof(state));
            if (string.IsNullOrWhiteSpace(country))
                throw new InvalidAddressException("Country cannot be empty.", nameof(country));
            if (string.IsNullOrWhiteSpace(countryCode))
                throw new InvalidAddressException("Country code cannot be empty.", nameof(countryCode));
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new InvalidAddressException("ZipCode cannot be empty.", nameof(zipCode));

            // Assign properties with trimming
            Type = type?.Trim();
            Street = street.Trim();
            Number = number?.Trim();
            District = district.Trim();
            City = city.Trim();
            State = state.Trim();
            Country = country.Trim();
            CountryCode = AddressFormatter.NormalizeCountryCode(countryCode);
            ZipCode = AddressFormatter.CleanZipCode(zipCode);
            MunicipalityIbge = municipalityIbge?.Trim();
            StateIbge = stateIbge?.Trim();
            Complement = complement?.Trim();
        }

        /// <summary>
        /// Gets the address display combining Type and Street (e.g., "Rua das Flores").
        /// </summary>
        public string StreetDisplay => AddressFormatter.FormatStreetDisplay(Type, Street);

        /// <summary>
        /// Formats the ZIP code to the Brazilian pattern (xxxxx-xxx).
        /// </summary>
        /// <returns>The formatted ZIP code.</returns>
        public string FormatZipCode()
        {
            return AddressFormatter.FormatBrazilianZipCode(ZipCode);
        }

        /// <summary>
        /// Returns the complete formatted address as a single string.
        /// </summary>
        /// <returns>The full address string including all components.</returns>
        public string FullAddress()
        {
            return AddressFormatter.BuildFullAddress(
                Type, Street, Number, Complement, District, City, State, Country, ZipCode);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Address"/> is equal to the current address.
        /// </summary>
        /// <param name="other">The address to compare with the current address.</param>
        /// <returns>true if the specified address is equal to the current address; otherwise, false.</returns>
        public bool Equals(Address? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return Type == other.Type &&
                   Street == other.Street &&
                   Number == other.Number &&
                   District == other.District &&
                   Complement == other.Complement &&
                   City == other.City &&
                   State == other.State &&
                   Country == other.Country &&
                   CountryCode == other.CountryCode &&
                   ZipCode == other.ZipCode &&
                   MunicipalityIbge == other.MunicipalityIbge &&
                   StateIbge == other.StateIbge;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current address.
        /// </summary>
        /// <param name="obj">The object to compare with the current address.</param>
        /// <returns>true if the specified object is equal to the current address; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Address other && Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this address.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Type);
            hash.Add(Street);
            hash.Add(Number);
            hash.Add(District);
            hash.Add(Complement);
            hash.Add(City);
            hash.Add(State);
            hash.Add(Country);
            hash.Add(CountryCode);
            hash.Add(ZipCode);
            hash.Add(MunicipalityIbge);
            hash.Add(StateIbge);
            return hash.ToHashCode();
        }

        /// <summary>
        /// Determines whether two specified addresses have the same value.
        /// </summary>
        /// <param name="left">The first address to compare, or null.</param>
        /// <param name="right">The second address to compare, or null.</param>
        /// <returns>true if the value of left is the same as the value of right; otherwise, false.</returns>
        public static bool operator ==(Address? left, Address? right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Determines whether two specified addresses have different values.
        /// </summary>
        /// <param name="left">The first address to compare, or null.</param>
        /// <param name="right">The second address to compare, or null.</param>
        /// <returns>true if the value of left is different from the value of right; otherwise, false.</returns>
        public static bool operator !=(Address? left, Address? right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Returns a string representation of the address.
        /// </summary>
        /// <returns>The full formatted address string.</returns>
        public override string ToString()
        {
            return FullAddress();
        }
    }
}
