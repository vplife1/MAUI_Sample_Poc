using FirstApp.Model;
using FirstApp.ViewModel;

namespace FirstApp.View;

public partial class AddEmployeePage : ContentPage
{
    private AddEmployeePageViewModel _viewModel;
    public AddEmployeePage()
    {
        InitializeComponent();
        _viewModel = new AddEmployeePageViewModel();
        this.BindingContext = _viewModel;
    }


    public AddEmployeePage(EmployeeModel obj)
    {
        InitializeComponent();
        this.BindingContext = new AddEmployeePageViewModel(obj);
    }
}