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
    public sealed class ResistantSkinCreep : Ability
    {
        public ResistantSkinCreep(): base(1802650433)
        {
        }

        public ResistantSkinCreep(int newId): base(1802650433, newId)
        {
        }

        public ResistantSkinCreep(string newRawcode): base(1802650433, newRawcode)
        {
        }

        public ResistantSkinCreep(ObjectDatabaseBase db): base(1802650433, db)
        {
        }

        public ResistantSkinCreep(int newId, ObjectDatabaseBase db): base(1802650433, newId, db)
        {
        }

        public ResistantSkinCreep(string newRawcode, ObjectDatabaseBase db): base(1802650433, newRawcode, db)
        {
        }
    }
}