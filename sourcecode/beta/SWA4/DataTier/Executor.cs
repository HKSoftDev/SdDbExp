// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Executor.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace DataTier;

/// <remarks/>
public class Executor : DbConn
{
	#region Methods

	/// <returns>List from <paramref name="databaseTable"/> as a DataTable</returns><param name="connectionString" /><param name="databaseTable" /><param name="id">-1 selects all entries</param><exception cref="ArgumentEmptyException" />
	private static DataTable GetListDataTable(string connectionString, string databaseTable, int id=-1) {
		if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentEmptyException(nameof(connectionString),nameof(connectionString)+Error.CantBeEmpty);
		if (string.IsNullOrWhiteSpace(databaseTable)) throw new ArgumentEmptyException(nameof(databaseTable),nameof(databaseTable)+Error.CantBeEmpty);
		if (id>=0) return DbReturnDataTable(connectionString,@"SELECT * FROM ["+databaseTable+"] WHERE [Id]="+id);
		else return DbReturnDataTable(connectionString,"SELECT * FROM ["+databaseTable+"]"); }

	#region Read

	/// <returns>List{strings} from <paramref name="databaseTable"/> in database</returns><param name="connectionString" /><param name="databaseTable" /><param name="id" /><exception cref="ArgumentEmptyException" />
	public static List<string> ReadListFromDataBase(string connectionString, string databaseTable, int id=-1) {
		if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentEmptyException(nameof(connectionString),nameof(connectionString)+Error.CantBeEmpty);
		if (string.IsNullOrWhiteSpace(databaseTable)) throw new ArgumentEmptyException(nameof(databaseTable),nameof(databaseTable)+Error.CantBeEmpty);
		List<string> listRes=new(); using DataTable dm = GetListDataTable(connectionString,databaseTable,id); foreach (DataRow row in dm.Rows) { string rowString=string.Empty; 
			for (int i = 0; i<row.Table.Columns.Count; i++) rowString+=row[i]+";"; rowString=rowString.Remove(rowString.Length-1); listRes.Add(rowString); } return listRes; }

	/// <returns>List{strings} from <paramref name="storedProcedure"/> in database</returns><param name="connectionString" /><param name="storedProcedure" />
	/// <param name="args">e.g. @InstitutionIdentifier, @OrganizationStructureIdentifier or @OrganizationIdentifier</param><exception cref="ArgumentEmptyException" />
	public static List<string> ReadListFromDataBaseFromStoredProcedure(string connectionString, string storedProcedure, string[]? args=null) {
		if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentEmptyException(nameof(connectionString),nameof(connectionString)+Error.CantBeEmpty);
		if (string.IsNullOrWhiteSpace(storedProcedure)) throw new ArgumentEmptyException(nameof(storedProcedure),nameof(storedProcedure)+Error.CantBeEmpty);
		List<string> listRes=new(); using DataTable dm = DbReturnDataTableFromStoredProcedure(connectionString,storedProcedure,args); foreach (DataRow row in dm.Rows) { string rowString = string.Empty;
			for (int i = 0; i<row.Table.Columns.Count; i++) rowString+=row[i]+";"; rowString=rowString.Remove(rowString.Length-1); listRes.Add(rowString); } return listRes; }

	#endregion

	/// <summary>Sends <paramref name="sqlQuery"/> to database</summary><param name="connectionString" /><param name="sqlQuery" /><returns>Result as bool</returns><exception cref="ArgumentEmptyException" />
	public static bool WriteToDataBase(string connectionString, string sqlQuery) {
		if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentEmptyException(nameof(connectionString),nameof(connectionString)+Error.CantBeEmpty);
		if (string.IsNullOrWhiteSpace(sqlQuery)) throw new ArgumentEmptyException(nameof(sqlQuery),nameof(sqlQuery)+Error.CantBeEmpty);
		return FunctionExecuteNonQuery(connectionString, sqlQuery); }

	#endregion

}
