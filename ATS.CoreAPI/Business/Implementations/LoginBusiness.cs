using ATS.CoreAPI.Bussiness;
using ATS.CoreAPI.Configurations;
using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.DTO;
using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using ATS.CoreAPI.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{

    public class LoginBussinesImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private readonly TokenConfiguration _configuration;
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBussinesImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public bool RevokeToken(string userName)
        {
            return _repository.RevokeToken(userName);
        }

        public TokenDTO ValidateCredentials(UserDTO userCredentials)
        {
            User user = null;
            try
            {
                user = _repository.ValidateCredentials(userCredentials);
                return GenerateCredentials(user);
            }
            catch (UserPasswordNotSetException ex)
            {
                throw new UserPasswordNotSetException(GenerateCredentials(ex.User));
            }
        }

        private TokenDTO GenerateCredentials(User user)
        {
            if (user is null) return null;
            List<Claim> claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName),
            new Claim("id",user.ID.ToString()),
        };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);
            _repository.RefreshUserInfo(user);
            return new TokenDTO(true, createDate.ToString(DATE_FORMAT), expirationDate.ToString(DATE_FORMAT), accessToken, refreshToken);
        }

        public TokenDTO GenerateTemporaryCredentials(User user)
        {
            if (user is null) return null;
            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName),
                new Claim("id",user.ID.ToString()),
            };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(1);
            _repository.RefreshUserInfo(user);
            return new TokenDTO(true, createDate.ToString(DATE_FORMAT), expirationDate.ToString(DATE_FORMAT), accessToken, refreshToken);
        }

        public TokenDTO ValidateCredentials(TokenDTO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var userName = principal.Identity.Name;
            var user = _repository.ValidateCredentials(userName);
            if (user is null || user.RefreshToken != token.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now) return null;
            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            _repository.RefreshUserInfo(user);
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);
            return new TokenDTO(true, createDate.ToString(DATE_FORMAT), expirationDate.ToString(DATE_FORMAT), accessToken, refreshToken);
        }
    }
}
