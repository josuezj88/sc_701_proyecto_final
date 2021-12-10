using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Categorias, DataModels.Categorias>().ReverseMap();
            CreateMap<data.Condicion, DataModels.Condicion>().ReverseMap();
            CreateMap<data.Tutores, DataModels.Tutores>().ReverseMap();
            CreateMap<data.Direcciones, DataModels.Direcciones>().ReverseMap();
            CreateMap<data.Productos, DataModels.Productos>().ReverseMap();
            CreateMap<data.Detalles, DataModels.Detalles>().ReverseMap();
            CreateMap<data.Diarios, DataModels.Diarios>().ReverseMap();
            CreateMap<data.Pollitos, DataModels.Pollitos>().ReverseMap();
            CreateMap<data.Noticias, DataModels.Noticias>().ReverseMap();
            CreateMap<data.AspNetUsers, DataModels.AspNetUsers>().ReverseMap();
        }
    }
}
