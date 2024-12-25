using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Volunteer;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private IVolunteerService _volunteerService;

        public VolunteerController(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        /// <summary>
        /// Получение списка всех волонтеров
        /// </summary>
        /// <returns>Список волонтеров</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var volunteers = await _volunteerService.GetAll();
            var response = volunteers.Adapt<List<GetVolunteerResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение волонтера по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор волонтера</param>
        /// <returns>Волонтер</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var volunteer = await _volunteerService.GetById(id);
            if (volunteer == null)
                return NotFound();

            var response = volunteer.Adapt<GetVolunteerResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового волонтера
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Volunteer
        ///     {
        ///        "FirstName": "Иван",
        ///        "LastName": "Иванов",
        ///        "Email": "ivan@example.com",
        ///        "Phone": "+1234567890",
        ///        "Availability": "Полный день"
        ///     }
        ///
        /// </remarks>
        /// <param name="volunteer">Волонтер</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateVolunteerRequest request)
        {
            var volunteer = request.Adapt<Volunteer>();
            await _volunteerService.Create(volunteer);
            return Ok();
        }

        /// <summary>
        /// Обновление данных волонтера
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Volunteer
        ///     {
        ///        "VolunteerId": 1,
        ///        "FirstName": "Иван",
        ///        "LastName": "Иванов",
        ///        "Email": "ivan@example.com",
        ///        "Phone": "+1234567890",
        ///        "Availability": "Полный день"
        ///     }
        ///
        /// </remarks>
        /// <param name="volunteer">Волонтер</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateVolunteerRequest request)
        {
            var volunteer = request.Adapt<Volunteer>();
            await _volunteerService.Update(volunteer);
            return Ok();
        }

        /// <summary>
        /// Удаление волонтера по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор волонтера</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _volunteerService.Delete(id);
            return Ok();
        }
    }
}