using DocControl.Application.Documents.Queries;
using DocControl.Domain.Entities;
using DocControl.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocControl.Application.Documents.Handlers
{
    public class GetDocumentsQueryHandler : IRequestHandler<GetDocumentsQuery, IEnumerable<Document>>
    {
        private readonly IDocumentRepository _documentRepository;

        public GetDocumentsQueryHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<IEnumerable<Document>> Handle(GetDocumentsQuery request, 
            CancellationToken cancellationToken)
        {
            return await _documentRepository.GetDocumentsAsync();
        }
    }
}
