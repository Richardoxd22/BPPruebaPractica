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
    public class EditorialServicio : IEditorialServicio
    {
        private readonly IEditorialRepositorio editorialRepositorio;

        public EditorialServicio(IEditorialRepositorio editorialRepositorio)
        {
            this.editorialRepositorio = editorialRepositorio;
        }

        public async Task<bool> CreateAsync(CrearEditorialDto editorialDto)
        {
            var editorial = new Editorial
            {
                Nombre = editorialDto.Nombre,
                Direccion = editorialDto.Direccion
            };
            await editorialRepositorio.CreateAsync(editorial);
            return true;
        }

        public async Task<bool> DeletedAsync(int id)
        {
            var consult = editorialRepositorio.GetAll();
            consult = consult.Where(a => a.Id == id);
            var editorial = consult.SingleOrDefault();

            await editorialRepositorio.DeleteAsync(editorial);
            return true;
        }

        public async Task<ICollection<EditorialDto>> GetAllAsync()
        {
            var consult = editorialRepositorio.GetAll();
            var listaeditoriales = await consult.Select(x => new EditorialDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Direccion = x.Direccion
            }).ToListAsync();

            return listaeditoriales;
        }

        public async Task<EditorialDto> GetByIdAsync(int id)
        {
            var consult = editorialRepositorio.GetAll();
            consult = consult.Where(a => a.Id == id);
            var editorial = await consult.Select(a => new EditorialDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Direccion = a.Direccion
            }).SingleOrDefaultAsync();
            return editorial;
        }

        public async Task<bool> UpdatedAsync(int id, CrearEditorialDto editorialDto)
        {
            var consult = editorialRepositorio.GetAll();
            consult = consult.Where(a => a.Id == id);
            var editorial = consult.SingleOrDefault();

            editorial.Nombre=editorialDto.Nombre;
            editorial.Direccion = editorialDto.Direccion;


            await editorialRepositorio.UpdateAsync(editorial);
            return true;
        }
    }
}
