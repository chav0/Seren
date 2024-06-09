namespace Seren.Scripts.Views.Pages;

public class PageFactory : IPageFactory
{
    private readonly IServiceProvider _serviceProvider;

    public PageFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TPage GetPage<TPage>() where TPage : class => _serviceProvider.GetService<TPage>();

    public TViewModel GetViewModel<TViewModel>() where TViewModel : class => _serviceProvider.GetService<TViewModel>();
}