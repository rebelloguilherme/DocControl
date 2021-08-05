using DocControl.Application.Documents.Commands;
using DocControl.Domain.Entities;
using DocControl.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocControl.Application.Documents.Handlers
{
    public class DocumentCreateCommandHandler : IRequestHandler<DocumentCreateCommand, Document>
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentCreateCommandHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public async Task<Document> Handle(DocumentCreateCommand request, 
            CancellationToken cancellationToken)
        {
            var document = new Document(request.Code, request.Title, request.Process,
                              request.Category, request.File);

            if (document == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _documentRepository.CreateAsync(document);
            }
        }
    }
}
