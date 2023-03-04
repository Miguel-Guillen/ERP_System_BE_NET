using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP_System_BE_NET.Models.Repository
{
    public class EmpleadoR : IEmpleadoR
    {
        private readonly AplicationDBContext _dbcontext;
        public EmpleadoR(AplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // Get list of employees
        public async Task<List<Empleado>> GetEmpleados(bool estado)
        {
            if(estado == false)
            {
                return await _dbcontext.Empleados.Where(e => e.Estado != false).ToListAsync();
            }
            else
            {
                return await _dbcontext.Empleados.ToListAsync();
            }
        }

        // Get list of furloughed employees
        public async Task<List<Empleado>> GetBajaEmpleados()
        {
            return await _dbcontext.Empleados.Where(e => e.Estado == false).ToListAsync();
        }

        // Get one employee
        public async Task<Empleado> GetEmpleado(int id)
        {
            return await _dbcontext.Empleados.FindAsync(id);
            // return await _dbcontext.Empleados.FirstOrDefaultAsync(e => e.id == id && e.Estado == true);
        }

        // Add new employee
        public async Task<Empleado> AddEmpleado(Empleado empleado)
        {
            _dbcontext.Add(empleado);
            await _dbcontext.SaveChangesAsync();
            return empleado;
        }

        // Update employee
        public async Task UpdateEmpleado(Empleado empleado)
        {
            var empleadoEncontrado = await _dbcontext.Empleados.FirstOrDefaultAsync(x => x.id == empleado.id);
            if (empleadoEncontrado != null)
            {
                empleadoEncontrado.Email = empleado.Email;
                empleadoEncontrado.Area = empleado.Area;
                empleadoEncontrado.Estado = empleado.Estado;
                empleadoEncontrado.Puesto = empleado.Puesto;
                empleadoEncontrado.Nombre = empleado.Nombre;
                empleadoEncontrado.Apellidos = empleado.Apellidos;
                empleadoEncontrado.Ingreso = empleado.Ingreso;
            }

            await _dbcontext.SaveChangesAsync();
        }

        // Delete employee
        public async Task DeleteEmpleado(int id)
        {
            var empleadoEncontrado = await _dbcontext.Empleados.FirstOrDefaultAsync(empleado => empleado.id == id);
            if (empleadoEncontrado != null)
            {
                // _dbcontext.Remove(empleadoEncontrado);
                empleadoEncontrado.Estado = false;
            }

            await _dbcontext.SaveChangesAsync();
        }
    }
}
