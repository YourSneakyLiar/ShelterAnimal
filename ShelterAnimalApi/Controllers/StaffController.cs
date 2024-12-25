using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Staff;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        /// <summary>
        /// Получение списка всех сотрудников
        /// </summary>
        /// <returns>Список сотрудников</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staff = await _staffService.GetAll();
            var response = staff.Adapt<List<GetStaffResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение сотрудника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns>Сотрудник</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var staff = await _staffService.GetById(id);
            if (staff == null)
                return NotFound();

            var response = staff.Adapt<GetStaffResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового сотрудника
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Staff
        ///     {
        ///        "FirstName": "Иван",
        ///        "LastName": "Иванов",
        ///        "Email": "ivan@example.com",
        ///        "Phone": "+1234567890",
        ///        "Position": "Ветеринар"
        ///     }
        ///
        /// </remarks>
        /// <param name="staff">Сотрудник</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateStaffRequest request)
        {
            var staff = request.Adapt<Staff>();
            await _staffService.Create(staff);
            return Ok();
        }

        /// <summary>
        /// Обновление данных сотрудника
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Staff
        ///     {
        ///        "StaffId": 1,
        ///        "FirstName": "Иван",
        ///        "LastName": "Иванов",
        ///        "Email": "ivan@example.com",
        ///        "Phone": "+1234567890",
        ///        "Position": "Ветеринар"
        ///     }
        ///
        /// </remarks>
        /// <param name="staff">Сотрудник</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateStaffRequest request)
        {
            var staff = request.Adapt<Staff>();
            await _staffService.Update(staff);
            return Ok();
        }

        /// <summary>
        /// Удаление сотрудника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _staffService.Delete(id);
            return Ok();
        }
    }
}