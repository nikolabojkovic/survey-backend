using System.Collections.Generic;

namespace Survey.Application
{
    public class SectionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}
