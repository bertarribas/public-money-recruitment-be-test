using VacationRental.Domain.Interfaces;
using VacationRental.Domain.ViewModels;

namespace VacationRental.DataAccess.TypeRepositories
{
    public class ResourceIdViewModelRepository : IResourceIdViewModelRepository
    {
        public ResourceIdViewModel GetNewResourceId(int rentalsCount) =>  new ResourceIdViewModel { Id = rentalsCount + 1 };
    }
}
