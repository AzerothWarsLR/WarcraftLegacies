using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Ultravision : Ability
    {
        public Ultravision(): base(1953264961)
        {
        }

        public Ultravision(int newId): base(1953264961, newId)
        {
        }

        public Ultravision(string newRawcode): base(1953264961, newRawcode)
        {
        }

        public Ultravision(ObjectDatabase db): base(1953264961, db)
        {
        }

        public Ultravision(int newId, ObjectDatabase db): base(1953264961, newId, db)
        {
        }

        public Ultravision(string newRawcode, ObjectDatabase db): base(1953264961, newRawcode, db)
        {
        }
    }
}