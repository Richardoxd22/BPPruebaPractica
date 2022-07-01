using Curso.Biblioteca.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServicioDef
{
    public interface IAutorServicio
    {

        Task<ICollection<AutorDto>> GetAllAsync();

        Task<AutorDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CrearAutorDto autorDto);
        Task<bool> UpdatedAsync(int id, CrearAutorDto autorDto);
        Task<bool> DeletedAsync(int id);

    }
}
