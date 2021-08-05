using DocControl.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocControl.Application.Documents.Commands
{
    public abstract class DocumentCommand : IRequest<Document>
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Process { get; set; }
        public string Category { get; set; }
        public string File { get; set; }
    }
}
