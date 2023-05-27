using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects;
using Business.Rules.Business;
using Business.Rules.Validation.Users;
using Core.Aspects.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Dtos;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IMapper _mapper;

    public UserManager(IUserDal userDal, UserBusinessRules userBusinessRules, IMapper mapper)
    {
        _userDal = userDal;
        _userBusinessRules = userBusinessRules;
        _mapper = mapper;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        User? user = await _userDal.GetAsync(c => c.Id == id);
        await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
        return user!;
    }

    [SecuredOperation("logged")]
    public async Task<UserGetByIdDto> GetByIdDtoAsync(int id)
    {
        User? user = await _userDal.GetAsync(c => c.Id == id);
        await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
        UserGetByIdDto mappedUser = _mapper.Map<UserGetByIdDto>(user);
        return mappedUser;
    }

    [SecuredOperation("logged")]
    [ValidationAspect(typeof(UpdateUserDtoValidator))]
    public async Task<UpdatedUserDto> UpdateAsync(int id, UpdateUserDto updateUserDto)
    {
        User? user = await _userDal.GetAsync(c => c.Id == id);
        await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
        await _userBusinessRules.UserMailShouldBeNotExistsWhenUpdate(user!.Id, updateUserDto.Email);

        user.FirstName = updateUserDto.FirstName;
        user.LastName = updateUserDto.LastName;
        user.Email = updateUserDto.Email;

        if (!string.IsNullOrEmpty(updateUserDto.Password))
        {
            HashingHelper.CreatePasswordHash(updateUserDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
        }

        User updatedUser = await _userDal.UpdateAsync(user);
        UpdatedUserDto mappedUser = _mapper.Map<UpdatedUserDto>(updatedUser);
        return mappedUser;
    }
}
