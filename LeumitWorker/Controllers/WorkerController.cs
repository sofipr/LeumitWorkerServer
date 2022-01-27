using LeumitWorker.Interface;
using LeumitWorker.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Linq;

namespace LeumitWorker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;


        public WorkersController(
           IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        [Route("GetWorkers")]
        public async Task<ActionResult> GetAll()
        {
            var workers = await _workerService.GetAllWorkers();
            return Ok(JsonConvert.SerializeObject(workers));
        }

        [HttpGet]
        [Route("GetSum")]
        public  double GetSum()
        {
            return  _workerService.GetAllSum();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var workers = await _workerService.GetWorkerById(id);
            return Ok(JsonConvert.SerializeObject(workers));
        }

        [HttpPut]
        [Route("UpdateWorker")]
        public async Task<ActionResult> UpdateWorker([FromBody] Worker worker)
        {
            var workers = await _workerService.UpdateWorker(worker);
            return Ok(JsonConvert.SerializeObject(workers));
        }


    }
}
