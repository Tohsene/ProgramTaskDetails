namespace WebApplication5.Models
{
    public class ApplicationFormModel
    {
        public string? CoverImage { get; set; }
        public PersonalInfoModel? PersonalInformation { get; set; }
        public ProfileModel? Profile { get; set; }
        public AdditionQuestionModel? AdditionQuestion { get; set; }
    }

    public class AdditionQuestionModel
    {
        public QuestionType Question { get; set; }
    }

    public class ProfileModel
    {
        public EducationDto? Education { get; set; }
        public WorkExperienceDto? Experience { get; set; }
        public string? Resume { get; set; }
    }

    public class PersonalInfoModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public string? CurrentResidence { get; set; }
        public string? IDNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
    }
}
