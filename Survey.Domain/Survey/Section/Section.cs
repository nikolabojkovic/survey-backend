using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class Section : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FormId { get; set; }

        public Form Form { get ; set; }
        public IEnumerable<SectionQuestion> SectionQuestions { get; set; }
    }
}
