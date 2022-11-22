using Android.Locations;
using FirstApp.Model;
using FirstApp.Service;
using FirstApp.View;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Maui.Networking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Java.Util.Jar.Attributes;

namespace FirstApp.ViewModel
{
    public class ShowEmployeePageViewModel : BaseViewModel
    {
        #region Properties

        public ObservableCollection<EmployeeModel> Employees { get; set; } = new ObservableCollection<EmployeeModel>();
        public ObservableCollection<ZipCodeModel> ZipCode { get; set; } = new ObservableCollection<ZipCodeModel>();
        private readonly EmployeeService _employeeService;
        private readonly ZipCodeService _zipCodeService;
        public ICommand AddEmpCommand { get; }
        public ICommand BtnClickCommand { get; }     
        #endregion

        #region Constructor
        public ShowEmployeePageViewModel()
        {
            _employeeService = new EmployeeService();
            _zipCodeService = new ZipCodeService();
            AddEmpCommand = new Command(async () => await AddEmpCommandAsync());
            BtnClickCommand = new Command(async () => await BtnClickCommandAsync());
        }

        private async Task BtnClickCommandAsync()
        {
          await App.Current.MainPage.Navigation.PushAsync(new AddEmployeePage());
        }
        #endregion

        #region Methods
        public async void ShowEmployee()
        {
            try
            {
                List<EmployeeModel> allEmployees = await _employeeService.GetAllEmployees();

                if (allEmployees?.Count > 0)
                {
                    Employees.Clear();
                    foreach (var employee in allEmployees)
                    {
                        Employees.Add(employee);
                    }
                }                

            }
            catch (Exception ex)
            {
            }
        }
        public async void ShowZipCode()
        {
            try
            {
                List<ZipCodeModel> zipcode = await _zipCodeService.GetAllZipCode();

                if (zipcode?.Count > 0)
                {
                    ZipCode.Clear();
                    foreach (var zip in zipcode)
                    {
                        ZipCode.Add(zip);
                    }
                }                

            }
            catch (Exception ex)
            {
            }
        }
        #endregion


        #region Commands
        private async Task AddEmpCommandAsync()
        {
            Analytics.TrackEvent("Add employee Page", new Dictionary<string, string> { {"first time", "Sample Text" } });
            await App.Current.MainPage.Navigation.PushAsync(new AddEmployeePage());
        }
       
        public ICommand SelectedEmployeeCommand => new Command<EmployeeModel>(async (employee) =>
        {
            string res = await App.Current.MainPage.DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

            switch (res)
            {
                case "Update":
                    await App.Current.MainPage.Navigation.PushAsync(new AddEmployeePage(employee));
                    Analytics.TrackEvent("Update Employee", new Dictionary<string, string> { { "Update", employee.Name } });
                    break;
                case "Delete":
                    int del =await _employeeService.DeleteEmployee(employee);
                    if (del > 0)
                    {
                        Employees.Remove(employee);
                        Analytics.TrackEvent("Remove Employee", new Dictionary<string, string> { { "Remove", employee.Name } });
                    }
                    break;
            }
        });
        #endregion

    }
}
