using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
                ChangeTextJg(sender,e);
            } else if (NotenteredCheck()) {
                NotenteredMessage();
            } else {
                this.Close();
            }
        }

        //更新処理メソッド
        public void Apply() {
            Config.GetInstance().UpdateStatus(
                tbSmtp.Text,
                tbSender.Text,
                tbPassWord.Password,
                int.Parse(tbPort.Text),
                cbSsl.IsChecked ?? false); //更新処理を呼び出す
        }

        //適用(更新) 
        private void btApply_Click(object sender, RoutedEventArgs e) {
            try {
                Config.GetInstance().UpdateStatus(
               tbSmtp.Text,
               tbSender.Text,
               tbPassWord.Password,
               int.Parse(tbPort.Text),
               cbSsl.IsChecked ?? false); //更新処理を呼び出す
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //OKボタン
        private void btOk_Click(object sender, RoutedEventArgs e) {
            
            if (tbSmtp.Text == "" || tbUserName.Text == "" || tbPort.Text == "" || tbPassWord.Password == "") {
                NotenteredMessage();
            } else {
                btApply_Click(sender,e);//更新処理を呼び出す
                this.Close();
            }
        }

        //ロード時に一度だけ呼び出される 設定画面
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Config cf = Config.GetInstance();

            tbSmtp.Text = cf.Smtp;
            tbSender.Text = cf.MailAddress;
            tbPort.Text = cf.Port.ToString();
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;
            tbUserName.Text = cf.MailAddress;
        }

        //未入力項目チェック
        public static bool NotenteredCheck() {
            ConfigWindow cw = new ConfigWindow();
            if (cw.tbSmtp.Text == "" || cw.tbUserName.Text == "" || cw.tbSender.Text == "" ||
                cw.tbPort.Text == "" || cw.tbPassWord.Password == "") {
                return true;
            } else {
                return false;
            }
        }

        //データが変更されているかチェック
        public static bool DataCheck() {
            Config cf = Config.GetInstance();
            ConfigWindow cw = new ConfigWindow();
            if (cf.Smtp != cw.tbSmtp.Text || cf.MailAddress != cw.tbSender.Text || cf.PassWord != cw.tbPassWord.Password ||
                cf.Port != int.Parse(cw.tbPort.Text) || cf.Ssl != cw.cbSsl.IsChecked || cf.MailAddress != cw.tbUserName.Text) {
                return true;
            } else {
                return false;
            }

        }
        //未入力項目メッセージ
        public static void NotenteredMessage() {
            MessageBox.Show("入力されていない項目があります");
        }

        //変更判定メッセージ
       private void ChangeTextJg(object sender,RoutedEventArgs e) {
            
            DialogResult result = System.Windows.Forms.MessageBox.Show("変更されていますがキャンセルしてよろしいですか？", "警告",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (result == System.Windows.Forms.DialogResult.OK) {
                btApply_Click(sender,e);
                this.Close();
            } else if (result == System.Windows.Forms.DialogResult.Cancel) {
                this.Close();
            }
        }
    }
}