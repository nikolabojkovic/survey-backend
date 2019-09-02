using Microsoft.EntityFrameworkCore;
using Survey.Application.Interfaces;
using Survey.Domain.Survey;
using Survey.Domain.Users;
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
        public DbSet<Section> Sections { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<QuestionResponse> QuestionResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FormConfiguration());

            modelBuilder.ApplyConfiguration(new SectionConfiguration());

            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new CheckBoxesQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new RadioButtonsQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new ShortQuestionConfiguration());

            modelBuilder.ApplyConfiguration(new AnswerConfiguration());

            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new TextAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new CheckBoxAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new RadioButtonAnswerConfiguration());

            modelBuilder.ApplyConfiguration(new QuestionResponseConfiguration());
            modelBuilder.ApplyConfiguration(new ResponseTextOptionConfiguration());
            modelBuilder.ApplyConfiguration(new CehckboxQuestionResponseConfiguration());
            modelBuilder.ApplyConfiguration(new ResponseRadioButtonOptionConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new SectionQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new FormUserConfiguration());
        }
    }
}
