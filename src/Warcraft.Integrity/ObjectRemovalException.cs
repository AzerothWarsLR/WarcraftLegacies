using War3Api.Object;
using War3Net.Common.Extensions;

namespace Warcraft.Integrity;

public sealed class ObjectRemovalException(BaseObject baseObject, Exception innerException) : Exception(
  $"Could not remove {baseObject.GetType()} {(baseObject.NewId != 0 ? baseObject.NewId.ToRawcode() : baseObject.OldId.ToRawcode())} - {(baseObject.NewId != 0 ? baseObject.NewId : baseObject.OldId)}", innerException);
