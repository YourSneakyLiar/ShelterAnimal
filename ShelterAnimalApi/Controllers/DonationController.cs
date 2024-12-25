using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Donation;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private IDonationService _donationService;

        public DonationController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        /// <summary>
        /// Получение списка всех пожертвований
        /// </summary>
        /// <returns>Список пожертвований</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donations = await _donationService.GetAll();
            var response = donations.Adapt<List<GetDonationResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение пожертвования по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пожертвования</param>
        /// <returns>Пожертвование</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var donation = await _donationService.GetById(id);
            if (donation == null)
                return NotFound();

            var response = donation.Adapt<GetDonationResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пожертвования
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Donation
        ///     {
        ///        "DonorName": "Иван Иванов",
        ///        "Amount": 1000.50,
        ///        "DonationDate": "2023-10-01"
        ///     }
        ///
        /// </remarks>
        /// <param name="donation">Пожертвование</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateDonationRequest request)
        {
            var donation = request.Adapt<Donation>();
            await _donationService.Create(donation);
            return Ok();
        }

        /// <summary>
        /// Обновление данных пожертвования
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Donation
        ///     {
        ///        "DonationId": 1,
        ///        "DonorName": "Иван Иванов",
        ///        "Amount": 1000.50,
        ///        "DonationDate": "2023-10-01"
        ///     }
        ///
        /// </remarks>
        /// <param name="donation">Пожертвование</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDonationRequest request)
        {
            var donation = request.Adapt<Donation>();
            await _donationService.Update(donation);
            return Ok();
        }

        /// <summary>
        /// Удаление пожертвования по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пожертвования</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _donationService.Delete(id);
            return Ok();
        }
    }
}