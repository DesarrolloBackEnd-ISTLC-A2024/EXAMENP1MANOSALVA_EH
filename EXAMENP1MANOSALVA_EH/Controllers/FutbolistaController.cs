using EXAMENP1MANOSALVA_EH.Comunes;
using EXAMENP1MANOSALVA_EH.Model;
using Microsoft.AspNetCore.Mvc;

using EXAMENP1MANOSALVA_EH.Model;
using Microsoft.AspNetCore.Mvc;
using EXAMENP1MANOSALVA_EH.Comunes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EXAMENP1MANOSALVA_EH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutbolistaController : ControllerBase
    {
        // GET: api/<FutbolistasController>
        [HttpGet]
        public List<Futbolista> Get()
        {
            return ConexionDB.GetFutbolistas();
        }

        // GET api/<FutbolistasController>/5
        [HttpGet("{id}")]
        public Futbolista Get(int id)
        {
            return ConexionDB.GetFutbolista(id);
        }

        // GET api/<FutbolistasController>/historial/5
        [HttpGet("historial/{id}")]
        public List<Equipo> GetHistorial(int id)
        {
            return ConexionDB.GetHistorial(id);
        }

        // POST api/<FutbolistasController>
        [HttpPost]
        public void Post([FromBody] Futbolista objFutbolista)
        {
            ConexionDB.PostFutbolista(objFutbolista);
        }

        // PUT api/<FutbolistasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Futbolista objFutbolista)
        {
            ConexionDB.PutFutbolista(id, objFutbolista);
        }

        // DELETE api/<FutbolistasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ConexionDB.DeleteFutbolista(id);
        }
    }
}

