using System.Text.Json;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DropNGo_Shared;
using DropNGo_User_Mobile.Views;

namespace DropNGo_User_Mobile.ViewModels;

public partial class ParcelListViewModel : ObservableObject
{
    public ParcelListViewModel()
    {
        ParcelString = ReceiveParcels().Result.ToString();
        Parcels = ReceiveParcels().Result;
    }

    [RelayCommand]
    public Task<List<Parcel>> ReceiveParcels()//Todo handle exceptions
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("http://192.168.1.10:5112");

        try
        {
            var response = client.GetAsync("parcel").Result.Content.ReadAsStringAsync().Result;
            var list = JsonSerializer.Deserialize<List<Parcel>>(response);
            return Task.FromResult(list);
        }
        catch (Exception e)
        {
            var toast = Toast.Make(e.Message, ToastDuration.Long, 14);
            toast.Show();
        }
        return Task.FromResult(new List<Parcel>());
    }

    [RelayCommand]
    public async Task RefreshParcels()
    {
        Parcels = ReceiveParcels().Result;
        IsRefreshing = false;
    }

    [ObservableProperty] string parcelString;
    [ObservableProperty] List<Parcel> parcels;
    [ObservableProperty] bool isRefreshing = false;
}