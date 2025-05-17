using AutoMapper;
using Business.DTOs.Requests.Bootcamp;
using Business.DTOs.Responses.Bootcamp;
using Entities;

namespace Business.Profiles;

public class BootcampProfile : Profile
{
    public BootcampProfile() 
    {
        CreateMap<Bootcamp, GetAllBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, GetBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, CreateBootcampRequest>().ReverseMap();
        CreateMap<Bootcamp, UpdateBootcampRequest>().ReverseMap();
        CreateMap<Bootcamp, DeleteBootcampRequest>().ReverseMap();
    }
}
