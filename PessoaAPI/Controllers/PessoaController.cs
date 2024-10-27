using Microsoft.AspNetCore.Mvc;
using PessoaAPI.Models;
using PessoaAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PessoaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await _pessoaRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Pessoa> GetById(int id)
        {
            return await _pessoaRepository.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pessoa pessoa)
        {
            var result = await _pessoaRepository.Create(pessoa);
            if (result > 0)
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pessoa pessoa)
        {
            if (id != pessoa.Id)
                return BadRequest();

            var result = await _pessoaRepository.Update(pessoa);
            if (result > 0)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pessoaRepository.Delete(id);
            if (result > 0)
                return Ok();
            return BadRequest();
        }
    }
}
