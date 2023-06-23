using AutoMapper;
using ComSysSoftw_Backend.API.Response;
using ComSysSoftw_Backend.Infraestructure.Models;
using Infraestructure.Models;

namespace ComSysSoftw_Backend.API.Mapper;

public class ModelToResponse:Profile
{
    public ModelToResponse()
    {
        CreateMap<User, UserResponse>();
        CreateMap<Veterinary, VeterinaryResponse>();
        CreateMap<Meeting, MeetingResponse>();
        CreateMap<Pet, PetResponse>();
        CreateMap<Comment, CommentResponse>();
        CreateMap<Product, ProductResponse>();
    }
}
