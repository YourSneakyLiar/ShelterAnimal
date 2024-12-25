using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.EventAttendance;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventAttendanceController : ControllerBase
    {
        private IEventAttendanceService _eventAttendanceService;

        public EventAttendanceController(IEventAttendanceService eventAttendanceService)
        {
            _eventAttendanceService = eventAttendanceService;
        }

        /// <summary>
        /// Получение списка всех записей о посещении мероприятий
        /// </summary>
        /// <returns>Список записей о посещении мероприятий</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var attendances = await _eventAttendanceService.GetAll();
            var response = attendances.Adapt<List<GetEventAttendanceResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение записи о посещении мероприятия по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи о посещении мероприятия</param>
        /// <returns>Запись о посещении мероприятия</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var attendance = await _eventAttendanceService.GetById(id);
            if (attendance == null)
                return NotFound();

            var response = attendance.Adapt<GetEventAttendanceResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой записи о посещении мероприятия
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /EventAttendance
        ///     {
        ///        "EventId": 1,
        ///        "VolunteerId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="eventAttendance">Запись о посещении мероприятия</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateEventAttendanceRequest request)
        {
            var attendance = request.Adapt<EventAttendance>();
            await _eventAttendanceService.Create(attendance);
            return Ok();
        }

        /// <summary>
        /// Обновление записи о посещении мероприятия
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /EventAttendance
        ///     {
        ///        "AttendanceId": 1,
        ///        "EventId": 1,
        ///        "VolunteerId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="eventAttendance">Запись о посещении мероприятия</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateEventAttendanceRequest request)
        {
            var attendance = request.Adapt<EventAttendance>();
            await _eventAttendanceService.Update(attendance);
            return Ok();
        }
        /// <summary>
        /// Удаление записи о посещении мероприятия по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи о посещении мероприятия</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventAttendanceService.Delete(id);
            return Ok();
        }
    }
}