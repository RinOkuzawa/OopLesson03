using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6 {
    class Program {
        static void Main(string[] args) {
            //整数の例
            var numbers = new List<int> { 19, 17, 15, 24, 12, 25, 14, 20, 12, 28, 19, 30, 24 };

            //var strings = numbers.Select(n => n.ToString("0000")).ToArray();
            //foreach (var str in strings) {
            //    Console.WriteLine(str);
            //}

            numbers.Select(n => n.ToString("0000")).Distinct().ToList().ForEach(s => Console.Write(s + " "));
            Console.WriteLine();

            var sortednumbers = numbers.OrderBy(n=>n).Distinct();
            foreach (var item in sortednumbers) {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            //文字列の例
            var words = new List<string> { 
                "Microsoft", "Apple", "Google", "Oracle","Facebook" };

            var lower = words.Select(s => s.ToLower()).ToArray();
            foreach (var item in lower) {
                Console.WriteLine(item);
            }

            ////オブジェクトの例
            //var books = Books.GetBooks();
            ////タイトルリスト
            //var titles = books.Select(x => x.Title).ToArray();
            //foreach (var tt in titles) {
            //    Console.Write(tt+" ");
            //}

            //Console.WriteLine();

            //var desc = books.OrderByDescending(n => n.Pages);
            //foreach (var item in desc) {
            //    Console.Write(item.Title+item.Pages + " ");
            //}
            //Console.WriteLine();
            Console.WriteLine();









            //6-1.1
            Console.WriteLine("---6-1.1---");
            var numberss = new int[] { 5, 10, 17, 93, 21, 10, 40, 21, 3, 35 };
            Console.WriteLine($"最大値は:{numberss.Max()}");
            Console.WriteLine();

            //6-1.2
            Console.WriteLine("---6-1.2---");
            var la = numberss.Length-2;
            foreach (var item in numberss.Skip(la)) {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            //6-1.3
            Console.WriteLine("---6-1.3---");
            var ss = numberss.Select(n => n.ToString()).ToArray();
            foreach (var str in ss) {
                Console.Write(str + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //6-1.4
            Console.WriteLine("---6-1.4---");
            var small = numberss.OrderBy(n => n).Take(3);
            foreach (var item in small) {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //6-1.5
            Console.WriteLine("---6-1.5---");
            var bigten = numberss.Where(n => n>10).Distinct();
            foreach (var item in bigten) {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //6-2.1
            var books = new List<Book> {
               new Book { Title = "C#プログラミングの新常識C#", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET　MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            //すべての書籍から「C#」の文字がいくつあるかをカウントする
            int count = 0;
            foreach (var book in books) {
                for (int i=0;i<book.Title.Length-1;i++) {
                    if ((book.Title[i] == 'C') && (book.Title[i + 1] == '#')) {
                        count++;
                    }
                }
            }
            Console.WriteLine($"文字列ぬ含まれる「C#」の数は:{count}");

            Console.WriteLine("---6-2.1---");
            var mg = books.FirstOrDefault(x => x.Title == "ワンダフル・C#ライフ");
            Console.WriteLine($"ワンダフル・C#ライフは 価格:{mg.Price} ページ数:{mg.Pages}");
            Console.WriteLine();


            Console.WriteLine("---6-2.2---");
            var ct = books.Count(x => x.Title.Contains("C#"));
            Console.WriteLine($"C#が含まれている書籍の数は:{ct}");
            Console.WriteLine();

            Console.WriteLine("---6-2.3---");
            var avg = books.Where(x => x.Title.Contains("C#")).Average(x=>x.Pages);
            Console.WriteLine($"C#がタイトルに含まれる書籍の平均ページ数:{avg}");
            Console.WriteLine();

            Console.WriteLine("---6-2.4---");
            var max = books.FirstOrDefault(x => x.Price >= 4000);
            Console.WriteLine($"4000円以上の最初の本のタイトルは:{max.Title}");
            Console.WriteLine();

            Console.WriteLine("---6-2.5---");
            Console.WriteLine($"4000円未満の本で最大ページ数:{books.Where(x => x.Price < 4000).Max(x => x.Pages)}");
            Console.WriteLine();

            Console.WriteLine("---6-2.6---");
            var tk = books.Where(x => x.Pages >= 400).OrderByDescending(x => x.Price);
            foreach (var item in tk) {
                Console.WriteLine($"タイトル:{item.Title} 価格:{item.Price}");
            }
            Console.WriteLine();

            Console.WriteLine("---6-2.7---");
            var booook = books.Where(x=>x.Title.Contains("C#")&&x.Pages<=500);
            foreach (var item in booook) {
                Console.WriteLine($"{item.Title}");
            }
        }
    }
    
}
