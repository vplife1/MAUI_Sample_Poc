using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Model
{
    public class ZipCodeModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }

    [Table("Result")]
    public class Root
    {
        public List<ZipCodeModel> results { get; set; }
    }
}
