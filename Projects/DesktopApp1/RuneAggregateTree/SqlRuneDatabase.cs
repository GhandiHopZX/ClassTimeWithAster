using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneAggregateTree.Sql
{
    // RUNE TOKENSSSSSS!!!!!
    public class SqlRuneDatabase : TokenDatabase
    {
        public SqlRuneDatabase (string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;
        protected override Token AddCore(Token token)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                //var cmd = new SqlCommand("", connection);
                var cmd = connection.CreateCommand();
                cmd.CommandText = "AddRune";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Add parameter 1 - long way when you need control over parameter
                var parameter = new SqlParameter("@name", System.Data.SqlDbType.NVarChar);
                parameter.Value = token.Name;
                cmd.Parameters.Add(parameter);

                //Add parameter 2 - quick way when you just need type/value
                cmd.Parameters.AddWithValue("@description", token.description);
                cmd.Parameters.AddWithValue("@price", token.priceh);

                var result = Convert.ToInt32(cmd.ExecuteScalar());

                token.RTID = result;
                return token;
            }
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        protected override void DeleteCore(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                //var cmd = new SqlCommand("", connection);
                var cmd = connection.CreateCommand();
                cmd.CommandText = "DeleteRune";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                //No results
                cmd.ExecuteNonQuery();
            };
        }

        protected override IEnumerable<Token> GetAllCore()
        {
            var ds = new DataSet();

            using (var conn = GetConnection())
            {
                var cmd = new SqlCommand("GetRunes", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                var da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                //If you wanted to update
                //da.Update(ds);
            };

            //Disconnected from DB
            //ds.Tables[0].Rows[0][0] = "Old";
            //ds.Tables[0].Rows[0]["Name"] = "Old";
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                return from r in table.Rows.OfType<DataRow>()
                       select new Token()
                       {
                           RTID = Convert.ToInt32(r[0]),  //Ordinal, convert
                           Name = r["Name"].ToString(), //By name, convert
                           description = r.IsNull("description") ? "" : r["description"].ToString(), //handle DB nulls
                           priceh = r.Field<decimal>("Price"),
                          
                       };
            };

            return Enumerable.Empty<Token>();
        }

        protected override Token GetCore(int id)
        {
            using (var conn = GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetTokens";
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var tokenId = reader.GetInt32(0);
                    if (tokenId == id)
                    {
                        return new Token()
                        {
                            RTID = tokenId,
                            Name = GetString(reader, "Name"),
                            description = GetString(reader, "Description"),
                            priceh = reader.GetFieldValue<decimal>(3)
                        };
                    };
                };
            };

            return null;
        }
        private string GetString(IDataReader reader, string name)
        {
            var ordinal = reader.GetOrdinal(name);

            if (reader.IsDBNull(ordinal))
                return "";

            return reader.GetString(ordinal);
        }

        protected override Token UpdateCore(int id, Token token)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                //var cmd = new SqlCommand("", connection);
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UpdateGame";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Add parameter 1 - long way when you need control over parameter
                var parameter = new SqlParameter("@name", System.Data.SqlDbType.NVarChar);
                parameter.Value = token.Name;
                cmd.Parameters.Add(parameter);

                //Add parameter 2 - quick way when you just need type/value
                cmd.Parameters.AddWithValue("@description", token.description);
                cmd.Parameters.AddWithValue("@price", token.priceh);
                cmd.Parameters.AddWithValue("@id", id);

                //No results
                cmd.ExecuteNonQuery();
            };

            return token;
        }


    }
}
