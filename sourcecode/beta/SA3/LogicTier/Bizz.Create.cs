// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Check.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

///<remarks />
public partial class Bizz // Create
{
	#region Methods

	/// <summary>Creates Config.Uri for 3IN1 API</summary>
	public void Create3in1ApiUri() { this.Config.Uri=@"http://10.112.166.69:11000/"+this.Config.Api+"?User=3IN1&Silo="+Config.Silo+"&UUID="+"&Format="+this.Config.Format;
		if (this.Config.Uri.Length >= 1) this.Config.UriContainsData=true; else this.Config.UriContainsData=false; }

	/// <summary>Creates Config.Uri for API</summary>
	public void CreateApiUri() { this.Config.Uri=@"http://10.112.166.69:11000"+this.Config.Api+"?User="+Config.UserName+"&Silo="+this.Config.Silo+"&UUID="+this.Config.Uuid+"&Format="+this.Config.Format;
		if (this.Config.Uri.Length >= 1) this.Config.UriContainsData=true; else this.Config.UriContainsData=false; }

	/// <summary>Creates Config.Uri for MOCH API</summary>
	public void CreateMochApiUri() { this.Config.Uri=@"http://10.112.166.69:11000:11000/MOCH?User=MOCH&Silo="+this.Config.Silo+"&UUID="+"&Format="+this.Config.Format;
		if (this.Config.Uri.Length >= 1) this.Config.UriContainsData=true; else this.Config.UriContainsData=false; }

	#endregion

}
