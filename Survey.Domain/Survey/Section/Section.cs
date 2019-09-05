using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class Section : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FormId { get; set; }

        public Form Form { get ; set; }
        public ICollection<SectionQuestion> SectionQuestions { get; set; }

        public static Section Create(string name, string description, int formId)
        {
            return new Section
            {
                Name = name,
                Description = description,

                FormId = formId
            };
        }

        public Section AddQuestion(int questionId)
        {
            var sectionQuestion = new SectionQuestion { SectionId = Id, QuestionId = questionId };
            SectionQuestions.Add(sectionQuestion);

            return this;
        }
    }
}
