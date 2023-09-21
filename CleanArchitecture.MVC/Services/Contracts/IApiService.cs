﻿using CleanArchitecture.MVC.Services.Abstract;
// ReSharper disable InconsistentNaming

namespace CleanArchitecture.MVC.Services.Contracts
{
    public interface IApiService
    {
        #region Token

        protected void AddBearerTokenInRequestHeader();

        #endregion

        #region Api

        Task<ApiResponse<Tvm>> GetAsync<Tdto, Tvm>(string uriPath);
        Task<ApiResponse<Tvm>> PostAsync<Tdto, Tvm>(string uriPath, object data);
        Task<ApiResponse<Tvm>> PutAsync<Tdto, Tvm>(string uriPath, object data);
        Task<ApiResponse<Tvm>> DeleteAsync<Tdto, Tvm>(string uriPath);

        #endregion



    }
}
