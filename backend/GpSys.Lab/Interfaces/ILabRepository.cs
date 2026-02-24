namespace Lab.Interfaces
{
  public interface ILabRepository
  {
    Task<LabEntity?> GetByIdAsync(int id);
    Task<IList<LabEntity>> GetAllAsync();
    Task AddAsync(LabEntity lab);
    Task FilterAsync();
  }
}