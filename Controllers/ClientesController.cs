using AspCore_JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspCore_JWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult GetClientes()
    {
        List<Client> clientes = new List<Client>();
        clientes.Add(new Client() {
            Nome = "Macoratti",
            Email = "macoratti@yahoo.com"
        });
        clientes.Add(new Client() {
            Nome = "Nathaly",
            Email = "nathaly.mesquita@xp.com"
        });
        clientes.Add(new Client() {
            Nome = "Thales",
            Email = "thales.carneiro@trybe.com"
        });
        return new ObjectResult(clientes);
    }
}