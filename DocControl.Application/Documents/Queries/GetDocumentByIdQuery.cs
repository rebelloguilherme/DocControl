using DocControl.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocControl.Application.Documents.Queries
{
    public class GetDocumentByIdQuery : IRequest<Document>
    {
        public int Id { get; set; }

        public GetDocumentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
