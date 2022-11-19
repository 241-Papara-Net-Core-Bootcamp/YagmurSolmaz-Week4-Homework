using Entry.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entry.Service.Abstracts
{
    public interface IEntryService
    {
        Task AddAsync(EntryDto entryDto);
        Task Update(EntryDto entryDto, string name);
        Task<List<EntryDto>> GetAllAsync();
        Task<EntryDto> GetAsync(string name);
        Task Delete(string name);
    }
}