using Mango.Web.Models;
using Mango.Web.Models.Dto;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class ProductService : BaseServiceImpl, IProductServices
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory) 
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SSD.ApiType.POST,
                Data = productDto,
                Url = SSD.ProductAPIBase+"api/products",
                AccessToken="" 
            });
        }
         
        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SSD.ApiType.DELETE,
                Url = SSD.ProductAPIBase + "api/products/"+id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SSD.ApiType.GET,
                Url = SSD.ProductAPIBase + "api/products",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SSD.ApiType.GET,
                Url = SSD.ProductAPIBase + "api/products/" + id,
                AccessToken = ""
            });
        }

        public  async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SSD.ApiType.PUT,
                Data = productDto,
                Url = SSD.ProductAPIBase + "api/products",
                AccessToken = ""
            });
        }
    }
}
