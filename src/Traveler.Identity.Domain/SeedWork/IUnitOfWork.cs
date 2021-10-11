using System.Threading.Tasks;

namespace Traveler.Identity.Domain.SeedWork
{
	public interface IUnitOfWork
	{
		Task<bool> Commit();
	}
}