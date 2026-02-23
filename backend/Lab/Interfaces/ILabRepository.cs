namespace Lab.Interfaces
{
  public interface ILabRepository
  {
    Task<LabEntity?> GetByIdAsync(int id);
    Task<IList<LabEntity>> GetAllAsync();
    Task CreateAsync(LabEntity lab);
    Task FilterAsync();
  }
}