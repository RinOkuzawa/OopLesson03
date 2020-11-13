using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace SendMailApp {
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window {
        

        public ConfigWindow() {
            InitializeComponent();
        }

        private void btDefault_Click(object sender, RoutedEventArgs e) {
            Config cf = (Config.GetInstance()).GetDefaultStatus();
            tbSmtp.Text = cf.Smtp;
            tbSender.Text = cf.MailAddress;
            tbUserName.Text = cf.MailAddress;
            tbPort.Text = cf.Port.ToString();
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;


        }

        //キャンセルボタン
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            if (DataCheck()) {
                if (ChangeTextJg()) {
                    this.Close();
                } 
            } else if(CancelSaveStatus() == true){
                Message();
            } else if(CancelSaveStatus() == false){
                setStatus();
            } else {
                this.Close();
            }
        } 

        //適用(更新) 
        private void btApply_Click(object sender, RoutedEventArgs e) {
            if (CancelSaveStatus() == true) {
                Message();
            } else if (CancelSaveStatus() == false) {
                setStatus();
            }
        }

        //OKボタン
        private void btOk_Click(object sender, RoutedEventArgs e) {
            btApply_Click(sender, e);  //更新処理を呼び出す
            this.Close();
        }

        //ロード時に一度だけ呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Config cf = Config.GetInstance();
            this.tbSmtp.Text = cf.Smtp;
            this.tbSender.Text = cf.MailAddress;
            this.tbPort.Text = cf.Port.ToString();
            this.tbPassWord.Password = cf.PassWord;
            this.cbSsl.IsChecked = cf.Ssl;
            this.tbUserName.Text = cf.MailAddress;
        }

        //未入力項目チェックメソッド
        public static bool CancelSaveStatus() {
            ConfigWindow cw = new ConfigWindow();
            if (cw.tbSmtp.Text == "" || cw.tbUserName.Text == "" || cw.tbSender.Text == "" || int.Parse(cw.tbPort.Text) == 0|| cw.tbPassWord.Password == "") {
                return true;
            } else {
                return false;
            }

        }

        //メッセージボックスメソッド
            public static bool ChangeTextJg() {
            ConfigWindow cw = new ConfigWindow();
            MessageBoxResult result = MessageBox.Show("変更されていますがキャンセルしてよろしいですか？", "警告", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK) {
                return true;
            } else  {
                return false;
            }
        }
        
        public static void Message() {
            MessageBox.Show("入力されていない項目があります");
        }
        

        public void setStatus() {
            ConfigWindow cw = new ConfigWindow();
            (Config.GetInstance()).UpdateStatus(
                cw.tbSmtp.Text,
                cw.tbSender.Text,
                cw.tbPassWord.Password,
                int.Parse(cw.tbPort.Text),
                cw.cbSsl.IsChecked ?? false
                );
        }

        //データが変更されているかの判定
        public static bool DataCheck() {
            ConfigWindow cw = new ConfigWindow();
            Config cf = Config.GetInstance();

            
            if (cf.Smtp != cw.tbSmtp.Text || cf.MailAddress != cw.tbSender.Text || cf.PassWord != cw.tbPassWord.Password || cf.Port != int.Parse(cw.tbPort.Text) || cf.Ssl != cw.cbSsl.IsChecked || cf.MailAddress != cw.tbUserName.Text) {
                return true;
            } else {
                return false;
            }
               
        }
    }
}
