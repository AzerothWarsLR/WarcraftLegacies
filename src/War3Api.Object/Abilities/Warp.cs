using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Warp : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataTeleportAreaWidth;
        private readonly Lazy<ObjectProperty<float>> _dataTeleportAreaHeight;
        public Warp(): base(1886549825)
        {
            _dataTeleportAreaWidth = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaWidth, SetDataTeleportAreaWidth));
            _dataTeleportAreaHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaHeight, SetDataTeleportAreaHeight));
        }

        public Warp(int newId): base(1886549825, newId)
        {
            _dataTeleportAreaWidth = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaWidth, SetDataTeleportAreaWidth));
            _dataTeleportAreaHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaHeight, SetDataTeleportAreaHeight));
        }

        public Warp(string newRawcode): base(1886549825, newRawcode)
        {
            _dataTeleportAreaWidth = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaWidth, SetDataTeleportAreaWidth));
            _dataTeleportAreaHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaHeight, SetDataTeleportAreaHeight));
        }

        public Warp(ObjectDatabase db): base(1886549825, db)
        {
            _dataTeleportAreaWidth = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaWidth, SetDataTeleportAreaWidth));
            _dataTeleportAreaHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaHeight, SetDataTeleportAreaHeight));
        }

        public Warp(int newId, ObjectDatabase db): base(1886549825, newId, db)
        {
            _dataTeleportAreaWidth = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaWidth, SetDataTeleportAreaWidth));
            _dataTeleportAreaHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaHeight, SetDataTeleportAreaHeight));
        }

        public Warp(string newRawcode, ObjectDatabase db): base(1886549825, newRawcode, db)
        {
            _dataTeleportAreaWidth = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaWidth, SetDataTeleportAreaWidth));
            _dataTeleportAreaHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaHeight, SetDataTeleportAreaHeight));
        }

        public ObjectProperty<float> DataTeleportAreaWidth => _dataTeleportAreaWidth.Value;
        public ObjectProperty<float> DataTeleportAreaHeight => _dataTeleportAreaHeight.Value;
        private float GetDataTeleportAreaWidth(int level)
        {
            return _modifications[829452887, level].ValueAsFloat;
        }

        private void SetDataTeleportAreaWidth(int level, float value)
        {
            _modifications[829452887, level] = new LevelObjectDataModification{Id = 829452887, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataTeleportAreaHeight(int level)
        {
            return _modifications[846230103, level].ValueAsFloat;
        }

        private void SetDataTeleportAreaHeight(int level, float value)
        {
            _modifications[846230103, level] = new LevelObjectDataModification{Id = 846230103, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}