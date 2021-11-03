using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BuildNaga : Ability
    {
        public BuildNaga(): base(1969375041)
        {
        }

        public BuildNaga(int newId): base(1969375041, newId)
        {
        }

        public BuildNaga(string newRawcode): base(1969375041, newRawcode)
        {
        }

        public BuildNaga(ObjectDatabase db): base(1969375041, db)
        {
        }

        public BuildNaga(int newId, ObjectDatabase db): base(1969375041, newId, db)
        {
        }

        public BuildNaga(string newRawcode, ObjectDatabase db): base(1969375041, newRawcode, db)
        {
        }
    }
}