using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Core;
using DryIoc;

namespace DemoGame
{
    internal class Program
    {
        private readonly ILogger _logger;

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

        public Program(ILogger logger)
        {
            _logger = logger;
            _logger.Write("calling Program.ctor");
        }

        private void Run(string[] args)
        {
            _logger.Write(string.Format("Args: {0}", string.Join(";", args)));
        }
    }
}
