using AutoMapper;
using QuickStartServiceLayer.Models;

namespace QuickStartServiceLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, QuickStartDALLayer.Models.Product>();

        }

    }
}
