using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class Question : Entity
    {
        public string Text { get; private set; }
        public string Description { get; private set; }
        public bool IsRequired { get; private set; }
        public string CustomErrorMessage { get; private set; }
        public QuestionType Type { get; set; }

        public IEnumerable<SectionQuestion> QuestionSections { get; set; }
        public Answer Answer { get; protected set; } 
    }
}
