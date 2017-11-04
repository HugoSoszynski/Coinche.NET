// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: CoincheClient.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace CoincheClient {

  /// <summary>Holder for reflection information generated from CoincheClient.proto</summary>
  public static partial class CoincheClientReflection {

    #region Descriptor
    /// <summary>File descriptor for CoincheClient.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CoincheClientReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChNDb2luY2hlQ2xpZW50LnByb3RvEg1Db2luY2hlQ2xpZW50IkMKEEF1dGhl",
            "bnRpZmljYXRpb24SDAoEbmFtZRgBIAEoCRIhCgR0ZWFtGAIgASgOMhMuQ29p",
            "bmNoZUNsaWVudC5UZWFtIhMKBENoYXQSCwoDbXNnGAEgASgJIoEBCgZDTG9i",
            "YnkSJgoDY21kGAEgASgOMhkuQ29pbmNoZUNsaWVudC5DTG9iYnkuQ21kEg0K",
            "BXZhbHVlGAIgASgJEiEKBHRlYW0YAyABKA4yEy5Db2luY2hlQ2xpZW50LlRl",
            "YW0iHQoDQ21kEggKBFRFQU0QABIMCghVU0VSTkFNRRABImsKB0NTZXJ2ZXIS",
            "JwoDY21kGAEgASgOMhouQ29pbmNoZUNsaWVudC5DU2VydmVyLkNtZBINCgV2",
            "YWx1ZRgCIAEoCSIoCgNDbWQSCwoHTElTVElORxAAEggKBEpPSU4QARIKCgZD",
            "UkVBVEUQAiJmCgVDR2FtZRIlCgNjbWQYASABKA4yGC5Db2luY2hlQ2xpZW50",
            "LkNHYW1lLkNtZBINCgV2YWx1ZRgCIAEoCSInCgNDbWQSCAoEQ0FSRBAAEgwK",
            "CENPTlRSQUNUEAESCAoESEFORBACIqsCCg9HZW5lcmFsaXN0UHJvdG8SJgoE",
            "dHlwZRgBIAEoDjIYLkNvaW5jaGVDbGllbnQuQ21kVGFyZ2V0Ei8KBGF1dGgY",
            "AiABKAsyHy5Db2luY2hlQ2xpZW50LkF1dGhlbnRpZmljYXRpb25IABIjCgRj",
            "aGF0GAMgASgLMhMuQ29pbmNoZUNsaWVudC5DaGF0SAASKQoIbG9iYnljbWQY",
            "BCABKAsyFS5Db2luY2hlQ2xpZW50LkNMb2JieUgAEisKCXNlcnZlcmNtZBgF",
            "IAEoCzIWLkNvaW5jaGVDbGllbnQuQ1NlcnZlckgAEicKB2dhbWVjbWQYBiAB",
            "KAsyFC5Db2luY2hlQ2xpZW50LkNHYW1lSAASEQoJdGltZXN0YW1wGAcgASgJ",
            "QgYKBGJvZHkqMQoEVGVhbRIICgRCTFVFEAASBwoDUkVEEAESDAoIU1BFQ1RB",
            "VEUQAhIICgROT05FEAMqVQoJQ21kVGFyZ2V0EhQKEEFVVEhFTlRJRklDQVRJ",
            "T04QABIICgRDSEFUEAESDAoITE9CQllDTUQQAhILCgdHQU1FQ01EEAMSDQoJ",
            "U0VSVkVSQ01EEARiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::CoincheClient.Team), typeof(global::CoincheClient.CmdTarget), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CoincheClient.Authentification), global::CoincheClient.Authentification.Parser, new[]{ "Name", "Team" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CoincheClient.Chat), global::CoincheClient.Chat.Parser, new[]{ "Msg" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CoincheClient.CLobby), global::CoincheClient.CLobby.Parser, new[]{ "Cmd", "Value", "Team" }, null, new[]{ typeof(global::CoincheClient.CLobby.Types.Cmd) }, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CoincheClient.CServer), global::CoincheClient.CServer.Parser, new[]{ "Cmd", "Value" }, null, new[]{ typeof(global::CoincheClient.CServer.Types.Cmd) }, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CoincheClient.CGame), global::CoincheClient.CGame.Parser, new[]{ "Cmd", "Value" }, null, new[]{ typeof(global::CoincheClient.CGame.Types.Cmd) }, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CoincheClient.GeneralistProto), global::CoincheClient.GeneralistProto.Parser, new[]{ "Type", "Auth", "Chat", "Lobbycmd", "Servercmd", "Gamecmd", "Timestamp" }, new[]{ "Body" }, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum Team {
    [pbr::OriginalName("BLUE")] Blue = 0,
    [pbr::OriginalName("RED")] Red = 1,
    [pbr::OriginalName("SPECTATE")] Spectate = 2,
    [pbr::OriginalName("NONE")] None = 3,
  }

  public enum CmdTarget {
    [pbr::OriginalName("AUTHENTIFICATION")] Authentification = 0,
    [pbr::OriginalName("CHAT")] Chat = 1,
    [pbr::OriginalName("LOBBYCMD")] Lobbycmd = 2,
    [pbr::OriginalName("GAMECMD")] Gamecmd = 3,
    [pbr::OriginalName("SERVERCMD")] Servercmd = 4,
  }

  #endregion

  #region Messages
  public sealed partial class Authentification : pb::IMessage<Authentification> {
    private static readonly pb::MessageParser<Authentification> _parser = new pb::MessageParser<Authentification>(() => new Authentification());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Authentification> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CoincheClient.CoincheClientReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Authentification() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Authentification(Authentification other) : this() {
      name_ = other.name_;
      team_ = other.team_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Authentification Clone() {
      return new Authentification(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "team" field.</summary>
    public const int TeamFieldNumber = 2;
    private global::CoincheClient.Team team_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CoincheClient.Team Team {
      get { return team_; }
      set {
        team_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Authentification);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Authentification other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (Team != other.Team) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Team != 0) hash ^= Team.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (Team != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Team);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Team != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Team);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Authentification other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Team != 0) {
        Team = other.Team;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 16: {
            team_ = (global::CoincheClient.Team) input.ReadEnum();
            break;
          }
        }
      }
    }

  }

  public sealed partial class Chat : pb::IMessage<Chat> {
    private static readonly pb::MessageParser<Chat> _parser = new pb::MessageParser<Chat>(() => new Chat());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Chat> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CoincheClient.CoincheClientReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Chat() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Chat(Chat other) : this() {
      msg_ = other.msg_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Chat Clone() {
      return new Chat(this);
    }

    /// <summary>Field number for the "msg" field.</summary>
    public const int MsgFieldNumber = 1;
    private string msg_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Msg {
      get { return msg_; }
      set {
        msg_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Chat);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Chat other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Msg != other.Msg) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Msg.Length != 0) hash ^= Msg.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Msg.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Msg);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Msg.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Msg);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Chat other) {
      if (other == null) {
        return;
      }
      if (other.Msg.Length != 0) {
        Msg = other.Msg;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Msg = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class CLobby : pb::IMessage<CLobby> {
    private static readonly pb::MessageParser<CLobby> _parser = new pb::MessageParser<CLobby>(() => new CLobby());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CLobby> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CoincheClient.CoincheClientReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CLobby() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CLobby(CLobby other) : this() {
      cmd_ = other.cmd_;
      value_ = other.value_;
      team_ = other.team_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CLobby Clone() {
      return new CLobby(this);
    }

    /// <summary>Field number for the "cmd" field.</summary>
    public const int CmdFieldNumber = 1;
    private global::CoincheClient.CLobby.Types.Cmd cmd_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CoincheClient.CLobby.Types.Cmd Cmd {
      get { return cmd_; }
      set {
        cmd_ = value;
      }
    }

    /// <summary>Field number for the "value" field.</summary>
    public const int ValueFieldNumber = 2;
    private string value_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Value {
      get { return value_; }
      set {
        value_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "team" field.</summary>
    public const int TeamFieldNumber = 3;
    private global::CoincheClient.Team team_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CoincheClient.Team Team {
      get { return team_; }
      set {
        team_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CLobby);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CLobby other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Cmd != other.Cmd) return false;
      if (Value != other.Value) return false;
      if (Team != other.Team) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Cmd != 0) hash ^= Cmd.GetHashCode();
      if (Value.Length != 0) hash ^= Value.GetHashCode();
      if (Team != 0) hash ^= Team.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Cmd != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Cmd);
      }
      if (Value.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Value);
      }
      if (Team != 0) {
        output.WriteRawTag(24);
        output.WriteEnum((int) Team);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Cmd != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Cmd);
      }
      if (Value.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Value);
      }
      if (Team != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Team);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CLobby other) {
      if (other == null) {
        return;
      }
      if (other.Cmd != 0) {
        Cmd = other.Cmd;
      }
      if (other.Value.Length != 0) {
        Value = other.Value;
      }
      if (other.Team != 0) {
        Team = other.Team;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            cmd_ = (global::CoincheClient.CLobby.Types.Cmd) input.ReadEnum();
            break;
          }
          case 18: {
            Value = input.ReadString();
            break;
          }
          case 24: {
            team_ = (global::CoincheClient.Team) input.ReadEnum();
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the CLobby message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public enum Cmd {
        [pbr::OriginalName("TEAM")] Team = 0,
        [pbr::OriginalName("USERNAME")] Username = 1,
      }

    }
    #endregion

  }

  public sealed partial class CServer : pb::IMessage<CServer> {
    private static readonly pb::MessageParser<CServer> _parser = new pb::MessageParser<CServer>(() => new CServer());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CServer> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CoincheClient.CoincheClientReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CServer() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CServer(CServer other) : this() {
      cmd_ = other.cmd_;
      value_ = other.value_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CServer Clone() {
      return new CServer(this);
    }

    /// <summary>Field number for the "cmd" field.</summary>
    public const int CmdFieldNumber = 1;
    private global::CoincheClient.CServer.Types.Cmd cmd_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CoincheClient.CServer.Types.Cmd Cmd {
      get { return cmd_; }
      set {
        cmd_ = value;
      }
    }

    /// <summary>Field number for the "value" field.</summary>
    public const int ValueFieldNumber = 2;
    private string value_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Value {
      get { return value_; }
      set {
        value_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CServer);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CServer other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Cmd != other.Cmd) return false;
      if (Value != other.Value) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Cmd != 0) hash ^= Cmd.GetHashCode();
      if (Value.Length != 0) hash ^= Value.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Cmd != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Cmd);
      }
      if (Value.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Value);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Cmd != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Cmd);
      }
      if (Value.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Value);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CServer other) {
      if (other == null) {
        return;
      }
      if (other.Cmd != 0) {
        Cmd = other.Cmd;
      }
      if (other.Value.Length != 0) {
        Value = other.Value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            cmd_ = (global::CoincheClient.CServer.Types.Cmd) input.ReadEnum();
            break;
          }
          case 18: {
            Value = input.ReadString();
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the CServer message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public enum Cmd {
        [pbr::OriginalName("LISTING")] Listing = 0,
        [pbr::OriginalName("JOIN")] Join = 1,
        [pbr::OriginalName("CREATE")] Create = 2,
      }

    }
    #endregion

  }

  public sealed partial class CGame : pb::IMessage<CGame> {
    private static readonly pb::MessageParser<CGame> _parser = new pb::MessageParser<CGame>(() => new CGame());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CGame> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CoincheClient.CoincheClientReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CGame() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CGame(CGame other) : this() {
      cmd_ = other.cmd_;
      value_ = other.value_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CGame Clone() {
      return new CGame(this);
    }

    /// <summary>Field number for the "cmd" field.</summary>
    public const int CmdFieldNumber = 1;
    private global::CoincheClient.CGame.Types.Cmd cmd_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CoincheClient.CGame.Types.Cmd Cmd {
      get { return cmd_; }
      set {
        cmd_ = value;
      }
    }

    /// <summary>Field number for the "value" field.</summary>
    public const int ValueFieldNumber = 2;
    private string value_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Value {
      get { return value_; }
      set {
        value_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CGame);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CGame other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Cmd != other.Cmd) return false;
      if (Value != other.Value) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Cmd != 0) hash ^= Cmd.GetHashCode();
      if (Value.Length != 0) hash ^= Value.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Cmd != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Cmd);
      }
      if (Value.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Value);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Cmd != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Cmd);
      }
      if (Value.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Value);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CGame other) {
      if (other == null) {
        return;
      }
      if (other.Cmd != 0) {
        Cmd = other.Cmd;
      }
      if (other.Value.Length != 0) {
        Value = other.Value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            cmd_ = (global::CoincheClient.CGame.Types.Cmd) input.ReadEnum();
            break;
          }
          case 18: {
            Value = input.ReadString();
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the CGame message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public enum Cmd {
        [pbr::OriginalName("CARD")] Card = 0,
        [pbr::OriginalName("CONTRACT")] Contract = 1,
        [pbr::OriginalName("HAND")] Hand = 2,
      }

    }
    #endregion

  }

  public sealed partial class GeneralistProto : pb::IMessage<GeneralistProto> {
    private static readonly pb::MessageParser<GeneralistProto> _parser = new pb::MessageParser<GeneralistProto>(() => new GeneralistProto());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GeneralistProto> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CoincheClient.CoincheClientReflection.Descriptor.MessageTypes[5]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GeneralistProto() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GeneralistProto(GeneralistProto other) : this() {
      type_ = other.type_;
      timestamp_ = other.timestamp_;
      switch (other.BodyCase) {
        case BodyOneofCase.Auth:
          Auth = other.Auth.Clone();
          break;
        case BodyOneofCase.Chat:
          Chat = other.Chat.Clone();
          break;
        case BodyOneofCase.Lobbycmd:
          Lobbycmd = other.Lobbycmd.Clone();
          break;
        case BodyOneofCase.Servercmd:
          Servercmd = other.Servercmd.Clone();
          break;
        case BodyOneofCase.Gamecmd:
          Gamecmd = other.Gamecmd.Clone();
          break;
      }

    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GeneralistProto Clone() {
      return new GeneralistProto(this);
    }

    /// <summary>Field number for the "type" field.</summary>
    public const int TypeFieldNumber = 1;
    private global::CoincheClient.CmdTarget type_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CoincheClient.CmdTarget Type {
      get { return type_; }
      set {
        type_ = value;
      }
    }

    /// <summary>Field number for the "auth" field.</summary>
    public const int AuthFieldNumber = 2;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CoincheClient.Authentification Auth {
      get { return bodyCase_ == BodyOneofCase.Auth ? (global::CoincheClient.Authentification) body_ : null; }
      set {
        body_ = value;
        bodyCase_ = value == null ? BodyOneofCase.None : BodyOneofCase.Auth;
      }
    }

    /// <summary>Field number for the "chat" field.</summary>
    public const int ChatFieldNumber = 3;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CoincheClient.Chat Chat {
      get { return bodyCase_ == BodyOneofCase.Chat ? (global::CoincheClient.Chat) body_ : null; }
      set {
        body_ = value;
        bodyCase_ = value == null ? BodyOneofCase.None : BodyOneofCase.Chat;
      }
    }

    /// <summary>Field number for the "lobbycmd" field.</summary>
    public const int LobbycmdFieldNumber = 4;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CoincheClient.CLobby Lobbycmd {
      get { return bodyCase_ == BodyOneofCase.Lobbycmd ? (global::CoincheClient.CLobby) body_ : null; }
      set {
        body_ = value;
        bodyCase_ = value == null ? BodyOneofCase.None : BodyOneofCase.Lobbycmd;
      }
    }

    /// <summary>Field number for the "servercmd" field.</summary>
    public const int ServercmdFieldNumber = 5;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CoincheClient.CServer Servercmd {
      get { return bodyCase_ == BodyOneofCase.Servercmd ? (global::CoincheClient.CServer) body_ : null; }
      set {
        body_ = value;
        bodyCase_ = value == null ? BodyOneofCase.None : BodyOneofCase.Servercmd;
      }
    }

    /// <summary>Field number for the "gamecmd" field.</summary>
    public const int GamecmdFieldNumber = 6;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CoincheClient.CGame Gamecmd {
      get { return bodyCase_ == BodyOneofCase.Gamecmd ? (global::CoincheClient.CGame) body_ : null; }
      set {
        body_ = value;
        bodyCase_ = value == null ? BodyOneofCase.None : BodyOneofCase.Gamecmd;
      }
    }

    /// <summary>Field number for the "timestamp" field.</summary>
    public const int TimestampFieldNumber = 7;
    private string timestamp_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Timestamp {
      get { return timestamp_; }
      set {
        timestamp_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    private object body_;
    /// <summary>Enum of possible cases for the "body" oneof.</summary>
    public enum BodyOneofCase {
      None = 0,
      Auth = 2,
      Chat = 3,
      Lobbycmd = 4,
      Servercmd = 5,
      Gamecmd = 6,
    }
    private BodyOneofCase bodyCase_ = BodyOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BodyOneofCase BodyCase {
      get { return bodyCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearBody() {
      bodyCase_ = BodyOneofCase.None;
      body_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GeneralistProto);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GeneralistProto other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Type != other.Type) return false;
      if (!object.Equals(Auth, other.Auth)) return false;
      if (!object.Equals(Chat, other.Chat)) return false;
      if (!object.Equals(Lobbycmd, other.Lobbycmd)) return false;
      if (!object.Equals(Servercmd, other.Servercmd)) return false;
      if (!object.Equals(Gamecmd, other.Gamecmd)) return false;
      if (Timestamp != other.Timestamp) return false;
      if (BodyCase != other.BodyCase) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Type != 0) hash ^= Type.GetHashCode();
      if (bodyCase_ == BodyOneofCase.Auth) hash ^= Auth.GetHashCode();
      if (bodyCase_ == BodyOneofCase.Chat) hash ^= Chat.GetHashCode();
      if (bodyCase_ == BodyOneofCase.Lobbycmd) hash ^= Lobbycmd.GetHashCode();
      if (bodyCase_ == BodyOneofCase.Servercmd) hash ^= Servercmd.GetHashCode();
      if (bodyCase_ == BodyOneofCase.Gamecmd) hash ^= Gamecmd.GetHashCode();
      if (Timestamp.Length != 0) hash ^= Timestamp.GetHashCode();
      hash ^= (int) bodyCase_;
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Type != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Type);
      }
      if (bodyCase_ == BodyOneofCase.Auth) {
        output.WriteRawTag(18);
        output.WriteMessage(Auth);
      }
      if (bodyCase_ == BodyOneofCase.Chat) {
        output.WriteRawTag(26);
        output.WriteMessage(Chat);
      }
      if (bodyCase_ == BodyOneofCase.Lobbycmd) {
        output.WriteRawTag(34);
        output.WriteMessage(Lobbycmd);
      }
      if (bodyCase_ == BodyOneofCase.Servercmd) {
        output.WriteRawTag(42);
        output.WriteMessage(Servercmd);
      }
      if (bodyCase_ == BodyOneofCase.Gamecmd) {
        output.WriteRawTag(50);
        output.WriteMessage(Gamecmd);
      }
      if (Timestamp.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Timestamp);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Type != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Type);
      }
      if (bodyCase_ == BodyOneofCase.Auth) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Auth);
      }
      if (bodyCase_ == BodyOneofCase.Chat) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Chat);
      }
      if (bodyCase_ == BodyOneofCase.Lobbycmd) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Lobbycmd);
      }
      if (bodyCase_ == BodyOneofCase.Servercmd) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Servercmd);
      }
      if (bodyCase_ == BodyOneofCase.Gamecmd) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Gamecmd);
      }
      if (Timestamp.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Timestamp);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GeneralistProto other) {
      if (other == null) {
        return;
      }
      if (other.Type != 0) {
        Type = other.Type;
      }
      if (other.Timestamp.Length != 0) {
        Timestamp = other.Timestamp;
      }
      switch (other.BodyCase) {
        case BodyOneofCase.Auth:
          Auth = other.Auth;
          break;
        case BodyOneofCase.Chat:
          Chat = other.Chat;
          break;
        case BodyOneofCase.Lobbycmd:
          Lobbycmd = other.Lobbycmd;
          break;
        case BodyOneofCase.Servercmd:
          Servercmd = other.Servercmd;
          break;
        case BodyOneofCase.Gamecmd:
          Gamecmd = other.Gamecmd;
          break;
      }

    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            type_ = (global::CoincheClient.CmdTarget) input.ReadEnum();
            break;
          }
          case 18: {
            global::CoincheClient.Authentification subBuilder = new global::CoincheClient.Authentification();
            if (bodyCase_ == BodyOneofCase.Auth) {
              subBuilder.MergeFrom(Auth);
            }
            input.ReadMessage(subBuilder);
            Auth = subBuilder;
            break;
          }
          case 26: {
            global::CoincheClient.Chat subBuilder = new global::CoincheClient.Chat();
            if (bodyCase_ == BodyOneofCase.Chat) {
              subBuilder.MergeFrom(Chat);
            }
            input.ReadMessage(subBuilder);
            Chat = subBuilder;
            break;
          }
          case 34: {
            global::CoincheClient.CLobby subBuilder = new global::CoincheClient.CLobby();
            if (bodyCase_ == BodyOneofCase.Lobbycmd) {
              subBuilder.MergeFrom(Lobbycmd);
            }
            input.ReadMessage(subBuilder);
            Lobbycmd = subBuilder;
            break;
          }
          case 42: {
            global::CoincheClient.CServer subBuilder = new global::CoincheClient.CServer();
            if (bodyCase_ == BodyOneofCase.Servercmd) {
              subBuilder.MergeFrom(Servercmd);
            }
            input.ReadMessage(subBuilder);
            Servercmd = subBuilder;
            break;
          }
          case 50: {
            global::CoincheClient.CGame subBuilder = new global::CoincheClient.CGame();
            if (bodyCase_ == BodyOneofCase.Gamecmd) {
              subBuilder.MergeFrom(Gamecmd);
            }
            input.ReadMessage(subBuilder);
            Gamecmd = subBuilder;
            break;
          }
          case 58: {
            Timestamp = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
