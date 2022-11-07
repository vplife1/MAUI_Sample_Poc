using FirstApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


namespace FirstApp.Service
{
    public class ZipCodeService
    {
        #region properties 
        SQLiteAsyncConnection conn;
        List<ZipCodeModel> _resultList = new();
        Root _root = new();       
        HttpClient _httpClient;       
        private string fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"/zip.db";     
        #endregion

        #region Constructor
        public ZipCodeService()
        {
            conn = new SQLiteAsyncConnection(fileName);
            _httpClient = new HttpClient();                   
        }
        #endregion

        #region API Consume

        public async Task<List<ZipCodeModel>> GetAllZipCode()
        {         
            await conn.CreateTableAsync<ZipCodeModel>();
            List<ZipCodeModel> resultsFromSQL = await conn.Table<ZipCodeModel>().ToListAsync();
            if (resultsFromSQL.Count == 0)
            {

                if (_resultList?.Count > 0)
                    return _resultList;

                var url = "https://www.zipwise.com/webservices/citysearch.php?key=dksr5ewwvyy7tnjk&format=json&string=Acton";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    _root = await response.Content.ReadFromJsonAsync<Root>();
                    _resultList = _root.results;
                    var rowsAdded = await conn.InsertAllAsync(_resultList);
                }
            }
            else _resultList = resultsFromSQL;
            return _resultList;
        }
        #endregion
    }
}
