using System.Diagnostics;
using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Views;

public abstract class BaseView<TViewModel> : BaseView where TViewModel : BaseViewModel
{
    protected BaseView(TViewModel viewModel) : base(viewModel)
    {
    }

    public new TViewModel BindingContext => (TViewModel) base.BindingContext;
}

public abstract class BaseView : ContentView
{
    protected BaseView(object? viewModel = null) => BindingContext = viewModel;
}