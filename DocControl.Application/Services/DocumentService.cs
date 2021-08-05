using AutoMapper;
using DocControl.Application.DTOs;
using DocControl.Application.Interfaces;
using DocControl.Application.Documents.Commands;
using DocControl.Application.Documents.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocControl.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public DocumentService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<DocumentDTO>> GetDocuments()
        {
            var documentsQuery = new GetDocumentsQuery();

            if (documentsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(documentsQuery);

            return _mapper.Map<IEnumerable<DocumentDTO>>(result);
        }

        public async Task<DocumentDTO> GetById(int? id)
        {
            var documentByIdQuery = new GetDocumentByIdQuery(id.Value);

            if (documentByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(documentByIdQuery);

            return _mapper.Map<DocumentDTO>(result);
        }

        public async Task Add(DocumentDTO documentDto)
        {
            var documentCreateCommand = _mapper.Map<DocumentCreateCommand>(documentDto);
            await _mediator.Send(documentCreateCommand);
        }

        public async Task Update(DocumentDTO documentDto)
        {
            var documentUpdateCommand = _mapper.Map<DocumentUpdateCommand>(documentDto);
            await _mediator.Send(documentUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var documentRemoveCommand = new DocumentRemoveCommand(id.Value);
            if (documentRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(documentRemoveCommand);
        }
    }
}
