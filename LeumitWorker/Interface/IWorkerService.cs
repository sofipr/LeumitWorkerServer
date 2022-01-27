using LeumitWorker.Models;

namespace LeumitWorker.Interface
{
    public interface IWorkerService
    {
        Task<List<Worker>> GetAllWorkers();
        double GetAllSum();
        Task<Worker> GetWorkerById(int id);
        Task<Worker> UpdateWorker(Worker wToUpdate);
    }
}
