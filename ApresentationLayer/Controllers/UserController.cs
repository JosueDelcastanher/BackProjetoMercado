using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.AddressModel;
using BusinessLogicalLayer.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApresentationLayer.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : AbstractController
    {
        private readonly IUserService _userService;
        private readonly IAddressService _addressService;

        public UserController(IUserService userService, IAddressService addressService)
        {
            _userService = userService;
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpGet("{id}")]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var user = await _userService.GetById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var user = await _userService.Delete(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserUpdateRequestModel model)
        {
            try
            {
                var user = await _userService.Update(id, model);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPut]
        [Route("{id}/password")]
        public async Task<IActionResult> UpdatePassword([FromRoute] int id, [FromBody] UserPasswordRequestModel model)
        {
            try
            {
                var user = await _userService.ChangePassword(id, model);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequestModel model)
        {
            try
            {
                var user = await _userService.Create(model);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestModel model)
        {
            try
            {
                var user = await _userService.Login(model);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPost]
        [Route("{userId}/address")]
        public async Task<IActionResult> CreateAddress([FromRoute] int userId, [FromBody] AddressRequestModel model)
        {
            try
            {
                var address = await _addressService.Create(userId, model, false);
                return Ok(address);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpGet]
        [Route("{userId}/address")]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId)
        {
            try
            {
                var address = await _addressService.GetByUserId(userId);
                return Ok(address);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPut]
        [Route("{userId}/address")]
        public async Task<IActionResult> UpdateAddress([FromRoute] int userId, [FromBody] AddressUpdateModel model)
        {
            try
            {
                var address = await _addressService.UpdateAddressByUser(userId, model);
                return Ok(address);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }
    }
}