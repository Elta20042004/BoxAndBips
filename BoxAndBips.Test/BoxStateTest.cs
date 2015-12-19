using System;
using BoxAndBips.State;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BoxAndBips.Test
{
    [TestClass]
    public class BoxStateTest
    {
        [TestMethod]
        public void DoStep_BoxAndSpeedBip_StateChangedAsFastBox()
        {
            Mock<IWorld> worldMock = new Mock<IWorld>();

            worldMock.Setup(t => t.M)
                .Returns(1);
            worldMock.Setup(t => t.N)
                .Returns(2);
            worldMock.Setup(t => t.GetCell(0, 1))
                .Returns(new SpeedBip());

            Box boxA = new Box("Lena", 15, worldMock.Object);
            boxA.X = 0;
            boxA.Y = 0;

            boxA.StepRight();
            Assert.IsTrue(boxA.State is FastBoxState);
        }

        [TestMethod]
        public void DoStep_BoxAndLifeBip_BoxLifeIncreased()
        {
            Mock<IWorld> worldMock = new Mock<IWorld>();

            worldMock.Setup(t => t.M)
                .Returns(1);
            worldMock.Setup(t => t.N)
                .Returns(2);
            worldMock.Setup(t => t.GetCell(0, 1))
                .Returns(new LifeBip(5));

            Box boxA = new Box("Lena", 15, worldMock.Object);
            boxA.X = 0;
            boxA.Y = 0;

            boxA.StepRight();
            Assert.AreEqual(19, boxA.State.Life);
        }

        [TestMethod]
        public void CheckLife_BoxIsDead_StateChangeAsDeadBoxState()
        {
            Mock<IWorld> worldMock = new Mock<IWorld>();

            worldMock.Setup(t => t.M)
                .Returns(1);
            worldMock.Setup(t => t.N)
                .Returns(2);

            Box boxA = new Box("Lena", 1, worldMock.Object);
            boxA.X = 0;
            boxA.Y = 0;

            boxA.StepRight();
            Assert.IsTrue(boxA.State is DeadBoxState);
        }
    }
}
