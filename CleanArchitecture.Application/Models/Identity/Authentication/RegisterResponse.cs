﻿namespace CleanArchitecture.Application.Models.Identity.Authentication
{
    public class RegisterResponse
    {
        public string UserId { get; set; }

        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
