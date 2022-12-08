using BlazorContactos.Server.Model;
using BlazorContactos.Server.Model.Entities;
using BlazorContactos.Shared.DTOS.MediosContactos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorContactos.Server.Controllers
{
    [ApiController, Route("api/MediosContactos")]
    public class MediosContactosController : ControllerBase  
    {
        private readonly ApplicationDbContext context;

        public MediosContactosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MediosContactoDTO>>> GetAlumnos()
        {
            var mediosContactos = await context.MediosContactos.ToListAsync();

            var mediosContactoDTO = new List<MediosContactoDTO>();

            foreach (var mediosContacto in mediosContactos)
            {
                var MediosContactoDTO = new MediosContactoDTO();
                MediosContactoDTO.Id = mediosContacto.Id;
                MediosContactoDTO.TipoContacto = mediosContacto.TipoContacto;
                MediosContactoDTO.Contacto = mediosContacto.Contacto;


                mediosContactoDTO.Add(MediosContactoDTO);
            }

            return mediosContactoDTO;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MediosContactoDTO>> Get(int id)
        {
            var mediosContacto = await context.MediosContactos.FirstOrDefaultAsync(x => x.Id == id);

            if (mediosContacto == null)
            {
                return NotFound();
            }

            var MediosContactoDTO = new MediosContactoDTO();
            MediosContactoDTO.Id = mediosContacto.Id;
            MediosContactoDTO.Contacto = mediosContacto.Contacto;
            

            return MediosContactoDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] MediosContactoDTO mediosContactoDTO)
        {
            var mediosContacto = new MediosContacto();
            
            mediosContacto.Contacto = mediosContactoDTO.Contacto;

            context.MediosContactos.Add(mediosContacto);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] MediosContactoDTO mediosContactoDTO)
        {
            var mediosContactoDb = await context.MediosContactos.FirstOrDefaultAsync(x => x.Id == mediosContactoDTO.Id);

            if (mediosContactoDb == null)
            {
                return NotFound();
            }

            mediosContactoDb.Contacto = mediosContactoDb.Contacto;

            context.MediosContactos.Update(mediosContactoDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var mediosContactoDb = await context.MediosContactos.FirstOrDefaultAsync(x => x.Id == id);

            if (mediosContactoDb == null)
            {
                return NotFound();
            }

            context.MediosContactos.Remove(mediosContactoDb);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}

