using System;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Repository;
using System.Collections.Generic;

namespace app.Controllers
{
    public class FundoCapitalController : Controller
    {
        private readonly IFundoCapitalRepository _fundoCapitalRepository;

        [HttpGet("v1/fundocapital")]
        public IActionResult GetAll()
        {
            return Ok(_fundoCapitalRepository.GetAll());
        }

        [HttpPost("v1/fundocapital")]
        public IActionResult Add([FromBody]FundoCapital fundoCapital)
        {
            _fundoCapitalRepository.Add(fundoCapital);
            return Ok();
        }

        [HttpPut("v1/fundocapital/{id}")]
        public IActionResult Edit(Guid id, [FromBody]FundoCapital fundoCapital)
        {
            var result = _fundoCapitalRepository.GetById(id);
            if (result == null)
                return NotFound();           

            result.Nome = fundoCapital.Nome;
            result.ValorAtual = fundoCapital.ValorAtual;
            result.ValorNecessario = fundoCapital.ValorNecessario;
            result.DataResgate = fundoCapital.DataResgate;
            _fundoCapitalRepository.Edit(id, result);

            return Ok();
        }

        [HttpGet("v1/fundocapital/{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _fundoCapitalRepository.GetById(id);
            if (result == null)
                return NotFound();     

            return Ok(result);
        }

        [HttpDelete("v1/fundocapital/{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _fundoCapitalRepository.GetById(id);
            if (result == null)
                return NotFound();     

            _fundoCapitalRepository.Delete(id);
            return Ok();
        }
    }
}