using SimpleToDoist;
using SimpleToDoist.TasksCreation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static SimpleToDoist.AppConstants;
using static SimpleToDoist.TaskSaving;

namespace SimpleToDoist.test
{
    public class EssentialTests
    {
        // TaskItem Constructor Tests
        [Fact]
        public void Test_01_Constructor_InvalidParams1_NegativeIndex()
        {
            // Arrange
            int index = -1;
            const int negativeIndexError = -1;

            // Act
            TaskItem taskItem = new TaskItem(index);

            // Assert
            Assert.Equal(negativeIndexError, taskItem.TaskIndex);
            Assert.Equal("", taskItem.TaskName);
            
            Assert.False(taskItem.TaskCompletion);
            Assert.NotNull(taskItem);
        }

        [Fact]
        public void Test_02_Constructor_InvalidParams2_EmptyTaskName()
        {
            // Arrange
            int index = 0;
            const int desiredIndex = 0;
            string taskName = "";

            // Act
            TaskItem taskItem = new TaskItem(index);
            taskItem.TaskName = taskName;

            // Assert
            Assert.Equal(desiredIndex, taskItem.TaskIndex);
            Assert.Equal("", taskItem.TaskName);
            
            Assert.False(taskItem.TaskCompletion);
            Assert.NotNull(taskItem);
        }

        [Fact]
        public void Test_03_Constructor_ValidParams1()
        {
            // Arrange
            int index = 0;
            const int desiredIndex = 0;
            string desiredTaskName = string.Concat(newTaskName, desiredIndex.ToString());

            // Act
            TaskItem taskItem = new TaskItem(index);

            // Assert
            Assert.Equal(desiredIndex, taskItem.TaskIndex);
            Assert.Equal(desiredTaskName, taskItem.TaskName);
            
            Assert.False(taskItem.TaskCompletion);
            Assert.NotNull(taskItem);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(999)]
        public void Test_04_ValidateTaskParams1_IndexValidation(
            int index)
        {
            // Arrange
            const string validString = "valid";

            // Act
            TaskItem taskItem = new TaskItem(index);
            taskItem.TaskName = taskItem.TaskTitle = validString;
            bool isValid = taskItem.ValidateTaskParams();

            // Assert
            if (index < 0)
            {
                Assert.False(isValid);
            } 
            else
            {
                Assert.True(isValid);
            }

            
            Assert.False(taskItem.TaskCompletion);
            Assert.NotNull(taskItem);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("1")]
        [InlineData("---")]
        [InlineData("//*-+\\{{}}[[]](())\"\'|;")]
        [InlineData("item")]
        [InlineData("taskName")]
        [InlineData("someLongStringToTestIfThereIsNoProblemWithLongerNamesForEitherTaskNameOrTaskTitle")]
        [InlineData("nameWith_SpecialCharacters")]
        [InlineData("nameWith-SpecialCharacters")]
        [InlineData("nameWith.SpecialCharacters")]
        [InlineData(".name-With*Special//Characters_+=-")]
        public void Test_05_ValidateTaskParams2_NameValidation(
            string taskName)
        {
            // Arrange
            int index = 0;
            const string validString = "valid";

            // Act
            TaskItem taskItem = new TaskItem(index);
            taskItem.TaskTitle = validString;

            taskItem.TaskName = taskName;

            bool isValid = taskItem.ValidateTaskParams();

            // Assert
            if (string.IsNullOrWhiteSpace(taskName))
            {
                Assert.False(isValid);
            }
            else
            {
                Assert.True(isValid);
            }

            
            Assert.False(taskItem.TaskCompletion);
            Assert.NotNull(taskItem);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("1")]
        [InlineData("---")]
        [InlineData("//*-+\\{{}}[[]](())\"\'|;")]
        [InlineData("item")]
        [InlineData("taskName")]
        [InlineData("someLongStringToTestIfThereIsNoProblemWithLongerNamesForEitherTaskNameOrTaskTitle")]
        [InlineData("nameWith_SpecialCharacters")]
        [InlineData("nameWith-SpecialCharacters")]
        [InlineData("nameWith.SpecialCharacters")]
        [InlineData(".name-With*Special//Characters_+=-")]
        public void Test_06_ValidateTaskParams3_TitleValidation(
            string taskTitle)
        {
            // Arrange
            int index = 0;

            // Act
            TaskItem taskItem = new TaskItem(index);
            taskItem.TaskTitle = taskTitle;

            bool isValid = taskItem.ValidateTaskParams();

            // Assert
            if (string.IsNullOrWhiteSpace(taskTitle))
            {
                Assert.False(isValid);
            }
            else
            {
                Assert.True(isValid);
            }

            
            Assert.False(taskItem.TaskCompletion);
            Assert.NotNull(taskItem);
        }
    }
}