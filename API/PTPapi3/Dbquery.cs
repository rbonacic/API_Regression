using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPapi3
{
    public class SQLDataTable
    {
        string _err = "";
        public DataTable DataTable = new DataTable();
        private string _server;
        private string _database;
        private string _query;

        SqlDataAdapter da = new SqlDataAdapter();

        public SQLDataTable()
        { }

        public SQLDataTable(string Server, string Database, string Query)
        {
            this._server = Server;
            this._database = Database;
            this._query = Query;
            this.Fill();
        }

        public string Server
        {
            set { this._server = value; }
        }

        public string Database
        {
            set { this._database = value; }
        }

        public string Command
        {
            set { this._query = value; }
        }

        private string GetConnectionString()
        {
            return "Data Source=" + _server + ";Initial Catalog=" + _database + ";Integrated Security=SSPI;";
        }

        private void Fill()
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand(_query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            this.DataTable = dt;
        }

        public void Execute()
        {
            this.Fill();
        }
    }

}
