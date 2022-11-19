using Microsoft.AspNetCore.Mvc;
using Entry.Data.Dtos;
using Entry.Service.Abstracts;
using System.Threading.Tasks;
using System;

namespace Entry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _entryService;
        public EntryController(IEntryService entryService)
        {
            _entryService = entryService;
        }

        [HttpGet("GetEntries")]
        public async Task<IActionResult> GetEntries()
        {
            var entryList = await _entryService.GetAllAsync();
            return Ok(entryList);

        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetEntryById(string name)
        {
            var entry = await _entryService.GetAsync(name);
            return Ok(entry);
        }

        [HttpPost]
        public async Task<IActionResult> AddEntry(EntryDto entryDto)
        {

            await _entryService.AddAsync(entryDto);
            return Ok();

        }

        [HttpPut("{name}")]
        public async Task<IActionResult> UpdateEProduct(EntryDto entryDto, string name)
        {

            await _entryService.Update(entryDto, name);
            return Ok();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteEntry(string name)
        {
            await _entryService.Delete(name);
            return Ok();
        }
    }
}