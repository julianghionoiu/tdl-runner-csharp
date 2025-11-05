using System;
using System.Collections.Generic;
using BeFaster.App.Solutions.CHK;
using BeFaster.App.Solutions.FIZ;
using BeFaster.App.Solutions.HLO;
using BeFaster.App.Solutions.SUM;
using BeFaster.Runner;
using BeFaster.Runner.Utils;
using Newtonsoft.Json.Linq;
using TDL.Client;
using TDL.Client.Queue.Abstractions;
using TDL.Client.Runner;

namespace BeFaster.App
{
    internal class SendCommandToServer
    {
        /// <summary>
        /// ~~~~~~~~~~ Running the system: ~~~~~~~~~~~~~
        ///
        ///   From IDE:
        ///      Configure the "BeFaster.App" solution to Run on External Console then run.
        ///
        ///   From command line:
        ///      dotnet run --project src\BeFaster.App
        ///
        ///   To run your unit tests locally:
        ///      Run the "BeFaster.App.Tests" project.
        ///        or
        ///      dotnet test
        ///
        /// ~~~~~~~~~~ The workflow ~~~~~~~~~~~~~
        ///
        ///   By running this file you interact with a challenge server.
        ///   The interaction follows a request-response pattern:
        ///        * You are presented with your current progress and a list of actions.
        ///        * You trigger one of the actions by typing it on the console.
        ///        * After the action feedback is presented, the execution will stop.
        ///
        ///   +------+-----------------------------------------------------------------------+
        ///   | Step | The usual workflow                                                    |
        ///   +------+-----------------------------------------------------------------------+
        ///   |  1.  | Run this file.                                                        |
        ///   |  2.  | Start a challenge by typing "start".                                  |
        ///   |  3.  | Read the description from the "challenges" folder.                    |
        ///   |  4.  | Locate the file corresponding to your current challenge in:           |
        ///   |      |   src\BeFaster.App\Solutions                                          |
        ///   |  5.  | Replace the following placeholder exception with your solution:       |
        ///   |      |   throw new SolutionNotImplementedException()                         |
        ///   |  6.  | Deploy to production by typing "deploy".                              |
        ///   |  7.  | Observe the output, check for failed requests.                        |
        ///   |  8.  | If passed, go to step 1.                                              |
        ///   +------+-----------------------------------------------------------------------+
        ///
        ///   You are encouraged to change this project as you please:
        ///        * You can use your preferred libraries.
        ///        * You can use your own test framework.
        ///        * You can change the file structure.
        ///        * Anything really, provided that this file stays runnable.
        ///
        /// </summary>
        /// <param name="args">Action.</param>
        private static void Main(string[] args)
        {
            var entryPointMapping = new EntryPointMapping();

            var runner = new QueueBasedImplementationRunner.Builder().
                SetConfig(Utils.GetRunnerConfig()).
                WithSolutionFor("sum", entryPointMapping.Sum).
                WithSolutionFor("hello", entryPointMapping.Hello).
                WithSolutionFor("fizz_buzz", entryPointMapping.FizzBuzz).
                WithSolutionFor("checkout", entryPointMapping.Checkout).
                WithSolutionFor("rabbit_hole", entryPointMapping.RabbitHole).
                WithSolutionFor("render_house", entryPointMapping.RenderHouse).
                WithSolutionFor("amazing_maze", entryPointMapping.AmazingMaze).
                WithSolutionFor("ultimate_maze", entryPointMapping.UltimateMaze).
                WithSolutionFor("increment", entryPointMapping.Increment).
                WithSolutionFor("to_uppercase", entryPointMapping.ToUppercase).
                WithSolutionFor("letter_to_santa", entryPointMapping.LetterToSanta).
                WithSolutionFor("count_lines", entryPointMapping.CountLines).
                WithSolutionFor("array_sum", entryPointMapping.ArraySum).
                WithSolutionFor("int_range", entryPointMapping.IntRange).
                WithSolutionFor("filter_pass", entryPointMapping.FilterPass).
                WithSolutionFor("inventory_add", entryPointMapping.InventoryAdd).
                WithSolutionFor("inventory_size", entryPointMapping.InventorySize).
                WithSolutionFor("inventory_get", entryPointMapping.InventoryGet).
                WithSolutionFor("waves", entryPointMapping.Waves).
                Create();

            ChallengeSession.ForRunner(runner)
                .WithConfig(Utils.GetConfig())
                .WithActionProvider(new UserInputAction(args))
                .Start();

            if (Console.IsInputRedirected == false) // Ensure there is a console
            {
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey();
            }
        }
    }
}
