using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Vaccination;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationController : ControllerBase
    {
        private IVaccinationService _vaccinationService;

        public VaccinationController(IVaccinationService vaccinationService)
        {
            _vaccinationService = vaccinationService;
        }

        /// <summary>
        /// Получение списка всех вакцинаций
        /// </summary>
        /// <returns>Список вакцинаций</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vaccinations = await _vaccinationService.GetAll();
            var response = vaccinations.Adapt<List<GetVaccinationResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение вакцинации по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор вакцинации</param>
        /// <returns>Вакцинация</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vaccination = await _vaccinationService.GetById(id);
            if (vaccination == null)
                return NotFound();

            var response = vaccination.Adapt<GetVaccinationResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой вакцинации
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Vaccination
        ///     {
        ///        "AnimalId": 1,
        ///        "VaccineName": "Вакцина от бешенства",
        ///        "VaccinationDate": "2023-10-01"
        ///     }
        ///
        /// </remarks>
        /// <param name="vaccination">Вакцинация</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateVaccinationRequest request)
        {
            var vaccination = request.Adapt<Vaccination>();
            await _vaccinationService.Create(vaccination);
            return Ok();
        }


        /// <summary>
        /// Обновление данных вакцинации
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Vaccination
        ///     {
        ///        "VaccinationId": 1,
        ///        "AnimalId": 1,
        ///        "VaccineName": "Вакцина от бешенства",
        ///        "VaccinationDate": "2023-10-01"
        ///     }
        ///
        /// </remarks>
        /// <param name="vaccination">Вакцинация</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateVaccinationRequest request)
        {
            var vaccination = request.Adapt<Vaccination>();
            await _vaccinationService.Update(vaccination);
            return Ok();
        }

        /// <summary>
        /// Удаление вакцинации по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор вакцинации</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _vaccinationService.Delete(id);
            return Ok();
        }
    }
}