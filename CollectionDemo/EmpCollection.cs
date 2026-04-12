using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionDemo;


class Employee1
{
    // variable
    // arrary
    // collection
    // generic collection

    public void VariableDemo()
    {
        int i = 10;
        Console.WriteLine(i); // 10
        i = 20;
        Console.WriteLine(i); // 20
        i = 30;
        Console.WriteLine(i); // 30

        int[] arraryi= new int[3]; // strongly types
        arraryi[0] = 10;
        arraryi[1] = 20;
        arraryi[2] = 30;

        // string , boolean

        ArrayList arrList = new ArrayList();
        arrList.Add(10); // boxing
        arrList.Add("Ashua");
        arrList.Add(true);
        arrList.Add(120.12);
        foreach (var item in arrList)
        {
            Console.WriteLine(item);
        }

        Stack stk = new Stack();
        stk.Push(10);
        stk.Push("Ashua");
        stk.Push(true);
        foreach (var item in stk)
        {
            Console.WriteLine(item);
        }
        stk.Pop();

        Queue queue = new Queue();
        queue.Enqueue(10);
        queue.Enqueue("Ashua"); 
        queue.Enqueue(true);
        foreach (var item in queue)
        {
            Console.WriteLine(item);
        }
        queue.Dequeue();

        Hashtable hashtable = new Hashtable();
        hashtable.Add(1, "Ashua");
        hashtable.Add(2, "Kumar");
        hashtable.Add(3, "Singh");
            

        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        dictionary.Add(1, "Ashua");
        dictionary.Add(2, "Kumar");
        dictionary.Add(3, "Singh");

        // Very important
        List<int> list = new List<int>();
        IEnumerable<int> enumerable = list as IEnumerable<int>;
        IQueryable<int> queryable = list as IQueryable<int>;



    }


}

