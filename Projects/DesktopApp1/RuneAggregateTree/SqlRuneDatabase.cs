using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneAggregateTree
{
    // To fix this shit turn the damn runes into 
    // tokenable objects already... and rename
    // this mess
    public class SqlRuneDatabase : RuneDatabase
    {
        public SqlRuneDatabase (string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;
        protected override RuneTree.Rune AddCore(RuneTree.Rune rune)
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
                parameter.Value = rune.Name;
                cmd.Parameters.Add(parameter);

                //Add parameter 2 - quick way when you just need type/value
                cmd.Parameters.AddWithValue("@description", rune.Description);
                cmd.Parameters.AddWithValue("@price", rune.Price);

                var result = Convert.ToInt32(cmd.ExecuteScalar());

                rune.ID = result;
                return rune;
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

        protected override IEnumerable<RuneTree.Rune> GetAllCore()
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
                       select new RuneTree.Rune()
                       {
                           ID = Convert.ToInt32(r[0]),  //Ordinal, convert
                           Name = r["Name"].ToString(), //By name, convert
                           Description = r.IsNull("description") ? "" : r["description"].ToString(), //handle DB nulls
                           Price = r.Field<decimal>("Price"),
                          
                       };
            };

            return Enumerable.Empty<RuneTree.Rune>();
        }

        protected override RuneTree.Rune GetCore(int id)
        {
            using (var conn = GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetRunes";
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var runeId = reader.GetInt32(0);
                    if (runeId == id)
                    {
                        return new RuneTree.Rune()
                        {
                            ID = runeId,
                            Name = GetString(reader, "Name"),
                            Description = GetString(reader, "Description"),
                            Price = reader.GetFieldValue<decimal>(3)
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

        protected override RuneTree.Rune UpdateCore(int id, RuneTree.Rune newRune)
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
                parameter.Value newRune.Name;
                cmd.Parameters.Add(parameter);

                //Add parameter 2 - quick way when you just need type/value
                cmd.Parameters.AddWithValue("@description", newRune.Description);
                cmd.Parameters.AddWithValue("@price", newRune.Price);
                cmd.Parameters.AddWithValue("@id", id);

                //No results
                cmd.ExecuteNonQuery();
            };

            return newRune;
        }


    }
}
