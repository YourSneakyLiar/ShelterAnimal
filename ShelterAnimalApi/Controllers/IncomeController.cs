using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Income;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        /// <summary>
        /// Получение списка всех доходов
        /// </summary>
        /// <returns>Список доходов</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var incomes = await _incomeService.GetAll();
            var response = incomes.Adapt<List<GetIncomeResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение дохода по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор дохода</param>
        /// <returns>Доход</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var income = await _incomeService.GetById(id);
            if (income == null)
                return NotFound();

            var response = income.Adapt<GetIncomeResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового дохода
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Income
        ///     {
        ///        "Amount": 1000.50,
        ///        "Description": "Пожертвование от благотворителя",
        ///        "IncomeDate": "2023-10-01"
        ///     }
        ///
        /// </remarks>
        /// <param name="income">Доход</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateIncomeRequest request)
        {
            var income = request.Adapt<Income>();
            await _incomeService.Create(income);
            return Ok();
        }

        /// <summary>
        /// Обновление данных дохода
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Income
        ///     {
        ///        "IncomeId": 1,
        ///        "Amount": 1000.50,
        ///        "Description": "Пожертвование от благотворителя",
        ///        "IncomeDate": "2023-10-01"
        ///     }
        ///
        /// </remarks>
        /// <param name="income">Доход</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateIncomeRequest request)
        {
            var income = request.Adapt<Income>();
            await _incomeService.Update(income);
            return Ok();
        }

        /// <summary>
        /// Удаление дохода по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор дохода</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _incomeService.Delete(id);
            return Ok();
        }
    }
}