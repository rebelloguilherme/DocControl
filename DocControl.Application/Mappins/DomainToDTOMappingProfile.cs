using AutoMapper;
using DocControl.Application.DTOs;
using DocControl.Domain.Entities;

namespace DocControl.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Document, DocumentDTO>().ReverseMap();
        }
    }
}
