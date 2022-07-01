using Curso.Biblioteca.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServicioDef
{
    public interface IEditorialServicio
    {

        Task<ICollection<EditorialDto>> GetAllAsync();

        Task<EditorialDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CrearEditorialDto editorialDto);
        Task<bool> UpdatedAsync(int id, CrearEditorialDto editorialDto);
        Task<bool> DeletedAsync(int id);

    }
}
