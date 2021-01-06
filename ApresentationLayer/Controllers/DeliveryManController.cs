using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.DeliveryManModel;
using BusinessLogicalLayer.Models.DeliveryManMolder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApresentationLayer.Controllers
{
    [Route("deliverymans")]
    [ApiController]
    public class DeliveryManController : AbstractController
    {
        private readonly IDeliveryManService _deliveryManService;

        public DeliveryManController(IDeliveryManService deliveryManService)
        {
            _deliveryManService = deliveryManService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var deliveryMans = await _deliveryManService.GetAll();
                return Ok(deliveryMans);
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
                var deliveryMan = await _deliveryManService.GetById(id);
                return Ok(deliveryMan);
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
                var deliveryMan = await _deliveryManService.Delete(id);
                return Ok(deliveryMan);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] DeliveryManUpdateModel model)
        {
            try
            {
                var deliveryMan = await _deliveryManService.Update(id, model);
                return Ok(deliveryMan);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DeliveryManRequestModel model)
        {
            try
            {
                var deliveryMan = await _deliveryManService.Create(model);
                return Ok(deliveryMan);
            }
            catch (Exception ex)
            {
                return HandleControllerErrors(ex);
            }
        }
    }
}