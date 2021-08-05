using DocControl.Application.Documents.Queries;
using DocControl.Domain.Entities;
using DocControl.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DocControl.Application.Documents.Handlers
{
    public class GetDocumentByIdQueryHandler : IRequestHandler<GetDocumentByIdQuery, Document>
    {
        private readonly IDocumentRepository _documentRepository;
        public GetDocumentByIdQueryHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<Document> Handle(GetDocumentByIdQuery request,
             CancellationToken cancellationToken)
        {
            return await _documentRepository.GetByIdAsync(request.Id);
        }
    }
}
