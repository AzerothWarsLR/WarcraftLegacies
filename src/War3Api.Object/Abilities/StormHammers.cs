using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class StormHammers : Ability
    {
        public StormHammers(): base(1752462145)
        {
        }

        public StormHammers(int newId): base(1752462145, newId)
        {
        }

        public StormHammers(string newRawcode): base(1752462145, newRawcode)
        {
        }

        public StormHammers(ObjectDatabase db): base(1752462145, db)
        {
        }

        public StormHammers(int newId, ObjectDatabase db): base(1752462145, newId, db)
        {
        }

        public StormHammers(string newRawcode, ObjectDatabase db): base(1752462145, newRawcode, db)
        {
        }
    }
}