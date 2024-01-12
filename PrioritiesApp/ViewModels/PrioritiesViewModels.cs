using PrioritiesApp.BLL;
using PrioritiesApp.Models;

namespace PrioritiesApp.ViewModels
{
	public class PrioritiesViewModels
	{
		private Priorities _priority = new Priorities();
		private string _mensaje = string.Empty;

		private readonly PrioritiesBLL _priorityBLL;

		public PrioritiesViewModels(PrioritiesBLL priorityBLL)
		{
			var t = new Priorities
			{
				PriorityId = 0,
				Description = ""
			};
			this._priorityBLL = priorityBLL;
		}

		public Priorities Priority
		{
			get { return _priority; }
			set { _priority = value; }
		}

		public void Nuevo()
		{
			Priority = new Priorities();
		}

		public void Save()
		{
			var guardar = _priorityBLL.Guardar(Priority);

			if(guardar)
			{

			}
		}

		public async void Buscar()
		{
			var buscar = await _priorityBLL.FindAsync(Priority.PriorityId);

			if (buscar != null)
				Priority = buscar;
		}

		public void Eliminar()
		{
			var eliminar = _priorityBLL.Delete(Priority.PriorityId);
		}
	}
}
