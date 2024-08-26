using CommunityToolkit.Maui.Views;
using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Popups;

public partial class ErrorPopup : Popup
{
    public ErrorPopup(ErrorPopupViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }

    private void OnOkButtonClicked(object? sender, EventArgs e) => Close();
}