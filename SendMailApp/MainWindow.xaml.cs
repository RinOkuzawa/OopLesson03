using System;
using System.Collections.Generic;
using System.IO;
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

        //設定ボタンイベントハンドラ
        private static void ConfigWindowShow() {

            ConfigWindow configWindow = new ConfigWindow();
            configWindow.ShowDialog();
        }

        //送信完了イベント
        private void Sc_sendCompleted(object sender,System.ComponentModel.AsyncCompletedEventArgs e) {
            if (e.Cancelled) {
                MessageBox.Show("送信はキャンセルされました");
            } else {
                MessageBox.Show(e.Error?.Message ?? "送信完了");
            }
        }

        //送信キャンセル
        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            if (sc == null) {
                sc.SendAsyncCancel();
            }
        }

        //メール送信処理
        private void SendButton_Click(object sender, RoutedEventArgs e) {          
            try {
                Config cf = Config.GetInstance();
                MailMessage msg = new MailMessage(cf.MailAddress,tbTo.Text,tbTitle.Text,tbBody.Text);

                //msg.Subject = tbTitle.Text; //件名
                //msg.Body = tbBody.Text; //本文

                if (tbCc.Text != "") {
                    msg.CC.Add(tbCc.Text);
                }
                if (tbBcc.Text != "") {
                    msg.Bcc.Add(tbBcc.Text);
                }

                sc.Host = cf.Smtp; //SMTPサーバの設定
                sc.Port = cf.Port;
                sc.EnableSsl = cf.Ssl;
                sc.Credentials = new NetworkCredential(cf.MailAddress, cf.PassWord);


                //sc.Send(msg);  //送信
                sc.SendMailAsync(msg);     
                
            }catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        

        //設定ボタン
        private void btConfig_Click(object sender, RoutedEventArgs e) {
            ConfigWindowShow();
        }

        //メインウィンドウがロードされるタイミングで呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e) {   
            try {
                Config.GetInstance().DeSerialize();
            } catch(FileNotFoundException) {
                ConfigWindowShow();
            }catch(Exception ex){
            MessageBox.Show(ex.Message);
            }
        }

        //メインウィンドウがクローズされるタイミングで呼び出される
        private void Window_Closed(object sender, EventArgs e) {
            try {
                Config.GetInstance().Serialize();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }  
        }

        //添付追加
        //private void addButton_Click(object sender, RoutedEventArgs e) {
        //    var openD = new OpenFileDialog();
        //    openD.Filter = "全てのファイル (*.*)|*.*";
        //    if (openD.ShowDialog()==true) {
        //        tempList.Items.Add(openD.FileName);
        //    }
        //}
        //
        ////添付削除
        //private void deleteButton_Click(object sender, RoutedEventArgs e) {
        //    tempList.Items.Clear();
        //}
    }
}
