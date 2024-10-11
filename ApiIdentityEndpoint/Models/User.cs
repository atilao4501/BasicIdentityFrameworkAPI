using System;
using Microsoft.AspNetCore.Identity;

namespace ApiIdentityEndpoint.Models;

public class User : IdentityUser
{
    public string Documento { get; set; } = string.Empty;
}
