using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BoxAndBips.Test
{
    [TestClass]
    public class RandomRobotTest
    {
        [TestMethod]
        public void DoStep_StepUp_CanStep()
        {
            Mock<IWorld> worldMock = new Mock<IWorld>();
            worldMock.Setup(t => t.M).Returns(2);
            worldMock.Setup(t => t.N).Returns(1);
            Box b = new Box("Lena", 1, worldMock.Object);
            b.X = 1;
            b.Y = 0;
            Box[] box = new Box[] { b };

            RandomRobot rB = new RandomRobot(box);
            rB.DoStep();
            Assert.AreEqual(0, b.X);
            Assert.AreEqual(0, b.Y);
        }

        [TestMethod]
        public void DoStep_StepDown_CanStep()
        {
            Mock<IWorld> worldMock = new Mock<IWorld>();
            worldMock.Setup(t => t.M).Returns(2);
            worldMock.Setup(t => t.N).Returns(1);
            Box b = new Box("Alex", 1, worldMock.Object);
            b.X = 0;
            b.Y = 0;
            Box[] box = new Box[] { b };

            RandomRobot rB = new RandomRobot(box);
            rB.DoStep();
            Assert.AreEqual(1, b.X);
            Assert.AreEqual(0, b.Y);
        }

        [TestMethod]
        public void DoStep_StepRight_CanStep()
        {
            Mock<IWorld> worldMock = new Mock<IWorld>();
            worldMock.Setup(t => t.M).Returns(1);
            worldMock.Setup(t => t.N).Returns(2);
            Box b = new Box("Alisa", 1, worldMock.Object);
            b.X = 0;
            b.Y = 0;
            Box[] box = new Box[] { b };

            RandomRobot rB = new RandomRobot(box);
            rB.DoStep();
            Assert.AreEqual(0, b.X);
            Assert.AreEqual(1, b.Y);
        }
     
        [TestMethod]
        public void DoStep_StepLeft_CanStep()
        {
            Mock<IWorld> worldMock = new Mock<IWorld>();
            worldMock.Setup(t => t.M).Returns(1);
            worldMock.Setup(t => t.N).Returns(2);
            Box b = new Box("BoB", 1, worldMock.Object);
            b.X = 0;
            b.Y = 1;
            Box[] box = new Box[] { b };

            RandomRobot rB = new RandomRobot(box);
            rB.DoStep();
            Assert.AreEqual(0, b.X);
            Assert.AreEqual(0, b.Y);
        }

        [TestMethod]
        public void DoStep_Step_CanNotStep()
        {
            Mock<IWorld> worldMock = new Mock<IWorld>();
            worldMock.Setup(t => t.M).Returns(1);
            worldMock.Setup(t => t.N).Returns(1);
            Box b = new Box("BoB", 1, worldMock.Object);
            b.X = 0;
            b.Y = 0;
            Box[] box = new Box[] { b };

            RandomRobot rB = new RandomRobot(box);
            rB.DoStep();
            Assert.AreEqual(0, b.X);
            Assert.AreEqual(0, b.Y);
        }

    }
}
