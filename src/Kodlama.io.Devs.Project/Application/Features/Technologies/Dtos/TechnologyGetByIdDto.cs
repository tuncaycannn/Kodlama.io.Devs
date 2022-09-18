namespace Application.Features.Technologies.Dtos
{
    public class TechnologyGetByIdDto
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public int ProgrammingLanguageName { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

    }
}
