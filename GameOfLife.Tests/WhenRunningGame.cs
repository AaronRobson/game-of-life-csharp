namespace GameOfLife.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenRunningGame
    {
        private GameOfLifeClass _game;

        const int GliderOffset = 3;

        [SetUp]
        public void Given()
        {
            _game = new GameOfLifeClass();
            _game.Set_Max(10, 10);
        }

        [TestCase]
        public void InitialPopulationIsZero()
        {
            Assert.That(_game.Get_Population_As_Int(), Is.Zero);
        }

        [TestCase]
        public void InitialGenerationsIsZero()
        {
            Assert.That(_game.Get_Generation_As_Int(), Is.Zero);
        }

        [TestCase]
        public void GliderPopulationIsCorrect()
        {
            _game.Spawn_Glider();
            Assert.That(_game.Get_Population_As_Int(), Is.EqualTo(5));
        }

        [TestCase]
        public void GliderCellsAreCorrect()
        {
            _game.Spawn_Glider();
            Assert.That(_game.Get_Current_Point(1 + GliderOffset, 0 + GliderOffset), Is.True);
            Assert.That(_game.Get_Current_Point(2 + GliderOffset, 1 + GliderOffset), Is.True);
            Assert.That(_game.Get_Current_Point(0 + GliderOffset, 2 + GliderOffset), Is.True);
            Assert.That(_game.Get_Current_Point(1 + GliderOffset, 2 + GliderOffset), Is.True);
            Assert.That(_game.Get_Current_Point(2 + GliderOffset, 2 + GliderOffset), Is.True);
        }

        [TestCase]
        public void GliderIterationPopulationIsCorrect()
        {
            _game.Spawn_Glider();
            _game.Iteration();
            Assert.That(_game.Get_Population_As_Int(), Is.EqualTo(5));
        }

        [TestCase]
        public void GliderIterationGenerationsIsCorrect()
        {
            _game.Spawn_Glider();
            _game.Iteration();
            Assert.That(_game.Get_Generation_As_Int(), Is.EqualTo(1));
        }

        [TestCase]
        public void GliderIterationCellsAreCorrect()
        {
            _game.Spawn_Glider();
            _game.Iteration();
            Assert.That(_game.Get_Current_Point(0 + GliderOffset, 1 + GliderOffset), Is.True);
            Assert.That(_game.Get_Current_Point(2 + GliderOffset, 1 + GliderOffset), Is.True);
            Assert.That(_game.Get_Current_Point(1 + GliderOffset, 2 + GliderOffset), Is.True);
            Assert.That(_game.Get_Current_Point(2 + GliderOffset, 2 + GliderOffset), Is.True);
            Assert.That(_game.Get_Current_Point(1 + GliderOffset, 3 + GliderOffset), Is.True);
        }
    }
}
