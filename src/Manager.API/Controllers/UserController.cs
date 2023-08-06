using AutoMapper;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Manager.Core.Exceptions;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    
    public UserController(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }
    
    [HttpGet]
    [Route("/api/v1/users/get-all")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var allUsers = await _userService.Get();

            return Ok(new ResultViewModel
            {
                Message = "Usuários encontrados com sucesso!",
                Success = true,
                Data = allUsers
            });
        }
        catch (DomainException error)
        {
            return BadRequest(Responses.DomainErrorMessage(error.Message));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
    
    [HttpGet]
    [Route("/api/v1/users/get/{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum usuário foi encontrado com o ID informado.",
                    Success = true,
                    Data = user
                });
            }
            
            return Ok(new ResultViewModel
            {
                Message = "Usuário encontrado com sucesso!",
                Success = true,
                Data = user
            });
        }
        catch (DomainException error)
        {
            return BadRequest(Responses.DomainErrorMessage(error.Message));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
    
    [HttpPost]
    [Route("/api/v1/users/create")]
    public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
    {
        try
        {
            var userDTO = _mapper.Map<UserDTO>(userViewModel);
            var userCreated = await _userService.Create(userDTO);
            
            return Ok(new ResultViewModel
            {
                Message = "Usuário criado com sucesso!",
                Success = true,
                Data = userCreated
            });
        }
        catch (DomainException error)
        {
            return BadRequest(Responses.DomainErrorMessage(error.Message, error.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
    
    [HttpPut]
    [Route("/api/v1/users/update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserViewModel userViewModel)
    {
        try
        {
            var userDTO = _mapper.Map<UserDTO>(userViewModel);
            var userUpdated = await _userService.Update(userDTO);
            
            return Ok(new ResultViewModel
            {
                Message = "Usuário atualizado com sucesso!",
                Success = true,
                Data = userUpdated
            });
        }
        catch (DomainException error)
        {
            return BadRequest(Responses.DomainErrorMessage(error.Message, error.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
    
    [HttpDelete]
    [Route("/api/v1/users/remove/{id}")]
    public async Task<IActionResult> Remove(long id)
    {
        try
        {
            await _userService.Remove(id);
            
            return Ok(new ResultViewModel
            {
                Message = "Usuário removido com sucesso!",
                Success = true,
                Data = null
            });
        }
        catch (DomainException error)
        {
            return BadRequest(Responses.DomainErrorMessage(error.Message));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
    
    [HttpGet]
    [Route("/api/v1/users/get-by-email")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        try
        {
            var getByEmail = await _userService.GetByEmail(email);
            
            return Ok(new ResultViewModel
            {
                Message = "Usuário encontrado com sucesso",
                Success = true,
                Data = getByEmail
            });
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
    
    [HttpGet]
    [Route("/api/v1/users/search-by-email")]
    public async Task<IActionResult> SearchByEmail([FromQuery] string email)
    {
        try
        {
            var searchedUsers = await _userService.SearchByEmail(email);
            
            return Ok(new ResultViewModel
            {
                Message = "Usuário encontrado com sucesso",
                Data = searchedUsers,
                Success = true
            });
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
    
    [HttpGet]
    [Route("/api/v1/users/search-by-name")]
    public async Task<IActionResult> SearchByName([FromQuery] string name)
    {
        try
        {
            var searchByName = await _userService.SearchByName(name);
            
            return Ok(new ResultViewModel
            {
                Message = "Usuário encontrado com sucesso",
                Success = true,
                Data = searchByName
            });
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
}