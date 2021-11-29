#nullable enable

using System;
using System.IO;
using System.Text;
using CSharpLua;
using War3Net.CodeAnalysis.Jass;
using War3Net.CodeAnalysis.Transpilers;

namespace AzerothWarsCSharp.Launcher
{
    public static class ScriptTranspiler
    {
        /// <summary>
        /// Transpile a string of JASS code into a string of the equivalent Lua code.
        /// </summary>
        /// <param name="inputJass"></param>
        /// <returns></returns>
        public static string JassToLua(string inputJass)
        {
            //Register common.j and blizzard.j files
            var jassHelperFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Warcraft III", "JassHelper");
            var commonJPath = Path.Combine(jassHelperFolder, "common.j");
            var blizzardJPath = Path.Combine(jassHelperFolder, "blizzard.j");
            var transpiler = new JassToLuaTranspiler();
            transpiler.RegisterJassFile(JassSyntaxFactory.ParseCompilationUnit(File.ReadAllText(commonJPath)));
            transpiler.RegisterJassFile(JassSyntaxFactory.ParseCompilationUnit(File.ReadAllText(blizzardJPath)));

            var luaCompilationUnit = transpiler.Transpile(JassSyntaxFactory.ParseCompilationUnit(inputJass));

            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream, leaveOpen: true);
            var luaRenderOptions = new LuaSyntaxGenerator.SettingInfo
            {
                Indent = 2,
                IsCommentsDisabled = true,
            };

            var luaRenderer = new LuaRenderer(luaRenderOptions, writer);
            luaRenderer.RenderCompilationUnit(luaCompilationUnit);
            writer.Flush();

            return Encoding.UTF8.GetString(stream.ToArray(), 0, (int) stream.Length);
        }
    }
}