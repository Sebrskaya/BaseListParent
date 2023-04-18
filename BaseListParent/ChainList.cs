using System;
using System.Reflection;

public class ChainList<T> : BaseList<T> where T : IComparable
{
    private class Node<T>
    {
        public T Data { set; get; }
        public Node<T>? Next { set; get; }
        public Node(T data, Node<T>? next)
        {
            Data = data;
            Next = next;
        }

    }
    //public class Methods 
    //{
    Node<T> head = null;
    //public int count = 0;

    public override T this[int i]
    {
        get
        {
            CheckIndex(i);
            return GetNode(i).Data;
        }

        set
        {
            CheckIndex(i);
            GetNode(i).Data = value;
        }
    }
    private Node<T> GetNode(int pos)
    {
        Node<T> pred = head;
        if (pred == null)
        {
            //Console.WriteLine("Узлов нет!");
            return null;
        }

        for (int i = 0; i < pos; i++)
        {
            pred = pred.Next;
        }

        return pred;

    }
    public override void Add(T a)
    {
        Node<T> node = new Node<T>(a, null);
        if (count == 0)
        {
            node.Next = null;
            head = node;
            count++;
            return;
        }
        Node<T> pred = GetNode(count - 1);
        pred.Next = node;
        count++;
    }

    public override void Insert(int pos, T a)
    {
        CheckIndex(pos, 1);
        if (pos > count | pos < 0)
        {
            return;
        }
        if (pos == 0)
        {
            head = new Node<T>(a, head);
            count++;
            return;
        }

        Node<T> pred = GetNode(pos - 1);
        pred.Next = new Node<T>(a, pred.Next);
        count++;
    }
    public override void Print()
    {
        Node<T> pred = head;
        //Console.WriteLine("Список:");
        for (int i = 0; i < count; i++)
        {
            Console.Write(pred.Data + " ");
            pred = pred.Next;
        }
        Console.Write("\n");
    }
    public override void Clear()
    {
        count = 0;
        head = null;
    }
    public override void Delete(int pos)
    {
        if (pos < 0 | pos > count - 1 | count == 0)
            return;

        if (count == 1)
        {
            count--;
            return;
        }
        if (pos == 0)
        {
            head = GetNode(pos + 1);
            count--;
            return;
        }

        Node<T> current = GetNode(pos);
        Node<T> pred = GetNode(pos - 1);
        pred.Next = current.Next;
        count--;
    }

    public override int Lenght()
    {
        //Console.WriteLine("List lenght:\n" + count);
        return count;
    }
    public override void Sort()//bubble
    {
        for (int i = 0; i < GetCount; i++)
        {
            Node<T> current = head;
            int flag = 0;
            for (int j = 0; j < GetCount - i - 1; j++)
            {
                if (current.Data.CompareTo(current.Next.Data) == 1)
                {
                    T temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    flag = 1;
                }
                current = current.Next;
            }
            if (flag == 0) break;
        }
    }
    public override BaseList<T> Clone()
    {
        ChainList<T> list = new ChainList<T>();
        list.Assign(this);
        return list;
    }
    //}
}
