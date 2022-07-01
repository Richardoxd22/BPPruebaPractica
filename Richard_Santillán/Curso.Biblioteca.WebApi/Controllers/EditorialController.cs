using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServicioDef;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase,IEditorialServicio
    {
        private readonly IEditorialServicio editorialServicio;
      public EditorialController(IEditorialServicio editorialServicio)
        {
            this.editorialServicio = editorialServicio;
        }
        [HttpPost]
        public async Task<bool> CreateAsync(CrearEditorialDto editorialDto)
        {
            return await editorialServicio.CreateAsync(editorialDto);
        }
        [HttpDelete]
        public async Task<bool> DeletedAsync(int id)
        {
            return await editorialServicio.DeletedAsync(id);
        }
        [HttpGet]
        public async Task<ICollection<EditorialDto>> GetAllAsync()
        {
           return await editorialServicio.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<EditorialDto> GetByIdAsync(int id)
        {
            return await editorialServicio.GetByIdAsync(id);
        }
        [HttpPut]
        public async Task<bool> UpdatedAsync(int id, CrearEditorialDto editorialDto)
        {
            return await editorialServicio.UpdatedAsync(id, editorialDto);
        }
    }
}
