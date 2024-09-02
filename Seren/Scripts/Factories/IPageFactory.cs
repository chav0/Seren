using Seren.Scripts.ViewModels;
using Seren.Scripts.Views.Views;

namespace Seren.Scripts.Views.Pages;

public interface IPageFactory
{
    TPage GetPage<TPage>() where TPage : BasePage;
    TView GetView<TView>() where TView : BaseView;
    public TViewModel GetViewModel<TViewModel>() where TViewModel : BaseViewModel;
}