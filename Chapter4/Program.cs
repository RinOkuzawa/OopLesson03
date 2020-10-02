using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4 {
    class Program {
        static void Main(string[] args) {
            //4-2.1
            var yms = new YearMonth[] {
                new YearMonth(2001, 1),
                new YearMonth(1996, 3),
                new YearMonth(2020, 10),
                new YearMonth(2011, 3),
                new YearMonth(1992, 12),
            };

            // 4-2.2
            Console.WriteLine("Q4-2.2");
            foreach (var ym in yms) {
                Console.WriteLine(ym);
            }
            Console.WriteLine();



            // 4-2.4
            Console.WriteLine("Q4-2.4");
            var yearmonth = Find21(yms);
            if (yearmonth == null) {
                Console.WriteLine("21世紀のデータはありません");
            } else {
                Console.WriteLine(yearmonth);
            }
            Console.WriteLine();


            // 4-2.5
            Console.WriteLine("Q4-2.5");
            var array = yms.Select(ym => ym.AddOneMonth()).ToArray();
            foreach (var ym in array) {
                Console.WriteLine(ym);
            }
        }

        // 4-2.3
        static YearMonth Find21(YearMonth[] yms) {
            foreach (var ym in yms) {
                if (ym.Is21Century) {
                    return ym;
                } 
            }
            return null;
        }
    }
}
