using DocControl.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocControl.Application.Documents.Queries
{
    public class GetDocumentsQuery : IRequest<IEnumerable<Document>>
    {

    }
}
