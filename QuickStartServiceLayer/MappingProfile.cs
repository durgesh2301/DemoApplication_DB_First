using AutoMapper;
using QuickStartServiceLayer.Models;

namespace QuickStartServiceLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create mappings from Service layer models to Data Access Layer models
            CreateMap<Product, QuickStartDALLayer.Models.Product>();
            CreateMap<User, QuickStartDALLayer.Models.User>();
            CreateMap<Category, QuickStartDALLayer.Models.Category>();
            CreateMap<PurchaseDetail, QuickStartDALLayer.Models.PurchaseDetail>();
            CreateMap<Role, QuickStartDALLayer.Models.Role>();
            CreateMap<CardDetail, QuickStartDALLayer.Models.CardDetail>();

            // Create mappings from Data Access Layer models to Service layer models
            CreateMap<Product, QuickStartDALLayer.Models.Product>().ReverseMap();
            CreateMap<User, QuickStartDALLayer.Models.User>().ReverseMap();
            CreateMap<Category, QuickStartDALLayer.Models.Category>().ReverseMap();
            CreateMap<PurchaseDetail, QuickStartDALLayer.Models.PurchaseDetail>().ReverseMap();
            CreateMap<Role, QuickStartDALLayer.Models.Role>().ReverseMap();
            CreateMap<CardDetail, QuickStartDALLayer.Models.CardDetail>().ReverseMap();
        }

    }
}
