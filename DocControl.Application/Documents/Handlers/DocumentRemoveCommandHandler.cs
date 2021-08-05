using DocControl.Application.Documents.Commands;
using DocControl.Domain.Entities;
using DocControl.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocControl.Application.Documents.Handlers
{
    public class DocumentRemoveCommandHandler : IRequestHandler<DocumentRemoveCommand, Document>
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentRemoveCommandHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository ?? throw new
                ArgumentNullException(nameof(documentRepository));
        }

        public async Task<Document> Handle(DocumentRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var document = await _documentRepository.GetByIdAsync(request.Id);

            if (document == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _documentRepository.RemoveAsync(document);
                return result;
            }
        }
    }
}
