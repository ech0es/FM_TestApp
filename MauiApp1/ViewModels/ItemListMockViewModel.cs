using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MauiApp1.ViewModels;

public class ItemListMockViewModel : ViewModelBase
{
    private ItemViewModel _selectedItem;
    private static readonly PropertyChangedEventArgs SelectedItemChangedEventArgs = new(nameof(SelectedItem));

    public ItemListMockViewModel()
    {
        Items.Add(new ItemViewModel("Basketball", "a team sport in which two teams, most commonly of five players each, opposing one another on a rectangular court, compete with the primary objective of shooting a basketball.", "basketball", false));
        Items.Add(new ItemViewModel("Soccer", "a team sport played between two teams of 11 players on a rectangular field with a goal at each end.", "soccer", false));
        Items.Add(new ItemViewModel("Tennis", "a racket sport that is played either individually against a single opponent (singles) or between two teams of two players each (doubles).", "tennis", true));
        Items.Add(new ItemViewModel("Badminton", "a racquet sport played using racquets to hit a shuttlecock across a net.", "badminton", true));

        _selectedItem = Items.First();

        SelectItemCommand = new Command<ItemViewModel>(ExecuteSelectItemCommand);
    }

    public ObservableCollection<ItemViewModel> Items { get; } = new ObservableCollection<ItemViewModel>();

    public ItemViewModel SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (_selectedItem == value) return;
            _selectedItem = value;
            RaisePropertChanged(SelectedItemChangedEventArgs);
        }
    }

    public ICommand SelectItemCommand { get; }

    private void ExecuteSelectItemCommand(ItemViewModel item)
    {
        SelectedItem = item;
    }
}