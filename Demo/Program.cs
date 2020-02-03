using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Core;
using DryIoc;

namespace Demo
{
    internal class Program
    {
        private readonly ILogger _logger;

        private readonly IGame _game;

        public static void Main(string[] args)
        {
            var compositionRoot = CreateCompositionRoot();

            var program = compositionRoot.Resolve<Program>();
            program.Run(args);
        }

        private static IContainer CreateCompositionRoot()
        {
            var container = new Container();

            var modDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mods");

            var entryPoints = Directory.GetFiles(modDirectory, "Mod*.dll")
                .Select(Assembly.LoadFile)
                .SelectMany(entryPointAssembly =>
                {
                    return entryPointAssembly.GetTypes()
                        .Where(exportedType => exportedType.Name == "EntryPoint");
                });

            foreach (var entryPoint in entryPoints)
            {
                entryPoint.GetMethod("Register").Invoke(null, new object[] { container });
            }

            container.Register<Program>(Reuse.Singleton);
            return container;
        }

        public Program(ILogger logger, IGame game)
        {
            _logger = logger;
            _game = game;

            _logger.Write("calling Program.ctor");
        }

        private void Run(string[] args)
        {
            _game.Run(args);
        }
    }
}
