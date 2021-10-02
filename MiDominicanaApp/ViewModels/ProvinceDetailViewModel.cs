﻿using MiDominicanaApp.Models;
using MiDominicanaApp.Services;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MiDominicanaApp.ViewModels
{
    class ProvinceDetailViewModel : BaseViewModel
    {
        IMiDominicanaApiService _miDominicanaApiService;
        IPageDialogService _pageDialog;

        public Province province { get; set; } = new Province();

        public ProvinceDetailViewModel(IMiDominicanaApiService miDominicanaApiService, IPageDialogService pageDialog)
        {
            _miDominicanaApiService = miDominicanaApiService;
            _pageDialog = pageDialog;
            Task.Run(async () => { await GetProvince(); });
        }

        private async Task GetProvince()
        {
            var rnd = new Random();
            var provinceId = rnd.Next(1, 32);
            if(Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var provinceResponse = await _miDominicanaApiService.GetProvinceDetailAsync(provinceId);
                if (provinceResponse != null)
                {
                    var responseContent = await provinceResponse.Content.ReadAsStringAsync();
                    province = JsonSerializer.Deserialize<Province>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await _pageDialog.DisplayAlertAsync("Alerta", "No hay conexión a internet.", "OK");
                });
            }
        }
    }
}
