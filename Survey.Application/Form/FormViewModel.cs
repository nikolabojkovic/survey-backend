using Survey.Domain.Survey;
using System.Collections.Generic;

namespace Survey.Application
{
    public class FormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FormType Type { get; set; }

        public IEnumerable<SectionViewModel> Sections { get; set; }
    }
}
