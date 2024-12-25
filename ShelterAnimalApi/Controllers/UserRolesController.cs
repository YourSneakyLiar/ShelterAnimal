using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.UserRole;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        /// <summary>
        /// Получение списка всех ролей пользователей
        /// </summary>
        /// <returns>Список ролей пользователей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userRoles = await _userRoleService.GetAll();
            var response = userRoles.Adapt<List<GetUserRoleResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение роли пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор роли пользователя</param>
        /// <returns>Роль пользователя</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userRole = await _userRoleService.GetById(id);
            if (userRole == null)
                return NotFound();

            var response = userRole.Adapt<GetUserRoleResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой роли пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /UserRole
        ///     {
        ///        "UserId": 1,
        ///        "RoleId": 2
        ///     }
        ///
        /// </remarks>
        /// <param name="userRole">Роль пользователя</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRoleRequest request)
        {
            var userRole = request.Adapt<UserRole>();
            await _userRoleService.Create(userRole);
            return Ok();
        }

        /// <summary>
        /// Обновление данных роли пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /UserRole
        ///     {
        ///        "UserRoleId": 1,
        ///        "UserId": 1,
        ///        "RoleId": 2
        ///     }
        ///
        /// </remarks>
        /// <param name="userRole">Роль пользователя</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserRoleRequest request)
        {
            var userRole = request.Adapt<UserRole>();
            await _userRoleService.Update(userRole);
            return Ok();
        }

        /// <summary>
        /// Удаление роли пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор роли пользователя</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRoleService.Delete(id);
            return Ok();
        }
    }
}