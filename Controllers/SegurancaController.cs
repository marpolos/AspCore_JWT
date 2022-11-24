using Microsoft.AspNetCore.Mvc;
using AspCore_JWT.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace AspCore_JWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SegurancaController : ControllerBase
{
    /* public void ConfigureService(IServiceCollection services)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        services.AddSingleton<IConfiguration>(Configuration);
    } */
    /* private IConfiguration _config;
    public SegurancaController(IConfiguration Configuration)
    {
        _config = Configuration;
    } */
    [HttpGet]
    [Authorize]
    public IActionResult GetAll()
    {
        List<Usuario> usuarios = new() { new Usuario() { NomeUsuario = "Marcia" }, new Usuario() { NomeUsuario = "Carlos" } };
        return Ok(usuarios);
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Login([FromBody]Usuario loginDetalhes)
    {
        bool resultado = ValidarUsuario(loginDetalhes);
        if(resultado)
        {
            var tokenString = GerarTokenJWT();
            return Ok(new { token = tokenString });
        }
        else return Unauthorized();
    }

    private static string GerarTokenJWT()
    {
        var issuer = "MarcelleByMacoratti";
        var audience = "MinhaAudiencia";
        var expiry = DateTime.Now.AddDays(1);
        var key = Encoding.UTF8.GetBytes("senhasupersecreta");
        var securityKey = new SymmetricSecurityKey(key);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: expiry,
            signingCredentials: credentials
            );
        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }

    private static bool ValidarUsuario(Usuario loginDetalhes)
    {
        return loginDetalhes.NomeUsuario == "Marcelle" && loginDetalhes.Senha == "1234";
    }

}