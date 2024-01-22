using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class ProductUrlResolver :IValueResolver<Product,ProductToReturnDTO,string>
    {
        private readonly IConfiguration configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                var ApiUrl = configuration.GetValue<string>("ApiUrl");
                return ApiUrl + source.PictureUrl;

            }

            return null;
        }
    }
}
