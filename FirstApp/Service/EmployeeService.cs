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

        #region Properties
        private readonly SQLiteAsyncConnection _dbConnection;
        private string fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"/Employee.db"; 
        #endregion

        #region Constructor
        public EmployeeService()
        {

            try
            {
                _dbConnection = new SQLiteAsyncConnection(fileName);
                _dbConnection.CreateTableAsync<EmployeeModel>();
            }
            catch (Exception ex)
            {
            }

        }
        #endregion

        #region Public Method        
        public async Task<List<EmployeeModel>> GetAllEmployees()
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
        #endregion
    }
}
