using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using numfortune.ViewModels;
using System;

namespace numfortune.Pages;

public partial class HomePage : UserControl
{
    public HomePage()
    {
        InitializeComponent();
        cookie.Text = MainViewModel.Tick();
    }



    public void OnTick_Click(Object obj, RoutedEventArgs args) => cookie.Text = MainViewModel.Tick();
}