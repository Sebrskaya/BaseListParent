using System;
/*BaseList<string> arrayList = new ArrayList<string>();
BaseList<string> arrayList2 = new ArrayList<string>();
BaseList<int> arrayList3 = new ArrayList<int>();
BaseList<int> chainList = new ChainList<int>();
*/

/*arrayList2.Add(1);
arrayList2.Add(5);
arrayList2.Add(10);
arrayList2.Add(11);
arrayList2.Add(5);*/

/*arrayList2.Add("e1");
arrayList2.Add("E2");
arrayList2.Add("B3");
arrayList2.Add("M4");
arrayList2.Add("S5");*/

/*arrayList.Add(1);
arrayList.Add(5);
arrayList.Add(10);
arrayList.Add(11);
arrayList.Add(5);*/


/*chainList.Add(0);
chainList.Add(3);
chainList.Add(991);
chainList.Add(37);
chainList.Add(4);

chainList.Sort();
chainList.Print();*/

/*arrayList.Add("Turing");
arrayList.Add("Elon");
arrayList.Add("Bill");
arrayList.Add("Mark");
arrayList.Add("Steve");*/

//arrayList.Sort();

//arrayList2.Print();

//arrayList3 = arrayList + arrayList2;

//Console.WriteLine(arrayList != arrayList2);

//arrayList3.Print();

public abstract class BaseList<T> where T : IComparable
{
    protected int count = 0;
    public int Count
    {
        get { return count; }
    }//дописать
    public abstract void Add(T a);
    public abstract void Delete(int pos);
    public abstract void Insert(int pos, T a);
    public abstract void Clear();

    /*int CompareTo(BaseList<T> other)
    {
        if (count == other.Count)
            return 0;
        if (count > other.Count)
            return 1;
        if (count < other.Count)
            return -1;
    }
    */
    public abstract int Lenght();
    public abstract T this[int i]
    { set; get; }
    public abstract void Print();
    public void Assign(BaseList<T> sourceList)//A.Assign(B) => A превращается в В
    {
        Clear();
        for (int i = 0; i < sourceList.Count; i++)
        {
            Add(sourceList[i]);
        }
    }
    public void AssignTo(BaseList<T> destList)//A.Assign(B) => B превращается в A
    {
        destList.Assign(this);
    }
    public abstract BaseList<T> Clone();
    public virtual void Sort()
    {
        for (int current = 0; current < count - 1; current++)
        {
            int minIndex = current;

            for (int i = current + 1; i < count; i++)
                if (this[minIndex].CompareTo(this[i]) == 1)
                    minIndex = i;



            T buf = this[current];
            this[current] = this[minIndex];
            this[minIndex] = buf;
        }
    }
    public bool EqualsTo(BaseList<T> otherList)
    {
        if (this.Count != otherList.Count)
            return false;
        for (int i = 0; i < otherList.Count; i++)
            if (this[i].CompareTo(otherList[i]) != 1)
                return false;

        return true;
    }
    public void CheckIndex(int index, int flag = 0)
    {
        // для случаев, когда вызывается не метод Insert(int index, int data)
        if (flag != 1 && (index >= count || count == 0)) throw new EWrongIndex("Индекс вне диапазона");

        // для случаев, когда вызываается метод Insert(int index, int data)
        if (flag == 1 && index > count) throw new EWrongIndex("Индекс вне диапазона");
    }
    public int GetCount { get { return count; } } // количество элементов
    public static BaseList<T> operator +(BaseList<T> list1, BaseList<T> list2)
    {
        BaseList<T> newList = list1.Clone(); // а может проблема в Assign? Возможно следует убрать Clear()?
                                             // просто почему мы не можем применить Clone() и с помощью Asssing(BaseList sourceList) дописать недостающие элементы?
        for (int i = 0; i < list2.GetCount; i++)
        {
            newList.Add(list2[i]);
        }
        return newList;
    }

    public static bool operator ==(BaseList<T> list1, BaseList<T> list2)
    {
        if (list1.EqualsTo(list2)) 
            return true;
        return false;
    }

    public static bool operator !=(BaseList<T> list1, BaseList<T> list2)
    {
        if (list1.EqualsTo(list2)) 
            return false;
        return true;
    }
}
