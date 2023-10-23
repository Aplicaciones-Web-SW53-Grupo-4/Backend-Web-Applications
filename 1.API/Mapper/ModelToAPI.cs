using _1.API.Request;
using _1.API.Response;
using _3.Data.Model;
using AutoMapper;

namespace _1.API.Mapper;

public class ModelToAPI : Profile
{
    public ModelToAPI()
    {
        CreateMap<User, UserRequest>();
        CreateMap<User, UserRegisterRequest>();
        CreateMap<User, UserLoginRequest>();
        CreateMap<User, UserResponse>();
    }
}