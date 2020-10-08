using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6 {
    class Program {
        static void Main(string[] args) {
            
            var numbers = new List<int> { 9,7,-5,4,2,5,4,2,-4,8,-1,6,4,};
            Console.WriteLine($"平均値:{numbers.Average()}");
            Console.WriteLine($"合計:{numbers.Sum()}");
            Console.WriteLine($"最小値:{numbers.Where((x => x >= 0)).Min()}");
            Console.WriteLine($"最大値:{numbers.Max()}");

            bool exits = numbers.Any(n => n % 7 == 0);

            var results = numbers.Where(n => n > 0).Take(3);
            foreach (var item in results) {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            var books = Books.GetBooks();
            Console.WriteLine($"本の平均価格:{books.Average(n=>n.Price)}");
            Console.WriteLine($"本の合計価格:{books.Sum(n=>n.Price)}");
            Console.WriteLine($"本のページが最大:{books.Max(n=>n.Pages)}");
            Console.WriteLine($"高価な本:{books.Max(n => n.Price)}");
            Console.WriteLine($"タイトルに物語がある冊数:{books.Count(x=>x.Title.Contains("物語"))}");

            //600ページを超える書籍があるか
            Console.WriteLine("600ページを超える書籍が");
            Console.WriteLine(books.Any(n => n.Pages > 600)? "ある" : "ない");
            //すべてが200ページ以上の書籍か
            Console.WriteLine("すべての本は200ページ以上か");
            Console.WriteLine(books.All(n => n.Pages >= 200) ? "Yes" : "No");
            //400ページを超える本は何冊目か？(FirstOrDefaultメソッド)
            //var book = books.FirstOrDefault(x => x.Pages > 400);
            //int i;
            //for (i=0;i<books.Count;i++) {
            //    if (books[i].Title==book.Title) {
            //        break;
            //    }
            //}

            var count = books.FindIndex(x => x.Pages > 400);
            Console.WriteLine($"400ページを超える本は{count+1}冊目です");

            //本の値段が400円以上のものを３冊表示
            var fprice = books.Where(x => x.Price >= 400).Take(3);
            foreach (var item in fprice) {
                
                    Console.Write(item.Title + " ");
            }
            Console.WriteLine(numbers.Where(n=>n>0));
            foreach (var item in ) {

            }















            //6-1.1
            var numberss = new int[] { 5, 10, 17, 93, 21, 10, 40, 21, 3, 35 };
            Console.WriteLine($"最大値は:{numberss.Max()}");

            //6-1.2
            var la = numberss.Length-2;
            foreach (var item in numberss.Skip(la)) {
                Console.WriteLine(item);
            }

            //6-1.3
            Console.WriteLine(numbers.w);
        }


    }
    
}
