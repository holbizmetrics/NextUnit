namespace NextUnit.VisualStudioExtension
{
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.ComponentModel.Design;
    using Task = System.Threading.Tasks.Task;

    namespace NextUnit.VisualStudioExtension
    {
        internal sealed class RunNextUnitTestCommand
        {
            // Command set identifier from .vsct file
            public static readonly Guid CommandSet = new Guid("c2f5c3b2-7bcd-4a12-b36f-5fb3e5b5a1c2");
            public const int CommandId = 0x0100; // The command ID

            private readonly AsyncPackage package;

            // Constructor that gets a handle to the package
            private RunNextUnitTestCommand(AsyncPackage package, OleMenuCommandService commandService)
            {
                this.package = package ?? throw new ArgumentNullException(nameof(package));

                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(this.Execute, menuCommandID);
                commandService.AddCommand(menuItem);
            }

            public static async Task InitializeAsync(AsyncPackage package)
            {
                OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
                await package.JoinableTaskFactory.SwitchToMainThreadAsync();
                new RunNextUnitTestCommand(package, commandService);
            }

            private void Execute(object sender, EventArgs e)
            {
                // Your existing ExecuteAsync logic here
            }
        }
    }
}
