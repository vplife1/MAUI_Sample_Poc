using FirstApp.Model;
using FirstApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirstApp.ViewModel
{
    public class AddEmployeePageViewModel : BaseViewModel
    {
        #region Properties
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _address;
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        private int _employeeID;
        private readonly EmployeeService _employeeService;
        #endregion

        #region Constructor
        public AddEmployeePageViewModel()
        {
            _employeeService = new EmployeeService();
        }

        public AddEmployeePageViewModel(EmployeeModel employeeObj)
        {
            Name = employeeObj.Name;
            Email = employeeObj.Email;
            Address = employeeObj.Address;
            _employeeID = employeeObj.ID;
            _employeeService = new EmployeeService();

        }
        #endregion


        #region Commands
        public ICommand AddEmployeeCommand => new Command(async () =>
        {
            EmployeeModel obj = new EmployeeModel
            {
                Email = Email,
                Address = Address,
                Name = Name,
                ID = _employeeID,
            };
            if (_employeeID > 0)
            {
                _employeeService.UpdateEmployee(obj);
            }
            else
            {
                _employeeService.InsertEmployee(obj);
            }
            await App.Current.MainPage.Navigation.PopAsync();
        });
        #endregion

    }
}
