using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Szkolimy_za_darmo_api.Controllers.Resources.Return;
using Szkolimy_za_darmo_api.Controllers.Resources.Query;
using Szkolimy_za_darmo_api.Controllers.Resources.Save;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Query;

namespace Szkolimy_za_darmo_api.Controllers
{
    [Route("/api/trainings")]
    public class TrainingsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITrainingRepository trainingRepository;
        private readonly IMapper mapper;

        public TrainingsController(IMapper mapper, IUnitOfWork unitOfWork, ITrainingRepository trainingRepository)
        {
            this.mapper = mapper;
            this.trainingRepository = trainingRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> createTraining([FromBody] SaveTrainingResource trainingResource)
        {   
            if (!ModelState.IsValid) return BadRequest(ModelState);
                
            Training training = mapper.Map<SaveTrainingResource,Training>(trainingResource);
            DateTime now =  DateTime.Now;
            training.InsertDate = now;
            training.LastUpdate = now;
            trainingRepository.Add(training);
            await unitOfWork.CompleteAsync();

            Training trainingToMap = await trainingRepository.GetOne(training.Id);
            var response = mapper.Map<Training, TrainingResource>(trainingToMap);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateTraining(int id, [FromBody] SaveTrainingResource trainingResource)
        {   
            if (!ModelState.IsValid) return BadRequest(ModelState);
                
            Training training = await trainingRepository.GetOne(id);
            if (training == null)
                return NotFound();
            mapper.Map<SaveTrainingResource, Training>(trainingResource, training);
            training.LastUpdate = DateTime.Now;
            trainingRepository.UpdateTags(training);
            await unitOfWork.CompleteAsync();

            training = await trainingRepository.GetOne(training.Id);
            var result = mapper.Map<Training, TrainingResource>(training);
            return Ok(result);
        }

        [HttpGet] 
        public async Task<IActionResult> getTrainings(TrainingQueryResource queryResource)
        {   

            if (!ModelState.IsValid) return BadRequest(ModelState);

            TrainingQuery trainingQuery = mapper.Map<TrainingQueryResource, TrainingQuery>(queryResource);
            QueryResult<Training> queryResult = await trainingRepository.GetAll(trainingQuery);

            var response = mapper.Map< QueryResult<Training> , QueryResultResource<TrainingResource> >(queryResult);
            return Ok(response);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> getTraining(int id)
        {   
            Training training = await trainingRepository.GetOne(id);
            if (training == null) {
                return NotFound();
            }

            var response = mapper.Map<Training, TrainingResource>(training);
            return Ok(response);
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> removeTraining(int id)
        {   
            Training training = await trainingRepository.GetOne(id, includeRelated: false);
            if (training == null) {
                return NotFound();
            }

            trainingRepository.Remove(training);
            await unitOfWork.CompleteAsync();
            return Ok(id);
        }
        
        [HttpGet("categories")] 
        public async Task<IActionResult> getAllCategories(){
            IEnumerable<Category> categories = await trainingRepository.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("localizations")] 
        public async Task<IActionResult> getAllLocalizations(){
            IEnumerable<Localization> localizations = await trainingRepository.GetAllLocalizations();
            return Ok(localizations);
        }

        [HttpGet("statuses")] 
        public async Task<IActionResult> getAllStatuses(){
            IEnumerable<MarketStatus> localizations = await trainingRepository.GetAllStatuses();
            return Ok(localizations);
        }
    }
}