using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Event;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Получение списка всех мероприятий
        /// </summary>
        /// <returns>Список мероприятий</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAll();
            var response = events.Adapt<List<GetEventResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение мероприятия по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор мероприятия</param>
        /// <returns>Мероприятие</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var eventItem = await _eventService.GetById(id);
            if (eventItem == null)
                return NotFound();

            var response = eventItem.Adapt<GetEventResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового мероприятия
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Event
        ///     {
        ///        "EventName": "Благотворительный забег",
        ///        "EventDate": "2023-10-15T10:00:00",
        ///        "description": "Сбор средств с проведения забега пойжёт на оказание мед помощи новоприбывшим животным"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <param name="event">Мероприятие</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateEventRequest request)
        {
            var eventItem = request.Adapt<Event>();
            await _eventService.Create(eventItem);
            return Ok();
        }


        /// <summary>
        /// Обновление данных мероприятия
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Event
        ///     {
        ///        "EventId": 1,
        ///        "EventName": "Благотворительный забег",
        ///        "EventDate": "2023-10-15T10:00:00",
        ///        "description": "Сбор средств с проведения забега пойжёт на оказание мед помощи новоприбывшим животным"
        ///     }
        ///
        /// </remarks>
        /// <param name="event">Мероприятие</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateEventRequest request)
        {
            var eventItem = request.Adapt<Event>();
            await _eventService.Update(eventItem);
            return Ok();
        }


        /// <summary>
        /// Удаление мероприятия по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор мероприятия</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventService.Delete(id);
            return Ok();
        }
    }
}