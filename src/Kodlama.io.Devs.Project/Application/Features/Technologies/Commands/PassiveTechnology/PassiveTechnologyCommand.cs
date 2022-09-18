using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.PassiveTechnology
{
    public class PassiveTechnologyCommand : IRequest<PassiveTechnologyDto>
    {
        public int Id { get; set; }
        public bool Status { get; set; }

        public class PassiveTechnoloygCommandHandler : IRequestHandler<PassiveTechnologyCommand, PassiveTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public PassiveTechnoloygCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<PassiveTechnologyDto> Handle(PassiveTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology mappedTechnology = _mapper.Map<Technology>(request);
                Technology passiveTechnology = await _technologyRepository.UpdateAsync(mappedTechnology);
                PassiveTechnologyDto mappedPassiveTechnologyDto = _mapper.Map<PassiveTechnologyDto>(passiveTechnology);

                return mappedPassiveTechnologyDto;
            }
        }
    }
}
