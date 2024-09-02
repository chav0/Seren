using Seren.Scripts.ViewModels;
using Seren.Scripts.Views.Views;

namespace Seren.Scripts.Views.Pages;

public class PageFactory(IServiceProvider serviceProvider) : IPageFactory
{
    public TPage GetPage<TPage>() where TPage : BasePage => 
        serviceProvider.GetService<TPage>();
    
    public TView GetView<TView>() where TView : BaseView => 
        serviceProvider.GetService<TView>();

    public TViewModel GetViewModel<TViewModel>() where TViewModel : BaseViewModel => 
        serviceProvider.GetService<TViewModel>();
}