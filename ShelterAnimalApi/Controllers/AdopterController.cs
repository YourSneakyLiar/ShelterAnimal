using Domain.Interfaces; 
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Adopter;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdopterController : ControllerBase
    {
        private IAdopterService _adopterService;

        public AdopterController(IAdopterService adopterService)
        {
            _adopterService = adopterService;
        }

        /// <summary>
        /// Получение списка всех усыновителей
        /// </summary>
        /// <returns>Список усыновителей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var adopters = await _adopterService.GetAll();
            var response = adopters.Adapt<List<GetAdopterResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение усыновителя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор усыновителя</param>
        /// <returns>Усыновитель</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var adopter = await _adopterService.GetById(id);
            if (adopter == null)
                return NotFound();

            var response = adopter.Adapt<GetAdopterResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового усыновителя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Adopter
        ///     {
        ///        "FirstName": "Иван",
        ///        "LastName": "Иванов",
        ///        "Email": "ivan@example.com",
        ///        "Phone": "+1234567890",
        ///        "Address": "ул. Пушкина, д. 10"
        ///     }
        ///
        /// </remarks>
        /// <param name="adopter">Усыновитель</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateAdopterRequest request)
        {
            var adopter = request.Adapt<Adopter>();
            await _adopterService.Create(adopter);
            return Ok();
        }

        /// <summary>
        /// Обновление данных усыновителя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Adopter
        ///     {
        ///        "AdopterId": 1,
        ///        "FirstName": "Иван",
        ///        "LastName": "Иванов",
        ///        "Email": "ivan@example.com",
        ///        "Phone": "+1234567890",
        ///        "Address": "ул. Пушкина, д. 10"
        ///     }
        ///
        /// </remarks>
        /// <param name="adopter">Усыновитель</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAdopterRequest request)
        {
            var adopter = request.Adapt<Adopter>();
            await _adopterService.Update(adopter);
            return Ok();
        }

        /// <summary>
        /// Удаление усыновителя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор усыновителя</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _adopterService.Delete(id);
            return Ok();
        }
    }
    }