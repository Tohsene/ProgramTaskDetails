using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class ProgramDetailsModel : ProgramDetailsDto
    {
        public int Id { get; set; }

    }

    public class ProgramDetailsDto
    {

        [Required]
        public string ProgramTitle { get; set; }

        [StringLength(250, ErrorMessage = "ProgramSummary cannot exceed 250 characters.")]
        public string? ProgramSummary { get; set; }

        [Required]
        public string ProgramDescription { get; set; }

        public string? ProgramSkills { get; set; }
        public string? ProgramBenefits { get; set; }
        public string? ApplicationCriteria { get; set; }

        [Required]
        public string ProgramType { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime? ProgramStart { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime ApplicationOpen { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime ApplicationClose { get; set; }

        public string? Duration { get; set; }

        [Required]
        public string ProgramLocation { get; set; }
        public string? MinQualification { get; set; }
        public int? NumOfApplications { get; set; }

    }
}
