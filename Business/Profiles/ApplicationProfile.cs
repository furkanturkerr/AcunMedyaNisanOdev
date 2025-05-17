using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Requests.Application;
using Business.DTOs.Responses.Applicaton;
using Entities;

namespace Business.Profiles;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Application, CreateApplicationRequest>().ReverseMap();
        CreateMap<Application, UpdateApplicationRequest>().ReverseMap();
        CreateMap<Application, DeleteApplicationRequest>().ReverseMap();
        CreateMap<Application, GetAllApplicationsResponse>().ReverseMap();
        CreateMap<Application, GetApplicationResponse>().ReverseMap();
    }
}
