

using System.Collections.Generic;
using TDL.Client.Queue.Abstractions;
using BeFaster.App.Solutions.CHK;
using BeFaster.App.Solutions.RBT;
using BeFaster.App.Solutions.HOC;
using BeFaster.App.Solutions.AMZ;
using BeFaster.App.Solutions.ULT;
using BeFaster.App.Solutions.DMO;
using BeFaster.App.Solutions.FIZ;
using BeFaster.App.Solutions.HLO;
using BeFaster.App.Solutions.SUM;

namespace BeFaster.App
{
    /// <summary>
    /// Maps RPC events to instance method calls with correctly typed parameters.
    /// </summary>
    internal class EntryPointMapping
    {
        private readonly SumSolution sumSolution;
        private readonly HelloSolution helloSolution;
        private readonly FizzBuzzSolution fizzBuzzSolution;
        private readonly CheckoutSolution checkoutSolution;
        private readonly RabbitHoleSolution rabbitHoleSolution;
        private readonly HouseOfCardsSolution houseOfCardsSolution;

        private readonly AmazingSolution amazingSolution;
        private readonly UltimateSolution ultimateSolution;
        private readonly DemoRound1Solution demoRound1Solution;
        private readonly DemoRound2Solution demoRound2Solution;
        private readonly DemoRound3Solution demoRound3Solution;
        private readonly DemoRound4n5Solution demoRound4n5Solution;

        public EntryPointMapping()
        {
            sumSolution = new SumSolution();
            helloSolution = new HelloSolution();
            fizzBuzzSolution = new FizzBuzzSolution();
            checkoutSolution = new CheckoutSolution();
            rabbitHoleSolution = new RabbitHoleSolution();
            houseOfCardsSolution = new HouseOfCardsSolution();
            amazingSolution = new AmazingSolution();
            ultimateSolution = new UltimateSolution();
            demoRound1Solution = new DemoRound1Solution();
            demoRound2Solution = new DemoRound2Solution();
            demoRound3Solution = new DemoRound3Solution();
            demoRound4n5Solution = new DemoRound4n5Solution();
        }

        public object Sum(List<ParamAccessor> p) =>
            sumSolution.Sum(p[0].GetAsInteger(), p[1].GetAsInteger());

        public object Hello(List<ParamAccessor> p) =>
            helloSolution.Hello(p[0].GetAsString());

        public object FizzBuzz(List<ParamAccessor> p) =>
            fizzBuzzSolution.FizzBuzz(p[0].GetAsInteger());

        public object Checkout(List<ParamAccessor> p) =>
            checkoutSolution.Checkout(p[0].GetAsString());

        public object RabbitHole(List<ParamAccessor> p) =>
            rabbitHoleSolution.RabbitHole(
                p[0].GetAsInteger(),
                p[1].GetAsInteger(),
                p[2].GetAsString(),
                p[3].GetAsMapOf<string>()
            );

       public object RenderHouse(List<ParamAccessor> p) =>
            houseOfCardsSolution.RenderHouse(
                p[0].GetAsString(),
                p[1].GetAsMapOf<string>()
            );

        public object AmazingMaze(List<ParamAccessor> p) =>
            amazingSolution.AmazingMaze(
                p[0].GetAsInteger(),
                p[1].GetAsInteger(),
                p[2].GetAsMapOf<string>()
            );

        public object UltimateMaze(List<ParamAccessor> p) =>
            ultimateSolution.UltimateMaze(
                p[0].GetAsInteger(),
                p[1].GetAsInteger(),
                p[2].GetAsMapOf<string>()
            );

        // Demo Round 1

        public object Increment(List<ParamAccessor> p) =>
            demoRound1Solution.Increment(p[0].GetAsInteger());

        public object ToUppercase(List<ParamAccessor> p) =>
            demoRound1Solution.ToUppercase(p[0].GetAsString());

        public object LetterToSanta(List<ParamAccessor> p) =>
            demoRound1Solution.LetterToSanta();

        public object CountLines(List<ParamAccessor> p) =>
            demoRound1Solution.CountLines(p[0].GetAsString());

        // Demo Round 2

        public object ArraySum(List<ParamAccessor> p) =>
            demoRound2Solution.ArraySum(p[0].GetAsListOf<int>());

        public object IntRange(List<ParamAccessor> p) =>
            demoRound2Solution.IntRange(p[0].GetAsInteger(), p[1].GetAsInteger());

        public object FilterPass(List<ParamAccessor> p) =>
            demoRound2Solution.FilterPass(p[0].GetAsListOf<int>(), p[1].GetAsInteger());

        // Demo Round 3

        public object InventoryAdd(List<ParamAccessor> p) =>
            demoRound3Solution.InventoryAdd(p[0].GetAsObject<InventoryItem>(), p[1].GetAsInteger());

        public object InventorySize(List<ParamAccessor> p) =>
            demoRound3Solution.InventorySize();

        public object InventoryGet(List<ParamAccessor> p) =>
            demoRound3Solution.InventoryGet(p[0].GetAsString());

        // Demo Round 4 and 5

        public object Waves(List<ParamAccessor> p) =>
            demoRound4n5Solution.Waves(p[0].GetAsInteger());
    }
}
