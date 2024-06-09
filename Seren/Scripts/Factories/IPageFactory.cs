namespace Seren.Scripts.Views.Pages;

public interface IPageFactory
{
    TPage GetPage<TPage>() where TPage : class;

    public TViewModel GetViewModel<TViewModel>() where TViewModel : class;
}