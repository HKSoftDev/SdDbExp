// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DateRange.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public class DateRange
{
  #region Constructors

  /// <summary>Initializes an empty instance of DateRange</summary>
  public DateRange() { }

  /// <summary>Initializes a new instance of DateRange</summary><param name="from" /><param name="to" />
  public DateRange(string from,string to) { this.From=from; this.To=to; }

  #endregion

  #region Properties

  /// <remarks />
  public string From { get; set; } = "2010-01-01";

  /// <remarks />
  public string To { get; set; } = "9999-12-31";

  #endregion

  #region Methods
  /// <summary>Compares this DateRange to <paramref name="range"/></summary><param name="range" /><returns>Result as bool</returns>
  public bool Equals(DateRange range) { if (this==null) throw new NullReferenceException(); if(!IsEmpty()&&range.IsEmpty()) return false; if(IsEmpty()&&!range.IsEmpty()) return false;
    if(!IsEmpty()&&!range.IsEmpty()) if (!IsEmpty()&&!range.IsEmpty()&&!this.From.Equals(range.From)) return false;  if (!IsEmpty()&&!range.IsEmpty()&&!this.To.Equals(range.To))
      return false; return true; }

  /// <returns>Result as bool</returns>
  public bool IsEmpty() { if (this==null) throw new NullReferenceException(); if (!this.From.Equals("2010-01-01")) return false; if (this.To.Equals("9999-12-31")) return false; return true; }

  #endregion
}

