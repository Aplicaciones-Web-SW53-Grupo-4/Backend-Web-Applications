using _1.API.Request;
using _1.API.Response;
using _3.Data.Model;
using AutoMapper;

namespace _1.API.Mapper;

public class ModelToAPI : Profile
{
    public ModelToAPI()
    {
        CreateMap<User, UserRegisterRequest>();
        CreateMap<User, UserLoginRequest>();
        CreateMap<User, ProfileOwnerResponse>();
        CreateMap<Automobile, SearchAutomovilFilterResponse>();
        CreateMap<Automobile, AutomobileCreateRequest>();
        CreateMap<User,ProfileUpdateRequest>();
        CreateMap< Automobile , SearchAutomovilFilterResponse>();
        CreateMap<RequestRent, RentRequest>();
        CreateMap<Automobile,AutomobileResponse>();
        CreateMap< User,OwnerResponse>();
        CreateMap<RequestRent,RequestRentOwnerResponse>();

    }
}