using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class HarvestNaga : Ability
    {
        public HarvestNaga(): base(1634225729)
        {
        }

        public HarvestNaga(int newId): base(1634225729, newId)
        {
        }

        public HarvestNaga(string newRawcode): base(1634225729, newRawcode)
        {
        }

        public HarvestNaga(ObjectDatabase db): base(1634225729, db)
        {
        }

        public HarvestNaga(int newId, ObjectDatabase db): base(1634225729, newId, db)
        {
        }

        public HarvestNaga(string newRawcode, ObjectDatabase db): base(1634225729, newRawcode, db)
        {
        }
    }
}