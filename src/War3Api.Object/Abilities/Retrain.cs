using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Retrain : Ability
    {
        public Retrain(): base(1952805441)
        {
        }

        public Retrain(int newId): base(1952805441, newId)
        {
        }

        public Retrain(string newRawcode): base(1952805441, newRawcode)
        {
        }

        public Retrain(ObjectDatabase db): base(1952805441, db)
        {
        }

        public Retrain(int newId, ObjectDatabase db): base(1952805441, newId, db)
        {
        }

        public Retrain(string newRawcode, ObjectDatabase db): base(1952805441, newRawcode, db)
        {
        }
    }
}