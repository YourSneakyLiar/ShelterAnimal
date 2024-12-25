using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Expense;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        /// <summary>
        /// Получение списка всех расходов
        /// </summary>
        /// <returns>Список расходов</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expenses = await _expenseService.GetAll();
            var response = expenses.Adapt<List<GetExpenseResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение расхода по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор расхода</param>
        /// <returns>Расход</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var expense = await _expenseService.GetById(id);
            if (expense == null)
                return NotFound();

            var response = expense.Adapt<GetExpenseResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового расхода
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Expense
        ///     {
        ///        "Amount": 500.75,
        ///        "Description": "Закупка корма для животных",
        ///        "ExpenseDate": "2023-10-01"
        ///     }
        ///
        /// </remarks>
        /// <param name="expense">Расход</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateExpenseRequest request)
        {
            var expense = request.Adapt<Expense>();
            await _expenseService.Create(expense);
            return Ok();
        }


        /// <summary>
        /// Обновление данных расхода
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Expense
        ///     {
        ///        "ExpenseId": 1,
        ///        "Amount": 500.75,
        ///        "Description": "Закупка корма для животных",
        ///        "ExpenseDate": "2023-10-01"
        ///     }
        ///
        /// </remarks>
        /// <param name="expense">Расход</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateExpenseRequest request)
        {
            var expense = request.Adapt<Expense>();
            await _expenseService.Update(expense);
            return Ok();
        }

        /// <summary>
        /// Удаление расхода по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор расхода</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _expenseService.Delete(id);
            return Ok();
        }
    }
}