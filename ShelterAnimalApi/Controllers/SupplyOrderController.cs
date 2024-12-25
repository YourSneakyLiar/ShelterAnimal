using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.SupplyOrder;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyOrderController : ControllerBase
    {
        private ISupplyOrderService _supplyOrderService;

        public SupplyOrderController(ISupplyOrderService supplyOrderService)
        {
            _supplyOrderService = supplyOrderService;
        }

        /// <summary>
        /// Получение списка всех заказов поставок
        /// </summary>
        /// <returns>Список заказов поставок</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _supplyOrderService.GetAll();
            var response = orders.Adapt<List<GetSupplyOrderResponse>>();
            return Ok(response);
        }


        /// <summary>
        /// Получение заказа поставки по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор заказа поставки</param>
        /// <returns>Заказ поставки</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _supplyOrderService.GetById(id);
            if (order == null)
                return NotFound();

            var response = order.Adapt<GetSupplyOrderResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового заказа поставки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /SupplyOrder
        ///     {
        ///        "SupplyId": 1,
        ///        "OrderDate": "2023-10-01",
        ///        "Quantity": 50
        ///       
        ///     }
        ///
        /// </remarks>
        /// <param name="supplyOrder">Заказ поставки</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateSupplyOrderRequest request)
        {
            var order = request.Adapt<SupplyOrder>();
            await _supplyOrderService.Create(order);
            return Ok();
        }

        /// <summary>
        /// Обновление данных заказа поставки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /SupplyOrder
        ///     {
        ///        "OrderId": 1,
        ///        "SupplyId": 1,
        ///        "OrderDate": "2023-10-01",
        ///        "Quantity": 50
        ///     
        ///     }
        ///
        /// </remarks>
        /// <param name="supplyOrder">Заказ поставки</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSupplyOrderRequest request)
        {
            var order = request.Adapt<SupplyOrder>();
            await _supplyOrderService.Update(order);
            return Ok();
        }

        /// <summary>
        /// Удаление заказа поставки по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор заказа поставки</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _supplyOrderService.Delete(id);
            return Ok();
        }
    }
}