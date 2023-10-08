namespace WebApplication5.Models
{
    public class WorkExperienceModel : WorkExperienceDto
    {
        public bool IsCurrentlyWorking { get; set; }
        public void CloseWork()
        {
            if (IsCurrentlyWorking)
            {
                EndDate = null;
            }
        }
    }
    public class WorkExperienceDto
    {
        public string Company { get; set; }
        public string Title { get; set; }
        public string WorkLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
