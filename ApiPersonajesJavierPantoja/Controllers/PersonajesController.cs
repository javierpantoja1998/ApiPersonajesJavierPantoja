using ApiPersonajesJavierPantoja.Models;
using ApiPersonajesJavierPantoja.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesJavierPantoja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        //Inyectamos el repo
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        //FUNCION PARA SACAR TODOS LOS PERSONAJES
        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> Get()
        {
            return await this.repo.GetPersonajesAsync();
        }

        //FUNCION PARA SACAR LOS DETALLES
        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindDoctor(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> InsertDoctor(Personaje per)
        {
            await this.repo.InsertarPersonaje(per.IdPersonaje, per.Nombre,
                per.Imagen, per.IdSerie);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDoctor(Personaje per)
        {
            await this.repo.UpdatePersonaje(per.IdPersonaje, per.Nombre, per.Imagen, per.IdSerie);
            return Ok();
        }
    }
}
