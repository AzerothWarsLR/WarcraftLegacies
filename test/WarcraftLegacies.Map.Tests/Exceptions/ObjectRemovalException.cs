using War3Api.Object;
using Warcraft.Cartographer.Extensions;

namespace WarcraftLegacies.Map.Tests.Exceptions;

public sealed class ObjectRemovalException(BaseObject baseObject, Exception innerException) : Exception(
  $"Could not remove {baseObject.GetType()} {baseObject.GetReadableId()} - {baseObject.GetId()}", innerException);
