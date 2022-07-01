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
    public class AutorServicio : IAutorServicio
    {
        private readonly IAutorRepositorio autorRepositorio;

        public AutorServicio(IAutorRepositorio autorRepositorio)
        {
            this.autorRepositorio = autorRepositorio;
        }

        public async Task<bool> CreateAsync(CrearAutorDto autorDto)
        {
            var autor = new Autor
            {
                Nombre = autorDto.Nombre,
                Apellido = autorDto.Apellido
            };
            await autorRepositorio.CreateAsync(autor);
            return true;
        }

        public async Task<bool> DeletedAsync(int id)
        {
            var consult = autorRepositorio.GetAll();
            consult = consult.Where(a => a.Id == id);
            var autor = consult.SingleOrDefault();

            await autorRepositorio.DeleteAsync(autor);
            return true;
        }

        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
            var consult = autorRepositorio.GetAll();
            var listaautores = await consult.Select(x => new AutorDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).ToListAsync();

            return listaautores;
        }

        public async Task<AutorDto> GetByIdAsync(int id)
        {
            var consult = autorRepositorio.GetAll();
            consult = consult.Where(a => a.Id == id);
            var autor = await consult.Select(a => new AutorDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Apellido = a.Apellido
            }).SingleOrDefaultAsync();
            return autor;
        }

        public async Task<bool> UpdatedAsync(int id, CrearAutorDto autorDto)
        {
            var consult = autorRepositorio.GetAll();
            consult = consult.Where(a => a.Id == id);
            var autor = consult.SingleOrDefault();

            autor.Nombre=autorDto.Nombre;
            autor.Apellido = autorDto.Apellido;


            await autorRepositorio.UpdateAsync(autor);
            return true;
        }
    }
}
