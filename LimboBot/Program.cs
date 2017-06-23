using LimboBot.Actions;
using LimboBot.Model.DTO;
using LimboBot.Services.GitHub;
using LimboBot.Services.Slack;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace LimboBot
{
    class Program
    {

        private CommandLineApplication app;
        private LimboSettingsCollection settingGroups;
        private IServiceProvider iocProvider;

        public Program()
        {
            this.app = this.BuildCommandLineApp();
            this.iocProvider = this.BuildServiceProvider();
        }

        public void Start(String[] args)
        {
            this.settingGroups = this.LoadSettings();
            this.app.Execute(args);
        }

        private IServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                .AddTransient<IGitHubService, GitHubService>()
                .AddTransient<ISlackService, SlackService>()
                .BuildServiceProvider();
        }

        private CommandLineApplication BuildCommandLineApp()
        {
            CommandLineApplication app = new CommandLineApplication(false);
            app.Name = "limbo";

            app.Command("scan", (command) =>
            {
                command.Description = "Scans for matching pull requests";
                command.HelpOption("-?|-h|--help");

                command.OnExecute(() =>
                {
                    foreach (LimboSettings settings in this.settingGroups.SettingGroups)
                    {
                        //At this time, no reason to be async
                        var scanAction = new NotifyOpenPullRequestsAction(this.iocProvider, settings);
                        scanAction.Run().Wait();
                    }

                    return 0;
                });
            });

            app.HelpOption("-? | -h | --help");

            return app;
        }

        private LimboSettingsCollection LoadSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("limbo.json");

            IConfigurationRoot config = builder.Build();
            LimboSettingsCollection settings = new LimboSettingsCollection();
            config.Bind(settings);

            return settings;
        }

        /// <summary>
        /// Entry point for command line application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start(args);
        }
    }
}