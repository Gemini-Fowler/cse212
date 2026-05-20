using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue a single item and dequeue it.
    // Expected Result: "A" is returned.
    // Defect(s) Found:
    // - Dequeue never removes the item from the list, so the queue never shrinks.
    // - Loop condition in Dequeue uses (index < Count - 1), skipping the last item.
    public void TestPriorityQueue_EnqueueSingle()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);

        var result = pq.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Enqueue items with different priorities.
    // Expected Result: Highest priority ("High") is removed first.
    // Defect(s) Found:
    // - Highest priority detection is incorrect because the loop skips the last element.
    // - Dequeue does not remove the returned item from the queue.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 5);
        pq.Enqueue("High", 10);

        var result = pq.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Items with equal priority should be dequeued FIFO.
    // Expected Result: A, then B, then C.
    // Defect(s) Found:
    // - Code incorrectly uses >= instead of >, causing later items to override earlier ones.
    // - FIFO behavior for ties is broken.
    public void TestPriorityQueue_FIFOTie()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 7);
        pq.Enqueue("B", 7);
        pq.Enqueue("C", 7);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities with FIFO tie-breaking.
    // Expected Result: B, C, D, A.
    // Defect(s) Found:
    // - Loop skips last element, so highest priority may be missed.
    // - FIFO tie-breaking is incorrect due to >= comparison.
    // - Dequeue does not remove the item.
    public void TestPriorityQueue_Mixed()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 3);
        pq.Enqueue("B", 10);
        pq.Enqueue("C", 10);
        pq.Enqueue("D", 5);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found:
    // - No defect here; this part of the code works correctly.
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}
