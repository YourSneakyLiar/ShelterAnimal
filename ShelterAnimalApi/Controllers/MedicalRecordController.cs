using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.MedicalRecord;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        /// <summary>
        /// Получение списка всех медицинских записей
        /// </summary>
        /// <returns>Список медицинских записей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var records = await _medicalRecordService.GetAll();
            var response = records.Adapt<List<GetMedicalRecordResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение медицинской записи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор медицинской записи</param>
        /// <returns>Медицинская запись</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _medicalRecordService.GetById(id);
            if (record == null)
                return NotFound();

            var response = record.Adapt<GetMedicalRecordResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой медицинской записи
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /MedicalRecord
        ///     {
        ///        "AnimalId": 1,
        ///        "RecordDate": "2023-10-01",
        ///        "Treatment": "Прием антибиотиков"
        ///     }
        ///
        /// </remarks>
        /// <param name="medicalRecord">Медицинская запись</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateMedicalRecordRequest request)
        {
            var record = request.Adapt<MedicalRecord>();
            await _medicalRecordService.Create(record);
            return Ok();
        }

        /// <summary>
        /// Обновление данных медицинской записи
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /MedicalRecord
        ///     {
        ///        "RecordId": 1,
        ///        "AnimalId": 1,
        ///        "RecordDate": "2023-10-01",       
        ///        "Treatment": "Прием антибиотиков"
        ///     }
        ///
        /// </remarks>
        /// <param name="medicalRecord">Медицинская запись</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateMedicalRecordRequest request)
        {
            var record = request.Adapt<MedicalRecord>();
            await _medicalRecordService.Update(record);
            return Ok();
        }

        /// <summary>
        /// Удаление медицинской записи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор медицинской записи</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _medicalRecordService.Delete(id);
            return Ok();
        }
    }
}