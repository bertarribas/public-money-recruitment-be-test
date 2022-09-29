using System.Collections.Generic;
using VacationRental.Domain.ViewModels;

namespace VacationRental.Domain.Interfaces
{
    public interface IResourceIdViewModelRepository
    {
        ResourceIdViewModel GetNewResourceId(int rentalsCount);
    }
}