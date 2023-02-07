namespace ModelTester.Objects {
    public struct CollisionShape : IDataRW {
        public Node Node;
        public ShapeType Type;
        public Vec3 Vertices1, Vertices2;
        public float Radius;

        void IDataRW.ReadFrom(DataStream ds) {
            ds.ReadData(ref Node);
            ds.ReadStruct(ref Type);

            if((uint)Type > 3)
                throw new ParsingException();

            ds.ReadStruct(ref Vertices1);

            if(Type != ShapeType.Sphere)
                ds.ReadStruct(ref Vertices2);

            if((Type == ShapeType.Sphere) || (Type == ShapeType.Cylinder))
                ds.ReadStruct(ref Radius);
        }

        void IDataRW.WriteTo(DataStream ds) {
            ds.WriteData(ref Node);
            ds.WriteStruct(Type);
            ds.WriteStruct(ref Vertices1);

            if(Type != ShapeType.Sphere)
                ds.WriteStruct(ref Vertices2);

            if((Type == ShapeType.Sphere) || (Type == ShapeType.Cylinder))
                ds.WriteStruct(Radius);
        }

        public enum ShapeType : uint {
            Box,
            Plane,
            Sphere,
            Cylinder,
        }
    }
}
