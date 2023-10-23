using _1.API.Request;
using _3.Data.Model;
using AutoMapper;

namespace _1.API.Mapper;

public class APIToModel :Profile
{
    public APIToModel()
    {
        CreateMap<UserRequest, User>();
        CreateMap<UserRegisterRequest, User>();
        CreateMap<UserLoginRequest, User>();
    }
}