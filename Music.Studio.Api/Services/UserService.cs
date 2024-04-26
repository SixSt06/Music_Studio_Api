using Music.Studio.Api.Dto;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<bool> UserExist(int idUser)
    {
        var user= await _userRepository.GetByIdAsync(idUser);
        return (user != null);
    }

    public async Task<UserDto> SaveAsync(UserDto userDto)
    {
        var user = new User
        {
            Name = userDto.Name,
            Password = userDto.Password,
            idEmployee_FK = userDto.idEmployee_FK,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        user = await _userRepository.SaveAsync(user);
        userDto.idUser = userDto.idUser;
        return userDto;
    }

    public async Task<UserDto> UpdateAsync(UserDto userDto)
    {
        var user = await _userRepository.GetByIdAsync(userDto.idUser);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        user.Name = userDto.Name;
        user.Password = userDto.Password;
        user.idEmployee_FK = userDto.idEmployee_FK;
        user.UpdatedBy = "";
        user.UpdatedDate = DateTime.Now;
        await _userRepository.UpdateAsync(user);
        return userDto;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var user = await _userRepository.GetAllAsync();
        var usersDto = user.Select(c => new UserDto(c)).ToList();
        return usersDto;
    }

    public async Task<bool> DeleteAsync(int idUser)
    {
        return await _userRepository.DeleteAsync(idUser);
    }

    public async Task<UserDto> GetByIdAsync(int idUser)
    {
        var user = await _userRepository.GetByIdAsync(idUser);
        if (user == null)
        {
            throw new Exception("User not Found");
        }

        var userDtp = new UserDto(user);
        return userDtp;
    }
}