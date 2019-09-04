using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class Question : Entity
    {
        public string Text { get; protected set; }
        public string Description { get; protected set; }
        public bool IsRequired { get; protected set; }
        public string CustomErrorMessage { get; protected set; }
        public QuestionType Type { get; protected set; }

        public ICollection<SectionQuestion> QuestionSections { get; protected set; }
        public ICollection<QuestionResponse> QuestionResponses { get; protected set; }
        public ICollection<Answer> Answers { get; set; }

        public void Update(string text, string description, bool isRequired, string custormErrorMessage)
        {
            Text = text;
            Description = description;
            IsRequired = isRequired;
            CustomErrorMessage = CustomErrorMessage;
        }
    }
}
