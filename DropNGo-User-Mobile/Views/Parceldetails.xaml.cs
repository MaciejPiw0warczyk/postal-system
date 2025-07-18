using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DropNGo_User_Mobile.ViewModels;

namespace DropNGo_User_Mobile.Views;

public partial class ParcelDetails : ContentPage
{
    public ParcelDetails(ParcelDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}