using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServicioDef;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase,ILibroServicio
    {
        private readonly ILibroServicio libroServicio;
      public LibroController(ILibroServicio libroServicio)
        {
            this.libroServicio = libroServicio;
        }
        [HttpPost]
        public async Task<bool> CreateAsync(CrearLibroDto libroDto)
        {
            return await libroServicio.CreateAsync(libroDto);
        }
        [HttpDelete]
        public async Task<bool> DeletedAsync(int id)
        {
            return await libroServicio.DeletedAsync(id);
        }
        [HttpGet]
        public async Task<ICollection<LibroDto>> GetAllAsync()
        {
           return await libroServicio.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<LibroDto> GetByIdAsync(int id)
        {
            return await libroServicio.GetByIdAsync(id);
        }
        [HttpPut]
        public async Task<bool> UpdatedAsync(int id, CrearLibroDto libroDto)
        {
            return await libroServicio.UpdatedAsync(id, libroDto);
        }
    }
}
