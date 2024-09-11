using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace DAQO20240910Login.Controllers
{
     

    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private static List<Nota> notas = new List<Nota>();

        // GET: api/notas
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Nota> Get()
        {
            return notas;
        }

        // POST api/notas
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Nota nota)
        {
            if (nota == null)
            {
                return BadRequest("Nota no puede ser nula.");
            }

            notas.Add(nota);
            return Ok();
        }

        
    }

    public class Nota
    {
        public int Id { get; set; }
        public string Asignatura { get; set; }
        public int Valor { get; set; }
    }


}
