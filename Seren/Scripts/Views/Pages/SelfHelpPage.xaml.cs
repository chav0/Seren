using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Pages;

public partial class SelfHelpPage : BasePage<SelfHelpViewModel>
{
    public SelfHelpPage(SelfHelpViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}