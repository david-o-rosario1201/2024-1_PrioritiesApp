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

        public bool Eliminar(int id)
		{
			var priority = _context.Priorities.Find(id);
			_context.Priorities.Remove(priority);
			return _context.SaveChanges() > 0;

        }

		public bool Guardar(Priorities Priority)
		{
			if (Priority.PriorityId == 0)
				_context.Priorities.Add(Priority);

			else
                _context.Entry(Priority).State = EntityState.Modified;

            return _context.SaveChanges() > 0;
        }

        public Priorities? Buscar(int priorityId)
		{
			return _context.Priorities.Where(o => o.PriorityId == priorityId).
				AsNoTracking().SingleOrDefault();
		}

		public Priorities? BuscarDescripcion(string description)
		{
			return _context.Priorities.Where(des => des.Description.ToLower() == description.ToLower()).
				AsNoTracking().SingleOrDefault();
		}
	}
}