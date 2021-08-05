using DocControl.Domain.Entities;
using DocControl.Domain.Interfaces;
using DocControl.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocControl.Infra.Data.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        ApplicationDbContext _documentContext;
        public DocumentRepository(ApplicationDbContext context)
        {
            _documentContext = context;
        }

        public async Task<Document> CreateAsync(Document document)
        {
            _documentContext.Add(document);
            await _documentContext.SaveChangesAsync();
            return document;
        }

        public async Task<Document> GetByIdAsync(int? id)
        {
            return await _documentContext.Documents.FindAsync(id);
        }

        public async Task<IEnumerable<Document>> GetDocumentsAsync()
        {
            return await _documentContext.Documents.ToListAsync();
        }

        public async Task<Document> RemoveAsync(Document document)
        {
            _documentContext.Remove(document);
            await _documentContext.SaveChangesAsync();
            return document;
        }

        public async Task<Document> UpdateAsync(Document document)
        {
            _documentContext.Update(document);
            await _documentContext.SaveChangesAsync();
            return document;
        }
    }
}