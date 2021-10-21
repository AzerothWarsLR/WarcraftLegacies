using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ReincarnationGeneric : Ability
    {
        public ReincarnationGeneric(): base(846351937)
        {
        }

        public ReincarnationGeneric(int newId): base(846351937, newId)
        {
        }

        public ReincarnationGeneric(string newRawcode): base(846351937, newRawcode)
        {
        }

        public ReincarnationGeneric(ObjectDatabase db): base(846351937, db)
        {
        }

        public ReincarnationGeneric(int newId, ObjectDatabase db): base(846351937, newId, db)
        {
        }

        public ReincarnationGeneric(string newRawcode, ObjectDatabase db): base(846351937, newRawcode, db)
        {
        }
    }
}