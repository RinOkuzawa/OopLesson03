using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SendMailApp {
    public class Config { 
        //単一のインスタンス
        private static Config instance;
        //インスタンスの取得
        public static Config GetInstance() {
            if (instance == null) {
                instance = new Config();
            }
            return instance;
        }

        public string Smtp { get; set; }　//SMTPサーバー
        public string MailAddress { get; set; }　//自メールアドレス(送信元)
        public string PassWord { get; set; }　//パスワード
        public int Port  { get; set; }　//ポート番号
        public bool Ssl { get; set; } //SSL設定



        //コンストラクタ
        private Config() { }

        //初期設定
        public void DefaultSet() {
            Smtp = "smtp.gmail.com";
            MailAddress = "ojsinfosys01@gmail.com";
            PassWord = "ojsInfosys2020";
            Port = 587;
            Ssl = true;
        }

        //初期値取得用
        public Config GetDefaultStatus() {
            Config obj = new Config();
            obj.DefaultSet();
            return obj;
        }
        
        //設定データ更新
        public bool UpdateStatus(string smtp,string mailAddress,string passWord,int port,bool ssl) {
            this.Smtp = smtp;
            this.MailAddress = mailAddress;
            this.PassWord = passWord;
            this.Port = port;
            this.Ssl = ssl;
            return true;
        }

        public void Serialize() {
            using (var writer = XmlWriter.Create("Mail.xml")) {
                var serializer = new XmlSerializer(instance.GetType());
                serializer.Serialize(writer,instance);
            }
        }

        public void DeSerialize() {
            using (var reader = XmlReader.Create("Mail.xml")) {
                var serializer = new XmlSerializer(typeof(Config));
                Config.instance = serializer.Deserialize(reader) as Config;
            }
        }
    }
}
