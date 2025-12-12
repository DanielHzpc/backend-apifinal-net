using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize] // ← PROTEGE TODAS LAS RUTAS
[ApiController]
[Route("api/[controller]")]
public class EquipmentController : ControllerBase
{
    // ...
}

