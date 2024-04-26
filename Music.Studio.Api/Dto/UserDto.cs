using Music.Studio.Core;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Dto;

public class UserDto
{
    public int idUser { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    
    [NumericOnly(ErrorMessage = "Tipo de dato invalido.")]
    public int idEmployee_FK { get; set; }

    public UserDto()
    {
        
    }
    
    public UserDto(User user)
    {
        idUser = user.idUser;
        Name = user.Name;
        Password = user.Password;
        idEmployee_FK = user.idEmployee_FK;
    }
}