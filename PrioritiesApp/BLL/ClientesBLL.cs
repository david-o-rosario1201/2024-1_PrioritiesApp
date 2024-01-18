using Microsoft.EntityFrameworkCore;
using PrioritiesApp.DAL;
using PrioritiesApp.Models;
using System.Linq.Expressions;

namespace PrioritiesApp.BLL;

public class ClientesBLL
{
    private readonly Context _context;

    public ClientesBLL(Context context)
    {
        _context = context;
    }

    public async Task<bool> Guardar(Clientes cliente)
    {
        if (!await Existe(cliente.ClienteId))
            return await Insertar(cliente);
        else
            return await Modificar(cliente);
    }

    public async Task<bool> Insertar(Clientes cliente)
    {
        _context.Clientes.Add(cliente);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Clientes cliente)
    {
        _context.Update(cliente);
        return await _context.SaveChangesAsync() > 0;
    }

    private async Task<bool> Existe(int clienteId)
    {
        return await _context.Clientes
            .AnyAsync(c => c.ClienteId == clienteId);
    }

    public async Task<bool> Eliminar(Clientes cliente)
    {
        var cantidad = await _context.Clientes
            .Where(c => c.ClienteId == cliente.ClienteId)
            .ExecuteDeleteAsync();

        return cantidad > 0;
    }

    public async Task<Clientes?> BuscarCliente(string nombre)
    {
        return await _context.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Nombre.ToLower() == nombre.ToLower());
    }

    public async Task<Clientes?> BuscarId(int clienteId)
    {
        return await _context.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
    }

    public async Task<Clientes?> BuscarRNC(string RNC)
    {
        return await _context.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.RNC == RNC);
    }

    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
    {
        return await _context.Clientes
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
