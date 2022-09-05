using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Dtos
{
    public class PassiveProgrammingLanguageDto
    {
        public int Id { get; set; }
        public bool Status { get; set; }
     
    }
}
