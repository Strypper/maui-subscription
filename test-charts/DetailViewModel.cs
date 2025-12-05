using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace test_charts;

public partial class DetailViewModel : ObservableObject
{
    [ObservableProperty]
    string title = "Hello Thien";
    #region [ Subscriptions ]

    private readonly List<Subscription> subscriptions = new()
    {
        new() { Id = Guid.NewGuid(), Name = "Individual" },
        new() { Id = Guid.NewGuid(), Name = "Family" },
        new() { Id = Guid.NewGuid(), Name = "Student plans" },
        // ... more items
    };

    [ObservableProperty]
    private ObservableCollection<Subscription> filteredSubscriptions;

    [ObservableProperty]
    private Subscription selectedSubscription;

    [ObservableProperty]
    private int cursorPosition;

    [RelayCommand]
    private void TextChanged(string text)
    {
        FilteredSubscriptions.Clear();

        var filtered = subscriptions.Where(item =>
            item.Name.Contains(text, StringComparison.OrdinalIgnoreCase));

        foreach (var item in filtered)
            FilteredSubscriptions.Add(item);
    }
    #endregion

    #region [ Colors ]

    private readonly List<string> quickColors = new()
    {
        "#FF6B6B",
        "#4ECDC4",
        "#45B7D1",
        "#FFA07A",
        "#98D8C8",
        "#F7DC6F",
        "#BB8FCE",
        "#85C1E2",
        "#F8B88B",
        "#52C9D8",
        "#A8E6CF",
        "#FFD3B6",
        "#FFAAA5",
        "#FF8B94",
        "#A8D8EA",
        "#7FDBCA",
        "#FFB4B4",
        "#BAFFC9"
    };

    [ObservableProperty]
    private ObservableCollection<string> colors;


    [ObservableProperty]
    string selectedColor = "#FF6B6B";

    partial void OnSelectedColorChanged(string value)
    {
        
    }
    #endregion


    public DetailViewModel()
    {
        Colors = new(quickColors);
        FilteredSubscriptions = new(subscriptions);
    }
}

public class Provider
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
}

public class Subscription
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
}