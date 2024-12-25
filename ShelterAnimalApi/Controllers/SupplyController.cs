using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Supply;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyController : ControllerBase
    {
        private ISupplyService _supplyService;

        public SupplyController(ISupplyService supplyService)
        {
            _supplyService = supplyService;
        }

        /// <summary>
        /// Получение списка всех поставок
        /// </summary>
        /// <returns>Список поставок</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supplies = await _supplyService.GetAll();
            var response = supplies.Adapt<List<GetSupplyResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение поставки по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поставки</param>
        /// <returns>Поставка</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supply = await _supplyService.GetById(id);
            if (supply == null)
                return NotFound();

            var response = supply.Adapt<GetSupplyResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой поставки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Supply
        ///     {
        ///        "Name": "Корм для собак",
        ///        "Quantity": 100,
        ///        "Unit": "кг"
        ///     }
        ///
        /// </remarks>
        /// <param name="supply">Поставка</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateSupplyRequest request)
        {
            var supply = request.Adapt<Supply>();
            await _supplyService.Create(supply);
            return Ok();
        }

        /// <summary>
        /// Обновление данных поставки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Supply
        ///     {
        ///        "SupplyId": 1,
        ///        "Name": "Корм для собак",
        ///        "Quantity": 100,
        ///        "Unit": "кг"
        ///     }
        ///
        /// </remarks>
        /// <param name="supply">Поставка</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSupplyRequest request)
        {
            var supply = request.Adapt<Supply>();
            await _supplyService.Update(supply);
            return Ok();
        }


        /// <summary>
        /// Удаление поставки по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поставки</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _supplyService.Delete(id);
            return Ok();
        }
    }
}