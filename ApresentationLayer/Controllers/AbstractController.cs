using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.CustomsExceptions;
using System;

namespace ApresentationLayer.Controllers
{
    public class AbstractController : ControllerBase
    {
        protected IActionResult HandleControllerErrors(Exception ex)
        {
            if (ex is BadRequestException)
                return RaiseValidationErrors(ex as BadRequestException);

            return RaiseInternalServerError(ex);
        }

        private IActionResult RaiseValidationErrors(BadRequestException ex)
        {
            return BadRequest(ex.Errors);
        }

        private IActionResult RaiseInternalServerError(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error, tente mais tarde");
        }

    }
}