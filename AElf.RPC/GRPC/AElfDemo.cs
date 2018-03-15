// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: AElfDemo.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace AElf.RPC {

  /// <summary>Holder for reflection information generated from AElfDemo.proto</summary>
  public static partial class AElfDemoReflection {

    #region Descriptor
    /// <summary>File descriptor for AElfDemo.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AElfDemoReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5BRWxmRGVtby5wcm90bxIIQUVsZi5SUEMigwEKDEludm9rZU9wdGlvbhIn",
            "CgNyZWcYASABKAsyGi5BRWxmLlJQQy5TbWFydENvbnRyYWN0UmVnEhEKCWNs",
            "YXNzTmFtZRgCIAEoCRISCgptZXRob2ROYW1lGAMgASgJEiMKBnBhcmFtcxgE",
            "IAEoCzITLkFFbGYuUlBDLlBhcmFtTGlzdCI/ChBTbWFydENvbnRyYWN0UmVn",
            "EgwKBGJ5dGUYASABKAwSDwoHY2F0Z29yeRgCIAEoBRIMCgRuYW1lGAMgASgJ",
            "IhUKBlJlc3VsdBILCgNyZXMYASABKAkiLwoJUGFyYW1MaXN0EiIKBXBhcmFt",
            "GAEgAygLMhMuQUVsZi5SUEMuUGFyYW1ldGVyIicKCVBhcmFtZXRlchIMCgR0",
            "eXBlGAEgASgFEgwKBGRhdGEYAiABKAwyfAoHQUVsZlJQQxI0CgZJbnZva2US",
            "Fi5BRWxmLlJQQy5JbnZva2VPcHRpb24aEC5BRWxmLlJQQy5SZXN1bHQiABI7",
            "CgtMaXN0UmVzdWx0cxIWLkFFbGYuUlBDLkludm9rZU9wdGlvbhoQLkFFbGYu",
            "UlBDLlJlc3VsdCIAMAFiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.RPC.InvokeOption), global::AElf.RPC.InvokeOption.Parser, new[]{ "Reg", "ClassName", "MethodName", "Params" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.RPC.SmartContractReg), global::AElf.RPC.SmartContractReg.Parser, new[]{ "Byte", "Catgory", "Name" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.RPC.Result), global::AElf.RPC.Result.Parser, new[]{ "Res" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.RPC.ParamList), global::AElf.RPC.ParamList.Parser, new[]{ "Param" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.RPC.Parameter), global::AElf.RPC.Parameter.Parser, new[]{ "Type", "Data" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class InvokeOption : pb::IMessage<InvokeOption> {
    private static readonly pb::MessageParser<InvokeOption> _parser = new pb::MessageParser<InvokeOption>(() => new InvokeOption());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<InvokeOption> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.RPC.AElfDemoReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InvokeOption() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InvokeOption(InvokeOption other) : this() {
      Reg = other.reg_ != null ? other.Reg.Clone() : null;
      className_ = other.className_;
      methodName_ = other.methodName_;
      Params = other.params_ != null ? other.Params.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InvokeOption Clone() {
      return new InvokeOption(this);
    }

    /// <summary>Field number for the "reg" field.</summary>
    public const int RegFieldNumber = 1;
    private global::AElf.RPC.SmartContractReg reg_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::AElf.RPC.SmartContractReg Reg {
      get { return reg_; }
      set {
        reg_ = value;
      }
    }

    /// <summary>Field number for the "className" field.</summary>
    public const int ClassNameFieldNumber = 2;
    private string className_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ClassName {
      get { return className_; }
      set {
        className_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "methodName" field.</summary>
    public const int MethodNameFieldNumber = 3;
    private string methodName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string MethodName {
      get { return methodName_; }
      set {
        methodName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "params" field.</summary>
    public const int ParamsFieldNumber = 4;
    private global::AElf.RPC.ParamList params_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::AElf.RPC.ParamList Params {
      get { return params_; }
      set {
        params_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as InvokeOption);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(InvokeOption other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Reg, other.Reg)) return false;
      if (ClassName != other.ClassName) return false;
      if (MethodName != other.MethodName) return false;
      if (!object.Equals(Params, other.Params)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (reg_ != null) hash ^= Reg.GetHashCode();
      if (ClassName.Length != 0) hash ^= ClassName.GetHashCode();
      if (MethodName.Length != 0) hash ^= MethodName.GetHashCode();
      if (params_ != null) hash ^= Params.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (reg_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Reg);
      }
      if (ClassName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ClassName);
      }
      if (MethodName.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(MethodName);
      }
      if (params_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(Params);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (reg_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Reg);
      }
      if (ClassName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ClassName);
      }
      if (MethodName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MethodName);
      }
      if (params_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Params);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(InvokeOption other) {
      if (other == null) {
        return;
      }
      if (other.reg_ != null) {
        if (reg_ == null) {
          reg_ = new global::AElf.RPC.SmartContractReg();
        }
        Reg.MergeFrom(other.Reg);
      }
      if (other.ClassName.Length != 0) {
        ClassName = other.ClassName;
      }
      if (other.MethodName.Length != 0) {
        MethodName = other.MethodName;
      }
      if (other.params_ != null) {
        if (params_ == null) {
          params_ = new global::AElf.RPC.ParamList();
        }
        Params.MergeFrom(other.Params);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (reg_ == null) {
              reg_ = new global::AElf.RPC.SmartContractReg();
            }
            input.ReadMessage(reg_);
            break;
          }
          case 18: {
            ClassName = input.ReadString();
            break;
          }
          case 26: {
            MethodName = input.ReadString();
            break;
          }
          case 34: {
            if (params_ == null) {
              params_ = new global::AElf.RPC.ParamList();
            }
            input.ReadMessage(params_);
            break;
          }
        }
      }
    }

  }

  public sealed partial class SmartContractReg : pb::IMessage<SmartContractReg> {
    private static readonly pb::MessageParser<SmartContractReg> _parser = new pb::MessageParser<SmartContractReg>(() => new SmartContractReg());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SmartContractReg> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.RPC.AElfDemoReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SmartContractReg() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SmartContractReg(SmartContractReg other) : this() {
      byte_ = other.byte_;
      catgory_ = other.catgory_;
      name_ = other.name_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SmartContractReg Clone() {
      return new SmartContractReg(this);
    }

    /// <summary>Field number for the "byte" field.</summary>
    public const int ByteFieldNumber = 1;
    private pb::ByteString byte_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Byte {
      get { return byte_; }
      set {
        byte_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "catgory" field.</summary>
    public const int CatgoryFieldNumber = 2;
    private int catgory_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Catgory {
      get { return catgory_; }
      set {
        catgory_ = value;
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 3;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SmartContractReg);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SmartContractReg other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Byte != other.Byte) return false;
      if (Catgory != other.Catgory) return false;
      if (Name != other.Name) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Byte.Length != 0) hash ^= Byte.GetHashCode();
      if (Catgory != 0) hash ^= Catgory.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Byte.Length != 0) {
        output.WriteRawTag(10);
        output.WriteBytes(Byte);
      }
      if (Catgory != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Catgory);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Name);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Byte.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Byte);
      }
      if (Catgory != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Catgory);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SmartContractReg other) {
      if (other == null) {
        return;
      }
      if (other.Byte.Length != 0) {
        Byte = other.Byte;
      }
      if (other.Catgory != 0) {
        Catgory = other.Catgory;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Byte = input.ReadBytes();
            break;
          }
          case 16: {
            Catgory = input.ReadInt32();
            break;
          }
          case 26: {
            Name = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class Result : pb::IMessage<Result> {
    private static readonly pb::MessageParser<Result> _parser = new pb::MessageParser<Result>(() => new Result());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Result> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.RPC.AElfDemoReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Result() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Result(Result other) : this() {
      res_ = other.res_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Result Clone() {
      return new Result(this);
    }

    /// <summary>Field number for the "res" field.</summary>
    public const int ResFieldNumber = 1;
    private string res_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Res {
      get { return res_; }
      set {
        res_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Result);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Result other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Res != other.Res) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Res.Length != 0) hash ^= Res.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Res.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Res);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Res.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Res);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Result other) {
      if (other == null) {
        return;
      }
      if (other.Res.Length != 0) {
        Res = other.Res;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Res = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ParamList : pb::IMessage<ParamList> {
    private static readonly pb::MessageParser<ParamList> _parser = new pb::MessageParser<ParamList>(() => new ParamList());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ParamList> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.RPC.AElfDemoReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ParamList() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ParamList(ParamList other) : this() {
      param_ = other.param_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ParamList Clone() {
      return new ParamList(this);
    }

    /// <summary>Field number for the "param" field.</summary>
    public const int ParamFieldNumber = 1;
    private static readonly pb::FieldCodec<global::AElf.RPC.Parameter> _repeated_param_codec
        = pb::FieldCodec.ForMessage(10, global::AElf.RPC.Parameter.Parser);
    private readonly pbc::RepeatedField<global::AElf.RPC.Parameter> param_ = new pbc::RepeatedField<global::AElf.RPC.Parameter>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::AElf.RPC.Parameter> Param {
      get { return param_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ParamList);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ParamList other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!param_.Equals(other.param_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= param_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      param_.WriteTo(output, _repeated_param_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += param_.CalculateSize(_repeated_param_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ParamList other) {
      if (other == null) {
        return;
      }
      param_.Add(other.param_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            param_.AddEntriesFrom(input, _repeated_param_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class Parameter : pb::IMessage<Parameter> {
    private static readonly pb::MessageParser<Parameter> _parser = new pb::MessageParser<Parameter>(() => new Parameter());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Parameter> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.RPC.AElfDemoReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Parameter() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Parameter(Parameter other) : this() {
      type_ = other.type_;
      data_ = other.data_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Parameter Clone() {
      return new Parameter(this);
    }

    /// <summary>Field number for the "type" field.</summary>
    public const int TypeFieldNumber = 1;
    private int type_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Type {
      get { return type_; }
      set {
        type_ = value;
      }
    }

    /// <summary>Field number for the "data" field.</summary>
    public const int DataFieldNumber = 2;
    private pb::ByteString data_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Data {
      get { return data_; }
      set {
        data_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Parameter);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Parameter other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Type != other.Type) return false;
      if (Data != other.Data) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Type != 0) hash ^= Type.GetHashCode();
      if (Data.Length != 0) hash ^= Data.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
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
        output.WriteInt32(Type);
      }
      if (Data.Length != 0) {
        output.WriteRawTag(18);
        output.WriteBytes(Data);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Type != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Type);
      }
      if (Data.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Data);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Parameter other) {
      if (other == null) {
        return;
      }
      if (other.Type != 0) {
        Type = other.Type;
      }
      if (other.Data.Length != 0) {
        Data = other.Data;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Type = input.ReadInt32();
            break;
          }
          case 18: {
            Data = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
