
BaseList ChainList = new ChainList.Methods();
BaseList ArrayList = new ArrayList();
BaseList Brat = new ArrayList();
Random random = new Random();

for (int i = 0; i < 10; i++)
{
    int method = random.Next(0, 0);
    int pos = random.Next(0, 10001);
    int data = random.Next(0, 100);

    switch (method)
    {
        case 0:
            ChainList.Add(data);
            ArrayList.Add(data);
            break;

        case 11:
            ChainList.Insert(pos, data);
            ArrayList.Insert(pos, data);
            break;

        case 21:
            ChainList.Clear();
            ArrayList.Clear();
            break;

        case 31:
            ChainList.Delete(pos);
            ArrayList.Delete(pos);
            break;

        case 41:
            ChainList[pos] = data;
            ArrayList[pos] = data;
            break;
    }
    if (ArrayList.Lenght() != ChainList.Lenght())
    {
        //Console.WriteLine(i + " Count слетел!");
    }
}
for (int i = 0; i < ChainList.Lenght(); i++)
{
    if (ArrayList[i] != ChainList[i])
    {
        Console.WriteLine(i + " Элементы не ровны!");
    }
}
ChainList.Sort();
ArrayList.Sort();
ArrayList.Clone();
ChainList.Assign(ArrayList);
ChainList.Print();
ArrayList.Print();
Brat.Print();
Brat = ArrayList.Clone();
Brat.Print();
