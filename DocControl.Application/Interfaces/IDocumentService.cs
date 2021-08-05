using DocControl.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocControl.Application.Interfaces
{
    public interface IDocumentService
    {
        Task<IEnumerable<DocumentDTO>> GetDocuments();
        Task<DocumentDTO> GetById(int? id);
        Task Add(DocumentDTO documentDto);
        Task Update(DocumentDTO documentDto);
        Task Remove(int? id);
    }
}