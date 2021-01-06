using BusinessLogicalLayer.Models.SnackModel;
using Domain.Entities;
using Shared;

namespace BusinessLogicalLayer.CustomsAutoMapper
{
    public static class SnackMap
    {
        public static Snack SnackRequestToSnack(SnackRequestModel snackRequestModel)
        {
            return Map.ChangeValues<SnackRequestModel, Snack>(snackRequestModel);
        }

        public static SnackResponseModel SnackToSnackResponseModel(Snack snack)
        {
            return Map.ChangeValues<Snack, SnackResponseModel>(snack);
        }
    }
}
