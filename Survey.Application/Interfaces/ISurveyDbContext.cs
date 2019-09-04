using Microsoft.EntityFrameworkCore;
using Survey.Domain.Survey;
using Survey.Domain.Survey.Result;
using Survey.Domain.Users;
using System.Threading;
using System.Threading.Tasks;

namespace Survey.Application.Interfaces
{
    public interface ISurveyDbContext
    {
        DbSet<Form> Forms { get; set; }
        DbSet<Section> Sections { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<QuestionResponse> QuestionResponses { get; set; }
        DbSet<RadioButtonQuestionResponse> RadioButtonQuestionResponses { get; set; }
        DbSet<CheckBoxQuestionResponse> CheckBoxQuestionResponses { get; set; }
        DbSet<TextQuestionResponse> TextQuestionResponses { get; set; }
        DbSet<SurveyResult> SurveyResults { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
