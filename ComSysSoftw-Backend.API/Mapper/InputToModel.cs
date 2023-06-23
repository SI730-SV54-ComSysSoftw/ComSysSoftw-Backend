using AutoMapper;
using ComSysSoftw_Backend.API.Input;
using ComSysSoftw_Backend.Infraestructure.Models;
using Infraestructure.Models;

namespace ComSysSoftw_Backend.API.Mapper;

public class InputToModel:Profile
{
    public InputToModel()
    {

        CreateMap<UserInput, User>();
        CreateMap<VeterinaryInput, Veterinary>();
        CreateMap<PetInput, Pet>();
        CreateMap<MeetingInput, Meeting>();
        CreateMap<LoginRequest, User>();
        CreateMap<CommentInput, Comment>();
    }
}
