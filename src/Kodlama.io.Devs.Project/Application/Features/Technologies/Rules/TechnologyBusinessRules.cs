using Application.Features.Technologies.Constans;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException(BusinessRulesConstants.TechnologyExistsBefore);
        }

        public async Task TechnologyIdMustExist(int id)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(b => b.Id == id);
            if (!result.Items.Any()) throw new BusinessException(BusinessRulesConstants.TechnologyNotExist);
        }
    }
}
