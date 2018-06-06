using AutoMapper;
using FastFoodOnline.Models;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Configurations
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMapsModelsToViewModels();
            CreateMapViewModelsToModels();
        }

        private void CreateMapsModelsToViewModels()
        {
            CreateMap<Food, FoodViewModel>();

            CreateMap<FoodOrder, FoodOrderViewModel>();

            CreateMap<PaymentMethod, PaymentMethodViewModel>();

            CreateMap<SentEmail, SentEmailViewModel>();

            CreateMap<SentMessage, SentMessageViewModel>();

            CreateMap<Payment, PaymentViewModel>()
                .ForMember(pvm => pvm.FoodOrderViewModels, opt => opt.MapFrom(p => p.FoodOrders))
                .ForMember(pvm => pvm.PaymentMethodViewModel, opt => opt.MapFrom(p => p.PaymentMethod));

            CreateMap<User, UserViewModel>()
                .ForMember(uvm => uvm.Gender, opt => opt.MapFrom(u => (u.Gender == Gender.Male) ? "Male" : "Female"))
                .ForMember(uvm => uvm.PaymentViewModels, opt => opt.MapFrom(u => u.Payments))
                .ForMember(uvm => uvm.SentEmailViewModels, opt => opt.MapFrom(u => u.SentEmails))
                .ForMember(uvm => uvm.SentMessageViewModel, opt => opt.MapFrom(u => u.SentMessages));
        }

        private void CreateMapViewModelsToModels()
        {
            CreateMap<FoodOrderViewModel, FoodOrder>();

            CreateMap<PaymentMethodViewModel, PaymentMethod>();

            CreateMap<PaymentViewModel, Payment>()
                .ForMember(p => p.FoodOrders, opt => opt.MapFrom(pvm => pvm.FoodOrderViewModels));
        }
    }
}
