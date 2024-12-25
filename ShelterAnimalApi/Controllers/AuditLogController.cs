using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.AuditLog;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private IAuditLogService _auditLogService;

        public AuditLogController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        /// <summary>
        /// Получение списка всех записей аудита
        /// </summary>
        /// <returns>Список записей аудита</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _auditLogService.GetAll();
            var response = logs.Adapt<List<GetAuditLogResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение записи аудита по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи аудита</param>
        /// <returns>Запись аудита</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var log = await _auditLogService.GetById(id);
            if (log == null)
                return NotFound();

            var response = log.Adapt<GetAuditLogResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой записи аудита
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /AuditLog
        ///     {
        ///     
        ///        "UserId": 1
        ///        "Action": "Создание пользователя",
        ///        "ActionDate": "2023-10-01T12:00:00",
        ///        
        ///     }
        ///
        /// </remarks>
        /// <param name="auditLog">Запись аудита</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateAuditLogRequest request)
        {
            var log = request.Adapt<AuditLog>();
            await _auditLogService.Create(log);
            return Ok();
        }

        /// <summary>
        /// Обновление записи аудита
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /AuditLog
        ///     {
        ///        "UserId": 1
        ///        "LogId": 1,
        ///        "Action": "Обновление пользователя",
        ///        "ActionDate": "2023-10-01T12:00:00",
        ///        
        ///     }
        ///
        /// </remarks>
        /// <param name="auditLog">Запись аудита</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAuditLogRequest request)
        {
            var log = request.Adapt<AuditLog>();
            await _auditLogService.Update(log);
            return Ok();
        }

        /// <summary>
        /// Удаление записи аудита по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи аудита</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _auditLogService.Delete(id);
            return Ok();
        }
    }
}