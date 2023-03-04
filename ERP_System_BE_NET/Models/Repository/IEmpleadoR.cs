namespace ERP_System_BE_NET.Models.Repository
{
    public interface IEmpleadoR
    {
        Task<List<Empleado>> GetEmpleados(bool estado);
        Task<List<Empleado>> GetBajaEmpleados();
        Task<Empleado> GetEmpleado(int id);
        Task<Empleado> AddEmpleado(Empleado empleado);
        Task UpdateEmpleado(Empleado empleado);
        Task DeleteEmpleado(int id);
    }
}
