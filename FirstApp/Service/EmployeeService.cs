using FirstApp.Model;
using FirstApp.Repository;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Service
{
    public class EmployeeService:IEmployeeService
    {

        private readonly SQLiteAsyncConnection _dbConnection;
        public EmployeeService()
        {

            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Employee.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                _dbConnection.CreateTableAsync<EmployeeModel>();
            }
            catch (Exception ex)
            {
            }

        }

        public async Task<List<EmployeeModel>>  GetAllEmployees()
        {
            return await _dbConnection.Table<EmployeeModel>().ToListAsync();           
        }

        public async Task<int> InsertEmployee(EmployeeModel obj)
        {
            return await _dbConnection.InsertAsync(obj);
        }

        public async Task<int> UpdateEmployee(EmployeeModel obj)
        {
            return await _dbConnection.UpdateAsync(obj);
        }

        public async Task<int> DeleteEmployee(EmployeeModel obj)
        {
            return await _dbConnection.DeleteAsync(obj);
        }
    }
}
