using DocControl.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocControl.Application.Documents.Commands
{
    public class DocumentRemoveCommand : IRequest<Document> 
    {
        public int Id { get; set; }
        public DocumentRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
