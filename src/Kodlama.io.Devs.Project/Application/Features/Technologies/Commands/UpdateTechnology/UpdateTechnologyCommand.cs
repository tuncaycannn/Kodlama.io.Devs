using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<UpdateTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdateTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<UpdateTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.TechnologyIdMustExist(request.Id);

                Technology mappedTechnology = _mapper.Map<Technology>(request);
                Technology updateTechnology = await _technologyRepository.UpdateAsync(mappedTechnology);
                UpdateTechnologyDto mappedUpdateTechnologyDto = _mapper.Map<UpdateTechnologyDto>(updateTechnology);

                return mappedUpdateTechnologyDto;

            }
        }
    }
}
