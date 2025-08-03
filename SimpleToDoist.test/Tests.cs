using SimpleToDoist;
using SimpleToDoist.TasksCreation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
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

    public class ObjectDuplicationTests
    {
        [Fact]
        public void Test07_Duplication1_Object1IsNull()
        {
            // Arrange
            TaskItem task1 = null;
            TaskItem task2 = new TaskItem(0);



            // Act & Assert
            Assert.Throws<NullReferenceException>(() => task1.CopyTaskPropertiesFrom(task2));

            // Assert
            Assert.Null(task1);
            Assert.NotNull(task2);
            
        }

        [Fact]
        public void Test08_Duplication1_Object2IsNull()
        {
            // Arrange
            TaskItem task1 = new TaskItem(0);
            TaskItem task2 = null;

            // Act
            task1.CopyTaskPropertiesFrom(task2);

            // Assert
            Assert.NotNull(task1);
            Assert.Null(task2);
        }

        [Fact]
        public void Test09_Duplication1_ObjectsAreValid()
        {
            // Arrange
            TaskItem task1 = new TaskItem(0);
            TaskItem task2 = new TaskItem(11);

            // Act
            task1.CopyTaskPropertiesFrom(task2);

            // Assert
            Assert.NotNull(task1);
            Assert.NotNull(task2);

            Assert.Equal(task1.TaskName, task2.TaskName);
            Assert.Equal(task1.TaskTitle, task2.TaskTitle);
            Assert.Equal(task1.TaskDescription, task2.TaskDescription);
            Assert.Equal(task1.TaskCompletion, task2.TaskCompletion);
            Assert.Equal(task1.TaskDueDate, task2.TaskDueDate);
            Assert.Equal(task1.TaskPriority, task2.TaskPriority);
            Assert.Equal(task1.TaskCategory, task2.TaskCategory);
            Assert.Equal(task1.TaskLabelColor, task2.TaskLabelColor);
            Assert.Equal(task1.TaskLabel.Text, task2.TaskLabel.Text);
            Assert.Equal(task1.TaskLabelToolTip, task2.TaskLabelToolTip);
            Assert.Equal(task1.TaskCheckBox.Checked, task2.TaskCheckBox.Checked);

            Assert.Equal(task1, task2);
        }

        [Fact]
        public void Test10_Duplication1_ObjectsAreValid_PropertiesSetUp()
        {
            // Arrange
            TaskItem task1 = new TaskItem(0);
            TaskItem task2 = new TaskItem(11);

            // Act
            task1.CopyTaskPropertiesFrom(task2);

            // Assert
            Assert.NotNull(task1);
            Assert.NotNull(task2);

            Assert.Equal(task1.TaskName, task2.TaskName);
            Assert.Equal(task1.TaskTitle, task2.TaskTitle);
            Assert.Equal(task1.TaskDescription, task2.TaskDescription);
            Assert.Equal(task1.TaskCompletion, task2.TaskCompletion);
            Assert.Equal(task1.TaskDueDate, task2.TaskDueDate);
            Assert.Equal(task1.TaskPriority, task2.TaskPriority);
            Assert.Equal(task1.TaskCategory, task2.TaskCategory);
            Assert.Equal(task1.TaskLabelColor, task2.TaskLabelColor);
            Assert.Equal(task1.TaskLabel.Text, task2.TaskLabel.Text);
            Assert.Equal(task1.TaskLabelToolTip, task2.TaskLabelToolTip);
            Assert.Equal(task1.TaskCheckBox.Checked, task2.TaskCheckBox.Checked);

            Assert.Equal(task1, task2);
        }
    }
}