using FluentAssertions;
using NationalAuthorization.SDK;
using System;
using Xunit;

namespace NationalAuthorization.Tests
{
    public class SejamRegistrarTests
    {
        public const string USERNAME = "189";
        public const string PASSWORD = "F@r3ejiBr";
        public const string URL_ACCESS_TOKEN = @"https://apisejam.csdiran.com:58919/v1.1/accessToken";
        public const string URL_KYC_OTP = @"https://apisejam.csdiran.com:58919/v1.1/kycOtp";
        public const string URL_KYC = @"https://apisejam.csdiran.com:58919/v1.1/servicesWithOtp/profiles/";
        public const string TRUE_UNIQUE_IDENTIFIER = "0069667462";

        [Fact]
        public void GetAccessToken_Of_SejamRegistrar_Should_Throw_UriFormatException_When_Url_IsInvalidURL()
        {
            //Arrange
            SejamRegistrar authorizer = new SejamRegistrar();

            //Act
            Action validate = () => new AccessTokenRequest("", USERNAME, PASSWORD);

            //Assert
            validate.Should().Throw<UriFormatException>();
        }

        [Fact]
        public void GetAccessToken_Of_SejamRegistrar_Should_Return_Error_When_Url_IsNotAccessible()
        {
            //Arrange
            SejamRegistrar authorizer = new SejamRegistrar();
            AccessTokenRequest request =
                new AccessTokenRequest(URL_ACCESS_TOKEN + "pp", USERNAME, PASSWORD);

            //Act
            var accessToken = authorizer.GetAccessToken(request);

            //Assert
            AssertError(accessToken);
        }

        [Fact]
        public void GetAccessToken_Of_SejamRegistrar_Should_Return_Error_When_UsernameorPassword_IsEmpty()
        {
            //Arrange
            SejamRegistrar authorizer = new SejamRegistrar();
            AccessTokenRequest request = new AccessTokenRequest(URL_ACCESS_TOKEN, "", "");

            //Act
            var accessToken = authorizer.GetAccessToken(request);

            //Assert
            AssertError(accessToken);
            accessToken.ValidationMessages[0].Code.Should().Be("400");
        }

        [Fact]
        public void GetAccessToken_Of_SejamRegistrar_Should_Return_Error_When_UsernameorPassword_IsInvalid()
        {
            //Arrange
            SejamRegistrar authorizer = new SejamRegistrar();
            AccessTokenRequest request = new AccessTokenRequest(URL_ACCESS_TOKEN, "44234", "3424");

            //Act
            var accessToken = authorizer.GetAccessToken(request);

            //Assert
            AssertError(accessToken);
        }

        [Fact]
        public void GetAccessToken_Of_SejamRegistrar_Should_Return_AccessToken_When_UrlAnduserpass_AreValid()
        {
            //Arrange
            SejamRegistrar authorizer = new SejamRegistrar();
            AccessTokenRequest request =
                new AccessTokenRequest(URL_ACCESS_TOKEN, USERNAME, PASSWORD);

            //Act
            var accessToken = authorizer.GetAccessToken(request);

            //Assert
            accessToken.ValidationStatus.Should().BeTrue();
            accessToken.Token.Should().NotBeNull();
        }

        [Fact]
        public void GetKYCOtp_Of_SejamRegistrar_Should_Send_KycOtp_When_UrlAnduserpass_AreValid()
        {
            //Arrange
            SejamRegistrar authorizer = new SejamRegistrar();
            var requestKyc = new KycOtpRequest(URL_KYC_OTP, GetAccessToken(), TRUE_UNIQUE_IDENTIFIER);

            //Act
            var kycOtpResult = authorizer.GetKycOtp(requestKyc);

            //Assert
            kycOtpResult.ValidationStatus.Should().BeTrue();
        }

        [Fact]
        public void GetKycOtp_Of_SejamRegistrar_Should_Throw_UriFormatException_When_Url_IsInvalidURL()
        {
            //Arrange   

            //Act
            Action validate = () => new KycOtpRequest("", GetAccessToken(), TRUE_UNIQUE_IDENTIFIER);

            //Assert
            validate.Should().Throw<UriFormatException>();
        }

        [Fact]
        public void GetKYCOtp_Of_SejamRegistrar_Should_Return_Error_When_Url_IsInValid()
        {
            //Arrange     
            SejamRegistrar authorizer = new SejamRegistrar();
            var requestKyc = new KycOtpRequest(URL_KYC_OTP + "+", GetAccessToken(), TRUE_UNIQUE_IDENTIFIER);

            //Act
            var result = authorizer.GetKycOtp(requestKyc);

            //Assert
            AssertError(result);
        }

        [Fact]
        public void GetKYCOtp_Of_SejamRegistrar_Should_Return_Error_When_AccessToken_IsInValid()
        {
            //Arrange     
            SejamRegistrar authorizer = new SejamRegistrar();
            var requestKyc = new KycOtpRequest(URL_KYC_OTP, GetAccessToken() + "D", TRUE_UNIQUE_IDENTIFIER);

            //Act
            var result = authorizer.GetKycOtp(requestKyc);

            //Assert
            AssertError(result);
        }

        [Fact]
        public void GetKYCOtp_Of_ThirdPartyProvider_Should_Return_Error_When_UniqueIdentifier_IsInValid()
        {
            //Arrange     
            SejamRegistrar authorizer = new SejamRegistrar();
            var requestKyc = new KycOtpRequest(URL_KYC_OTP, GetAccessToken(), "8884454112");

            //Act
            var result = authorizer.GetKycOtp(requestKyc);

            //Assert
            AssertError(result);
        }

        [Fact]
        public void GetKYC_Of_ThirdPartyProvider_Should_SendKYC_When_UniqueIdentifierAndOtpIsValid()
        {
            //Arrange-Send OTPRequest Manual
            SejamRegistrar authorizer = new SejamRegistrar();

            var kycRequest = new KYCRequest(
                GetAccessToken(),
                URL_KYC,
                TRUE_UNIQUE_IDENTIFIER,
                "83458"
            );

            //Act
            var result = authorizer.GetKYC(kycRequest);
            //Assert
            result.ValidationStatus.Should().BeTrue();
            result.UniqueIdentifier.Should().NotBeNullOrEmpty();
        }

        private string GetAccessToken()
        {
            AccessTokenProvider provider = new AccessTokenProvider();
            return provider.Token;
        }

        private void AssertError(RequestResponse accessToken)
        {
            accessToken.ValidationStatus.Should().BeFalse();
            accessToken.ValidationMessages.Should().NotBeNull();
            accessToken.ValidationMessages.Should().HaveCountGreaterThan(0);
        }
    }
}
