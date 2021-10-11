using System;
using System.Threading.Tasks;

namespace traveler.identity.api.domain.SeedWork
{
	public interface IUnitOfWork
	{
		Task<bool> Commit();
	}
}