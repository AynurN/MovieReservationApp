using Microsoft.AspNetCore.Http;
using MovieReservationApp.MVC.ApiResponseMessages;
using MovieReservationApp.MVC.Services.Intefaces;
using MovieReservationApp.MVC.ViewModels.AuthVMs;
using RestSharp;
using System.CodeDom;

namespace MovieReservationApp.MVC.Services.Impelementations
{
    public class AuthService : IAuthService
    {
        private readonly RestClient restClient;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContext;

        public AuthService(IConfiguration configuration, IHttpContextAccessor httpContext)
        {
            this.configuration = configuration;
            this.httpContext = httpContext;
            restClient = new RestClient(configuration.GetSection("API:Base_Url").Value);
        }
        public async Task<LoginResponseVM> Login(UserLoginVM vm)
        {
            var request = new RestRequest("/auths/login", Method.Post);
            request.AddJsonBody(vm);

            var response = await restClient.ExecuteAsync<ApiResponseMessage<LoginResponseVM>>(request);

            if (!response.IsSuccessful)
            {
                throw new Exception();
            }

            return response.Data.Data;
        }

        public void Logout()
        {
            httpContext.HttpContext.Response.Cookies.Delete("token");
        }
    }
}
