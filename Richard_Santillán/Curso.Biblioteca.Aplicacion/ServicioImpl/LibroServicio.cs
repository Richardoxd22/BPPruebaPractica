using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServicioDef;
using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.RepositoriosDef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServicioImpl
{
    public class LibroServicio : ILibroServicio
    {
        private readonly ILibroRepositorio libroRepositorio;

        public LibroServicio(ILibroRepositorio libroRepositorio)
        {
            this.libroRepositorio = libroRepositorio;
        }

        public async Task<bool> CreateAsync(CrearLibroDto libroDto)
        {
            var libro = new Libro
            {
                Titulo= libroDto.Titulo,
                ISBN=libroDto.ISBN,
                AutorId=libroDto.AutorId,
                EditorialId=libroDto.EditorialId                
            };
            await libroRepositorio.CreateAsync(libro);
            return true;
        }

        public async Task<bool> DeletedAsync(int id)
        {
            var consult = libroRepositorio.GetAll();
            consult = consult.Where(a => a.Id == id);
            var libro = consult.SingleOrDefault();

            await libroRepositorio.DeleteAsync(libro);
            return true;
        }

        public async Task<ICollection<LibroDto>> GetAllAsync()
        {
            var consult = libroRepositorio.GetAll();
            var listalibroes = await consult.Select(x => new LibroDto
            {
                Id = x.Id,
                ISBN=x.ISBN,
                Autor= $"{x.Autor.Nombre} {x.Autor.Apellido}",
                Editorial= $"{x.Editorial.Nombre} {x.Editorial.Direccion}"

            }).ToListAsync();

            return listalibroes;
        }

        public async Task<LibroDto> GetByIdAsync(int id)
        {
            var consult = libroRepositorio.GetAll();
            consult = consult.Where(a => a.Id == id);
            var libro = await consult.Select(a => new LibroDto
            {
                Id = a.Id,
                ISBN = a.ISBN,
                Autor = $"{a.Autor.Nombre} {a.Autor.Apellido}",
                Editorial = $"{a.Editorial.Nombre} {a.Editorial.Direccion}"
            }).SingleOrDefaultAsync();
            return libro;
        }

        public async Task<bool> UpdatedAsync(int id, CrearLibroDto libroDto)
        {
            var consult = libroRepositorio.GetAll();
            consult = consult.Where(a => a.Id == id);
            var libro = consult.SingleOrDefault();

            libro.ISBN=libroDto.ISBN;
            libro.Titulo = libroDto.Titulo;


            await libroRepositorio.UpdateAsync(libro);
            return true;
        }
    }
}
