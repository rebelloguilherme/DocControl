using DocControl.Application.Documents.Commands;
using DocControl.Domain.Entities;
using DocControl.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocControl.Application.Documents.Handlers
{
    public class DocumentUpdateCommandHandler : IRequestHandler<DocumentUpdateCommand, Document>
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentUpdateCommandHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository ??
            throw new ArgumentNullException(nameof(documentRepository));
        }

        public async Task<Document> Handle(DocumentUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var document = await _documentRepository.GetByIdAsync(request.Id);

            if (document == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                document.Update(request.Code, request.Title, request.Process,
                                request.Category, request.File);//ver se precisa do Id

                return await _documentRepository.UpdateAsync(document);

            }
        }
    }
}
