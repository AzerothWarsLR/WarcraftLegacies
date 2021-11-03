using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Drop_Adro : Ability
    {
        public Drop_Adro(): base(1869767745)
        {
        }

        public Drop_Adro(int newId): base(1869767745, newId)
        {
        }

        public Drop_Adro(string newRawcode): base(1869767745, newRawcode)
        {
        }

        public Drop_Adro(ObjectDatabase db): base(1869767745, db)
        {
        }

        public Drop_Adro(int newId, ObjectDatabase db): base(1869767745, newId, db)
        {
        }

        public Drop_Adro(string newRawcode, ObjectDatabase db): base(1869767745, newRawcode, db)
        {
        }
    }
}