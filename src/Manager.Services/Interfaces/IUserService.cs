using Manager.Services.DTO;

namespace Manager.Services.Interfaces;

public interface IUserService
{
    Task<List<UserDTO>> Get();
    Task<UserDTO> Get(long id);
    Task<UserDTO> Create(UserDTO userDTO);
    Task<UserDTO> Update(UserDTO userDto);
    Task Remove(long id);
    Task<List<UserDTO>> SearchByName(string name);
    Task<List<UserDTO>> SearchByEmail(string email);
    Task<UserDTO> GetByEmail(string email);
}