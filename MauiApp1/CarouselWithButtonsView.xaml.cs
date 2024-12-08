using System.Collections.ObjectModel;
using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class CarouselWithButtonsView
{
    public CarouselWithButtonsView()
    {
        InitializeComponent();
    }
    
    public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
        nameof(Items), 
        typeof(ObservableCollection<ItemViewModel>), 
        typeof(CarouselWithButtonsView), 
        null);
    
    public static readonly BindableProperty CurrentItemProperty = BindableProperty.Create(
        nameof(CurrentItem), 
        typeof(ItemViewModel), 
        typeof(CarouselWithButtonsView), 
        null);

    public ObservableCollection<ItemViewModel> Items
    {
        get => (ObservableCollection<ItemViewModel>)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }
    
    public ItemViewModel CurrentItem
    {
        get => (ItemViewModel)GetValue(CurrentItemProperty);
        set => SetValue(CurrentItemProperty, value);
    }

    private void CarouselView_OnCurrentItemChanged(object? sender, CurrentItemChangedEventArgs e)
    {
        var index = Items.IndexOf((ItemViewModel)e.CurrentItem);
        btnPrevItem.IsEnabled = index > 0;
        btnNextItem.IsEnabled = index < Items.Count - 1;
    }

    private void BtnPrevItem_OnPressed(object? sender, EventArgs e)
    {
        carouselView.Position = Math.Max(0, carouselView.Position - 1);
    }

    private void BtnNextItem_OnPressed(object? sender, EventArgs e)
    {
        carouselView.Position = Math.Min(Items.Count - 1, carouselView.Position + 1);
    }
}