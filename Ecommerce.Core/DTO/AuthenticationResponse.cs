using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.DTO
{
    public record AuthenticationResponse(Guid UserId, string? Email, string? PersonName, string? Gender,
        string? Token, bool Success);
}
