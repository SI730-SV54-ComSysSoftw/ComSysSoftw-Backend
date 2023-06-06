using AutoMapper;
using ComSysSoftw_Backend.API.Input;
using Infraestructure.Models;

namespace ComSysSoftw_Backend.API.Mapper;

public class InputToModel:Profile
{
    public InputToModel()
    {

        CreateMap<UserInput, User>();

    }
}
