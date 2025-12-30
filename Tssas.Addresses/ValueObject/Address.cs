using Tssas.Addresses.Exceptions;
using Tssas.Addresses.Formatting;

namespace Tssas.ValueObjects.Address
{
    /// <summary>
    /// Value Object representing a complete address.
    /// </summary>
    public sealed class Address : IEquatable<Address>
    {
        public string? Type { get; }
        public string Street { get; }
        public string? Number { get; }
        public string District { get; }
        public string? Complement { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public string CountryCode { get; }
        public string ZipCode { get; }
        public string? MunicipalityIbge { get; }
        public string? StateIbge { get; }

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

        public string FormatZipCode()
        {
            return AddressFormatter.FormatBrazilianZipCode(ZipCode);
        }

        public string FullAddress()
        {
            return AddressFormatter.BuildFullAddress(
                Type, Street, Number, Complement, District, City, State, Country, ZipCode);
        }

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

        public override bool Equals(object? obj)
        {
            return obj is Address other && Equals(other);
        }

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

        public static bool operator ==(Address? left, Address? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Address? left, Address? right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return FullAddress();
        }
    }
}
