using Tssas.Addresses.Exceptions;
using Tssas.ValueObjects.Address;


namespace Tsaas.Addresses.Tests
{
    public class AddressValidationTests
    {
        [Fact]
        public void Constructor_WithValidRequiredFields_ShouldCreateAddress()
        {
            // Arrange & Act
            var address = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100"
            );

            // Assert
            Assert.NotNull(address);
            Assert.Equal("Flores", address.Street);
            Assert.Equal("Centro", address.District);
            Assert.Equal("São Paulo", address.City);
            Assert.Equal("SP", address.State);
            Assert.Equal("Brasil", address.Country);
            Assert.Equal("BR", address.CountryCode);
            Assert.Equal("01310100", address.ZipCode);
        }

        [Fact]
        public void Constructor_WithAllFields_ShouldCreateAddress()
        {
            // Arrange & Act
            var address = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310-100",
                type: "Rua",
                number: "123",
                municipalityIbge: "3550308",
                stateIbge: "35",
                complement: "Apto 45"
            );

            // Assert
            Assert.Equal("Rua", address.Type);
            Assert.Equal("Flores", address.Street);
            Assert.Equal("123", address.Number);
            Assert.Equal("Centro", address.District);
            Assert.Equal("Apto 45", address.Complement);
            Assert.Equal("São Paulo", address.City);
            Assert.Equal("SP", address.State);
            Assert.Equal("Brasil", address.Country);
            Assert.Equal("BR", address.CountryCode);
            Assert.Equal("01310100", address.ZipCode);
            Assert.Equal("3550308", address.MunicipalityIbge);
            Assert.Equal("35", address.StateIbge);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Constructor_WithEmptyStreet_ShouldThrowInvalidAddressException(string? street)
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidAddressException>(() =>
                new Address(
                    street: street!,
                    district: "Centro",
                    city: "São Paulo",
                    state: "SP",
                    country: "Brasil",
                    countryCode: "BR",
                    zipCode: "01310100"
                ));

            Assert.Equal("street", exception.PropertyName);
            Assert.Contains("Street cannot be empty", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Constructor_WithEmptyDistrict_ShouldThrowInvalidAddressException(string? district)
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidAddressException>(() =>
                new Address(
                    street: "Flores",
                    district: district!,
                    city: "São Paulo",
                    state: "SP",
                    country: "Brasil",
                    countryCode: "BR",
                    zipCode: "01310100"
                ));

            Assert.Equal("district", exception.PropertyName);
            Assert.Contains("District cannot be empty", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Constructor_WithEmptyCity_ShouldThrowInvalidAddressException(string? city)
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidAddressException>(() =>
                new Address(
                    street: "Flores",
                    district: "Centro",
                    city: city!,
                    state: "SP",
                    country: "Brasil",
                    countryCode: "BR",
                    zipCode: "01310100"
                ));

            Assert.Equal("city", exception.PropertyName);
            Assert.Contains("City cannot be empty", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Constructor_WithEmptyState_ShouldThrowInvalidAddressException(string? state)
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidAddressException>(() =>
                new Address(
                    street: "Flores",
                    district: "Centro",
                    city: "São Paulo",
                    state: state!,
                    country: "Brasil",
                    countryCode: "BR",
                    zipCode: "01310100"
                ));

            Assert.Equal("state", exception.PropertyName);
            Assert.Contains("State cannot be empty", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Constructor_WithEmptyCountry_ShouldThrowInvalidAddressException(string? country)
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidAddressException>(() =>
                new Address(
                    street: "Flores",
                    district: "Centro",
                    city: "São Paulo",
                    state: "SP",
                    country: country!,
                    countryCode: "BR",
                    zipCode: "01310100"
                ));

            Assert.Equal("country", exception.PropertyName);
            Assert.Contains("Country cannot be empty", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Constructor_WithEmptyCountryCode_ShouldThrowInvalidAddressException(string? countryCode)
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidAddressException>(() =>
                new Address(
                    street: "Flores",
                    district: "Centro",
                    city: "São Paulo",
                    state: "SP",
                    country: "Brasil",
                    countryCode: countryCode!,
                    zipCode: "01310100"
                ));

            Assert.Equal("countryCode", exception.PropertyName);
            Assert.Contains("Country code cannot be empty", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Constructor_WithEmptyZipCode_ShouldThrowInvalidAddressException(string? zipCode)
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidAddressException>(() =>
                new Address(
                    street: "Flores",
                    district: "Centro",
                    city: "São Paulo",
                    state: "SP",
                    country: "Brasil",
                    countryCode: "BR",
                    zipCode: zipCode!
                ));

            Assert.Equal("zipCode", exception.PropertyName);
            Assert.Contains("ZipCode cannot be empty", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Constructor_WithEmptyOptionalFields_ShouldSetThemAsNull(string? emptyValue)
        {
            // Arrange & Act
            var address = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100",
                type: emptyValue,
                number: emptyValue,
                municipalityIbge: emptyValue,
                stateIbge: emptyValue,
                complement: emptyValue
            );

            // Assert
            Assert.Null(address.Type);
            Assert.Null(address.Number);
            Assert.Null(address.MunicipalityIbge);
            Assert.Null(address.StateIbge);
            Assert.Null(address.Complement);
        }

        [Fact]
        public void Constructor_ShouldTrimAllStringFields()
        {
            // Arrange & Act
            var address = new Address(
                street: "  Flores  ",
                district: "  Centro  ",
                city: "  São Paulo  ",
                state: "  SP  ",
                country: "  Brasil  ",
                countryCode: "  br  ",
                zipCode: "  01310-100  ",
                type: "  Rua  ",
                number: "  123  ",
                complement: "  Apto 45  "
            );

            // Assert
            Assert.Equal("Rua", address.Type);
            Assert.Equal("Flores", address.Street);
            Assert.Equal("123", address.Number);
            Assert.Equal("Centro", address.District);
            Assert.Equal("Apto 45", address.Complement);
            Assert.Equal("São Paulo", address.City);
            Assert.Equal("SP", address.State);
            Assert.Equal("Brasil", address.Country);
        }

        [Fact]
        public void Constructor_ShouldNormalizeCountryCodeToUpperCase()
        {
            // Arrange & Act
            var address = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "br",
                zipCode: "01310100"
            );

            // Assert
            Assert.Equal("BR", address.CountryCode);
        }

        [Fact]
        public void Constructor_ShouldRemoveZipCodeFormatting()
        {
            // Arrange & Act
            var address = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310-100"
            );

            // Assert
            Assert.Equal("01310100", address.ZipCode);
        }

        [Fact]
        public void FormatZipCode_WithBrazilianZipCode_ShouldReturnFormattedZipCode()
        {
            // Arrange
            var address = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100"
            );

            // Act
            var formatted = address.FormatZipCode();

            // Assert
            Assert.Equal("01310-100", formatted);
        }

        [Fact]
        public void StreetDisplay_WithType_ShouldCombineTypeAndStreet()
        {
            // Arrange
            var address = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100",
                type: "Rua"
            );

            // Act
            var display = address.StreetDisplay;

            // Assert
            Assert.Equal("Rua Flores", display);
        }

        [Fact]
        public void StreetDisplay_WithoutType_ShouldReturnOnlyStreet()
        {
            // Arrange
            var address = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100"
            );

            // Act
            var display = address.StreetDisplay;

            // Assert
            Assert.Equal("Flores", display);
        }

        [Fact]
        public void FullAddress_WithAllFields_ShouldReturnCompleteFormattedAddress()
        {
            // Arrange
            var address = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100",
                type: "Rua",
                number: "123",
                complement: "Apto 45"
            );

            // Act
            var fullAddress = address.FullAddress();

            // Assert
            Assert.Equal("Rua Flores, 123 - Apto 45, Centro, São Paulo - SP, Brasil, CEP: 01310-100", fullAddress);
        }

        [Fact]
        public void FullAddress_WithoutNumber_ShouldShowSN()
        {
            // Arrange
            var address = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100",
                type: "Rua"
            );

            // Act
            var fullAddress = address.FullAddress();

            // Assert
            Assert.Contains("S/N", fullAddress);
            Assert.Equal("Rua Flores, S/N, Centro, São Paulo - SP, Brasil, CEP: 01310-100", fullAddress);
        }

        [Fact]
        public void ToString_ShouldReturnFullAddress()
        {
            // Arrange
            var address = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100",
                type: "Rua",
                number: "123"
            );

            // Act
            var result = address.ToString();

            // Assert
            Assert.Equal(address.FullAddress(), result);
        }

        [Fact]
        public void Equals_WithSameValues_ShouldReturnTrue()
        {
            // Arrange
            var address1 = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100",
                type: "Rua",
                number: "123"
            );

            var address2 = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100",
                type: "Rua",
                number: "123"
            );

            // Act & Assert
            Assert.True(address1.Equals(address2));
            Assert.True(address1 == address2);
            Assert.False(address1 != address2);
        }

        [Fact]
        public void Equals_WithDifferentValues_ShouldReturnFalse()
        {
            // Arrange
            var address1 = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100",
                type: "Rua",
                number: "123"
            );

            var address2 = new Address(
                street: "Paulista",
                district: "Bela Vista",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100",
                type: "Avenida",
                number: "1000"
            );

            // Act & Assert
            Assert.False(address1.Equals(address2));
            Assert.False(address1 == address2);
            Assert.True(address1 != address2);
        }

        [Fact]
        public void Equals_WithNull_ShouldReturnFalse()
        {
            // Arrange
            var address = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100"
            );

            // Act & Assert
            Assert.False(address.Equals(null));
            Assert.False(address == null);
            Assert.True(address != null);
        }

        [Fact]
        public void GetHashCode_WithSameValues_ShouldReturnSameHashCode()
        {
            // Arrange
            var address1 = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100",
                type: "Rua",
                number: "123"
            );

            var address2 = new Address(
                street: "Flores",
                district: "Centro",
                city: "São Paulo",
                state: "SP",
                country: "Brasil",
                countryCode: "BR",
                zipCode: "01310100",
                type: "Rua",
                number: "123"
            );

            // Act & Assert
            Assert.Equal(address1.GetHashCode(), address2.GetHashCode());
        }
    }
}
