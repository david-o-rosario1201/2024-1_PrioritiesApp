using PrioritiesApp.DAL;
using PrioritiesApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Linq;

namespace PrioritiesApp.BLL

{
	public class PrioritiesBLL
	{
		private Context _context;

        public PrioritiesBLL(Context context)
		{
			_context = context;
		}

		public async Task<Priorities?> FindAsync(int id)
		{
			var priority = await _context.Priorities.FindAsync(id);
			return priority;
		}

        public bool Delete(int id)
		{
			var priority = _context.Priorities.Find(id);
			_context.Priorities.Remove(priority);
			var deleted = _context.SaveChanges() > 0;
			return deleted;
		}

		public List<Priorities> GetPriorities()
		{
			var priorities = _context.Priorities.ToList();
			return priorities;
		}

		public bool Existe(int priorityId)
		{
			return _context.Priorities.Any(o => o.PriorityId == priorityId);
		}

		public bool Insertar(Priorities Priority)
		{
			_context.Priorities.Add(Priority);
			int cantidad = _context.SaveChanges();
			return cantidad > 0;
		}

		public bool Modificar(Priorities Priority)
		{
			_context.Entry(Priority).State = EntityState.Modified;
			return _context.SaveChanges() > 0;
		}

		/*public bool Guardar(Priorities Priority)
		{
			if (!Existe(Priority.PriorityId))
				return Insertar(Priority);

			else
				return Modificar(Priority);
		}*/

		public bool Guardar(Priorities Priority)
		{
			if (Priority.PriorityId == 0)
				_context.Priorities.Add(Priority);
			else
				_context.Entry(Priority).State = EntityState.Modified;

			var saved = _context.SaveChanges() > 0;
			return saved;
		}

		public bool Eliminar(Priorities Priority)
		{
			_context.Priorities.Remove(Priority); 
			int cantidad = _context.SaveChanges();
			return cantidad > 0;
		}

		/*public Priorities? Buscar(int PriorityId)
		{
			return _context.Priorities.AsNoTracking().FirstOrDefault(s => s.PriorityId ==PriorityId);
		}*/ //XmlConfigurationExtensions

		public Priorities? Buscar(int priorityId)
		{
			return _context.Priorities.Where(o => o.PriorityId == priorityId).
				AsNoTracking().SingleOrDefault();
		}
	}
}