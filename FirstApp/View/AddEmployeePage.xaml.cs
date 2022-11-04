using FirstApp.Model;
using FirstApp.ViewModel;

namespace FirstApp.View;

public partial class AddEmployeePage : ContentPage
{
    public AddEmployeePage()
    {
        InitializeComponent();
        this.BindingContext = new AddEmployeePageViewModel();
    }


    public AddEmployeePage(EmployeeModel obj)
    {
        InitializeComponent();
        this.BindingContext = new AddEmployeePageViewModel(obj);
    }
}