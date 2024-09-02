using Seren.Scripts.ViewModels;
using Seren.Scripts.Views.Pages;

namespace Seren.Scripts.Views.Views;

public partial class SelfHelpCardView
{
    private readonly IPageFactory _pageFactory;

    public SelfHelpCardView(SelfHelpViewModel viewModel, IPageFactory pageFactory) : base(viewModel)
    {
        _pageFactory = pageFactory;
        InitializeComponent();
    }

    private async void OnTapped(object? sender, TappedEventArgs e)
    {
        var selfHelpPage = _pageFactory.GetPage<SelfHelpPage>();
        await Navigation.PushAsync(selfHelpPage);
    }
}