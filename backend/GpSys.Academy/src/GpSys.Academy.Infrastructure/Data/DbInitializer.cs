using Bogus;
using GpSys.Academy.Application.Common.Interfaces;
using GpSys.Academy.Infrastructure.Persistence;

namespace GpSys.Academy.Infrastructure.Data
{
  public class DbInitializer(ApplicationDbContext context) : IDbInitializer
  {
    private readonly ApplicationDbContext _context = context;

    public async Task SeedAsync(int count)
    {
      if (_context.Courses.Any()) return;

      var courseFaker = new Faker<Course>()
        .CustomInstantiator(f =>
        {
          var code = f.Commerce.Ean8();
          var title = f.Company.CatchPhrase();
          var alias = f.Random.Replace("???-###");

          var result = Course.Create(code, title, alias);

          return result.Value!;
        });

      var courses = courseFaker.Generate(count);

      await _context.Courses.AddRangeAsync(courses);
      await _context.SaveChangesAsync();
    }

    public async Task ClearAsync()
    {
      await _context.Courses.IgnoreQueryFilters().ExecuteDeleteAsync();
    }

    public async Task ResetAsync(int count)
    {
      await ClearAsync();
      await SeedAsync(count);
    }
  }
}