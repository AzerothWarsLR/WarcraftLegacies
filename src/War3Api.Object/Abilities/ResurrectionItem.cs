using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ResurrectionItem : Ability
    {
        public ResurrectionItem(): base(2020755777)
        {
        }

        public ResurrectionItem(int newId): base(2020755777, newId)
        {
        }

        public ResurrectionItem(string newRawcode): base(2020755777, newRawcode)
        {
        }

        public ResurrectionItem(ObjectDatabase db): base(2020755777, db)
        {
        }

        public ResurrectionItem(int newId, ObjectDatabase db): base(2020755777, newId, db)
        {
        }

        public ResurrectionItem(string newRawcode, ObjectDatabase db): base(2020755777, newRawcode, db)
        {
        }
    }
}