// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewActiveWithOutMail.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

 /// <remarks />
 public partial class ViewActiveWithoutMail
 {
   /// <remarks />
   public string Tjenestenr { get; set; } = null!;

   /// <remarks />
   public string Cpr { get; set; } = null!;

   /// <remarks />
   public string Fornavn { get; set; } = null!;

   /// <remarks />
   public string Efternavn { get; set; } = null!;

   /// <remarks />
   public string Mail1 { get; set; } = null!;

   /// <remarks />
   public string Mail2 { get; set; } = null!;

}
