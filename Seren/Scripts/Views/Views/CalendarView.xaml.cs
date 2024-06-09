using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Views;

public partial class CalendarView : BaseView<CalendarViewModel>
{
    public CalendarView(CalendarViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}