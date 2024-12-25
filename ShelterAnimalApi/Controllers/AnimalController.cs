using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Animal;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        /// <summary>
        /// Получение списка всех животных
        /// </summary>
        /// <returns>Список животных</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var animals = await _animalService.GetAll();
            var response = animals.Adapt<List<GetAnimalResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение животного по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор животного</param>
        /// <returns>Животное</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var animal = await _animalService.GetById(id);
            if (animal == null)
                return NotFound();

            var response = animal.Adapt<GetAnimalResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового животного
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Animal
        ///     {
        ///        "Name": "Барсик",
        ///        "BreedId": 1,
        ///        "SpeciesId": 1,
        ///        "age": 6,
        ///        "Gender": "Мужской",
        ///        "Status": "Доступен для усыновления",
        ///        "description": "Очень ласковый",
        ///        "AdmissionDate": "2023-10-01"
        ///     }
        ///
        /// </remarks>
        /// <param name="animal">Животное</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateAnimalRequest request)
        {
            var animal = request.Adapt<Animal>();
            await _animalService.Create(animal);
            return Ok();
        }

        /// <summary>
        /// Обновление данных животного
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Animal
        ///     {
        ///       "Name": "Барсик",
        ///        "BreedId": 1,
        ///        "SpeciesId": 1,
        ///        "age": 6,
        ///        "Gender": "Мужской",
        ///        "Status": "Доступен для усыновления",
        ///        "description": "Очень ласковый",
        ///        "AdmissionDate": "2023-10-01"
        ///     }
        ///
        /// </remarks>
        /// <param name="animal">Животное</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAnimalRequest request)
        {
            var animal = request.Adapt<Animal>();
            await _animalService.Update(animal);
            return Ok();
        }


        /// <summary>
        /// Удаление животного по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор животного</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _animalService.Delete(id);
            return Ok();
        }
    }
}