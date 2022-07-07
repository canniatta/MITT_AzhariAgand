using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BindingModelResult;
using AppManagementDataUser.BusinessLayer.ResponseCodeError;
using AppManagementDataUser.DataAccess.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppManagementDataUser.BusinessLayer.BusinessObject
{
    public class BOToken
    {
        private readonly ResponseCode responseCode;
        private readonly IConfiguration _config;

        public BOToken(IConfiguration configuration, DBContext db)
        {
            responseCode = new();
            _config = configuration;
        }
        public Task<ResultBase<BMRToken>> GenerateToken(BMToken request)
        {
            var result = new ResultBase<BMRToken>()
            {
                Data = new()
            };
            string configApiKey = _config["Jwt:ApiKey"];
            try
            {
                if (!request.apiKey.Equals(configApiKey))
                {
                    result.IsOk = false;
                    result.Message = responseCode.GetEnumDesc(ResponseCode.errorList.MI005);
                    result.ResponseCode = ResponseCode.errorList.MI005.ToString();
                    return Task.FromResult(result);
                }

                var signingKey = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
                var securityKey = new SymmetricSecurityKey(signingKey);
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                double sessionExpired = double.Parse(_config["Jwt:SessionExpired"]);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, request.userName),
                    new Claim("host", request.host)
                };

                var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], claims, expires: DateTime.Now.AddMinutes(sessionExpired), signingCredentials: credentials);
                result.Data.Token = new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                result.IsOk = false;
                result.Message = ex.Message;
                result.ResponseCode = ResponseCode.errorList.MI999.ToString();
            }

            return Task.FromResult(result);
        }
    }
}
