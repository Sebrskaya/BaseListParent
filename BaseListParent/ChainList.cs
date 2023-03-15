
public class ChainList : BaseList
{
    private class Node
    {
        public int Data { set; get; }
        public Node Next { set; get; }
        public Node(int data, Node next)
        {
            Data = data;
            Next = next;
        }

    }
    //public class Methods 
    //{
        Node head = null;
        //public int count = 0;

        public override int this[int i]
        {
            get
            {
                if (i < count & i >= 0)
                    return GetNode(i).Data;
                else
                    return 0;
            }

            set
            {
                if (i < count)
                {
                    GetNode(i).Data = value;
                }
            }
        }
        private Node GetNode(int pos)
        {
            Node pred = head;
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
        public override void Add(int a)
        {
            Node node = new Node(a, null);
            if (count == 0)
            {
                node.Next = null;
                head = node;
                count++;
                return;
            }
            Node pred = GetNode(count - 1);
            pred.Next = node;
            count++;
        }

        public override void Insert(int pos, int a)
        {
            if (pos > count | pos < 0)
            {
                return;
            }
            if (pos == 0)
            {
                head = new Node(a, head);
                count++;
                return;
            }

            Node pred = GetNode(pos - 1);
            pred.Next = new Node(a, pred.Next);
            count++;
        }
        public override void Print()
        {
            Node pred = head;
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

            Node current = GetNode(pos);
            Node pred = GetNode(pos - 1);
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

            for (int i = 0; i < count-1; i++)
        {
            for (int j = 0; j < count - i; j++)
            {
                Node current = GetNode(j);
                if (current != null && current.Next != null && current.Data > current.Next.Data)
                {
                    int temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                }
            }
            break;
        }
                
        }
        public override BaseList Clone()
        {
            ChainList list = new ChainList();
            list.Assign(this);
            return list;
        }
    //}
}
