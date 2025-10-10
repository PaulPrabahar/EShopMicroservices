using Catalog.Api.Products.DelecteProduct;
using Catalog.Api.Products.UpdateProduct;

namespace Catalog.Api;

public class MapsterConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<UpdateProductResult, UpdateProductResponce>.NewConfig()
            .Map(dest => dest.isSuccess, src => src.isSuccess);
        TypeAdapterConfig<DeleteProductResult, DeleteProductResponse>.NewConfig()
            .Map(dest => dest.isSuccess, src => src.isSuccess);

    }
}
