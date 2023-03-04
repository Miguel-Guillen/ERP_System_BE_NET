using ERP_System_BE_NET.Models;
using ERP_System_BE_NET.Models.DTO;
using ERP_System_BE_NET.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ERP_System_BE_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        //private readonly IMapper _mapper;
        private readonly IEmpleadoR _empleadoR;

        public EmpleadoController(IEmpleadoR empleadoR)
        {
            //_mapper = mapper;
            _empleadoR = empleadoR;
        }

        [HttpGet]
        public async Task<IActionResult> Get(bool estado)
        {
            try
            {
                var listaEmpleados = await _empleadoR.GetEmpleados(estado);
                //var listMascotasDto = _mapper.Map<IEnumerable<MascotaDTO>>(listMascotas);

                return Ok(listaEmpleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Baja")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaEmpleados = await _empleadoR.GetBajaEmpleados();
                return Ok(listaEmpleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var empleadoEncontrado = await _empleadoR.GetEmpleado(id);
                if (empleadoEncontrado == null)
                {
                    return NotFound();
                }

                // var empleadoDTO = _mapper.Map<MascotaDTO>(mascota);
                return Ok(empleadoEncontrado);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Empleado empleadoDTO)
        {
            try
            {
                // var empleadoEncontrado = _mapper.Map<Mascota>(empleadoDTO);
                var empleado = empleadoDTO;
                empleado.Ingreso = DateTime.Now;
                var newEmpleado = await _empleadoR.AddEmpleado(empleado);
                // var empleadoAgregado = _mapper.Map<MascotaDTO>(mascota);

                return CreatedAtAction(nameof(Get), new { id = newEmpleado.id }, newEmpleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Empleado empleado)
        {
            try
            {
                // var empleado = _mapper.Map<Mascota>(mascotaDto);
                var nuevoEmpleado = empleado;
                if (id != nuevoEmpleado.id)
                {
                    return BadRequest();
                }

                var empleadoEncontrado = await _empleadoR.GetEmpleado(id);
                if (empleadoEncontrado == null)
                {
                    return NotFound();
                }

                await _empleadoR.UpdateEmpleado(nuevoEmpleado);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var empleadoEncontrado = await _empleadoR.GetEmpleado(id);
                if (empleadoEncontrado == null)
                {
                    return NotFound();
                }

                await _empleadoR.DeleteEmpleado(empleadoEncontrado.id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
