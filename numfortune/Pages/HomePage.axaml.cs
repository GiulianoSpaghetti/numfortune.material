using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using numfortune.ViewModels;
using System;

namespace numfortune.Pages;

public partial class HomePage : UserControl
{
    public HomePage()
    {
        DataContext ??= new MainViewModel();
        InitializeComponent();
    }
}