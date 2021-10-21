using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ParasiteEredar : Ability
    {
        public ParasiteEredar(): base(1634747201)
        {
        }

        public ParasiteEredar(int newId): base(1634747201, newId)
        {
        }

        public ParasiteEredar(string newRawcode): base(1634747201, newRawcode)
        {
        }

        public ParasiteEredar(ObjectDatabase db): base(1634747201, db)
        {
        }

        public ParasiteEredar(int newId, ObjectDatabase db): base(1634747201, newId, db)
        {
        }

        public ParasiteEredar(string newRawcode, ObjectDatabase db): base(1634747201, newRawcode, db)
        {
        }
    }
}