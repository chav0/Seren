using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Views;

public partial class TimerView : BaseView<TimerViewModel>
{
    public TimerView(TimerViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}