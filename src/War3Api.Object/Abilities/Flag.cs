using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Flag : Ability
    {
        public Flag(): base(1818642753)
        {
        }

        public Flag(int newId): base(1818642753, newId)
        {
        }

        public Flag(string newRawcode): base(1818642753, newRawcode)
        {
        }

        public Flag(ObjectDatabase db): base(1818642753, db)
        {
        }

        public Flag(int newId, ObjectDatabase db): base(1818642753, newId, db)
        {
        }

        public Flag(string newRawcode, ObjectDatabase db): base(1818642753, newRawcode, db)
        {
        }
    }
}