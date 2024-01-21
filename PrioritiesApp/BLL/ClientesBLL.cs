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

    public async Task<bool> Guardar(Clientes cliente, Clientes guardarCliente)
    {
        if (!await Existe(cliente.ClienteId))
            return await Insertar(cliente);
        else
        {
            if(guardarCliente.Nombre == cliente.Nombre && guardarCliente.RNC == cliente.RNC)///si el nombre y el RNC buscado no se ha cambiado
				return await Modificar(cliente);

			else if(guardarCliente.Nombre == cliente.Nombre)//el nombre no se cambio
            {
				if (await BuscarRNC(cliente.RNC) == null)//nuevo nombre y nuevo RNC
					return await Modificar(cliente);
			}
            else if(guardarCliente.RNC == cliente.RNC)//el RNC no se cambio
            {
                if(await BuscarCliente(cliente.Nombre) == null)
                    return await Modificar(cliente);
            }

			else
            {
				if (await BuscarCliente(cliente.Nombre) == null && await BuscarRNC(cliente.RNC) == null)//nuevo nombre y nuevo RNC
					return await Modificar(cliente);
			}
		}

        return false;
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
