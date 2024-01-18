using PrioritiesApp.DAL;
using PrioritiesApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Linq;
using System.Linq.Expressions;

namespace PrioritiesApp.BLL;

public class PrioritiesBLL
{
    private readonly Context _context;

    public PrioritiesBLL(Context context)
    {
        _context = context;
    }

    public async Task<bool> Guardar(Priorities priority)
    {
        if (!await Existe(priority.PriorityId))
            return await Insertar(priority);
        else
            return await Modificar(priority);
    }

    private async Task<bool> Insertar(Priorities priority)
    {
        _context.Priorities.Add(priority);
        return await _context.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Priorities priority)
    {
        _context.Update(priority);
        return await _context.SaveChangesAsync() > 0;
    }

    private async Task<bool> Existe(int priorityId)
    {
        return await _context.Priorities
            .AnyAsync(p => p.PriorityId == priorityId);
    }

    public async Task<bool> Eliminar(Priorities priority)
    {
        var cantidad = await _context.Priorities
            .Where(p => p.PriorityId == priority.PriorityId)
            .ExecuteDeleteAsync();

        return cantidad > 0;
    }

    public async Task<Priorities?> Buscar(int priorityId)
    {
        return await _context.Priorities
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PriorityId == priorityId);
    }

    public async Task<List<Priorities>> Listar(Expression<Func<Priorities, bool>> criterio)
    {
        return await _context.Priorities
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}