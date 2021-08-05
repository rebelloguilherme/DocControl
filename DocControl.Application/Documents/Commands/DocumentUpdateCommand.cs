using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocControl.Application.Documents.Commands
{
    public class DocumentUpdateCommand : DocumentCommand
    {
        public int Id { get; set; }
    }
}
