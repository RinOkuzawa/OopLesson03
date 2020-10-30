using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7 {
    class Program {
        static void Main(string[] args) {
            #region
            //var employeeDict = new Dictionary<int,Employee> {
            //    { 100,new Employee(100,"清水遼久")},
            //    { 112,new Employee(112,"芹沢洋和")},
            //    { 125,new Employee(125,"岩瀬奈央子")},
            //};

            //Console.WriteLine($"{employeeDict.Sum(x=>x.Value.Id)}");

            //foreach (KeyValuePair<int,Employee> item in employeeDict.Where(x=>x.Value.Id%2==0)) {
            //    Console.WriteLine($"{item.Value.Id} = {item.Value.Name}");
            //}

            //var employees = new List<Employee>() {
            //    new Employee(100,"清水遼久"),
            //    new Employee(112,"芹沢洋和"),
            //    new Employee(125,"岩瀬奈央子"),
            //    new Employee(143,"山田太郎"),
            //    new Employee(148,"池田次郎"),
            //    new Employee(152,"高田三郎"),
            //    new Employee(155,"石川幸也"),
            //    new Employee(161,"中沢信也"),

            //};

            ////Idが偶数のみディクショナリに変換する
            //var employeeDict = employees.Where(emp => emp.Id % 2 == 0).ToDictionary(emp => emp.Id);

            //foreach (KeyValuePair<int, Employee> item in employeeDict) {
            //    Console.WriteLine($"{item.Value.Id}{item.Value.Name}");
            //}

            //var dict = new Dictionary<MonthDay, string> {
            //    {new MonthDay(3,5),"珊瑚の日" },
            //    {new MonthDay(8,4),"箸の日" },
            //    {new MonthDay(10,3),"登山の日" },
            //};

            //var md = new MonthDay(8, 4);
            //var s = dict[md];
            //Console.WriteLine(s);











            //var lines = File.ReadAllLines("sample.txt");
            //var we = new WordsExtractor(lines);
            //foreach (var word in we.Extract()) {
            //    Console.WriteLine(word);
            //}










            //static public void DuplicateKeySample() {
        //    // ディクショナリの初期化
        //    var dict = new Dictionary<string, List<string>>() {
        //       { "PC", new List<string> { "パーソナル コンピュータ", "プログラム カウンタ", } },
        //       { "CD", new List<string> { "コンパクト ディスク", "キャッシュ ディスペンサー", } },
        //    };
        //
        //    // ディクショナリに追加
        //    var key = "EC";
        //    var value = "電子商取引";
        //    if (dict.ContainsKey(key)) {
        //        dict[key].Add(value);
        //    } else {
        //        dict[key] = new List<string> { value };
        //    }
        //
        //    // ディクショナリの内容を列挙
        //    foreach (var item in dict) {
        //        foreach (var term in item.Value) {
        //            Console.WriteLine("{0} : {1}", item.Key, term);
        //        }
        //    }
            #endregion
            
            // コンストラクタ呼び出し
            var abbrs = new Abbreviations();

            // Addメソッドの呼び出し例
            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核兵器不拡散条約");

            //問題7.2.3
            //Countプロパティを呼び出して数を出力させる
            //
            var count = abbrs.Count;
            Console.WriteLine(count);
            //Removeメソッドを呼び出して要素を削除する
            if (abbrs.Remove("NPT")) {
                Console.WriteLine("削除成功");
            } else {
                Console.WriteLine("削除失敗");
            }
            Console.WriteLine();

            //問題7.2.4
            foreach (var item in abbrs.Where(x => x.Key.Length == 3)) {
                Console.WriteLine(item.Key);
            }

            // インデクサの利用例
            var names = new[] { "WHO", "FIFA", "NPT", };
            foreach (var name in names) {
                var fullname = abbrs[name];
                if (fullname == null)
                    Console.WriteLine("{0}は見つかりません", name);
                else
                    Console.WriteLine("{0}={1}", name, fullname);
            }
            Console.WriteLine();

            // ToAbbreviationメソッドの利用例
            var japanese = "東南アジア諸国連合";
            var abbreviation = abbrs.ToAbbreviation(japanese);
            if (abbreviation == null)
                Console.WriteLine("{0} は見つかりません", japanese);
            else
                Console.WriteLine("「{0}」の略語は {1} です", japanese, abbreviation);
            Console.WriteLine();

            // FindAllメソッドの利用例
            foreach (var item in abbrs.FindAll("国際")) {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }
            Console.WriteLine();
        }
        
    }
}
