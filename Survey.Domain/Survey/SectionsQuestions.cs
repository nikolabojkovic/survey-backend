namespace Survey.Domain.Survey
{
    public class SectionQuestion
    {
        public int QuestionOrderIndex { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
