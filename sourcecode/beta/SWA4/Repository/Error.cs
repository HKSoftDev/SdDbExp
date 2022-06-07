// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Error.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <Summary>Common Error messages</Summary>
public static class Error
{
	#region Properties

	#region C

	/// <remarks />
	public const string CantBeEmpty = @" cannot be empty.";

	/// <remarks />
	public const string CantBeNeg = @" cannot be negative.";

	/// <remarks />
	public const string CantBeNull = @" cannot be NULL.";

	/// <remarks />
	public const string CantBeNullEmpty = @" cannot be NULL or empty.";

	/// <remarks />
	public const string CantBeNullWhSp = @" cannot be null, empty, or consists only of whitespace characters.";

	/// <remarks />
	public const string CantBeWhSp = @" cannot consist only of whitespace characters.";

	/// <remarks />
	public const string CantContWhSp = @" cannot contain whitespace characters.";

	#endregion

	/// <remarks />
	public const string DbNonExist = @"The requested entity was not found in the Database.";

	#region E

	/// <remarks />
	public const string ErrReadingFile = @"- Error while reading file from disc:\r\n";

	/// <remarks />
	public const string ErrReadFileCont = @"- Error while reading content of\r\n";

	/// <remarks />
	public const string ErrWriteFile = @"- Error while writing file to disc:\r\n";

	/// <remarks />
	public const string ErrWriteStrLine = @"- Error while adding string line to file:\r\n";

	#endregion

	#region I

	/// <remarks />
	public const string InvBaseAddr = @"Invalid base address.";

	/// <remarks />
	public const string InvBit = @" is not recognized as a valid bit as neither 'true'/'false', nor repesenting an integer within the range [0;1].";

	/// <remarks />
	public const string InvDate = @" is not recognized as a valid day with the format 'yyyy-MM-dd'.";

	/// <remarks />
	public const string InvDay = @" is not recognized as a valid day representing an integer within the range [1;31].";

	/// <remarks />
	public const string InvDelId = @"Cannot delete a non-existing entity from Database. Id must at be at least 1.";

	/// <remarks />
	public const string InvHour = @" is not recognized as a valid hour representing an integer within the range [0;23].";

	/// <remarks />
	public const string InvId = @" is not recognized as a valid identifier.";

	/// <remarks />
	public const string InvInsId = @"Cannot insert an existing entity to Database. Id must be 0.";

	/// <remarks />
	public const string InvInt = @"  is not recognized as a valid integer.";

	/// <remarks />
	public const string InvLogFilePath = @" must contain the application name.";

	/// <remarks />
	public const string InvMin = @" is not recognized as a valid minute representing an integer within the range [0;59].";

	/// <remarks />
	public const string InvMon = @" is not recognized as a valid month representing an integer within the range [1;12].";

	/// <remarks />
	public const string InvRef = @" is not recognized as a valid reference.";

	/// <remarks />
	public const string InvSec = @" is not recognized as a valid second representing an integer within the range [0;59].";

	/// <remarks />
	public const string InvSelId = @"Cannot select a non-existing entity from Database. Id must at be at least 1.";

	/// <remarks />
	public const string InvTime = " is not recognized as a valid time.";

	/// <remarks />
	public const string InvTypeParam = " is not recognised as a valid type parameter.";

	/// <remarks />
	public const string InvUpdId = @"Cannot update a non-existing entity in Database. Id must at be at least 1.";

	/// <remarks />
	public const string InvYear = " is not recognized as a valid second representing an integer within the range [1900;9999].";

	#endregion

	/// <remarks />
	public const string MsgLngExc = "Message length limit exceeded.";

	#region N

	/// <remarks />
	public const string NoConIO = "No Concurrent IO is allowed.";

	/// <remarks />
	public const string NotDeseriz = " could not be deserialized.";

	/// <remarks />
	public const string NotSeriz = " could not be serialized.";

	#endregion

	#region U

	/// <remarks />
	public const string UnkArg = " is not recognised as a valid argument.";

	/// <remarks />
	public const string UnkArgs = " are not recognised as valid arguments.";

	/// <remarks />
	public const string UnkAPI = " is not recognised as a valid API.";

	/// <remarks />
	public const string UnkAPIs = " are not recognised as valid APIs.";

	/// <remarks />
	public const string UnkInst = " are not recognised as valid InstitutionIdentifier.";

	/// <remarks />
	public const string UnkParam = " is not recognized as a valid parameter.";

	/// <remarks />
	public const string UnkParams = " are not recognized as valid parameters.";

	/// <remarks />
	public const string UnkTarget = @" is not recognized as a valid target.";

	/// <remarks />
	public const string UnkTargets = @" are not recognized as valid targets.";

	#endregion

	#endregion

}

