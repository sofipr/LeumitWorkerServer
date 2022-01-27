using LeumitWorker.Interface;
using LeumitWorker.Models;
using System.Linq;
namespace LeumitWorker.Services
{
    public class WorkerService : IWorkerService
    {
        private List<Worker> workers = new List<Worker>();

        public WorkerService()
        {
            workers.Add(new Worker { WorkerNumber = 1, WorkerName = "David Gutman", WorkerEmail = "david33@gmail.com", WorkerPhone = "0527344443", WorkerSalary = 20555 });
            workers.Add(new Worker { WorkerNumber = 2, WorkerName = "Moshe Levi", WorkerEmail = "moshe@gmail.com", WorkerPhone = "0507355543", WorkerSalary = 21555 });
            workers.Add(new Worker { WorkerNumber = 3, WorkerName = "Israel Goren", WorkerEmail = "israel@gmail.com", WorkerPhone = "0527554443", WorkerSalary = 30555 });
            workers.Add(new Worker { WorkerNumber = 4, WorkerName = "Yafa David", WorkerEmail = "yafa@gmail.com", WorkerPhone = "0547343343", WorkerSalary = 20535 });
            workers.Add(new Worker { WorkerNumber = 5, WorkerName = "Sharon Prose", WorkerEmail = "ssss@gmail.com", WorkerPhone = "0546644443", WorkerSalary = 10555 });
            workers.Add(new Worker { WorkerNumber = 6, WorkerName = "Eyal Cohen", WorkerEmail = "deyakkk@gmail.com", WorkerPhone = "0527312343", WorkerSalary = 60555 });
        }
        public async Task<List<Worker>> GetAllWorkers()
        {
            await Task.Delay(1000);
            return workers;
        }

        public Task<Worker> GetWorkerById(int id)
        {
            var res = workers.Find(x => x.WorkerNumber == id);
            if (res == null)
            {
                throw new Exception("id not found");
            }
            return Task.FromResult(res);
        }

        public Task<Worker> UpdateWorker(Worker wToUpdate)
        {
            var index = workers.FindIndex(x => x.WorkerNumber == wToUpdate.WorkerNumber);
            if (index == -1)
            {
                throw new Exception("worker not found");
            }
            workers[index] = wToUpdate;
            return Task.FromResult(wToUpdate);
        }

         double IWorkerService.GetAllSum()
        {
            double total = workers.Select(i => i.WorkerSalary).Sum();

            return total;
        }
    }
}
