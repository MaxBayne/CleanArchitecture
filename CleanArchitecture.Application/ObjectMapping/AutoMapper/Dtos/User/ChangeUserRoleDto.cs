﻿using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User
{
    public class ChangeUserRoleDto : BaseDto
    {
        public string? Role { get; set; }
    }
}
