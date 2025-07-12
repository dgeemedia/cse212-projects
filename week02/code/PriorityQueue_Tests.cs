using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 3 items with different priorities. Top priority is in the middle.
    // Expected Result: The item with the highest priority is removed first.
    // Defect(s) Found: None. Behavior matches requirements.

    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
    }


    [TestMethod]
    // Scenario: Add 3 items with the same high priority. Items should be dequeued in order added.
    // Expected Result: FIFO order is preserved among items with equal priority.
    // Defect(s) Found: None. Tie-breaker by insertion order works correctly.

    public void TestPriorityQueue_TieBreaker()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 4);
        priorityQueue.Enqueue("SecondHigh", 4);
        priorityQueue.Enqueue("ThirdHigh", 4);

        Assert.AreEqual("FirstHigh", priorityQueue.Dequeue());
        Assert.AreEqual("SecondHigh", priorityQueue.Dequeue());
        Assert.AreEqual("ThirdHigh", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None. Exception is thrown and message is correct.

    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Enqueue multiple values, dequeue one, then enqueue more values and continue dequeuing.
    // Expected Result: Highest priority item is always returned first, regardless of when it was added.
    // Defect(s) Found: None. Priority order remains correct even after multiple operations.

    public void TestPriorityQueue_AddAfterRemove()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Mid", 3);
        priorityQueue.Enqueue("High", 5);
        Assert.AreEqual("High", priorityQueue.Dequeue());

        priorityQueue.Enqueue("VeryHigh", 10);
        Assert.AreEqual("VeryHigh", priorityQueue.Dequeue());
    }
}