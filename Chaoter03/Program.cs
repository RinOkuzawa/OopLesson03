using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaoter03 {
    class Program {
        static void Main(string[] args) {
            //var names = new List<string> {
            //    "Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong Kong",
            //};
            //var query = names.Where(s=>s.Length<=5).ToList() ;
            //
            //
            //foreach (var s in query){
            //    Console.WriteLine(s);
            //    
            //}
            //Console.WriteLine("------");
            //
            //names[0] = "Osaka";
            //foreach (var s in query){
            //    Console.WriteLine(s);
            //}

            //Q3-1
            Console.WriteLine("Q3-1.1");
            var numbers = new List<int> {
                12,87,94,14,53,20,40,35,76,91,31,17,48
            };

            //Q3-1.1
            var exits = numbers.Exists(n => (n % 9 == 0) || (n % 8 == 0));
            if (exits) {
                Console.WriteLine("存在しています");
            } else {
                Console.WriteLine("存在していません");
            }


            Console.WriteLine();

            //Q3-1.2
            Console.WriteLine("Q3-1.2");
            numbers.ForEach(n => Console.Write(n / 2.0 + ","));

            Console.WriteLine("");
            Console.WriteLine();

            //Q3-1.3
            Console.WriteLine("Q3-1.3");
            var big = numbers.Where(n => n >= 50);
            foreach (var n in big) {
                Console.Write(n + ",");
            }

            Console.WriteLine("");
            Console.WriteLine();

            //Q3-1.4
            Console.WriteLine("Q3-1.4");
            var list = numbers.Select(n => n * 2).ToList();
            foreach (var n in list) {
                Console.Write(n + ",");
            }

            Console.WriteLine("");
            Console.WriteLine();

            //Q3-2
            Console.WriteLine("Q3-2.1");
            var names = new List<string> {
                 "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            //Q3-2.1
            Console.Write("都市名を入力してください:");
            do {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) //何も入力されていなかったら終了
                    break;
                var index = names.FindIndex(s => s == line);
                Console.WriteLine(index);
            } while (true);

            Console.WriteLine();

            //Q3-2.2
            Console.WriteLine("Q3-2.2");
            var count = names.Count(s => s.Contains('o'));
            Console.WriteLine(count);

            Console.WriteLine();

            //Q3-2.3
            Console.WriteLine("Q3-2.3");
            var selected = names.Where(s => s.Contains('o')).ToArray();
            foreach (var name in selected) {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            //Q3-2.4
            Console.WriteLine("Q3-2.4");
            var selectedd = names.Where(s => s.StartsWith("B")).Select(s => s.Length);
            foreach (var length in selectedd) {
                Console.WriteLine(length);
            }
        }
    }
}
