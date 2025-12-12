using ApiEmpresa.DTOs;
using ApiEmpresa.Interfaces;
using ApiEmpresa.Services;
using ApiEmpresa.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _users;
    private readonly PasswordService _passwords;
    private readonly JwtService _jwt;

    public AuthController(IUserRepository users, PasswordService passwords, JwtService jwt)
    {
        _users = users;
        _passwords = passwords;
        _jwt = jwt;
    }

    // REGISTRO
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto dto)
    {
        var exists = await _users.GetByEmailAsync(dto.Email);
        if (exists != null)
            return BadRequest("El usuario ya existe");

        var user = new User
        {
            Email = dto.Email,
            PasswordHash = _passwords.Hash(dto.Password),
            Rol = dto.Rol
        };

        await _users.RegisterAsync(user);

        return Ok("Usuario registrado correctamente");
    }

    // LOGIN
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto dto)
    {
        var user = await _users.GetByEmailAsync(dto.Email);
        if (user == null)
            return Unauthorized("Usuario no encontrado");

        if (!_passwords.Verify(dto.Password, user.PasswordHash))
            return Unauthorized("Contraseña incorrecta");

        var token = _jwt.Generate(user);

        return Ok(new { token });
    }
}
