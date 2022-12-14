using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technology : Entity
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public Technology()
        {

        }

        public Technology(int id, int programmingLanguageId, string name, bool status) : this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
            Status = status;
        }
    }
}
