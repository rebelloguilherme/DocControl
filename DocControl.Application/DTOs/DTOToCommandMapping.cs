using AutoMapper;
using DocControl.Application.DTOs;
using DocControl.Application.Documents.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocControl.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<DocumentDTO, DocumentCreateCommand>();
            CreateMap<DocumentDTO, DocumentUpdateCommand>();
        }
    }
}
