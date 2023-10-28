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
        CreateMap<ProfileResponse,User>();
        CreateMap<ProfileUpdateRequest,User>();
    }
}