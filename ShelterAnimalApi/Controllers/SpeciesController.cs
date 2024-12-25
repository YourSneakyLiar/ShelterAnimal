using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Species;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private ISpeciesService _speciesService;

        public SpeciesController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        /// <summary>
        /// Получение списка всех видов животных
        /// </summary>
        /// <returns>Список видов животных</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var species = await _speciesService.GetAll();
            var response = species.Adapt<List<GetSpeciesResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение вида животного по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор вида животного</param>
        /// <returns>Вид животного</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var species = await _speciesService.GetById(id);
            if (species == null)
                return NotFound();

            var response = species.Adapt<GetSpeciesResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового вида животного
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Species
        ///     {
        ///        "Name": "Собака"
        ///     }
        ///
        /// </remarks>
        /// <param name="species">Вид животного</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateSpeciesRequest request)
        {
            var species = request.Adapt<Species>();
            await _speciesService.Create(species);
            return Ok();
        }

        /// <summary>
        /// Обновление данных вида животного
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Species
        ///     {
        ///        "SpeciesId": 1,
        ///        "Name": "Собака"
        ///     }
        ///
        /// </remarks>
        /// <param name="species">Вид животного</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSpeciesRequest request)
        {
            var species = request.Adapt<Species>();
            await _speciesService.Update(species);
            return Ok();
        }

        /// <summary>
        /// Удаление вида животного по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор вида животного</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _speciesService.Delete(id);
            return Ok();
        }
    }
}