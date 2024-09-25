using MovieReservationApp.MVC.ApiResponseMessages;
using MovieReservationApp.MVC.Exceptions;
using MovieReservationApp.MVC.Services.Intefaces;
using RestSharp;

namespace MovieReservationApp.MVC.Services.Impelementations
{
    public class CrudService : ICrudService
    {
        private readonly RestClient restClient;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContext;

        public CrudService(IConfiguration configuration, IHttpContextAccessor httpContext)
        {
            this.configuration = configuration;
            this.httpContext = httpContext;
            restClient = new RestClient(configuration.GetSection("API:Base_Url").Value);
            var token = httpContext.HttpContext.Request.Cookies["token"];

            if (token != null)
            {
                restClient.AddDefaultHeader("Authorization", "Bearer " + token);
            }
        }
        public async Task Create<T>(string endpoint, T entity) where T : class
        {

            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(entity);

            var response = await restClient.ExecuteAsync<ApiResponseMessage<T>>(request);
            if (!response.IsSuccessful) 
                throw new Exception();
        }
        //public Task ReserveSeat<T>(string endpoint, int reservationId, string seatNo)
        //{

        //}


		public async Task Delete<T>(string endpoint, int id)
        {
            var request = new RestRequest(endpoint, Method.Delete);

            var response = await restClient.ExecuteAsync<ApiResponseMessage<T>>(request);
            if (!response.IsSuccessful) throw new Exception();
        }

        public async Task<T> GetAllAsync<T>(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            var response = await restClient.ExecuteAsync<ApiResponseMessage<T>>(request);

            if (!response.IsSuccessful)
            {
                throw new Exception();
            }

            return response.Data.Data;
        }

        public async Task<T> GetByIdAsync<T>(string endpoint, int id)
        {
            if (id < 1) throw new Exception();
            var request = new RestRequest(endpoint, Method.Get);
            var response = await restClient.ExecuteAsync<ApiResponseMessage<T>>(request);

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new BadRequestException(response.Data.ErrorMessage);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ModelNotFoundException(response.Data.ErrorMessage);
                }
            }

            return response.Data.Data;
        }

        public async Task Update<T>(string endpoint, T entity) where T : class
        {
            var request = new RestRequest(endpoint, Method.Put);
            request.AddJsonBody(entity);

            var response = await restClient.ExecuteAsync<ApiResponseMessage<T>>(request);

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest && response.Data.PropertyName is not null)
                {
                    throw new ModelStateException(response.Data.PropertyName, response.Data.ErrorMessage);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new BadRequestException(response.Data.ErrorMessage);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ModelNotFoundException(response.Data.ErrorMessage);
                }
            }
        }
    }
}
