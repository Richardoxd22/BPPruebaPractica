using Curso.Biblioteca.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServicioDef
{
    public interface ILibroServicio
    {

        Task<ICollection<LibroDto>> GetAllAsync();

        Task<LibroDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CrearLibroDto libroDto);
        Task<bool> UpdatedAsync(int id, CrearLibroDto libroDto);
        Task<bool> DeletedAsync(int id);

    }
}
