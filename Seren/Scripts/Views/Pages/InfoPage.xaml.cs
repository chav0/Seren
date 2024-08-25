using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Seren.Scripts.Views.Pages;

public partial class InfoPage : ContentPage
{
    public InfoPage()
    {
        InitializeComponent();
        ToMainPageCommand = new Command(OnToMainPageClicked);
        BindingContext = this;
    }

    public ICommand ToMainPageCommand { get; }

    private void OnToMainPageClicked() => Application.Current.MainPage = new AppShell();
}