using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace test_charts;

public partial class DetailViewModel : ObservableObject
{
    #region [ Company ]

    [ObservableProperty]
    string section1Title = "Company";

    [ObservableProperty]
    string companySearchText = "Google, Apple, Microsoft";

    [ObservableProperty]
    string companyValue = string.Empty;

    private readonly List<Provider> companies = new()
    {
        new() {
                Id = Guid.Parse("D3B2F1E4-5C6A-4B8D-9A2F-1B2C3D4E5F6A"),
                Name = "Google",
                Subscriptions = new List<Subscription>
                {
                    new() { Id = Guid.NewGuid(), Name = "Google One" },
                    new() { Id = Guid.NewGuid(), Name = "YouTube Premium" },
                    new() { Id = Guid.NewGuid(), Name = "Google Workspace" },
                }
              },
        new() {
                Id = Guid.Parse("D3B2F1E4-5C6A-4B8D-9A2F-1B2C3D4E5F6B"),
                Name = "Apple",
                Subscriptions = new List<Subscription>
                {
                    new() { Id = Guid.NewGuid(), Name = "Apple Music" },
                    new() { Id = Guid.NewGuid(), Name = "Apple TV+" },
                    new() { Id = Guid.NewGuid(), Name = "iCloud" },
                }
              },
        new() {
                Id = Guid.Parse("D3B2F1E4-5C6A-4B8D-9A2F-1B2C3D4E5F6C"),
                Name = "Microsoft",
                Subscriptions = new List<Subscription>
                {
                    new() { Id = Guid.NewGuid(), Name = "Microsoft 365" },
                    new() { Id = Guid.NewGuid(), Name = "Xbox Game Pass" },
                    new() { Id = Guid.NewGuid(), Name = "OneDrive" },
                }
               },
        // ... more items
    };

    [ObservableProperty]
    private ObservableCollection<Provider> filteredCompanies;

    [ObservableProperty]
    private Provider selectedCompany;

    partial void OnSelectedCompanyChanged(Provider value)
    {
        SubscriptionValue = string.Empty;
        FilteredSubscriptions = new(value.Subscriptions);
    }

    [RelayCommand]
    private void CompanyTextChanged(string text)
    {
        FilteredCompanies.Clear();
        var filtered = companies.Where(item =>
            item.Name.Contains(text, StringComparison.OrdinalIgnoreCase));
        foreach (var item in filtered)
            FilteredCompanies.Add(item);
    }
    #endregion

    #region [ Subscriptions ]

    [ObservableProperty]
    string section2Title = "Subscription Plan";

    [ObservableProperty]
    string subscriptionSearchText = "YouTube Premium, Spotify Family";

    [ObservableProperty]
    string subscriptionValue = string.Empty;

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

    [RelayCommand]
    private void SubscriptionTextChanged(string text)
    {
        FilteredSubscriptions.Clear();
        var filtered = subscriptions.Where(item =>
            item.Name.Contains(text, StringComparison.OrdinalIgnoreCase));
        foreach (var item in filtered)
            FilteredSubscriptions.Add(item);
    }
    #endregion

    #region [ Colors ]

    [ObservableProperty]
    string section3Title = "Color";

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

    #region [ Price ]

    [ObservableProperty]
    string section4Title = "Price (VND)";

    [ObservableProperty]
    private decimal price;
    #endregion

    #region [ Next Renewable Date ]

    [ObservableProperty]
    string section5Title = "Next Renewal Date";

    [ObservableProperty]
    bool isRecursiveBill = false;

    [ObservableProperty]
    DateTime nextRenewalSelectedDate = DateTime.Now;
    #endregion


    public DetailViewModel()
    {
        FilteredCompanies = new(companies);
        FilteredSubscriptions = new(subscriptions);
        Colors = new(quickColors);
    }
}

public class Provider
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}

public class Subscription
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
}