using System;

// Node class representing one element in the linked list
public class Node<T> {
    public T Data;
    public Node<T> Next;

    public Node(T data) {
        Data = data;
        Next = null;
    }
}

// STACK - LIFO (Last In, First Out)
public class LinkedStack<T> {
    private Node<T> top; // Points to top of the stack

    // O(1) - Add new item to the top
    public void Push(T item) {
        var newNode = new Node<T>(item);
        newNode.Next = top;
        top = newNode;
    }

    // O(1) - Remove top item
    public T Pop() {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
        T value = top.Data;
        top = top.Next;
        return value;
    }

    // O(1) - View top item
    public T Peek() => IsEmpty() ? throw new InvalidOperationException("Empty") : top.Data;

    public bool IsEmpty() => top == null;
}

// QUEUE - FIFO (First In, First Out)
public class LinkedQueue<T> {
    private Node<T> front; // Points to front of the queue
    private Node<T> rear;  // Points to rear of the queue
    private int count = 0;

    // O(1) - Add item to rear
    public void Enqueue(T item) {
        var newNode = new Node<T>(item);
        if (IsEmpty()) front = newNode;
        else rear.Next = newNode;
        rear = newNode;
        count++;
    }

    // O(1) - Remove item from front
    public T Dequeue() {
        if (IsEmpty()) throw new InvalidOperationException("Queue is empty");
        T value = front.Data;
        front = front.Next;
        if (front == null) rear = null;
        count--;
        return value;
    }

    public int Size() => count;
    public bool IsEmpty() => front == null;
}

// Sample Demo
class Program {
    static void Main() {
        Console.WriteLine("STACK (LIFO):");
        var stack = new LinkedStack<int>();
        stack.Push(1);
        stack.Push(2);
        Console.WriteLine("Top: " + stack.Peek());    // Should print 2
        Console.WriteLine("Pop: " + stack.Pop());     // Should print 2

        Console.WriteLine("\nQUEUE (FIFO):");
        var queue = new LinkedQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        Console.WriteLine("Dequeue: " + queue.Dequeue()); // Should print 10
        Console.WriteLine("Size: " + queue.Size());       // Should print 1
    }
}
