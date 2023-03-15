
public abstract class BaseList
{
    protected int count = 0;
    public int getCount 
    { 
        get { return count; } 
    }//дописать
    public abstract void Add(int a);
    public abstract void Delete(int pos);
    public abstract void Insert(int pos, int a);
    public abstract void Clear();

    public abstract int Lenght();
    public abstract int this[int i]
    { set; get; }
    public abstract void Print();
    public void Assign(BaseList sourceList)//A.Assign(B) => A превращается в В
    {
        Clear();
        for (int i = 0; i < sourceList.getCount; i++)
        {
            Add(sourceList[i]);
        }
    }
    public void AssignTo(BaseList destList)//A.Assign(B) => B превращается в A
    {
        destList.Assign(this);
    }
    public abstract BaseList Clone();
    public virtual void Sort()
    {
        for (int current = 0; current < count - 1; current++)
        {
            int minIndex = current;

            for (int i = current + 1; i < count; i++)
                if (this[minIndex] > this[i])
                    minIndex = i;
            
                

            int buf = this[current];
            this[current] = this[minIndex];
            this[minIndex] = buf;
        }
    }

}
