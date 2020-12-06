using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using edital.Data;
using edital.Model;
using edital.Services;
using edital.Services.Interfaces;

namespace edital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {        
        private readonly IEstadosService _estadoService;

        public EstadosController(IEstadosService estadoService)
        {
            _estadoService = estadoService;
        }
        
        // GET: api/Estados
        [HttpGet]
        public ActionResult<List<Estado>> GetEstados()
        {
           return _estadoService.GetEstados();
        }

        // GET: api/Estados/5
        [HttpGet("{id}")]
        public ActionResult<Estado> GetEstado(int id)
        {
           return _estadoService.GetEstado(id);
        }

        // PUT: api/Estados/5
        [HttpPut("{id}")]
       public ActionResult<Estado> PutEstado(int id, Estado estado)
        {
            if (id != estado.id)
            {
                return BadRequest();
            }

            bool resp  = _estadoService.AtualizaEstado(estado);
            if(!resp)
            {                            
                return NotFound();
            }

            estado = _estadoService.GetEstado(id);

            return estado;
        }

        // POST: api/Estados
       [HttpPost]
        public ActionResult<string> PostEstado(Estado novoEstado)
        {
            bool resp = _estadoService.CadastrarEstado(novoEstado);
            if(resp){
                return "Solicitação executada com sucesso!";
            }
            else{
                return "Falha ao executar a solicitação!"; 
            }           
        }

      /*  // DELETE: api/Estados/5
       [HttpDelete("{id}")]
        public ActionResult<Estado> DeletePaciente(int id)
        {
            
        }*/


    }
}
