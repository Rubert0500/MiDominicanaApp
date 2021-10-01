﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace MiDominicanaApp.Services
{
    public class MiDominicana : IMiDominicanaApiService
    {
        public async Task<HttpResponseMessage> GetCurrenciesAsync()
        {
            return await RestService.For<IMiDominicanaApi>("http://eladio37-001-site1.ftempurl.com").GetCurrenciesAsync();
        }

        public async Task<HttpResponseMessage> GetFuelsAsync()
        {
            return await RestService.For<IMiDominicanaApi>("http://eladio37-001-site1.ftempurl.com").GetFuelsAsync();
        }

        public async Task<HttpResponseMessage> GetProvincesAsync()
        {
            return await RestService.For<IMiDominicanaApi>("http://eladio37-001-site1.ftempurl.com").GetProvincesAsync();
        }
    }
}
