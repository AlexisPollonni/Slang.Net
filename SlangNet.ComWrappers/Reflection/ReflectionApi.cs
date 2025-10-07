using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Reflection;

internal static partial class ReflectionApi
{
    #region User Attribute
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionUserAttribute_GetName")]
    public static partial string ReflectionUserAttribute_GetName(UserAttribute attrib);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionUserAttribute_GetArgumentCount")]
    public static partial uint ReflectionUserAttribute_GetArgumentCount(UserAttribute attrib);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionUserAttribute_GetArgumentType")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? ReflectionUserAttribute_GetArgumentType(UserAttribute attrib, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionUserAttribute_GetArgumentValueInt")]
    public static partial SlangResult ReflectionUserAttribute_GetArgumentValueInt(UserAttribute attrib, uint index, out int rs);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionUserAttribute_GetArgumentValueFloat")]
    public static partial SlangResult ReflectionUserAttribute_GetArgumentValueFloat(UserAttribute attrib, uint index, out float rs);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionUserAttribute_GetArgumentValueString")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? ReflectionUserAttribute_GetArgumentValueString(UserAttribute attrib, uint index, out nuint outSize);
    
    #endregion

    
    
    #region TypeReflection
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetKind")]
    public static partial Unmanaged.TypeKind ReflectionType_GetKind(TypeReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetUserAttributeCount")]
    public static partial uint ReflectionType_GetUserAttributeCount(TypeReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetUserAttribute")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<UserAttribute>))]
    public static partial UserAttribute? ReflectionType_GetUserAttribute(TypeReflection type, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_FindUserAttributeByName")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<UserAttribute>))]
    public static partial UserAttribute? ReflectionType_FindUserAttributeByName(TypeReflection type, string name);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_applySpecializations")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? ReflectionType_applySpecializations(TypeReflection type, GenericReflection generic);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetFieldCount")]
    public static partial uint ReflectionType_GetFieldCount(TypeReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetFieldByIndex")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableReflection>))]
    public static partial VariableReflection? ReflectionType_GetFieldByIndex(TypeReflection type, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetElementCount")]
    public static partial nuint ReflectionType_GetElementCount(TypeReflection type);

    [LibraryImport("slang",
                   StringMarshalling = StringMarshalling.Utf8,
                   EntryPoint = "spReflectionType_GetSpecializedElementCount")]
    public static partial nuint ReflectionType_GetSpecializedElementCount(TypeReflection type, ShaderReflection reflection);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetElementType")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? ReflectionType_GetElementType(TypeReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetRowCount")]
    public static partial uint ReflectionType_GetRowCount(TypeReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetColumnCount")]
    public static partial uint ReflectionType_GetColumnCount(TypeReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetScalarType")]
    public static partial Unmanaged.ScalarType ReflectionType_GetScalarType(TypeReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetResourceShape")]
    public static partial Unmanaged.ResourceShape ReflectionType_GetResourceShape(TypeReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetResourceAccess")]
    public static partial Unmanaged.ResourceAccess ReflectionType_GetResourceAccess(TypeReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetResourceResultType")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? ReflectionType_GetResourceResultType(TypeReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetName")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? ReflectionType_GetName(TypeReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetFullName")]
    public static partial SlangResult ReflectionType_GetFullName(TypeReflection type, out IBlob outNameBlob);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_GetGenericContainer")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<GenericReflection>))]
    public static partial GenericReflection? ReflectionType_GetGenericContainer(TypeReflection type);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_getSpecializedTypeArgCount")]
    public static partial long ReflectionType_getSpecializedTypeArgCount(TypeReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionType_getSpecializedTypeArgType")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? ReflectionType_getSpecializedTypeArgType(TypeReflection type, long index);

    #endregion




    #region TypeLayoutReflection

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_GetType")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? ReflectionTypeLayout_GetType(TypeLayoutReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getKind")]
    public static partial Unmanaged.TypeKind ReflectionTypeLayout_getKind(TypeLayoutReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_GetSize")]
    public static partial nuint ReflectionTypeLayout_GetSize(TypeLayoutReflection type, ParameterCategory category);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_GetStride")]
    public static partial nuint ReflectionTypeLayout_GetStride(TypeLayoutReflection type, ParameterCategory category);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getAlignment")]
    public static partial int ReflectionTypeLayout_getAlignment(TypeLayoutReflection type, ParameterCategory category);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_GetFieldCount")]
    public static partial uint ReflectionTypeLayout_GetFieldCount(TypeLayoutReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_GetFieldByIndex")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableLayoutReflection>))]
    public static partial VariableLayoutReflection? ReflectionTypeLayout_GetFieldByIndex(TypeLayoutReflection type, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_findFieldIndexByName")]
    public static partial long ReflectionTypeLayout_findFieldIndexByName(TypeLayoutReflection typeLayout, string name, nint unused = 0);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_GetExplicitCounter")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableLayoutReflection>))]
    public static partial VariableLayoutReflection? ReflectionTypeLayout_GetExplicitCounter(TypeLayoutReflection typeLayout);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_GetElementStride")]
    public static partial nuint ReflectionTypeLayout_GetElementStride(TypeLayoutReflection type, ParameterCategory category);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_GetElementTypeLayout")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeLayoutReflection>))]
    public static partial TypeLayoutReflection? ReflectionTypeLayout_GetElementTypeLayout(TypeLayoutReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_GetElementVarLayout")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableLayoutReflection>))]
    public static partial VariableLayoutReflection? ReflectionTypeLayout_GetElementVarLayout(TypeLayoutReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getContainerVarLayout")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableLayoutReflection>))]
    public static partial VariableLayoutReflection? ReflectionTypeLayout_getContainerVarLayout(TypeLayoutReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_GetParameterCategory")]
    public static partial ParameterCategory ReflectionTypeLayout_GetParameterCategory(TypeLayoutReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_GetCategoryCount")]
    public static partial uint ReflectionTypeLayout_GetCategoryCount(TypeLayoutReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_GetCategoryByIndex")]
    public static partial ParameterCategory ReflectionTypeLayout_GetCategoryByIndex(TypeLayoutReflection type, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_GetMatrixLayoutMode")]
    public static partial Unmanaged.MatrixLayoutMode ReflectionTypeLayout_GetMatrixLayoutMode(TypeLayoutReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getGenericParamIndex")]
    public static partial int ReflectionTypeLayout_getGenericParamIndex(TypeLayoutReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getPendingDataTypeLayout")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeLayoutReflection>))]
    public static partial TypeLayoutReflection? ReflectionTypeLayout_getPendingDataTypeLayout(TypeLayoutReflection type);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getSpecializedTypePendingDataVarLayout")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableLayoutReflection>))]
    public static partial VariableLayoutReflection? ReflectionTypeLayout_getSpecializedTypePendingDataVarLayout(TypeLayoutReflection type);

    #endregion
    
    
    




    #region TypeLayoutReflection

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getBindingRangeCount")]
    public static partial long ReflectionTypeLayout_getBindingRangeCount(TypeLayoutReflection typeLayout);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getBindingRangeType")]
    public static partial BindingType ReflectionTypeLayout_getBindingRangeType(TypeLayoutReflection typeLayout, long index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_isBindingRangeSpecializable")]
    public static partial long ReflectionTypeLayout_isBindingRangeSpecializable(TypeLayoutReflection typeLayout, long index);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getBindingRangeBindingCount")]
    public static partial long ReflectionTypeLayout_getBindingRangeBindingCount(TypeLayoutReflection typeLayout, long index);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getBindingRangeLeafTypeLayout")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeLayoutReflection>))]
    public static partial TypeLayoutReflection? ReflectionTypeLayout_getBindingRangeLeafTypeLayout(TypeLayoutReflection typeLayout, long index);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getBindingRangeLeafVariable")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableReflection>))]
    public static partial VariableReflection? ReflectionTypeLayout_getBindingRangeLeafVariable(TypeLayoutReflection typeLayout, long index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getBindingRangeImageFormat")]
    public static partial Unmanaged.ImageFormat ReflectionTypeLayout_getBindingRangeImageFormat(TypeLayoutReflection typeLayout, long index);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getFieldBindingRangeOffset")]
    public static partial long ReflectionTypeLayout_getFieldBindingRangeOffset(TypeLayoutReflection typeLayout, long fieldIndex);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getExplicitCounterBindingRangeOffset")]
    public static partial long ReflectionTypeLayout_getExplicitCounterBindingRangeOffset(TypeLayoutReflection inTypeLayout);
        
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getBindingRangeDescriptorSetIndex")]
    public static partial long ReflectionTypeLayout_getBindingRangeDescriptorSetIndex(TypeLayoutReflection typeLayout, long index);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getBindingRangeFirstDescriptorRangeIndex")]
    public static partial long ReflectionTypeLayout_getBindingRangeFirstDescriptorRangeIndex(TypeLayoutReflection typeLayout, long index);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getBindingRangeDescriptorRangeCount")]
    public static partial long ReflectionTypeLayout_getBindingRangeDescriptorRangeCount(TypeLayoutReflection typeLayout, long index);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getDescriptorSetCount")]
    public static partial long ReflectionTypeLayout_getDescriptorSetCount(TypeLayoutReflection typeLayout);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getDescriptorSetSpaceOffset")]
    public static partial long ReflectionTypeLayout_getDescriptorSetSpaceOffset(TypeLayoutReflection typeLayout, long setIndex);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getDescriptorSetDescriptorRangeCount")]
    public static partial long ReflectionTypeLayout_getDescriptorSetDescriptorRangeCount(TypeLayoutReflection typeLayout, long setIndex);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getDescriptorSetDescriptorRangeIndexOffset")]
    public static partial long ReflectionTypeLayout_getDescriptorSetDescriptorRangeIndexOffset(TypeLayoutReflection typeLayout, long setIndex, long rangeIndex);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getDescriptorSetDescriptorRangeDescriptorCount")]
    public static partial long ReflectionTypeLayout_getDescriptorSetDescriptorRangeDescriptorCount(TypeLayoutReflection typeLayout, long setIndex, long rangeIndex);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getDescriptorSetDescriptorRangeType")]
    public static partial BindingType ReflectionTypeLayout_getDescriptorSetDescriptorRangeType(TypeLayoutReflection typeLayout, long setIndex, long rangeIndex);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getDescriptorSetDescriptorRangeCategory")]
    public static partial ParameterCategory ReflectionTypeLayout_getDescriptorSetDescriptorRangeCategory(TypeLayoutReflection typeLayout, long setIndex, long rangeIndex);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getSubObjectRangeCount")]
    public static partial long ReflectionTypeLayout_getSubObjectRangeCount(TypeLayoutReflection typeLayout);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getSubObjectRangeBindingRangeIndex")]
    public static partial long ReflectionTypeLayout_getSubObjectRangeBindingRangeIndex(TypeLayoutReflection typeLayout, long subObjectRangeIndex);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getSubObjectRangeSpaceOffset")]
    public static partial long ReflectionTypeLayout_getSubObjectRangeSpaceOffset(TypeLayoutReflection typeLayout, long subObjectRangeIndex);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeLayout_getSubObjectRangeOffset")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableLayoutReflection>))]
    public static partial VariableLayoutReflection? ReflectionTypeLayout_getSubObjectRangeOffset(TypeLayoutReflection typeLayout, long subObjectRangeIndex);

    #endregion







    #region VariableReflection

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariable_GetName")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? ReflectionVariable_GetName(VariableReflection var);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariable_GetType")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? ReflectionVariable_GetType(VariableReflection var);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariable_FindModifier")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<ModifierReflection>))]
    public static partial ModifierReflection? ReflectionVariable_FindModifier(VariableReflection var, Unmanaged.ModifierID modifierId);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariable_GetUserAttributeCount")]
    public static partial uint ReflectionVariable_GetUserAttributeCount(VariableReflection var);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariable_GetUserAttribute")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<UserAttribute>))]
    public static partial UserAttribute? ReflectionVariable_GetUserAttribute(VariableReflection var, uint index);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariable_FindUserAttributeByName")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<UserAttribute>))]
    public static partial UserAttribute? ReflectionVariable_FindUserAttributeByName(VariableReflection var, IGlobalSession globalSession, string name);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariable_HasDefaultValue")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool ReflectionVariable_HasDefaultValue(VariableReflection inVar);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariable_GetDefaultValueInt")]
    public static partial SlangResult ReflectionVariable_GetDefaultValueInt(VariableReflection inVar, out long rs);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariable_GetGenericContainer")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<GenericReflection>))]
    public static partial GenericReflection? ReflectionVariable_GetGenericContainer(VariableReflection var);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariable_applySpecializations")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableReflection>))]
    public static partial VariableReflection? ReflectionVariable_applySpecializations(VariableReflection var, GenericReflection generic);

    #endregion








    #region VariableLayoutReflection

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariableLayout_GetVariable")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableReflection>))]
    public static partial VariableReflection? ReflectionVariableLayout_GetVariable(VariableLayoutReflection var);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariableLayout_GetTypeLayout")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeLayoutReflection>))]
    public static partial TypeLayoutReflection? ReflectionVariableLayout_GetTypeLayout(VariableLayoutReflection var);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariableLayout_GetOffset")]
    public static partial nuint ReflectionVariableLayout_GetOffset(VariableLayoutReflection var, ParameterCategory category);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariableLayout_GetSpace")]
    public static partial nuint ReflectionVariableLayout_GetSpace(VariableLayoutReflection var, ParameterCategory category);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariableLayout_GetImageFormat")]
    public static partial Unmanaged.ImageFormat ReflectionVariableLayout_GetImageFormat(VariableLayoutReflection var);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariableLayout_GetSemanticName")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? ReflectionVariableLayout_GetSemanticName(VariableLayoutReflection var);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariableLayout_GetSemanticIndex")]
    public static partial nuint ReflectionVariableLayout_GetSemanticIndex(VariableLayoutReflection var);

    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariableLayout_getStage")]
    public static partial Unmanaged.Stage ReflectionVariableLayout_getStage(VariableLayoutReflection var);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionVariableLayout_getPendingDataLayout")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableLayoutReflection>))]
    public static partial VariableLayoutReflection? ReflectionVariableLayout_getPendingDataLayout(VariableLayoutReflection var);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionParameter_GetBindingIndex")]
    public static partial uint ReflectionParameter_GetBindingIndex(VariableLayoutReflection parameter);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionParameter_GetBindingSpace")]
    public static partial uint ReflectionParameter_GetBindingSpace(VariableLayoutReflection parameter);

    #endregion








    #region FunctionReflection

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_asDecl")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<DeclReflection>))]
    public static partial DeclReflection? ReflectionFunction_asDecl(FunctionReflection func);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_GetName")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? ReflectionFunction_GetName(FunctionReflection func);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_FindModifier")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<ModifierReflection>))]
    public static partial ModifierReflection? ReflectionFunction_FindModifier(FunctionReflection var, Unmanaged.ModifierID modifierId);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_GetUserAttributeCount")]
    public static partial uint ReflectionFunction_GetUserAttributeCount(FunctionReflection func);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_GetUserAttribute")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<UserAttribute>))]
    public static partial UserAttribute? ReflectionFunction_GetUserAttribute(FunctionReflection func, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_FindUserAttributeByName")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<UserAttribute>))]
    public static partial UserAttribute? ReflectionFunction_FindUserAttributeByName(FunctionReflection func, IGlobalSession globalSession, string name);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_GetParameterCount")]
    public static partial uint ReflectionFunction_GetParameterCount(FunctionReflection func);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_GetParameter")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableReflection>))]
    public static partial VariableReflection? ReflectionFunction_GetParameter(FunctionReflection func, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_GetResultType")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? ReflectionFunction_GetResultType(FunctionReflection func);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_GetGenericContainer")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<GenericReflection>))]
    public static partial GenericReflection? ReflectionFunction_GetGenericContainer(FunctionReflection func);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_applySpecializations")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<FunctionReflection>))]
    public static partial FunctionReflection? ReflectionFunction_applySpecializations(FunctionReflection func, GenericReflection generic);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_specializeWithArgTypes")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<FunctionReflection>))]
    public static partial FunctionReflection? ReflectionFunction_specializeWithArgTypes(FunctionReflection func, long argTypeCount, ReadOnlySpan<TypeReflection> argTypes);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_isOverloaded")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool ReflectionFunction_isOverloaded(FunctionReflection func);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_getOverloadCount")]
    public static partial uint ReflectionFunction_getOverloadCount(FunctionReflection func);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionFunction_getOverload")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<FunctionReflection>))]
    public static partial FunctionReflection? ReflectionFunction_getOverload(FunctionReflection func, uint index);

    #endregion





    #region DeclReflection

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionDecl_getChildrenCount")]
    public static partial uint ReflectionDecl_getChildrenCount(DeclReflection parentDecl);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionDecl_getChild")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<DeclReflection>))]
    public static partial DeclReflection? ReflectionDecl_getChild(DeclReflection parentDecl, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionDecl_getName")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? ReflectionDecl_getName(DeclReflection decl);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionDecl_getKind")]
    public static partial Unmanaged.DeclKind ReflectionDecl_getKind(DeclReflection decl);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionDecl_castToFunction")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<FunctionReflection>))]
    public static partial FunctionReflection? ReflectionDecl_castToFunction(DeclReflection decl);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionDecl_castToVariable")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableReflection>))]
    public static partial VariableReflection? ReflectionDecl_castToVariable(DeclReflection decl);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionDecl_castToGeneric")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<GenericReflection>))]
    public static partial GenericReflection? ReflectionDecl_castToGeneric(DeclReflection decl);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_getTypeFromDecl")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? Reflection_getTypeFromDecl(DeclReflection decl);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionDecl_getParent")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<DeclReflection>))]
    public static partial DeclReflection? ReflectionDecl_getParent(DeclReflection decl);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionDecl_findModifier")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<ModifierReflection>))]
    public static partial ModifierReflection? ReflectionDecl_findModifier(DeclReflection decl,
                                                                          Unmanaged.ModifierID modifierId);
    
    #endregion





    #region GenericReflection

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_asDecl")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<DeclReflection>))]
    public static partial DeclReflection? ReflectionGeneric_asDecl(GenericReflection generic);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_GetName")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? ReflectionGeneric_GetName(GenericReflection generic);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_GetTypeParameterCount")]
    public static partial uint ReflectionGeneric_GetTypeParameterCount(GenericReflection generic);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_GetTypeParameter")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableReflection>))]
    public static partial VariableReflection? ReflectionGeneric_GetTypeParameter(GenericReflection generic, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_GetValueParameterCount")]
    public static partial uint ReflectionGeneric_GetValueParameterCount(GenericReflection generic);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_GetValueParameter")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableReflection>))]
    public static partial VariableReflection? ReflectionGeneric_GetValueParameter(GenericReflection generic, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_GetTypeParameterConstraintCount")]
    public static partial uint ReflectionGeneric_GetTypeParameterConstraintCount(GenericReflection generic, VariableReflection typeParam);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_GetTypeParameterConstraintType")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? ReflectionGeneric_GetTypeParameterConstraintType(GenericReflection generic, VariableReflection typeParam, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_GetInnerKind")]
    public static partial Unmanaged.DeclKind ReflectionGeneric_GetInnerKind(GenericReflection generic);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_GetInnerDecl")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<DeclReflection>))]
    public static partial DeclReflection? ReflectionGeneric_GetInnerDecl(GenericReflection generic);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_GetOuterGenericContainer")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<GenericReflection>))]
    public static partial GenericReflection? ReflectionGeneric_GetOuterGenericContainer(GenericReflection generic);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_GetConcreteType")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? ReflectionGeneric_GetConcreteType(GenericReflection generic, VariableReflection typeParam);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_GetConcreteIntVal")]
    public static partial long ReflectionGeneric_GetConcreteIntVal(GenericReflection generic, VariableReflection valueParam);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionGeneric_applySpecializations")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<GenericReflection>))]
    public static partial GenericReflection? ReflectionGeneric_applySpecializations(GenericReflection currGeneric, GenericReflection generic);

    #endregion






    #region EntryPointReflection

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionEntryPoint_getName")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? ReflectionEntryPoint_getName(EntryPointReflection entryPoint);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionEntryPoint_getNameOverride")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? ReflectionEntryPoint_getNameOverride(EntryPointReflection entryPoint);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionEntryPoint_getFunction")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<FunctionReflection>))]
    public static partial FunctionReflection? ReflectionEntryPoint_getFunction(EntryPointReflection entryPoint);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionEntryPoint_getParameterCount")]
    public static partial uint ReflectionEntryPoint_getParameterCount(EntryPointReflection entryPoint);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionEntryPoint_getParameterByIndex")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableLayoutReflection>))]
    public static partial VariableLayoutReflection? ReflectionEntryPoint_getParameterByIndex(EntryPointReflection entryPoint, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionEntryPoint_getStage")]
    public static partial Unmanaged.Stage ReflectionEntryPoint_getStage(EntryPointReflection entryPoint);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionEntryPoint_getComputeThreadGroupSize")]
    public static partial void ReflectionEntryPoint_getComputeThreadGroupSize(EntryPointReflection entryPoint, nuint axisCount, Span<ulong> outSizeAlongAxis);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionEntryPoint_getComputeWaveSize")]
    public static partial void ReflectionEntryPoint_getComputeWaveSize(EntryPointReflection entryPoint, out nuint outWaveSize);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionEntryPoint_usesAnySampleRateInput")]
    public static partial int ReflectionEntryPoint_usesAnySampleRateInput(EntryPointReflection entryPoint);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionEntryPoint_getVarLayout")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableLayoutReflection>))]
    public static partial VariableLayoutReflection? ReflectionEntryPoint_getVarLayout(EntryPointReflection entryPoint);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionEntryPoint_getResultVarLayout")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableLayoutReflection>))]
    public static partial VariableLayoutReflection? ReflectionEntryPoint_getResultVarLayout(EntryPointReflection entryPoint);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionEntryPoint_hasDefaultConstantBuffer")]
    public static partial int ReflectionEntryPoint_hasDefaultConstantBuffer(EntryPointReflection entryPoint);

    #endregion




    #region TypeParameterReflection

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeParameter_GetName")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? ReflectionTypeParameter_GetName(TypeParameterReflection typeParam);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeParameter_GetIndex")]
    public static partial uint ReflectionTypeParameter_GetIndex(TypeParameterReflection typeParam);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeParameter_GetConstraintCount")]
    public static partial uint ReflectionTypeParameter_GetConstraintCount(TypeParameterReflection typeParam);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflectionTypeParameter_GetConstraintByIndex")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? ReflectionTypeParameter_GetConstraintByIndex(TypeParameterReflection typeParam, uint index);
    
    #endregion
    
    
    

    #region ProgramLayout

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_ToJson")]
    public static partial SlangResult Reflection_ToJson(ShaderReflection reflection, ICompileRequest request, out IBlob outBlob);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_GetParameterCount")]
    public static partial uint Reflection_GetParameterCount(ShaderReflection reflection);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_GetParameterByIndex")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableLayoutReflection>))]
    public static partial VariableLayoutReflection? Reflection_GetParameterByIndex(ShaderReflection reflection, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_GetTypeParameterCount")]
    public static partial uint Reflection_GetTypeParameterCount(ShaderReflection reflection);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_GetTypeParameterByIndex")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeParameterReflection>))]
    public static partial TypeParameterReflection? Reflection_GetTypeParameterByIndex(ShaderReflection reflection, uint index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_FindTypeParameter")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeParameterReflection>))]
    public static partial TypeParameterReflection? Reflection_FindTypeParameter(ShaderReflection reflection, string name);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_FindTypeByName")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? Reflection_FindTypeByName(ShaderReflection reflection, string name);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_GetTypeLayout")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeLayoutReflection>))]
    public static partial TypeLayoutReflection? Reflection_GetTypeLayout(ShaderReflection reflection, TypeReflection reflectionType, LayoutRules rules);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_FindFunctionByName")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<FunctionReflection>))]
    public static partial FunctionReflection? Reflection_FindFunctionByName(ShaderReflection reflection, string name);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_FindFunctionByNameInType")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<FunctionReflection>))]
    public static partial FunctionReflection? Reflection_FindFunctionByNameInType(ShaderReflection reflection, TypeReflection reflType, string name);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_FindVarByNameInType")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableReflection>))]
    public static partial VariableReflection? Reflection_FindVarByNameInType(ShaderReflection reflection, TypeReflection reflType, string name);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_TryResolveOverloadedFunction")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<FunctionReflection>))]
    public static partial FunctionReflection? Reflection_TryResolveOverloadedFunction(
        ShaderReflection reflection,
        uint candidateCount,
        [MarshalUsing(CountElementName = "candidateCount")]
        ReadOnlySpan<FunctionReflection> candidates);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_getEntryPointCount")]
    public static partial ulong Reflection_getEntryPointCount(ShaderReflection reflection);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_getEntryPointByIndex")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<EntryPointReflection>))]
    public static partial EntryPointReflection? Reflection_getEntryPointByIndex(ShaderReflection reflection, ulong index);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_findEntryPointByName")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<EntryPointReflection>))]
    public static partial EntryPointReflection? Reflection_findEntryPointByName(ShaderReflection reflection, string name);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_getGlobalConstantBufferBinding")]
    public static partial ulong Reflection_getGlobalConstantBufferBinding(ShaderReflection reflection);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_getGlobalConstantBufferSize")]
    public static partial nuint Reflection_getGlobalConstantBufferSize(ShaderReflection reflection);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_specializeType")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    public static partial TypeReflection? Reflection_specializeType(ShaderReflection reflection, TypeReflection type, long specializationArgCount, ReadOnlySpan<TypeReflection> specializationArgs, out IBlob outDiagnostics);
    
    //TODO
    ///[LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_specializeGeneric")]
    //[return: MarshalUsing(typeof(NullableStructMarshaller<GenericReflection>))]
    //public static partial GenericReflection? Reflection_specializeGeneric(ShaderReflection inProgramLayout, GenericReflection generic, long argCount, ReadOnlySpan<Unmanaged.ReflectionGenericArgType> argTypes, [NativeTypeName("const SlangReflectionGenericArg *")] Unmanaged.SlangReflectionGenericArg* args, out IBlob outDiagnostics);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_isSubType")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool Reflection_isSubType(ShaderReflection reflection, TypeReflection subType, TypeReflection superType);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_getHashedStringCount")]
    public static partial ulong Reflection_getHashedStringCount(ShaderReflection reflection);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_getHashedString")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? Reflection_getHashedString(ShaderReflection reflection, ulong index, out nuint outCount);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_getGlobalParamsTypeLayout")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeLayoutReflection>))]
    public static partial TypeLayoutReflection? Reflection_getGlobalParamsTypeLayout(ShaderReflection reflection);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_getGlobalParamsVarLayout")]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<VariableLayoutReflection>))]
    public static partial VariableLayoutReflection? Reflection_getGlobalParamsVarLayout(ShaderReflection reflection);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spReflection_GetSession")]
    public static partial ISession? Reflection_GetSession(ShaderReflection reflection);

    #endregion
    
    
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spComputeStringHash")]
    public static partial uint ComputeStringHash(string chars, nuint count);

    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "spGetTranslationUnitSource")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? GetTranslationUnitSource(ICompileRequest request, int translationUnitIndex);

}