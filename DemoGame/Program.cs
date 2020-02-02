using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Core;
using DryIoc;
using DryIoc.MefAttributedModel;

namespace DemoGame
{
    internal class Program
    {
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
            var entryPoints = new List<Type>();

            var entryPointAssemblyFiles = Directory.GetFiles(modDirectory, "Mod*.dll");

            Console.WriteLine("Found Mods:");
            Console.WriteLine(string.Join(Environment.NewLine, entryPointAssemblyFiles));

            var entryPointAssemblies = entryPointAssemblyFiles
                .Select(assemblyFile => Assembly.LoadFile(assemblyFile));

            foreach (var entryPointAssembly in entryPointAssemblies)
            {
                var types = entryPointAssembly.GetTypes();
                var entryPointTypes = types
                    .Where(exportedType => exportedType.Name == "EntryPoint");
                entryPoints.AddRange(entryPointTypes);
            }

            Console.WriteLine("Found EntryPoints in Mods:");
            Console.WriteLine(string.Join(Environment.NewLine, entryPoints.Select(type => type.Assembly.GetName().Name)));

            foreach (var entryPoint in entryPoints)
            {
                entryPoint.GetMethod("Register").Invoke(null, new object[] { container });
            }

            container.Register<Program>(Reuse.Singleton);
            return container;
        }

        public Program(ILogger logger)
        {
            logger.Write("calling Program.ctor");
        }

        private void Run(string[] args)
        {
            Console.WriteLine("Args: {0}", string.Join(";", args));
        }
    }
}
