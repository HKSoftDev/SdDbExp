// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Garbage.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

///<remarks />
public class Garbage { 

	///<remarks />
	public static void Collect() { GC.Collect(); GC.WaitForPendingFinalizers(); }

}
