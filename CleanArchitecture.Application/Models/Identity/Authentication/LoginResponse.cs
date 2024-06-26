﻿using System.Security.Claims;

namespace CleanArchitecture.Application.Models.Identity.Authentication
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserToken { get; set; }
        public IEnumerable<Claim> UserClaims { get; set; }


        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
