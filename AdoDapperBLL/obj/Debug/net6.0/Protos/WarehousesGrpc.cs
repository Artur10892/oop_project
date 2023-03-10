// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/warehouses.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace AdoDapperBLL.Protos {
  public static partial class Warehouses
  {
    static readonly string __ServiceName = "Warehouses";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::AdoDapperBLL.Protos.GetAllWarehousesRequest> __Marshaller_GetAllWarehousesRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::AdoDapperBLL.Protos.GetAllWarehousesRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::AdoDapperBLL.Protos.WarehousesResponse> __Marshaller_WarehousesResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::AdoDapperBLL.Protos.WarehousesResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::AdoDapperBLL.Protos.GetWarehouseByIdRequest> __Marshaller_GetWarehouseByIdRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::AdoDapperBLL.Protos.GetWarehouseByIdRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::AdoDapperBLL.Protos.WarehouseResponse> __Marshaller_WarehouseResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::AdoDapperBLL.Protos.WarehouseResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::AdoDapperBLL.Protos.GetByProductAndWarehouseIdRequest> __Marshaller_GetByProductAndWarehouseIdRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::AdoDapperBLL.Protos.GetByProductAndWarehouseIdRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::AdoDapperBLL.Protos.WarehouseProductResponse> __Marshaller_WarehouseProductResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::AdoDapperBLL.Protos.WarehouseProductResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::AdoDapperBLL.Protos.UpdateWarehouseProductsRequest> __Marshaller_UpdateWarehouseProductsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::AdoDapperBLL.Protos.UpdateWarehouseProductsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::AdoDapperBLL.Protos.UpdateWarehouseProductsResponse> __Marshaller_UpdateWarehouseProductsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::AdoDapperBLL.Protos.UpdateWarehouseProductsResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::AdoDapperBLL.Protos.GetAllWarehousesRequest, global::AdoDapperBLL.Protos.WarehousesResponse> __Method_GetAll = new grpc::Method<global::AdoDapperBLL.Protos.GetAllWarehousesRequest, global::AdoDapperBLL.Protos.WarehousesResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAll",
        __Marshaller_GetAllWarehousesRequest,
        __Marshaller_WarehousesResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::AdoDapperBLL.Protos.GetWarehouseByIdRequest, global::AdoDapperBLL.Protos.WarehouseResponse> __Method_GetById = new grpc::Method<global::AdoDapperBLL.Protos.GetWarehouseByIdRequest, global::AdoDapperBLL.Protos.WarehouseResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetById",
        __Marshaller_GetWarehouseByIdRequest,
        __Marshaller_WarehouseResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::AdoDapperBLL.Protos.GetByProductAndWarehouseIdRequest, global::AdoDapperBLL.Protos.WarehouseProductResponse> __Method_GetByProductAndWarehouseId = new grpc::Method<global::AdoDapperBLL.Protos.GetByProductAndWarehouseIdRequest, global::AdoDapperBLL.Protos.WarehouseProductResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetByProductAndWarehouseId",
        __Marshaller_GetByProductAndWarehouseIdRequest,
        __Marshaller_WarehouseProductResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::AdoDapperBLL.Protos.UpdateWarehouseProductsRequest, global::AdoDapperBLL.Protos.UpdateWarehouseProductsResponse> __Method_UpdateWarehouseProducts = new grpc::Method<global::AdoDapperBLL.Protos.UpdateWarehouseProductsRequest, global::AdoDapperBLL.Protos.UpdateWarehouseProductsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateWarehouseProducts",
        __Marshaller_UpdateWarehouseProductsRequest,
        __Marshaller_UpdateWarehouseProductsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::AdoDapperBLL.Protos.WarehousesReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Warehouses</summary>
    [grpc::BindServiceMethod(typeof(Warehouses), "BindService")]
    public abstract partial class WarehousesBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::AdoDapperBLL.Protos.WarehousesResponse> GetAll(global::AdoDapperBLL.Protos.GetAllWarehousesRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::AdoDapperBLL.Protos.WarehouseResponse> GetById(global::AdoDapperBLL.Protos.GetWarehouseByIdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::AdoDapperBLL.Protos.WarehouseProductResponse> GetByProductAndWarehouseId(global::AdoDapperBLL.Protos.GetByProductAndWarehouseIdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::AdoDapperBLL.Protos.UpdateWarehouseProductsResponse> UpdateWarehouseProducts(global::AdoDapperBLL.Protos.UpdateWarehouseProductsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(WarehousesBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetAll, serviceImpl.GetAll)
          .AddMethod(__Method_GetById, serviceImpl.GetById)
          .AddMethod(__Method_GetByProductAndWarehouseId, serviceImpl.GetByProductAndWarehouseId)
          .AddMethod(__Method_UpdateWarehouseProducts, serviceImpl.UpdateWarehouseProducts).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, WarehousesBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetAll, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::AdoDapperBLL.Protos.GetAllWarehousesRequest, global::AdoDapperBLL.Protos.WarehousesResponse>(serviceImpl.GetAll));
      serviceBinder.AddMethod(__Method_GetById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::AdoDapperBLL.Protos.GetWarehouseByIdRequest, global::AdoDapperBLL.Protos.WarehouseResponse>(serviceImpl.GetById));
      serviceBinder.AddMethod(__Method_GetByProductAndWarehouseId, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::AdoDapperBLL.Protos.GetByProductAndWarehouseIdRequest, global::AdoDapperBLL.Protos.WarehouseProductResponse>(serviceImpl.GetByProductAndWarehouseId));
      serviceBinder.AddMethod(__Method_UpdateWarehouseProducts, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::AdoDapperBLL.Protos.UpdateWarehouseProductsRequest, global::AdoDapperBLL.Protos.UpdateWarehouseProductsResponse>(serviceImpl.UpdateWarehouseProducts));
    }

  }
}
#endregion
