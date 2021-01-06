using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.DeliveryManModel;
using BusinessLogicalLayer.Models.DeliveryManMolder;
using Domain.Entities;
using Infra.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    public class DeliveryManService : BaseService<DeliveryMan>, IDeliveryManService
    {
        private readonly IDeliveryManRepository _deliveryManRepository;

        public DeliveryManService(IDeliveryManRepository deliveryManRepository)
        {
            _deliveryManRepository = deliveryManRepository;
        }

        public async Task<DeliveryManResponseModel> Create(DeliveryManRequestModel deliveryManModel)
        {
            var deliveryMan = DeliveryManMap.DeliveryManRequestModelToDeliveryMan(deliveryManModel);

            Validate(deliveryMan);

            await _deliveryManRepository.Create(deliveryMan);
            await _deliveryManRepository.Save();

            return DeliveryManMap.DeliveryManToDeliveryManResponse(deliveryMan);
        }

        public async Task<DeliveryManResponseModel> Delete(int id)
        {
            ValidateId(id);

            HandleError();

            var deliveryMan = await _deliveryManRepository.GetById(id);

            if (deliveryMan == null)
                AddError("Entregador", "Não encontrado");

            await _deliveryManRepository.Delete(id);
            await _deliveryManRepository.Save();

            return DeliveryManMap.DeliveryManToDeliveryManResponse(deliveryMan);
        }

        public async Task<List<DeliveryManResponseModel>> GetAll()
        {
            var deliveriesMans = await _deliveryManRepository.GetAll();
            return deliveriesMans.Select(x => DeliveryManMap.DeliveryManToDeliveryManResponse(x)).ToList();
        }

        public async Task<DeliveryManResponseModel> GetById(int id)
        {
            ValidateId(id);

            HandleError();

            var deliveryMan = await _deliveryManRepository.GetById(id);

            if (deliveryMan == null)
                AddError("Entregador", "Não encontrado");

            HandleError();

            return DeliveryManMap.DeliveryManToDeliveryManResponse(deliveryMan);
        }

        public async Task<DeliveryManResponseModel> Update(int id, DeliveryManUpdateModel deliveryManModel)
        {
            var deliveryManToUpdate = await _deliveryManRepository.GetById(id);

            if (deliveryManToUpdate == null)
                AddError("Entregador", "Não encontrado");

            deliveryManToUpdate.Update(deliveryManModel.Name, deliveryManModel.Salary);

            await _deliveryManRepository.Update(deliveryManToUpdate);
            await _deliveryManRepository.Save();

            return DeliveryManMap.DeliveryManToDeliveryManResponse(deliveryManToUpdate);
        }

        public override void Validate(DeliveryMan entity)
        {
            if (entity.IsInvalid())
                AddErrors(entity.GetErrors());

            HandleError();
        }
    }
}
