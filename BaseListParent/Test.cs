using System.Collections.Generic;

public class TestBaseList
{
    public static int CountErrorArrayList { get; set; }
    public static int CountErrorLinkedList { get; set; }
    public static void Main()
    {
        BaseList<int> arrayList = new ArrayList<int>();
        BaseList<int> chainList = new ChainList<int>();

        BaseList<int> arrayList2 = new ArrayList<int>();
        BaseList<int> chainList2 = new ChainList<int>();
        /*Filling(arrayList, linkedList);
        Console.WriteLine($"Количество исключений ArrayList: {CountErrorArrayList}");
        Console.WriteLine($"Количество исключений LinkedList: {CountErrorLinkedList}");

        arrayList.Print();
        Console.Write('\n');
        linkedList.Print();
        Console.WriteLine($"linkedList.GetCount =  {linkedList.GetCount}");
        Console.WriteLine($"arrayList.GetCount =  {arrayList.GetCount}");*/

        // заполняем массив и список и проверяем метод Assign
        Console.WriteLine("Assign");
        Filling(arrayList, chainList);
        arrayList.Assign(chainList);
        chainList.Assign(arrayList);
        Console.WriteLine($"Количество исключений ArrayList: {CountErrorArrayList}");
        Console.WriteLine($"Количество исключений LinkedList: {CountErrorLinkedList}");
        Console.WriteLine($"linkedList.GetCount =  {chainList.GetCount}");
        Console.WriteLine($"arrayList.GetCount =  {arrayList.GetCount}");
        arrayList.Print();
        Console.Write('\n');
        chainList.Print();
        CountErrorArrayList = 0;
        CountErrorLinkedList = 0;

        // заполняем массив и список и проверяем метод AssignTo
        Console.WriteLine("AssignTo");
        arrayList.Clear();
        chainList.Clear();
        Filling(arrayList, chainList);
        arrayList.AssignTo(chainList);
        chainList.AssignTo(arrayList);
        Console.WriteLine($"Количество исключений ArrayList: {CountErrorArrayList}");
        Console.WriteLine($"Количество исключений LinkedList: {CountErrorLinkedList}");
        Console.WriteLine($"linkedList.GetCount =  {chainList.GetCount}");
        Console.WriteLine($"arrayList.GetCount =  {arrayList.GetCount}");
        arrayList.Print();
        Console.Write('\n');
        chainList.Print();
        CountErrorArrayList = 0;
        CountErrorLinkedList = 0;

        // заполняем массив и список и проверяем метод Clone
        Console.WriteLine("Clone");
        arrayList.Clear();
        chainList.Clear();
        Filling(arrayList, chainList);
        chainList2 = arrayList.Clone();
        arrayList2 = chainList.Clone();
        Console.WriteLine($"Количество исключений ArrayList: {CountErrorArrayList}");
        Console.WriteLine($"Количество исключений LinkedList: {CountErrorLinkedList}");
        Console.WriteLine($"linkedList.GetCount =  {chainList.GetCount}");
        Console.WriteLine($"arrayList.GetCount =  {arrayList.GetCount}");
        arrayList.Print();
        Console.Write('\n');
        chainList.Print();
        CountErrorArrayList = 0;
        CountErrorLinkedList = 0;

        Console.WriteLine("\nВторые листы, проверка сложения");

        arrayList2 = arrayList + chainList;
        chainList2 = chainList + arrayList;
        Console.WriteLine($"Сравнение с помощью ==: {arrayList2 == chainList2}");
        Console.WriteLine($"Сравнение с помощью !=: {arrayList2 != chainList2}");

        arrayList2.Print();
        chainList2.Print();

        Console.WriteLine("Программа завершена!");
        Console.WriteLine($"linkedList.GetCount =  {chainList.GetCount}");
        Console.WriteLine($"arrayList.GetCount =  {arrayList.GetCount}");
    }


    static void Filling(BaseList<int> arrayList, BaseList<int> chainList)
    {
        Random rnd = new Random();
        for (int i = 0; i < 100; i++)
        {
            int choose = rnd.Next(0, 5);
            int data = rnd.Next(0, 100);
            int index = rnd.Next(0, 100);

            /*arrayList.Print();
            linkedList.Print();
            Console.WriteLine($"нач chainList.GetCount =  {chainList.GetCount}");
            Console.WriteLine($"нач arrayList.GetCount =  {arrayList.GetCount}");*/


            switch (choose)
            {
                case 0:
                    try
                    {
                        arrayList.Add(data);

                    }
                    catch (EWrongIndex ex)
                    {
                        //Console.WriteLine($"{ex.Message}");
                        CountErrorArrayList++;
                    }
                    break;
                case 1:
                    try
                    {
                        arrayList.Insert(index, data);
                    }
                    catch (EWrongIndex ex)
                    {
                        //Console.WriteLine($"{ex.Message}");
                        CountErrorArrayList++;
                    }
                    break;
                case 2:
                    try
                    {
                        arrayList.Delete(index);
                    }
                    catch (EWrongIndex ex)
                    {
                        //Console.WriteLine($"{ex.Message}");
                        CountErrorArrayList++;
                    }
                    break;
                case 13:
                    try
                    {
                        arrayList.Clear();
                    }
                    catch (EWrongIndex ex)
                    {
                        //Console.WriteLine($"{ex.Message}");
                        CountErrorArrayList++;
                    }
                    break;
                case 14:
                    try
                    {
                        arrayList.Sort();
                    }
                    catch (EWrongIndex ex)
                    {
                        //Console.WriteLine($"{ex.Message}");
                        CountErrorArrayList++;
                    }
                    break;
            }

            switch (choose)
            {
                case 0:
                    try
                    {
                        chainList.Add(data);

                    }
                    catch (EWrongIndex ex)
                    {
                        //Console.WriteLine($"{ex.Message}");
                        CountErrorLinkedList++;
                    }
                    break;
                case 1:
                    try
                    {
                        chainList.Insert(index, data);
                    }
                    catch (EWrongIndex ex)
                    {
                        //Console.WriteLine($"{ex.Message}");
                        CountErrorLinkedList++;
                    }
                    break;
                case 2:
                    try
                    {
                        chainList.Delete(index);
                    }
                    catch (EWrongIndex ex)
                    {
                        //Console.WriteLine($"{ex.Message}");
                        CountErrorLinkedList++;
                    }
                    break;
                case 13:
                    try
                    {
                        chainList.Clear();
                    }
                    catch (EWrongIndex ex)
                    {
                        //Console.WriteLine($"{ex.Message}");
                        CountErrorLinkedList++;
                    }
                    break;
                case 14:
                    try
                    {
                        chainList.Sort();
                    }
                    catch (EWrongIndex ex)
                    {
                        //Console.WriteLine($"{ex.Message}");
                        CountErrorLinkedList++;
                    }
                    break;
            }
            if (!CheckElements(arrayList, chainList))
            {
                Console.WriteLine("LinkedList");
                Console.WriteLine($"\nchoose = {choose}");
                Console.WriteLine($"index = {index}");
                Console.WriteLine($"data = {data}");

                arrayList.Print();
                chainList.Print();
                break;
            }
        }
    }

    static bool CheckElements(BaseList<int> arrayList, BaseList<int> linkedList)
    {
        if (linkedList.GetCount != arrayList.GetCount)
            return false;
        for (int i = 0; i < linkedList.GetCount; i++)
        {
            //Console.WriteLine(i);
            if (arrayList[i].CompareTo(linkedList[i]) == -1)
            {
                Console.WriteLine($"{i} Element!!!!!");
                Console.WriteLine($"arrayList = {arrayList[i]}");
                Console.WriteLine($"linkedList = {linkedList[i]}");
                return false;
            }
        }
        return true;
    }
}
