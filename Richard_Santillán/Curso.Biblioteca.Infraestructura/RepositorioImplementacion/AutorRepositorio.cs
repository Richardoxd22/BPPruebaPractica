using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.RepositoriosDef;
using Curso.Biblioteca.Infraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.RepositorioImplementacion
{

    
    public class AutorRepositorio : IAutorRepositorio
    {
        private readonly BibliotecaDbContext context;

        public AutorRepositorio(BibliotecaDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Autor autor)
        {
            await context.AddAsync(autor);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Autor autor)
        {
            context.Remove(autor);
            await context.SaveChangesAsync();
        }

        public IQueryable<Autor> GetAll()
        {
            return context.Autores.AsQueryable();
        }

        public async Task UpdateAsync(Autor autor)
        {
            context.Update(autor);
            await context.SaveChangesAsync();
        }
    }
}
