namespace WebApplication5.Models
{
    public class EducationModel : EducationDto
    {
        public bool IsCurrentlyStudying { get; set; }
        public void CloseEducation()
        {
            if (IsCurrentlyStudying)
            {
                EndDate = null;
            }
        }
    }
    public class EducationDto
    {
        public string School { get; set; }
        public string Degree { get; set; }
        public string CourseName { get; set; }
        public string StudyLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
