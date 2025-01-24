using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;

namespace numfortune.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DrawerList.PointerReleased += DrawerSelectionChanged;
    }
    public void DrawerSelectionChanged(object? sender, RoutedEventArgs? args)
    {
        if (sender is not ListBox listBox)
            return;

        if (!listBox.IsFocused && !listBox.IsKeyboardFocusWithin)
            return;
        try
        {
            PageCarousel.SelectedIndex = listBox.SelectedIndex;        }
        catch
        {
            // ignored
        }

        LeftDrawer.OptionalCloseLeftDrawer();
    }
}
