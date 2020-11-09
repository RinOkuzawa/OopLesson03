using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendMailApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        SmtpClient sc = new SmtpClient();
        public MainWindow() {
            InitializeComponent();
            sc.SendCompleted += Sc_sendCompleted;
        }

        //送信完了イベント
        private void Sc_sendCompleted(object sender,System.ComponentModel.AsyncCompletedEventArgs e) {
            if (e.Cancelled) {
                MessageBox.Show("送信はキャンセルされました");
            } else {
                MessageBox.Show(e.Error?.Message ?? "送信完了");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            
            sc.SendAsyncCancel();
        }

        //メール送信処理
        private void SendButton_Click(object sender, RoutedEventArgs e) {
            try {
                
                MailMessage msg = new MailMessage("ojsinfosys01@gmail.com",tbTo.Text);

                msg.Subject = tbTitle.Text; //件名
                msg.Body = tbBody.Text; //本文
                if (tbCc.Text != "") {
                    //CC
                    msg.CC.Add(tbCc.Text);
                }

                if (tbBcc.Text != "") {
                    //BCC
                    msg.Bcc.Add(tbBcc.Text);
                }
               

                sc.Host = "smtp.gmail.com"; //SMTPサーバの設定
                sc.Port = 587;
                sc.EnableSsl = true;
                sc.Credentials = new NetworkCredential("ojsinfosys01@gmail.com", "ojsInfosys2020");

                msg.From = new MailAddress("ojsinfosys01@gmail.com");

                #region
                //// TOの宛先メールアドレスを設定します。
                //msg.To.Add(tbTo.Text);
                //// 複数の宛先を設定するには、カンマ区切りでメールアドレスを追加します。
                //msg.To.Add(", " + tbTo.Text);

                //msg.To.Add(", " + tbTo.Text);
                #endregion

                //sc.Send(msg);  //送信
                sc.SendMailAsync(msg);

               
            }catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        //設定
        private void btConfig_Click(object sender, RoutedEventArgs e) {
            ConfigWindow cw = new ConfigWindow();
            cw.Show();
            Config cf = Config.GetInstance();
            cw.tbSmtp.Text = cf.Smtp;
            cw.tbSender.Text = cf.MailAddress;
            cw.tbPort.Text = cf.Port.ToString();
            cw.tbPassWord.Password = cf.PassWord;
            cw.cbSsl.IsChecked = cf.Ssl;

        }

        //メインウィンドウがロードされるタイミングで呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e) {

            AccessedThroughPropertyAttribute attribute = new AccessedThroughPropertyAttribute("aaaa");
            attribute.Match(sender);
        }
    }
}
