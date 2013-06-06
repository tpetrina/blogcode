using System;
using Mono.Cecil;

namespace Cecilian
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var assembly = AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("TestModule", new Version()), "TestModule.exe", ModuleKind.Console);

            var entryType = new TypeDefinition("TestModule", "Program", TypeAttributes.Class | TypeAttributes.Public);
            var mainMethod = new MethodDefinition("Main", MethodAttributes.Public | MethodAttributes.Static, assembly.MainModule.TypeSystem.Void);
            entryType.Methods.Add(mainMethod);
            assembly.MainModule.Types.Add(entryType);
            assembly.Write("TestModule.exe");
        }
    }
}
