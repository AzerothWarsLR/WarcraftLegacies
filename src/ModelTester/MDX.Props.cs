using System.Collections.Generic;
using ModelTester.Objects;
using ModelTester.Parsers;

namespace ModelTester {
    using static MainBlocks;

    public partial class MDX {
        public ModelInfo Info;
        public Sequence[] Sequences;
        public GlobalSequence[] GlobalSequences;
        public Material[] Materials;
        public Texture[] Textures;
        public TextureAnimation[] TextureAnimations;
        public Geoset[] Geosets;
        public GeosetAnimation[] GeosetAnimations;
        public Bone[] Bones;
        public Light[] Lights;
        public Helper[] Helpers;
        public Attachment[] Attachments;
        public Pivot[] Pivots;
        public ParticleEmitter[] ParticleEmitters;
        public ParticleEmitter2[] ParticleEmitters2;
        public RibbonEmitter[] RibbonEmitters;
        public EventObject[] EventObjects;
        public Camera[] Cameras;
        public CollisionShape[] CollisionShapes;

        static readonly Dictionary<MainBlocks, IBlockParser> _knownParsers = new Dictionary<MainBlocks, IBlockParser>
        {
            [MODL] = new StructParser<ModelInfo>(mdx => ref mdx.Info),
            [SEQS] = new StructArrayParser<Sequence>(mdx => ref mdx.Sequences),
            [GLBS] = new StructArrayParser<GlobalSequence>(mdx => ref mdx.GlobalSequences),
            [MTLS] = new DataArrayParser<Material>(mdx => ref mdx.Materials),
            [TEXS] = new StructArrayParser<Texture>(mdx => ref mdx.Textures),
            [TXAN] = new DataArrayParser<TextureAnimation>(mdx => ref mdx.TextureAnimations),
            [GEOS] = new DataArrayParser<Geoset>(mdx => ref mdx.Geosets),
            [GEOA] = new DataArrayParser<GeosetAnimation>(mdx => ref mdx.GeosetAnimations),
            [BONE] = new DataArrayParser<Bone>(mdx => ref mdx.Bones),
            [LITE] = new DataArrayParser<Light>(mdx => ref mdx.Lights),
            [HELP] = new DataArrayParser<Helper>(mdx => ref mdx.Helpers),
            [ATCH] = new DataArrayParser<Attachment>(mdx => ref mdx.Attachments),
            [PIVT] = new StructArrayParser<Pivot>(mdx => ref mdx.Pivots),
            [PREM] = new DataArrayParser<ParticleEmitter>(mdx => ref mdx.ParticleEmitters),
            [PRE2] = new DataArrayParser<ParticleEmitter2>(mdx => ref mdx.ParticleEmitters2),
            [RIBB] = new DataArrayParser<RibbonEmitter>(mdx => ref mdx.RibbonEmitters),
            [EVTS] = new DataArrayParser<EventObject>(mdx => ref mdx.EventObjects),
            [CAMS] = new DataArrayParser<Camera>(mdx => ref mdx.Cameras),
            [CLID] = new DataArrayParser<CollisionShape>(mdx => ref mdx.CollisionShapes),
        };

        public BinaryBlock[] UnknownBlocks;
    }

    interface IBlockParser {
        public void ReadFrom(MDX mdx, DataStream ds, uint blockSize);
        public void WriteTo(MDX mdx, DataStream ds);
        public bool HasData(MDX mdx);
    }
}
