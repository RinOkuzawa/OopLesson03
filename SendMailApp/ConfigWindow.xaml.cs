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
            tbPort.Text = cf.Port.ToString();
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;


        }

        private void btCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        //適用(更新)
        private void btApply_Click(object sender, RoutedEventArgs e) {
            
            (Config.GetInstance()).UpdateStatus(
                tbSmtp.Text,
                tbSender.Text,
                tbPassWord.Password,
                int.Parse(tbPort.Text),
                cbSsl.IsChecked ?? false
                );
        }

        private void btOk_Click(object sender, RoutedEventArgs e) {

        }
    }
}
