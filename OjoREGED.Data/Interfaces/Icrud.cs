namespace OjoREGEDAPI.Data
{
    public interface Icrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<Task> GetById(int id);
        Task<Task> Insert(T entity);
        Task<Task> Update(T entity);
        Task<Task> Delete(int id);
    }
}
