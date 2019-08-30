using Survey.Domain.Analytics;
using Survey.Domain.Users;
using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class Form : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOpen { get; set; }
        public FormType Type { get; set; }
        public AnaliticsType AnaliticsType { get; set; }
        
        public ICollection<Section> Sections { get; set; }
        public ICollection<FormUser> FormUsers { get; set; }
    }
}
