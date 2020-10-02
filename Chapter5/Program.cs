using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5 {
    class Program {
        static void Main(string[] args) {
            //5-1
            var s1 = Console.ReadLine();
            var s2 = Console.ReadLine();
            if (string.Compare(s1,s2,ignoreCase:true)==0) {
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }

            //5-2
            var line = Console.ReadLine();
            int num;
            if (int.TryParse(line, out num)) {
                Console.WriteLine($"{num:#,0}" );
            } else {
                Console.WriteLine("数値文字列ではないです");
            }

            //5-3
            var st = "Jackdaws love my big sphinx of quartz";

            //5-3.1
            int spaces = st.Count(c => c == ' ');
            Console.WriteLine("空白数:{0}", spaces);

            //5-3.2
            var chage = st.Replace("big", "small");
            Console.WriteLine(chage);

            //5-3.3
            int cnt = st.Split(' ').Length;
            Console.WriteLine($"単語数:{cnt}");

            //5-3.4
            var unforth = st.Split(' ').Where(s => s.Length <= 4);
            foreach (var unforths in unforth) {
                Console.WriteLine(unforths);
            }

            //5-3.5
            var array = st.Split(' ').ToArray();
            if (array.Length > 0) {
                var sb = new StringBuilder(array[0]);
                foreach (var word in array) {
                    sb.Append(word);
                    sb.Append(" ");
                }
                Console.WriteLine(sb);
            }

            //5-4
            string textbk = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            //var nyan = 
            
        }
    }
}
