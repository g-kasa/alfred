using Alfred.DataStructures.Lists;

namespace Alfred.DataStructures.UnitTests.Lists
{
    public class ArrayList_Tests
    {
        [Fact]
        public void ArrayList_Insert_TestLengthIncrementWithValidPositionIndex()
        {
            // Arrange
            var list = new ArrayList<int>();
            var positionIndex = 0;
            var value = 1;

            // Act
            list.Insert(positionIndex, value);
            
            // Assert
            Assert.Equal(1, list.Length);
        }

        [Fact]
        public void ArrayList_Insert_TestLengthIncrementWithNegativePositionIndex()
        {
            // Arrange
            var list = new ArrayList<int>();
            var positionIndex = -1;
            var value = 1;

            // Act
            var action = () => list.Insert(positionIndex, value);

            // Assert
            Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Fact]
        public void ArrayList_Insert_TestLengthIncrementWithPositionIndexGreaterThanLength()
        {
            // Arrange
            var list = new ArrayList<int>();
            var positionIndex = 1;
            var value = 1;

            // Act
            list.Insert(positionIndex, value);

            // Assert
            Assert.Equal(1, list.Length);
        }

        [Fact]
        public void ArrayList_Insert_TestLengthIncrementWithPositionIndexGreaterThanCapacity()
        {
            // Arrange
            var list = new ArrayList<int>();
            var positionIndex = 10;
            var value = 1;

            // Act
            list.Insert(positionIndex, value);
            
            // Assert
            Assert.Equal(1, list.Length);
        }

        [Fact]
        public void ArrayList_Insert_TestValueInsertedInTheMiddle()
        {
            // Arrange
            var list = new ArrayList<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            list.Insert(3, 4);
            list.Insert(4, 5);
            var positionIndex = 2;
            var value = 10;

            // Act
            list.Insert(positionIndex, value);
            
            // Assert
            Assert.Equal(value, list[positionIndex]);
            Assert.Equal(5, list[5]);
            Assert.Equal(4, list[4]);
            Assert.Equal(3, list[3]);
        }

        [Fact]
        public void ArrayList_Insert_TestInsertionOfMoreValuesThanCapacity()
        {
            // Arrange
            var list = new ArrayList<int>(2);

            // Act
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            list.Insert(3, 4);
            list.Insert(4, 5);

            // Assert
            Assert.Equal(5, list.Length);
        }

        [Fact]
        public void ArrayList_RemoveAt_TestLengthDecrement()
        {
            // Arrange
            var list = new ArrayList<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            list.Insert(3, 4);
            list.Insert(4, 5);
            var positionIndex = 2;

            // Act
            list.RemoveAt(positionIndex);
            
            // Assert
            Assert.Equal(4, list.Length);
        }

        [Fact]
        public void ArrayList_RemoveAt_TestValueRemovedIsReturned()
        {
            // Arrange
            var list = new ArrayList<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            list.Insert(3, 4);
            list.Insert(4, 5);
            var positionIndex = 2;
            
            // Act
            var value = list.RemoveAt(positionIndex);

            // Assert
            Assert.Equal(3, value);
        }

        [Fact]
        public void ArrayList_RemoveAt_TestLeftShiftingForRemainingValues()
        {
            // Arrange
            var list = new ArrayList<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            list.Insert(3, 4);
            list.Insert(4, 5);
            var positionIndex = 2;

            // Act
            list.RemoveAt(positionIndex);
            
            // Assert
            Assert.Equal(4, list[2]);
            Assert.Equal(5, list[3]);
        }
    }
}
