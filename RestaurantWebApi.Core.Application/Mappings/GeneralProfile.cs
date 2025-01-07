using AutoMapper;
using RestaurantWebApi.Core.Application.Dtos.Account;
using RestaurantWebApi.Core.Application.Dtos.Dishes;
using RestaurantWebApi.Core.Application.Dtos.Ingredients;
using RestaurantWebApi.Core.Application.Dtos.Orders;
using RestaurantWebApi.Core.Application.Dtos.Tables;
using RestaurantWebApi.Core.Application.Dtos.Users;
using RestaurantWebApi.Core.Application.Enums;
using RestaurantWebApi.Core.Domain.Entities;

namespace RestaurantWebApi.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region IngredientProfile
            CreateMap<Ingredient, IngredientDto>()
            .ReverseMap()
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Dishes, opt => opt.Ignore());

            CreateMap<Ingredient, IngredientSaveDto>()
            .ReverseMap()
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Dishes, opt => opt.Ignore());
            #endregion

            #region DishProfile
            CreateMap<Dish, DishDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => (DishCategory)src.CategoryId))
            .ReverseMap()
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Orders, opt => opt.Ignore());

            CreateMap<Dish, DishSaveDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => (DishCategory)src.CategoryId))
            .ForMember(dest => dest.IngredientIds, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Orders, opt => opt.Ignore());
            #endregion

            #region TableProfile
            CreateMap<Table, TableDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => ((Status)src.StatusId).ToString()))
            .ReverseMap()
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Orders, opt => opt.Ignore());

            CreateMap<Table, TableSaveDto>()
            .ReverseMap()
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => (int)src.Status))
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Orders, opt => opt.Ignore());
            #endregion

            #region OrderProfile
            CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => ((OrderStatus)src.StatusId).ToString()))
            .ReverseMap()
            .ForMember(dest => dest.Table, opt => opt.Ignore())
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Order, OrderSaveDto>()
            .ReverseMap()
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => (int)src.Status))
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            #endregion

            #region UserProfile
            CreateMap<AuthenticationRequest, LoginDto>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, UserSaveDto>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordDto>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordDto>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();
            #endregion
        }
    }
}
