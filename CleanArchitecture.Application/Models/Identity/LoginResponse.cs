﻿namespace CleanArchitecture.Application.Models.Identity
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
