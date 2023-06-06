using AutoMapper;
using ComSysSoftw_Backend.API.Response;
using Infraestructure.Models;

namespace ComSysSoftw_Backend.API.Mapper;

public class ModelToResponse:Profile
{
    public ModelToResponse()
    {
        CreateMap<User, UserResponse>();

    }
}
