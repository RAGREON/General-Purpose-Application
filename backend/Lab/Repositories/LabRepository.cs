namespace Lab.Repositories
{
  public class LabRepository(LabContext _context) : ILabRepository
  {

    public async Task<LabEntity?> GetByIdAsync(int id)
    {
      return await _context.Labs.FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<IList<LabEntity>> GetAllAsync()
    {
      return await _context.Labs.ToListAsync();
    }

    public async Task CreateAsync(LabEntity lab)
    {
      await _context.Labs.AddAsync(lab);
      await _context.SaveChangesAsync();
    }

    public async Task FilterAsync()
    {
      await _context.SaveChangesAsync();
    }
  }
};