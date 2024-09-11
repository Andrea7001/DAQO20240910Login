using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DAQO20240910Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private static List<Matricula> matriculas = new List<Matricula>();

       
        [HttpGet]
        [Authorize]  
        public IEnumerable<Matricula> Get()
        {
            return matriculas;
        }

        
        [HttpGet("{id}")]
        [Authorize] 
        public IActionResult Get(int id)
        {
            var matricula = matriculas.FirstOrDefault(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound("Matrícula no encontrada.");
            }

            return Ok(matricula);
        }

         
        [HttpPost]
        [Authorize] 
        public IActionResult Post([FromBody] Matricula matricula)
        {
            if (matricula == null)
            {
                return BadRequest("Datos de matrícula no pueden ser nulos.");
            }

             
            matricula.Id = matriculas.Count > 0 ? matriculas.Max(m => m.Id) + 1 : 1;
            matriculas.Add(matricula);
            return CreatedAtAction(nameof(Get), new { id = matricula.Id }, matricula);
        }

         
        [HttpPut("{id}")]
        [Authorize]  
        public IActionResult Put(int id, [FromBody] Matricula updatedMatricula)
        {
            if (updatedMatricula == null || updatedMatricula.Id != id)
            {
                return BadRequest("Datos de matrícula no válidos.");
            }

            var matricula = matriculas.FirstOrDefault(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound("Matrícula no encontrada.");
            }

             
            matricula.Estudiante = updatedMatricula.Estudiante;
            matricula.Curso = updatedMatricula.Curso;
            matricula.Año = updatedMatricula.Año;

            return Ok(matricula);
        }

 
    }

    public class Matricula
    {
        public int Id { get; set; }
        public string? Estudiante { get; set; }
        public string? Curso { get; set; }
        public string? Año { get; set; }
    }







}
