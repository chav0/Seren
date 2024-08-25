using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Pages;

public partial class SettingsPage
{
    public SettingsPage(SettingsViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}