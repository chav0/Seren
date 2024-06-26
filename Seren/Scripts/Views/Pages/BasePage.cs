using System.Diagnostics;
using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Pages;

public abstract class BasePage<TViewModel> : BasePage where TViewModel : BaseViewModel
{
    protected BasePage(TViewModel viewModel) : base(viewModel)
    {
    }

    public new TViewModel BindingContext => (TViewModel) base.BindingContext;
}

public abstract class BasePage : ContentPage
{
    protected BasePage(object? viewModel = null)
    {
        BindingContext = viewModel;

        if (string.IsNullOrWhiteSpace(Title))
        {
            Title = GetType().Name;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Debug.WriteLine($"OnAppearing: {Title}");
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        Debug.WriteLine($"OnDisappearing: {Title}");
    }
}