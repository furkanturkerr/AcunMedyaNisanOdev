using AutoMapper;
using Business.DTOs.Requests.Blacklist;
using Business.DTOs.Responses.Applicaton;
using Business.DTOs.Responses.Blacklist;
using Entities;

namespace Business.Profiles;

public class BlacklistProfile : Profile
{
    public BlacklistProfile()
    {
        CreateMap<Blacklist, CreateBlacklistRequest>().ReverseMap();
        CreateMap<Blacklist, UpdateBlacklistRequest>().ReverseMap();
        CreateMap<Blacklist,  DeleteBlacklistRequest>().ReverseMap();
        CreateMap<Blacklist, GetAllApplicationsResponse>().ReverseMap();
        CreateMap<Blacklist, GetBlacklistResponse>().ReverseMap();
    }
}
