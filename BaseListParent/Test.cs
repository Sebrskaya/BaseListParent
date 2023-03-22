using System;
BaseList<int> ChainList = new ChainList<int>();
BaseList<int> ArrayList = new ArrayList<int>();
BaseList<int> Brat = new ArrayList<int>();
Random random = new Random();

for (int i = 0; i < 10000; i++)
{
    int method = random.Next(0, 5);
    int pos = random.Next(0, 10001);
    int data = random.Next(0, 100);

    switch (method)
    {
        case 0:
            ChainList.Add(data);
            ArrayList.Add(data);
            break;

        case 1:
            ChainList.Insert(pos, data);
            ArrayList.Insert(pos, data);
            break;

        case 2:
            ChainList.Clear();
            ArrayList.Clear();
            break;

        case 3:
            ChainList.Delete(pos);
            ArrayList.Delete(pos);
            break;

        case 4:
            ChainList[pos] = data;
            ArrayList[pos] = data;
            break;

        case 5:
            ChainList.Sort();
            ArrayList.Sort();
            break;
    }
    if (ArrayList.Lenght() != ChainList.Lenght())
    {
        //Console.WriteLine(i + " Count слетел!");
    }
    //Check Assign \/
    ArrayList.Assign(ChainList);
    if (!ArrayList.EqualsTo(ChainList))
        Console.WriteLine("Assign не работает");
    ChainList.Assign(ArrayList);
    if (!ChainList.EqualsTo(ArrayList))
        Console.WriteLine("Assign не работает");

    //Check Clone
    Brat = ArrayList.Clone();
    if (ArrayList.EqualsTo(Brat) == false)
        Console.WriteLine("Clone не работает");
    Brat = ChainList.Clone();
    if (ArrayList.EqualsTo(Brat) == false)
        Console.WriteLine("Clone не работает");

    //Сравнение листов
    if (ArrayList.EqualsTo(ChainList) == false)
        Console.WriteLine("Ar и Ch Листы не равны");
    if (ArrayList.EqualsTo(Brat) == false)
        Console.WriteLine("Ar и Br Листы не равны");
    if (ArrayList.EqualsTo(Brat) == false)
        Console.WriteLine("Ch и Br Листы не равны");
}

ChainList.Print();
ArrayList.Print();
Brat.Print();
