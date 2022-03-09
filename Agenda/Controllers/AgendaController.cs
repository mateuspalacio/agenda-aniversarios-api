using Agenda.Exceptions;
using Agenda.Models;
using Agenda.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendaController : ControllerBase
    {
        
        private readonly ILogger<AgendaController> _logger;
        private readonly IPessoaRepository _rep;

        public AgendaController(ILogger<AgendaController> logger, IPessoaRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> CadastrarPessoa([FromBody] Pessoa p)
        {
            var resp = await _rep.CreatePessoa(p);
            return Ok(resp);
        }
        [HttpDelete("apagar")]
        public async Task<IActionResult> ApagarPessoa([FromQuery]string nome)
        {
            var resp = await _rep.DeletePessoa(nome);
            return Ok(resp);
        }
        [HttpPut("editar")]
        public async Task<IActionResult> EditarPessoa([FromBody] Pessoa p)
        {
            var resp = await _rep.EditPessoa(p);
            return Ok(resp);
        }
        [HttpGet("consultar/data")]
        public async Task<IActionResult> ConsultarPessoaPorData([FromQuery] int dia, int mes)
        {
            var resp = await _rep.GetPessoaDiaMes(dia, mes);
            return Ok(resp);
        }
        [HttpGet("consultar/mes")]
        public async Task<IActionResult> ConsultarPessoaPorMes([FromQuery] int mes)
        {
            var resp = await _rep.GetPessoaMes(mes);
            return Ok(resp);
        }
        [HttpGet("consultar/letra")]
        public async Task<IActionResult> ConsultarPessoaPorLetra([FromQuery] char letraInicial)
        {
            var resp = await _rep.GetPessoaLetra(letraInicial);
            return Ok(resp);
        }
        [HttpGet("consultar/todos/nome")]
        public async Task<IActionResult> ConsultarAgendaOrdenadaPorNome()
        {
            var resp = await _rep.GetPessoasOrderedByNome();
            return Ok(resp);
        }
        [HttpGet("consultar/todos/mes")]
        public async Task<IActionResult> ConsultarAgendaOrdenadaPorMes()
        {
            var resp = await _rep.GetPessoasOrderedByMes();
            return Ok(resp);
        }
    }
}