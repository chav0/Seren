using CommunityToolkit.Maui.Views;
using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Popups;

public partial class DeleteDataPopup : Popup
{
    public DeleteDataPopup(DeleteDataViewModel viewModel)
    {
        BindingContext = viewModel;
        Console.WriteLine("Delete Popup");
        InitializeComponent();
    }

    private void OnCancelButtonClicked(object? sender, EventArgs e)
    {
        Close();
    }

    private void OnDeleteButtonClicked(object? sender, EventArgs e)
    {
        Close();
    }
}