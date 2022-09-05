using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.PassiveProgrammingLanguage
{
    public class PassiveProgrammingLanguageCommand : IRequest<PassiveProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public bool Status { get; set; }

        public class PassiveProgrammingLanguageCommandHandler : IRequestHandler<PassiveProgrammingLanguageCommand, PassiveProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public PassiveProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<PassiveProgrammingLanguageDto> Handle(PassiveProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.ProgrammingLanguageIdMustExist(request.Id);

                ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage passiveProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(mappedProgrammingLanguage);
                PassiveProgrammingLanguageDto mappedBrandDto = _mapper.Map<PassiveProgrammingLanguageDto>(passiveProgrammingLanguage);

                return mappedBrandDto;
            }
        }
    }
}
