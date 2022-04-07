// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Envelope.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[Serializable]
public class Envelope
{
  #region Constructors
  /// <summary>Initializes an empty instance of Envelope</summary>
  public Envelope() { }

  /// <summary>Initializes a new instance of Envelope</summary><param name="body" />
  public Envelope(Body body) { this.Body=body; }

  /// <summary>Initializes a new instance of Envelope accepting data from existing Envelope</summary><param name="envelope" />
  public Envelope(Envelope envelope) { this.Body=envelope.Body; }

  #endregion

  #region Properties
  /// <remarks/>
  public Body Body { get; set; } = new();

  #endregion

}
