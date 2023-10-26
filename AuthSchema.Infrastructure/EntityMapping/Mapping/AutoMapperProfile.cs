using AuthSchema.Domain.Model;
using AuthSchema.Domain.Model.CardapioVirtual;
using AuthSchema.Infrastructure.Data.DTO;
using AuthSchema.Infrastructure.Data.DTO.CardapioVirtual;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.EntityMapping.Mapping
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.EmailUsuario, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario))
                .ReverseMap();

            CreateMap<AccessKey, AccessKeyDTO>()
                .ForMember(dest => dest.AccessKey, opt => opt.MapFrom(src => src.AccessKeyAttr))
                .ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<Domain.Model.Profile, ProfileDTO>().ReverseMap();

            CreateMap<UserProfile, UserProfileDTO>().ReverseMap();

            CreateMap<Cliente, ClienteDTO>().ReverseMap();

            CreateMap<UserCliente, UserClienteDTO>().ReverseMap();

            CreateMap<TipoPessoa, TipoPessoaDTO>().ReverseMap();

            CreateMap<TipoAcesso, TipoAcessoDTO>().ReverseMap();



        }
    }
}
