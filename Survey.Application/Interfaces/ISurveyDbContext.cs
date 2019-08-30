using Microsoft.EntityFrameworkCore;
using Survey.Domain.Survey;
using System.Threading;
using System.Threading.Tasks;

namespace Survey.Application.Interfaces
{
    public interface ISurveyDbContext
    {
        DbSet<Form> Forms { get; set; }
        DbSet<Question> Questions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
