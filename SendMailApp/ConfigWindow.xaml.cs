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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SendMailApp {
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window {
        //Config config = new Config();

        public ConfigWindow() {
            InitializeComponent();
        }

        private void btDefault_Click(object sender, RoutedEventArgs e) {
            Config cf =( Config.GetInstance()).GetDefaultStatus();
            tbSmtp.Text = cf.Smtp;
            tbSender.Text = cf.MailAddress;
            tbUserName.Text = cf.MailAddress;
            tbPort.Text = cf.Port.ToString();
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;


        }

        //キャンセルボタン
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        //適用(更新)
        private void btApply_Click(object sender, RoutedEventArgs e) {
            (Config.GetInstance()).UpdateStatus(
                tbSmtp.Text,
                tbSender.Text,
                tbPassWord.Password,
                int.Parse(tbPort.Text),
                cbSsl.IsChecked ?? false　//更新処理を呼び出す
                );
        }

        //OKボタン
        private void btOk_Click(object sender, RoutedEventArgs e) {
            btApply_Click(sender,e);
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

        
    }
}
