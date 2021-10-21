using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ResistantSkin31PosCreep : Ability
    {
        public ResistantSkin31PosCreep(): base(1802715969)
        {
        }

        public ResistantSkin31PosCreep(int newId): base(1802715969, newId)
        {
        }

        public ResistantSkin31PosCreep(string newRawcode): base(1802715969, newRawcode)
        {
        }

        public ResistantSkin31PosCreep(ObjectDatabase db): base(1802715969, db)
        {
        }

        public ResistantSkin31PosCreep(int newId, ObjectDatabase db): base(1802715969, newId, db)
        {
        }

        public ResistantSkin31PosCreep(string newRawcode, ObjectDatabase db): base(1802715969, newRawcode, db)
        {
        }
    }
}