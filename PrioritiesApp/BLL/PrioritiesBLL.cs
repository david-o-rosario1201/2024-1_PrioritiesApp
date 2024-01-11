using PrioritiesApp.DAL;
using PrioritiesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace PrioritiesApp.BLL

{
	public class PrioritiesBLL
	{
		private Context _context;

		public PrioritiesBLL(Context context)
		{
			_context = context;
		}

		public bool Save(Priorities priority)
		{
			if (priority.PriorityId == 0)
				_context.Priorities.Add(priority);

			else
				_context.Entry(priority).State = EntityState.Modified;

			var saved = _context.SaveChanges() > 0;
			return saved;
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
	}
}