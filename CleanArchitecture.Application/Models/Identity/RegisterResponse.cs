﻿namespace CleanArchitecture.Application.Models.Identity
{
    public class RegisterResponse
    {
        public string UserId { get; set; }

        public bool IsSuccess { get; set; }
        public Exception Exception { get; set; }
    }
}
