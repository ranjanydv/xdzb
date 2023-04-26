

using AppDev.Application.DTOs;
using AppDev.Domain.Entities;

namespace AppDev.Application.Common.Interface;

public interface IUserDetails
{
    Task<List<User>> GetAllUserAsync();
    Task<User> AddUserDetails(UserRequestDTO user);
}