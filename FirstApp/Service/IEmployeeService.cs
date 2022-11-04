using FirstApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Service
{
    internal interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetAllEmployees();
    }
}
