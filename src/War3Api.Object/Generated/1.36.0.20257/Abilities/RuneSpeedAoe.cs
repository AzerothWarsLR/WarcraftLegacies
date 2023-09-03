using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class RuneSpeedAoe : Ability
    {
        public RuneSpeedAoe(): base(1634947137)
        {
        }

        public RuneSpeedAoe(int newId): base(1634947137, newId)
        {
        }

        public RuneSpeedAoe(string newRawcode): base(1634947137, newRawcode)
        {
        }

        public RuneSpeedAoe(ObjectDatabaseBase db): base(1634947137, db)
        {
        }

        public RuneSpeedAoe(int newId, ObjectDatabaseBase db): base(1634947137, newId, db)
        {
        }

        public RuneSpeedAoe(string newRawcode, ObjectDatabaseBase db): base(1634947137, newRawcode, db)
        {
        }
    }
}