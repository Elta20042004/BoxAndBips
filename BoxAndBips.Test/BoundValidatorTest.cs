using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BoxAndBips.Test
{
    [TestClass]
    public class BoundValidatorTest
    {
        [TestMethod]
        public void Validator_OneCellWorld_NotValid()
        {
            BoundValidator validator = new BoundValidator();
            Mock<IWorld> worldMock = new Mock<IWorld>();
            worldMock.Setup(t => t.M).Returns(1);
            worldMock.Setup(t => t.N).Returns(1);

            bool result = validator.Validate(worldMock.Object, 1, 1);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validator_OneCellWorld_Valid()
        {
            BoundValidator validator = new BoundValidator();
            Mock<IWorld> worldMock = new Mock<IWorld>();
            worldMock.Setup(t => t.M).Returns(1);
            worldMock.Setup(t => t.N).Returns(1);

            bool result = validator.Validate(worldMock.Object,0, 0);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validator_OneCellWorldNegativeCoords_NotValid()
        {
            BoundValidator validator = new BoundValidator();
            Mock<IWorld> worldMock = new Mock<IWorld>();
            worldMock.Setup(t => t.M).Returns(1);
            worldMock.Setup(t => t.N).Returns(1);

            bool result = validator.Validate(worldMock.Object, -5, -10);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validator_TenVTenWorld_Valid()
        {
            BoundValidator validator = new BoundValidator();
            Mock<IWorld> worldMock = new Mock<IWorld>();
            worldMock.Setup(t => t.M).Returns(10);
            worldMock.Setup(t => t.N).Returns(10);

            bool result = validator.Validate(worldMock.Object, 5, 6);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validator_TenVTenWorldY_NotValid()
        {
            BoundValidator validator = new BoundValidator();
            Mock<IWorld> worldMock = new Mock<IWorld>();
            worldMock.Setup(t => t.M).Returns(10);
            worldMock.Setup(t => t.N).Returns(10);

            bool result = validator.Validate(worldMock.Object, 5, 11);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validator_TenVTenWorldX_NotValid()
        {
            BoundValidator validator = new BoundValidator();
            Mock<IWorld> worldMock = new Mock<IWorld>();
            worldMock.Setup(t => t.M).Returns(10);
            worldMock.Setup(t => t.N).Returns(10);

            bool result = validator.Validate(worldMock.Object, 11, 1);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validator_TenVTenWorldXY_NotValid()
        {
            BoundValidator validator = new BoundValidator();
            Mock<IWorld> worldMock = new Mock<IWorld>();
            worldMock.Setup(t => t.M).Returns(10);
            worldMock.Setup(t => t.N).Returns(10);

            bool result = validator.Validate(worldMock.Object, 11, 15);
            Assert.IsFalse(result);
        }

       
    }
}
