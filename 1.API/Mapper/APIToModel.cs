using _1.API.Request;
using _1.API.Response;
using _3.Data.Model;
using AutoMapper;

namespace _1.API.Mapper;

public class APIToModel :Profile
{
    public APIToModel()
    {
        CreateMap<UserRegisterRequest, User>();
        CreateMap<UserLoginRequest, User>();
        CreateMap<AutomobileCreateRequest, Automobile>();
        CreateMap<ProfileOwnerResponse,User>();
        CreateMap<SearchAutomovilFilterResponse,Automobile>();
        CreateMap<ProfileUpdateRequest,User>();
        CreateMap< Task<List<SearchAutomovilFilterResponse>>,Task<List<Automobile>> >();
        CreateMap<RentRequest, RequestRent>();
        CreateMap<AutomobileResponse, Automobile>();
        CreateMap<OwnerResponse, User>();
        CreateMap<RequestRentOwnerResponse, RequestRent>();
    }
}