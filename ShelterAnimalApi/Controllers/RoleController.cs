using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ShelterAnimalApi.Contracts.Role;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Получение списка всех ролей
        /// </summary>
        /// <returns>Список ролей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAll();
            var response = roles.Adapt<List<GetRoleResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение роли по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор роли</param>
        /// <returns>Роль</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleService.GetById(id);
            if (role == null)
                return NotFound();

            var response = role.Adapt<GetRoleResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Role
        ///     {
        ///        "RoleName": "Администратор"
        ///     }
        ///
        /// </remarks>
        /// <param name="role">Роль</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateRoleRequest request)
        {
            var role = request.Adapt<Role>();
            await _roleService.Create(role);
            return Ok();
        }

        /// <summary>
        /// Обновление данных роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Role
        ///     {
        ///        "RoleId": 1,
        ///        "RoleName": "Администратор"
        ///     }
        ///
        /// </remarks>
        /// <param name="role">Роль</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateRoleRequest request)
        {
            var role = request.Adapt<Role>();
            await _roleService.Update(role);
            return Ok();
        }

        /// <summary>
        /// Удаление роли по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор роли</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.Delete(id);
            return Ok();
        }
    }
}