using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appsqlite1
{
    public class Torcedor
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }

        public string Nome { get; set; }

        [MaxLength(100)]
        public string Time { get; set; }
    }
}
