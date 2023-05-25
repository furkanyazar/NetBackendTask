using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos;

namespace Business.Profiles;

public class UserMappingProfiles : Profile
{
    public UserMappingProfiles()
    {
        CreateMap<User, UserGetByIdDto>().ReverseMap();
        CreateMap<User, UpdatedUserDto>().ReverseMap();
    }
}
