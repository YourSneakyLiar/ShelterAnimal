using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Adoption;
namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionController : ControllerBase
    {
        private IAdoptionService _adoptionService;

        public AdoptionController(IAdoptionService adoptionService)
        {
            _adoptionService = adoptionService;
        }

        /// <summary>
        /// Получение списка всех усыновлений
        /// </summary>
        /// <returns>Список усыновлений</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var adoptions = await _adoptionService.GetAll();
            var response = adoptions.Adapt<List<GetAdoptionResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение усыновления по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор усыновления</param>
        /// <returns>Усыновление</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var adoption = await _adoptionService.GetById(id);
            if (adoption == null)
                return NotFound();

            var response = adoption.Adapt<GetAdoptionResponse>();
            return Ok(response);
        }


        /// <summary>
        /// Создание нового усыновления
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Adoption
        ///     {
        ///        "AdopterId": 1,
        ///        "AnimalId": 2,
        ///        "AdoptionDate": "2023-10-01"
        ///     }
        ///
        /// </remarks>
        /// <param name="adoption">Усыновление</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateAdoptionRequest request)
        {
            var adoption = request.Adapt<Adoption>();
            await _adoptionService.Create(adoption);
            return Ok();
        }

        /// <summary>
        /// Обновление данных усыновления
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Adoption
        ///     {
        ///        "AdoptionId": 1,
        ///        "AdopterId": 1,
        ///        "AnimalId": 2,
        ///        "AdoptionDate": "2023-10-01"
        ///     }
        ///
        /// </remarks>
        /// <param name="adoption">Усыновление</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAdoptionRequest request)
        {
            var adoption = request.Adapt<Adoption>();
            await _adoptionService.Update(adoption);
            return Ok();
        }

        /// <summary>
        /// Удаление усыновления по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор усыновления</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _adoptionService.Delete(id);
            return Ok();
        }
    }
}