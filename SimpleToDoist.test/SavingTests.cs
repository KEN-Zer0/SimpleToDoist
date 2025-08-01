using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SimpleToDoist;
using SimpleToDoist.TasksCreation;
using static SimpleToDoist.TaskSaving;
using static SimpleToDoist.AppConstants;

namespace SimpleToDoist.test
{
    public class SavingTests
    {
        [Fact]
        public void Test_Constructor_InvalidParams1()
        {
            // Arrange
            // Act
            TaskItem taskItem = new TaskItem(1);

            // Assert
            Assert.Null(taskItem);
            Assert.Equal(0, taskItem.TaskIndex);
            Assert.Null(taskItem.TaskName);
            Assert.False(taskItem.TaskCompletion);
        }

        [Fact]
        public void Test_Constructor_InvalidParams2()
        {
            TaskItem taskItem = new TaskItem(0);


        }
    }
}
