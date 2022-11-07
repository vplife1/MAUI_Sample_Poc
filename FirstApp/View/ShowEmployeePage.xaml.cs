using FirstApp.ViewModel;

namespace FirstApp.View;

public partial class ShowEmployeePage : ContentPage
{
    private ShowEmployeePageViewModel _viewModel;
    public ShowEmployeePage()
    {
        InitializeComponent();
        _viewModel = new ShowEmployeePageViewModel();
        this.BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.ShowEmployee();
        _viewModel.ShowZipCode();
    }
}