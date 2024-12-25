using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using ShelterAnimalApi.Contracts.User;
using Mapster;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            var response = users.Adapt<List<GetUserResponse>>();
            return Ok(response);

        }

        /// <summary>
        /// Получение пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var user = await _userService.GetById(id);
            if (user == null)
                return NotFound();

            var response = user.Adapt<GetUserResponse>();
            return Ok(response);
        }



        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "Username" : "A4Tech Bloody B188",
        ///        "PasswordHush" : "!Pa$$word123@",       
        ///        "Role" : "Администратор"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var user = request.Adapt<User>();
            await _userService.Create(user);
            return Ok();
        }


        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /User
        ///     {
        ///        "UserId": 1,
        ///        "Username": "A4Tech Bloody B188",
        ///        "PasswordHash": "!Pa$$word123@",
        ///        "Role": "Администратор"
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            var user = request.Adapt<User>();
            await _userService.Update(user);
            return Ok();
        }



        /// <summary>
        /// Удаление пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}