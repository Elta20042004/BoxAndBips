using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoxAndBips.Rule;
using Moq;

namespace BoxAndBips.Test
{
    [TestClass]
    public class DominanceRuleTest
    {
        [TestMethod]
        public void Apply_BoxAndBoxRight_ApplyDone()
        {
            DominanceRule dominanceRule = new DominanceRule();
            Mock<IWorld> worldMock = new Mock<IWorld>();

            worldMock.Setup(t => t.M).Returns(2);
            worldMock.Setup(t => t.N).Returns(1);


            Box boxA = new Box("Lena", 15, worldMock.Object);
            boxA.X = 0;
            boxA.Y = 0;

            Box boxB = new Box("Alex", 10, worldMock.Object);
            boxB.X = 0;
            boxB.Y = 1;

            worldMock.Setup(t => t.GetCell(0, 1)).Returns(boxB);

            dominanceRule.Apply(boxA, worldMock.Object);

            Assert.AreEqual(25, boxA.State.Life);
            Assert.AreEqual(0, boxB.State.Life);
        }

        [TestMethod]
        public void Apply_BoxAndBoxDown_ApplyDone()
        {
            DominanceRule dominanceRule = new DominanceRule();
            Mock<IWorld> worldMock = new Mock<IWorld>();

            worldMock.Setup(t => t.M).Returns(1);
            worldMock.Setup(t => t.N).Returns(2);


            Box boxA = new Box("Lena", 15, worldMock.Object);
            boxA.X = 0;
            boxA.Y = 0;

            Box boxB = new Box("Alex", 10, worldMock.Object);
            boxB.X = 1;
            boxB.Y = 0;

            worldMock.Setup(t => t.GetCell(1, 0)).Returns(boxB);

            dominanceRule.Apply(boxA, worldMock.Object);

            Assert.AreEqual(25, boxA.State.Life);
            Assert.AreEqual(0, boxB.State.Life);
        }

        [TestMethod]
        public void Apply_BoxAndBoxDown_ApplyNotDone()
        {
            DominanceRule dominanceRule = new DominanceRule();
            Mock<IWorld> worldMock = new Mock<IWorld>();

            worldMock.Setup(t => t.M).Returns(1);
            worldMock.Setup(t => t.N).Returns(3);


            Box boxA = new Box("Lena", 15, worldMock.Object);
            boxA.X = 0;
            boxA.Y = 0;

            Box boxB = new Box("Alex", 10, worldMock.Object);
            boxB.X = 2;
            boxB.Y = 0;

            worldMock.Setup(t => t.GetCell(2, 0)).Returns(boxB);

            dominanceRule.Apply(boxA, worldMock.Object);

            Assert.AreEqual(15, boxA.State.Life);
            Assert.AreEqual(10, boxB.State.Life);
        }

        [TestMethod]
        public void Apply_BoxAndBoxRight_ApplyNotDone()
        {
            DominanceRule dominanceRule = new DominanceRule();
            Mock<IWorld> worldMock = new Mock<IWorld>();

            worldMock.Setup(t => t.M).Returns(3);
            worldMock.Setup(t => t.N).Returns(1);


            Box boxA = new Box("Lena", 15, worldMock.Object);
            boxA.X = 0;
            boxA.Y = 0;

            Box boxB = new Box("Alex", 10, worldMock.Object);
            boxB.X = 0;
            boxB.Y = 2;

            worldMock.Setup(t => t.GetCell(0, 2)).Returns(boxB);

            dominanceRule.Apply(boxA, worldMock.Object);

            Assert.AreEqual(15, boxA.State.Life);
            Assert.AreEqual(10, boxB.State.Life);
        }
    }
}
