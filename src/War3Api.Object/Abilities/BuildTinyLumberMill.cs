using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BuildTinyLumberMill : Ability
    {
        public BuildTinyLumberMill(): base(1919043905)
        {
        }

        public BuildTinyLumberMill(int newId): base(1919043905, newId)
        {
        }

        public BuildTinyLumberMill(string newRawcode): base(1919043905, newRawcode)
        {
        }

        public BuildTinyLumberMill(ObjectDatabase db): base(1919043905, db)
        {
        }

        public BuildTinyLumberMill(int newId, ObjectDatabase db): base(1919043905, newId, db)
        {
        }

        public BuildTinyLumberMill(string newRawcode, ObjectDatabase db): base(1919043905, newRawcode, db)
        {
        }
    }
}