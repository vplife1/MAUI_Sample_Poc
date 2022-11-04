using FirstApp.Model;
using FirstApp.Service;
using FirstApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirstApp.ViewModel
{
    public class ShowEmployeePageViewModel : BaseViewModel
    {
        #region Properties

        public ObservableCollection<EmployeeModel> Employees { get; set; } = new ObservableCollection<EmployeeModel>();
        private readonly EmployeeService _employeeService;
        public ICommand AddEmpCommand { get; }
        

        
        #endregion

        #region Constructor
        public ShowEmployeePageViewModel()
        {
            _employeeService = new EmployeeService();
            AddEmpCommand = new Command(async () => await AddEmpCommandAsync());
        }
        #endregion

        #region Methods
        public async void ShowEmployee()
        {
            try
            {
                //List<EmployeeModel> allEmployees = await _employeeService.GetAllEmployees();

                //if (allEmployees?.Count > 0)
                //{
                //    Employees.Clear();
                //    foreach (var employee in allEmployees)
                //    {
                //        Employees.Add(employee);
                //    }
                //}
            }
            catch (Exception ex)
            {
            }
        }
        #endregion


        #region Commands
        private async Task AddEmpCommandAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddEmployeePage());
        }
       
        public ICommand SelectedEmployeeCommand => new Command<EmployeeModel>(async (employee) =>
        {
            string res = await App.Current.MainPage.DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

            switch (res)
            {
                case "Update":
                    await App.Current.MainPage.Navigation.PushAsync(new AddEmployeePage(employee));
                    break;
                case "Delete":
                    int del =await _employeeService.DeleteEmployee(employee);
                    if (del > 0)
                    {
                        Employees.Remove(employee);
                    }
                    break;
            }
        });
        #endregion

    }
}
