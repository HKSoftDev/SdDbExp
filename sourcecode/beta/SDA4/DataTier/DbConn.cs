// Copyright (c) Gywerd. All Rights reserved.
// Copyright (c) Haderslev Kommune. All Rights reserved.
// Licenced under Proprietary License. See License.txt

namespace DataTier;
/// <remarks/>
public class DbConn
{
	#region Methods

	/// <returns>Response to <paramref name="sqlQuery"/> from database as an ArrayList</returns><param name="connectionString" /><param name="sqlQuery" /><exception cref="ArgumentEmptyException" />
	protected static ArrayList DbReturnArrayListString(string connectionString, string sqlQuery)
	{
		if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentEmptyException(nameof(connectionString),nameof(connectionString)+Error.CantBeEmpty);
		if (string.IsNullOrWhiteSpace(sqlQuery)) throw new ArgumentEmptyException(nameof(sqlQuery),nameof(sqlQuery)+Error.CantBeEmpty);

		ArrayList arrayList = new();

		using SqlConnection connection = new(connectionString); connection.Open();
		using var cmd = connection.CreateCommand(); cmd.CommandText=sqlQuery;
		using var reader = cmd.ExecuteReader(); while (reader.Read()) for (int i = 0; i<reader.FieldCount; i++) arrayList.Add(reader.GetValue(i).ToString());

		return arrayList;

	}

	/// <returns>Response to <paramref name="sqlQuery"/> from database as a DataTable</returns><param name="connectionString" /><param name="sqlQuery" /><exception cref="ArgumentEmptyException" />
	protected static DataTable DbReturnDataTable(string connectionString, string sqlQuery)
	{
		if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentEmptyException(nameof(connectionString),nameof(connectionString)+Error.CantBeEmpty);
		if (string.IsNullOrWhiteSpace(sqlQuery)) throw new ArgumentEmptyException(nameof(sqlQuery),nameof(sqlQuery)+Error.CantBeEmpty);

		using SqlConnection connection=new(connectionString); connection.Open(); using SqlCommand command=new(sqlQuery, connection); using SqlDataAdapter adapter=new(command);
		DataTable dataTable=new(); adapter.Fill(dataTable); return dataTable;

	}

	/// <returns>Response to <paramref name="sqlCommand"/> from database as DataTable</returns><param name="sqlCommand" />
	protected static DataTable DbReturnDataTable(SqlCommand sqlCommand) { 
		using (sqlCommand.Connection) { sqlCommand.Connection.Open();  using (sqlCommand) { using SqlDataAdapter adapter=new(sqlCommand); using DataTable dtRes=new(); adapter.Fill(dtRes); return dtRes; } } }

	/// <returns>Response to <paramref name="storedProcedure"/> from database as DataTable</returns><param name="connectionString" /><param name="storedProcedure" />
	/// <param name="args">@InstitutionIdentifier, @OrganizationStructureIdentifier or @OrganizationIdentifier</param><exception cref="ArgumentEmptyException" />
	protected static DataTable DbReturnDataTableFromStoredProcedure(string connectionString,string storedProcedure,string[]? args=null)
	{
		if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentEmptyException(nameof(connectionString),nameof(connectionString)+Error.CantBeEmpty);
		if (string.IsNullOrWhiteSpace(storedProcedure)) throw new ArgumentEmptyException(nameof(storedProcedure),nameof(storedProcedure)+Error.CantBeEmpty);

		DataTable dataTable=new();

		if (args!=null)
		{
			try
			{
				using SqlConnection connection=new(connectionString); connection.Open();
				using SqlCommand command=new(storedProcedure, connection); command.CommandType=CommandType.StoredProcedure;

				switch (storedProcedure.ToLower())
				{
					case "selectget3in1organizations": command.Parameters.AddWithValue("@InstitutionIdentifier", args[0]); break;
					case "selectget3in1organizationstructures": command.Parameters.AddWithValue("@InstitutionIdentifier", args[0]); break;
					case "selectget3in1persons": command.Parameters.AddWithValue("@InstitutionIdentifier", args[0]); break;
					case "selectgetdepartments": command.Parameters.AddWithValue("@InstitutionIdentifier", args[0]); command.Parameters.AddWithValue("@Uuid", args[1]); command.Parameters.AddWithValue("@Active", args[2]); break;
					case "selectgetemployments": command.Parameters.AddWithValue("@InstitutionIdentifier", args[0]); command.Parameters.AddWithValue("@Uuid", args[1]); command.Parameters.AddWithValue("@Active", args[2]); break;
					case "selectgetinstitutions": command.Parameters.AddWithValue("@InstitutionIdentifier", args[0]); break;
					case "selectgetmochpersons": command.Parameters.AddWithValue("@InstitutionIdentifier", args[0]); break;
					case "selectgetorganizations": command.Parameters.AddWithValue("@InstitutionIdentifier", args[0]); command.Parameters.AddWithValue("@Active", args[2]); break;
					case "selectgetorganizationstructures": command.Parameters.AddWithValue("@InstitutionIdentifier", args[0]); break;
					case "selectgetpersons": command.Parameters.AddWithValue("@InstitutionIdentifier", args[0]); break;
					case "selectgetprofessions": command.Parameters.AddWithValue("@InstitutionIdentifier", args[0]); command.Parameters.AddWithValue("@Active", args[2]); break;
					case "selectxmemployments": command.Parameters.AddWithValue("@InstitutionIdentifier", args[0]); break;
				}

				using SqlDataAdapter adapter=new(command); adapter.Fill(dataTable);
			}
			catch (Exception) { throw; }
		}
		else
		{
			try
			{
				using SqlConnection connection = new(connectionString); connection.Open();
				using SqlCommand command = new(storedProcedure, connection); command.CommandType=CommandType.StoredProcedure;
				using SqlDataAdapter adapter = new(command); adapter.Fill(dataTable);
			}
			catch (Exception) { throw; }
		}

		return dataTable;

	}

	/// <returns>Response to <paramref name="sqlQuery"/> from database as List{string}</returns><param name="connectionString" /><param name="sqlQuery" /><exception cref="ArgumentEmptyException" />
	protected static List<string> DbReturnListString(string connectionString, string sqlQuery)
	{
		if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentEmptyException(nameof(connectionString),nameof(connectionString)+Error.CantBeEmpty);
		if (string.IsNullOrWhiteSpace(sqlQuery)) throw new ArgumentEmptyException(nameof(sqlQuery),nameof(sqlQuery)+Error.CantBeEmpty);

		List<string> listString = new();

		using SqlConnection connection = new(connectionString); connection.Open();
		using SqlCommand cmd = connection.CreateCommand(); cmd.CommandText=sqlQuery;
		using var reader = cmd.ExecuteReader(); while (reader.Read()) for (int i = 0; i<reader.FieldCount; i++) listString.Add((string)reader.GetValue(i)??"null");

		return listString;
	}

	/// <returns>Response to <paramref name="sqlQuery"/> as bool</returns><param name="connectionString" /><param name="sqlQuery" /><exception cref="ArgumentEmptyException" />
	protected static bool DbReturnBool(string connectionString, string sqlQuery)
	{
		if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentEmptyException(nameof(connectionString),nameof(connectionString)+Error.CantBeEmpty);
		if (string.IsNullOrWhiteSpace(sqlQuery)) throw new ArgumentEmptyException(nameof(sqlQuery),nameof(sqlQuery)+Error.CantBeEmpty);

		using SqlConnection connection = new(connectionString);connection.Open();
		using SqlCommand qlCommand = new(sqlQuery, connection); using SqlDataReader reader = qlCommand.ExecuteReader();
		bool result=false; while (reader.Read()) result=Convert.ToBoolean(reader.GetValue(0).ToString()); return result;

	}

	/// <returns>Response to <paramref name="sqlQuery"/> from database as bool</returns><param name="connectionString" /><param name="sqlQuery" /><param name="args" /><exception cref="ArgumentEmptyException" />
	protected static bool DbReturnBool(string connectionString, string sqlQuery, string[] args)
	{
		if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentEmptyException(nameof(connectionString),nameof(connectionString)+Error.CantBeEmpty);
		if (string.IsNullOrWhiteSpace(sqlQuery)) throw new ArgumentEmptyException(nameof(sqlQuery),nameof(sqlQuery)+Error.CantBeNullWhSp);

		bool result = false;

		if (args!=null)
		{
			using SqlConnection connection = new(connectionString);
			using SqlCommand sqlCommand = new(sqlQuery, connection); sqlCommand.CommandType=CommandType.StoredProcedure;

			switch (sqlQuery.ToLower())
			{
				case "usersadduser": sqlCommand.Parameters.Add("@pPerson", SqlDbType.Int).Value=Convert.ToInt32(args[0]); sqlCommand.Parameters.Add("@pInitials", SqlDbType.NVarChar).Value=args[1];
					sqlCommand.Parameters.Add("@pPassword", SqlDbType.NVarChar).Value=args[2]; sqlCommand.Parameters.Add("@pJobDescription", SqlDbType.Int).Value=Convert.ToInt32(args[3]);
					sqlCommand.Parameters.Add("@pUserLevel", SqlDbType.Int).Value=Convert.ToInt32(args[4]); break;
				case "usersupdatepassword": sqlCommand.Parameters.Add("@pId", SqlDbType.Int).Value=Convert.ToInt32(args[0]); sqlCommand.Parameters.Add("@pOldPassword", SqlDbType.NVarChar).Value=args[1];
					sqlCommand.Parameters.Add("@pNewPassword", SqlDbType.NVarChar).Value=args[2]; break;
				case "userslogin": sqlCommand.Parameters.Add("@pInitials", SqlDbType.NVarChar).Value=args[0]; sqlCommand.Parameters.Add("@pPassword", SqlDbType.NVarChar).Value=args[1]; break;
			}

			connection.Open();

			using DataTable dataTable = DbReturnDataTable(sqlCommand);

			if (dataTable.Rows.Count>0) foreach (DataRow row in dataTable.Rows) { result=Convert.ToBoolean(row[0].ToString()); break; }

		}

		return result;

	}

	/// <summary>Sends an <paramref name="sqlQuery"/> to database</summary><param name="connectionString" /><param name="sqlQuery" /><returns>Result as bool</returns><exception cref="ArgumentEmptyException" />
	protected static bool FunctionExecuteNonQuery(string connectionString, string sqlQuery)
	{
		if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentEmptyException(nameof(connectionString),nameof(connectionString)+Error.CantBeEmpty);
		if (string.IsNullOrWhiteSpace(sqlQuery)) throw new ArgumentEmptyException(nameof(sqlQuery),nameof(sqlQuery)+Error.CantBeEmpty);

		using SqlConnection connection = new(connectionString); connection.Open();
		using SqlCommand sqlCommand = new(sqlQuery, connection) { CommandTimeout=60 }; sqlCommand.ExecuteNonQuery();
		return true;

	}

	#endregion

}
