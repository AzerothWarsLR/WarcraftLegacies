using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ImpalingBolt : Ability
    {
        public ImpalingBolt(): base(1886218561)
        {
        }

        public ImpalingBolt(int newId): base(1886218561, newId)
        {
        }

        public ImpalingBolt(string newRawcode): base(1886218561, newRawcode)
        {
        }

        public ImpalingBolt(ObjectDatabase db): base(1886218561, db)
        {
        }

        public ImpalingBolt(int newId, ObjectDatabase db): base(1886218561, newId, db)
        {
        }

        public ImpalingBolt(string newRawcode, ObjectDatabase db): base(1886218561, newRawcode, db)
        {
        }
    }
}