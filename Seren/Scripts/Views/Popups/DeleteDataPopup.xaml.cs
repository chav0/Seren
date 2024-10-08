using CommunityToolkit.Maui.Views;
using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Popups;

public partial class DeleteDataPopup : Popup
{
    private readonly DeleteDataViewModel _viewModel;
    
    public DeleteDataPopup(DeleteDataViewModel viewModel)
    {
        _viewModel = viewModel;
        BindingContext = viewModel;
        InitializeComponent();
    }

    private void OnCancelButtonClicked(object? sender, EventArgs e) => Close();

    private void OnDeleteButtonClicked(object? sender, EventArgs e)
    {
        _viewModel.DeleteData(); 
        Close();
    }
}