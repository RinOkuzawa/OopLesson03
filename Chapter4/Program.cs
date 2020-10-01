using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4 {
    class Program {
        static void Main(string[] args) {
            string code = "12345";

            var message = GetMessage(code) ?? DefaultMessage();
            Console.WriteLine(message);
        }

        //スタブ
        private static object GetMessage(string code) {
            return "スパイダー";
        }
        //スタブ
        private static object DefaultMessage() {
            return "親愛なるあなたの隣人";
        }

        
    }
}
