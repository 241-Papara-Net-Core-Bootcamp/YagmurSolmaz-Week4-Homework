using AutoMapper;
using Entity.Data.Abstracts;
using Entry.Data.Dtos;
using Entry.Domain.Entities;
using Entry.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Entry.Service.Concretes
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _repository;
        private readonly IMapper _mapper;
        public EntryService(IEntryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task AddAsync(EntryDto entryDto)
        {
            var entry = _mapper.Map<EntryEntity>(entryDto);

            entry.Id = Guid.NewGuid();

            await _repository.AddAsync(entry);
        }

        public async Task Delete(string name)
        {
            var entry = await _repository.GetAsync(name);
            if (entry is null)
                throw new ArgumentException("Name not found");
            await _repository.Delete(name);
        }

        public async Task<List<EntryDto>> GetAllAsync()
        {
            var entries = await _repository.GetAllAsync();
            var entryDto = _mapper.Map<List<EntryDto>>(entries);
            return entryDto;
        }

        public async Task<EntryDto> GetAsync(string name)
        {
            var entry = await _repository.GetAsync(name);
            if (entry is null)
                throw new ArgumentException("Record is not found");
            var entryDto = _mapper.Map<EntryDto>(entry);
            return entryDto;
        }

        public async Task Update(EntryDto entryDto, string name)
        {
            var entry = await _repository.GetAsync(name);
            if (entry is null)
                throw new ArgumentException("Record is not found");
            var updatedEntry = _mapper.Map<EntryEntity>(entryDto);
            updatedEntry.Name = name;
            await _repository.Update(updatedEntry);

        }
    }
}