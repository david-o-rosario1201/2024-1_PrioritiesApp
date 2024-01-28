using Microsoft.EntityFrameworkCore;
using PrioritiesApp.DAL;
using PrioritiesApp.Models;
using System.Linq.Expressions;

namespace PrioritiesApp.Services;

public class SistemasServices
{
	private readonly Context _context;

	public SistemasServices(Context context)
	{
		_context = context;
	}

	public async Task<bool> Crear(Sistemas sistema)
	{
		if (!await Existe(sistema.SistemaId))
			return await Insertar(sistema);
		else
			return await Modificar(sistema);
	}

	public async Task<bool> Insertar(Sistemas sistema)
	{
		_context.Sistemas.Add(sistema);
		return await _context.SaveChangesAsync() > 0;
	}

	public async Task<bool> Modificar(Sistemas sistema)
	{
		_context.Update(sistema);
		var modifico = await _context.SaveChangesAsync() > 0;
		_context.Entry(sistema).State = EntityState.Detached;
		return modifico;
	}

	public async Task<bool> Existe(int id)
	{
		return await _context.Sistemas.AnyAsync(s => s.SistemaId == id);
	}

	public async Task<bool> Eliminar(Sistemas sistema)
	{
		var cantidad = await _context.Sistemas
			.Where(s => s.SistemaId == sistema.SistemaId)
			.ExecuteDeleteAsync();
		return cantidad > 0;
	}

	public async Task<Sistemas?> BuscarId(int Id)
	{
		return await _context.Sistemas
			.AsNoTracking()
			.FirstOrDefaultAsync(p => p.SistemaId == Id);
	}

	public async Task<Sistemas?> BuscarSistema(string nombre)
	{
		return await _context.Sistemas
			.AsNoTracking()
			.FirstOrDefaultAsync(s => s.Nombre == nombre);
	}

	public async Task<List<Sistemas>> Listar(Expression<Func<Sistemas, bool>> criterio)
	{
		return await _context.Sistemas.AsNoTracking().Where(criterio).ToListAsync();
	}
}
