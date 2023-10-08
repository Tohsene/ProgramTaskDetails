namespace WebApplication5.Models
{
    public class WorkFlowStage
    {
        public string StageName { get; set; }
        public List<Stage> StateType { get; set; }
    }

    public class Stage
    {
        public string Shortlisting { get; set; }
        public Interview VideoInterview { get; set; }
        public string Placement { get; set; }
    }

    public class Interview
    {
        public string InterviewQuestion { get; set; }
        public string VideoAdditionalInfo { get; set; }
        public DateTime VideoDuration { get; set; }
        public int VideoSubmissionDeadline { get; set; }
    }
}
