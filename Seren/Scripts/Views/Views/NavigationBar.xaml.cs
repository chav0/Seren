using System.Diagnostics;

namespace Seren.Scripts.Views.Views;

public partial class NavigationBar : ContentView
{
    public NavigationBar()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Ваш код для обработки нажатия на кнопку "Назад"
        if (Navigation.NavigationStack.Count > 0)
        {
            Navigation.PopAsync();
        }
    }

    public static readonly BindableProperty TitleTextProperty =
        BindableProperty.Create(nameof(TitleText), typeof(string), typeof(NavigationBar));

    public string TitleText
    {
        get => (string)GetValue(TitleTextProperty);
        set => SetValue(TitleTextProperty, value);
    }
}