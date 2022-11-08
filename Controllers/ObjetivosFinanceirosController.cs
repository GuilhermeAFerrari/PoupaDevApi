using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoupaDev.API.Entities;
using PoupaDev.API.Models;
using PoupaDev.API.Persistence;

namespace PoupaDev.API.Controllers
{
    [ApiController]
    [Route("api/objetivos-financeiros")]
    public class ObjetivosFinanceirosController : ControllerBase
    {
        private readonly PoupaDevContext _context;

        public ObjetivosFinanceirosController(PoupaDevContext context)
        {
            _context = context;
        }

        // GET api/objetivos-financeiros
        [HttpGet]
        public IActionResult GetTodos()
        {
            var objetivos = _context.Objetivos.Include(o => o.Operacoes);
            return Ok(objetivos);
        }

        // GET api/objetivos-financeiros/1
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            // se nao achar retornar NotFound()
            var objetivo = _context.Objetivos.Include(o => o.Operacoes).SingleOrDefault(o => o.Id == id);
            if (objetivo == null)
                return NotFound();    
            return Ok(objetivo);
        }

        // POST api/objetivos-financeiros
        [HttpPost]
        public IActionResult Post(ObjetivoFinanceiroInputModel model)
        {
            // Se dados de entrada inválidos Retornar BadRequest()
            var objetivo = new ObjetivoFinanceiro(
                model.Titulo,
                model.Descricao,
                model.ValorObjetivo
                );

            _context.Objetivos.Add(objetivo);
            _context.SaveChanges();

            var id = objetivo.Id;
            
            return CreatedAtAction(
                "GetPorId",
                new { id = id },
                model
            );
        }

        // POST api/objetivos-financeiros/1/operacoes
        [HttpPost("{id}/operacoes")]
        public IActionResult PostOperacao(int id, OperacaoInputModel model)
        {
            var operacao = new Operacao(model.ValorObjetivo, model.MyProperty, id);

            var objetivo = _context.Objetivos.Include(o => o.Operacoes).SingleOrDefault(o => o.Id == id);

            if(objetivo == null)
                return NotFound();

            objetivo.RealizarOperacaoFinanceira(operacao);

            _context.SaveChanges();

            return NoContent();
        }
    }
}