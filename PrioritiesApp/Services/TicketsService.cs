using Microsoft.EntityFrameworkCore;
using PrioritiesApp.DAL;
using PrioritiesApp.Models;
using System.Linq;
using System.Linq.Expressions;

namespace PrioritiesApp.Services;

public class TicketsService
{
	private readonly Context _context;

	public TicketsService(Context context)
	{
		_context = context;
	}

	public async Task<bool> Crear(Tickets tickets)
	{
		if (!await Existe(tickets.TicketId))
			return await Insertar(tickets);
		else
			return await Modificar(tickets);
	}

	public async Task<bool> Insertar(Tickets tickets)
	{
		_context.Tickets.Add(tickets);
		return await _context.SaveChangesAsync() > 0;
	}

	public async Task<bool> Modificar(Tickets tickets)
	{
		_context.Update(tickets);
		var modifico = await _context.SaveChangesAsync() > 0;
		_context.Entry(tickets).State = EntityState.Detached;
		return modifico;
	}

	public async Task<bool> Existe(int id)
	{
		return await _context.Tickets.AnyAsync(t => t.TicketId == id);
	}

	public async Task<bool> Eliminar(Tickets tickets)
	{
		var cantidad = await _context.Tickets
			.Where(t => t.TicketId == tickets.TicketId)
			.ExecuteDeleteAsync();
		return cantidad > 0;
	}

	public async Task<Tickets?> BuscarId(int Id)
	{
		return await _context.Tickets
			.AsNoTracking()
			.FirstOrDefaultAsync(t => t.TicketId == Id);
	}

	/*public async Task<Tickets?> BuscarSistema(string nombre)
	{
		return await _context.Tickets
			.AsNoTracking()
			.FirstOrDefaultAsync(t => t.Nombre == nombre);
	}*/

	public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
	{
		return await _context.Tickets.AsNoTracking().Where(criterio).ToListAsync();
	}
}
