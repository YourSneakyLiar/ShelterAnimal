using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Breed;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        private IBreedService _breedService;

        public BreedController(IBreedService breedService)
        {
            _breedService = breedService;
        }

        /// <summary>
        /// Получение списка всех пород
        /// </summary>
        /// <returns>Список пород</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var breeds = await _breedService.GetAll();
            var response = breeds.Adapt<List<GetBreedResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение породы по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор породы</param>
        /// <returns>Порода</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var breed = await _breedService.GetById(id);
            if (breed == null)
                return NotFound();

            var response = breed.Adapt<GetBreedResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой породы
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Breed
        ///     {
        ///        "Name": "Сиамская",
        ///        "SpeciesId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="breed">Порода</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateBreedRequest request)
        {
            var breed = request.Adapt<Breed>();
            await _breedService.Create(breed);
            return Ok();
        }

        /// <summary>
        /// Обновление данных породы
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Breed
        ///     {
        ///        "BreedId": 1,
        ///        "Name": "Сиамская",
        ///        "SpeciesId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="breed">Порода</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBreedRequest request)
        {
            var breed = request.Adapt<Breed>();
            await _breedService.Update(breed);
            return Ok();
        }

        /// <summary>
        /// Удаление породы по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор породы</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _breedService.Delete(id);
            return Ok();
        }
    }
}