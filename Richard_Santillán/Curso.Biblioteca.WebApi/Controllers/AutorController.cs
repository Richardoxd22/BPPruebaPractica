using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServicioDef;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase,IAutorServicio
    {
        private readonly IAutorServicio autorServicio;
      public AutorController(IAutorServicio autorServicio)
        {
            this.autorServicio = autorServicio;
        }
        [HttpPost]
        public async Task<bool> CreateAsync(CrearAutorDto autorDto)
        {
            return await autorServicio.CreateAsync(autorDto);
        }
        [HttpDelete]
        public async Task<bool> DeletedAsync(int id)
        {
            return await autorServicio.DeletedAsync(id);
        }
        [HttpGet]
        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
           return await autorServicio.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<AutorDto> GetByIdAsync(int id)
        {
            return await autorServicio.GetByIdAsync(id);
        }
        [HttpPut]
        public async Task<bool> UpdatedAsync(int id, CrearAutorDto autorDto)
        {
            return await autorServicio.UpdatedAsync(id, autorDto);
        }
    }
}
