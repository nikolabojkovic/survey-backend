using Microsoft.EntityFrameworkCore;
using Survey.Application.Interfaces;
using Survey.Domain.Survey;
using Survey.Persistence.Configurations;

namespace Survey.Persistence
{
    public class SurveyDbContext : DbContext, ISurveyDbContext
    {

        public SurveyDbContext(DbContextOptions<SurveyDbContext> options)
           : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<Question> Questions { get ; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FormConfiguration());

            modelBuilder.ApplyConfiguration(new SectionConfiguration());

            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new CheckBoxesQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new RadioButtonsQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new ShortQuestionConfiguration());

            modelBuilder.ApplyConfiguration(new AnswerConfiguration());

            modelBuilder.ApplyConfiguration(new OptionConfiguration());
            modelBuilder.ApplyConfiguration(new TextOptionConfiguration());
            modelBuilder.ApplyConfiguration(new CheckBoxOptionConfiguration());
            modelBuilder.ApplyConfiguration(new RadioButtonOptionConfiguration());

            modelBuilder.ApplyConfiguration(new ResponseConfiguration());
            modelBuilder.ApplyConfiguration(new ResponseOptionConfiguration());
            modelBuilder.ApplyConfiguration(new ResponseTextOptionConfiguration());
            modelBuilder.ApplyConfiguration(new ResponseCheckBoxOptionConfiguration());
            modelBuilder.ApplyConfiguration(new ResponseRadioButtonOptionConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new SectionQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new FormUserConfiguration());
        }
    }
}
