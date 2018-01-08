using System;
using System.Collections.Generic;

namespace DemoCollections {
    class DemoList {
        static void Main(string[] args) {
            IList<String> list = new List<String>();
            for (int i=0; i<10; i++)
                list.Add(i.ToString());
            foreach (var i in list)
                Console.Write(i + " ");
            list.Add("10");

            Console.Write("\n");
            foreach (var i in list)
                Console.Write(i + " ");

            Console.Write("\n");
            IEnumerator<String> it = list.GetEnumerator();
            while (it.MoveNext()) {
                Console.Write(it.Current + " ");
            }

            Console.WriteLine();
        }
    }
}
