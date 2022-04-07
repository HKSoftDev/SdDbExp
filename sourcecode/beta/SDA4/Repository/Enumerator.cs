// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Enumerator.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
using System.CodeDom.Compiler;

namespace Repository;

/// <remarks/>
public struct Enumerator
{
	#region Fields
	/// <remarks/>
	public enum PeriodCode {

		/// <remarks/>
		day, 

		/// <remarks/>
		week, 

		/// <remarks/>
		fortnight,

		/// <remarks/>
		halfmonth,

		/// <remarks/>
		month,

		/// <remarks/>
		year }

	/// <remarks />
	public enum ExitCode : int { 

		/// <remarks/>
		Success = 0,

		/// <remarks/>
		NoSuccessfulRun = 1,

		/// <remarks/>
		NotAllDataRetrieved = 2,

		/// <remarks/>
		NotAllDataDeserialized = 4,

		/// <remarks/>
		NotAllDataCleaned = 8,

		/// <remarks/>
		NotAllDatabaseUpdated = 16,

		/// <remarks/>
		InvalidDataException = 32,

		/// <remarks/>
		InvalidOption = 64,

		/// <remarks/>
		UnhandledError = 128 }

	#endregion

}
