using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartMonitoringSystem.Core.Domain.RepositoryContracts;
using SmartMonitoringSystem.Core.DTO;
using SmartMonitoringSystem.Core.Identity;
using SmartMonitoringSystem.Core.ServiceContracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SmartMonitoringSystem.Core.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginRepository _loginRepository;
        public JwtService(IConfiguration configuration,ILoginRepository loginRepository)
        {
            this._configuration = configuration;
            this._loginRepository = loginRepository;
        }
        public AuthenticationResponse CreateJWTToken(LoginDto applicationUser)
        {
            DateTime expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:expiration_minutes"]));
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,applicationUser.Email!),//Subject Id
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()), //JWT Unique Id
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString()), //Token generation datetime
                new Claim(ClaimTypes.NameIdentifier,applicationUser.Email!.ToString()), //Unique name identifier of user
                new Claim(ClaimTypes.Name,applicationUser.Email!.ToString()), //Unique name of the user
                new Claim(ClaimTypes.Email,applicationUser.Email.ToString()) //Unique email of the user
            };
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            //Creates JWTSecurityToken object with given issues, audience, claims, expiration and signing credentials
            JwtSecurityToken jwtTokenGenerator = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );
            // Create a JwtSecurityTokenHandler object.
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            //JWTBearer creates the token as a string
            string token = tokenHandler.WriteToken(jwtTokenGenerator);

            // Create and return an AuthenticationResponse object containing the token, user email, user name, and token expiration time.
            return new AuthenticationResponse()
            {
                Token = token,
                Email = applicationUser.Email,
                Expiration = expiration,
                RefreshToken = GenerateRefreshToken(),
                RefreshTokenExpirationDatatime = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["RefreshToken:expiration_minutes"]))
            };
        }

        public ClaimsPrincipal? GetClaimsPrincipalJwtToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidAudience = _configuration["Jwt:Audience"],
                ValidateIssuer = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),

                ValidateLifetime = false //Must be false., because we are generating new token,  present passed token is already expired
            };
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principles = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid Token");
            }
            return principles;
        }

        public async Task<int> LoginUser(LoginDto loginDTO)
        {
            var result = await _loginRepository.LoginUser(loginDTO);
            return result;
        }
        public async Task<TokenModel> GetProfileByUserID(int userID)
        {
            var profile = await _loginRepository.GetProfileByUserID(userID);
            return profile.ToTokenModelResponse();
        }

        private string GenerateRefreshToken()
        {
            byte[] randomNumbersInBtyes = new byte[64];
            RandomNumberGenerator randomNumber = RandomNumberGenerator.Create();
            randomNumber.GetBytes(randomNumbersInBtyes);
            return Convert.ToBase64String(randomNumbersInBtyes);
        }
    }
}
