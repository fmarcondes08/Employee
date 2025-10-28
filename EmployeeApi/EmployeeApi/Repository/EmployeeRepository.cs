using Microsoft.EntityFrameworkCore;
using TallerCodeChallengeApi.Data;
using TallerCodeChallengeApi.Models;
using TallerCodeChallengeApi.Models.Interfaces.Repositories;

namespace TallerCodeChallengeApi.Repository;

public class EmployeeRepository(AppDbContext db) : IEmployeeRepository
{
    public async Task<List<Employee>> GetAllAsync()
    {
        return await db.Employees.AsNoTracking().ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await db.Employees.FindAsync(id);
    }

    public async Task<Employee> CreateAsync(Employee employee)
    {
        db.Employees.Add(employee);
        await db.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> UpdateAsync(Employee employee)
    {
        db.Employees.Update(employee);
        await db.SaveChangesAsync();
        return employee;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        db.Employees.Remove(db.Employees.Find(id));
        await db.SaveChangesAsync();
        return true;
    }
}