namespace test_charts;

public partial class DetailPage : ContentPage
{
	private readonly DetailViewModel _viewmodel;

    public DetailPage(DetailViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = _viewmodel = viewmodel;
    }
}