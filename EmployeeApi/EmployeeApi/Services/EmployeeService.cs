using TallerCodeChallengeApi.Models;
using TallerCodeChallengeApi.Models.Interfaces.Repositories;
using TallerCodeChallengeApi.Models.Interfaces.Services;

namespace TallerCodeChallengeApi.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public async Task<List<Employee>> GetAllAsync()
    {
        return await employeeRepository.GetAllAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await employeeRepository.GetByIdAsync(id);
    }

    public async Task<Employee> CreateAsync(Employee employee)
    {
        return await employeeRepository.CreateAsync(employee);
    }

    public async Task<Employee?> UpdateAsync(Employee employee)
    {
        var existingEmployee = await employeeRepository.GetByIdAsync(employee.Id);
        if (existingEmployee == null) return null;
        
        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName  = employee.LastName;
        existingEmployee.Email     = employee.Email;
        existingEmployee.Position  = employee.Position;
        
        return await employeeRepository.UpdateAsync(existingEmployee);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var exists = await employeeRepository.GetByIdAsync(id);
        if (exists == null) return false;
        
        return await employeeRepository.DeleteAsync(id);
    }
}