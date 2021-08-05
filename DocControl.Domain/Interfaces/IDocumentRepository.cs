
using DocControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocControl.Domain.Interfaces
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetDocumentsAsync(); //Retorna lista de documentos
        Task<Document> GetByIdAsync(int? id); //Retorna um documento pelo id
        Task<Document> CreateAsync(Document document); //Cria um documento
        Task<Document> UpdateAsync(Document document); //Atualiza um documento
        Task<Document> RemoveAsync(Document document); //Remove um documento
    }
}
