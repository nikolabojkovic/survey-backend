using Survey.Domain.Analytics;
using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class Form : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsOpen { get; private set; }
        public FormType Type { get; private set; }
        public AnaliticsType AnaliticsType { get; private set; }
        
        public ICollection<Section> Sections { get; private set; }
        public ICollection<FormUser> FormUsers { get; private set; }
        public ICollection<QuestionResponse> QuestionResponses { get; private set; }

        public static Form Create(string name, string descripion)
        {
            return new Form
            {
                Sections = new List<Section>(),
                FormUsers = new List<FormUser>(),

                Name = name,
                Description = descripion,

                Type = FormType.Survey,
                AnaliticsType = AnaliticsType.Summary
            };
        }

        public Form AddSection(string name, string description)
        {
            var section = Section.Create(name, description, Id);
            Sections.Add(section);

            return this;
        }
    }
}
