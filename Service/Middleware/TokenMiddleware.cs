using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Service.Services.Implementation;

namespace StockMaster.Services
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _request;
        private TokenService _tokenService;

        public TokenMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task Invoke(HttpContext context, IConfiguration configuration)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            _tokenService = new TokenService(configuration);

            var userId = _tokenService.ValidateToken(token);

            if (userId != null)
            {
                context.Items["User"] = userId;
            }

            await _request(context);
        }
    }
}
