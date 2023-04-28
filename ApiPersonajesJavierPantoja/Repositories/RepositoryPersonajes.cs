using ApiPersonajesJavierPantoja.Data;
using ApiPersonajesJavierPantoja.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesJavierPantoja.Repositories
{
    public class RepositoryPersonajes
    {
        //Inyectamos el context
        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        //FUNCION PARA SACAR TODOS LOS PERSONAJES
        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();

        }

        //FUNCION PARA LOS DETALLES
        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes
            .FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        //Funcion para insertar
        public async Task InsertarPersonaje
            (int idPersonaje, string nombre,
            string imagen, int idSerie)
        {
            Personaje per = new Personaje();
            per.IdPersonaje = idPersonaje;
            per.Nombre = nombre;
            per.Imagen = imagen;
            per.IdSerie = idSerie;
            this.context.Personajes.Add(per);
            await this.context.SaveChangesAsync();
        }

        //Funcion para Modificar
        public async Task UpdatePersonaje(int idPersonaje, string nombre,
            string imagen, int idSerie)
        {
            Personaje per = await this.FindPersonajeAsync(idPersonaje);
            per.Nombre = nombre;
            per.Imagen =imagen;
            per.IdSerie = idSerie;
            await this.context.SaveChangesAsync();
        }

        //FUNCION PARA BORRAR
        public async Task DeleteDoctor(int id)
        {
            Personaje doc = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(doc);
            await this.context.SaveChangesAsync();
        }
    }
}
