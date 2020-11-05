﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMailApp {
    class Config {
        public string Smtp { get; set; }　//SMTPサーバー
        public string MailAddress { get; set; }　//自メールアドレス
        public string PassWord { get; set; }　//パスワード
        public int Port  { get; set; }　//ポート番号
        public bool Ssl { get; set; }　//SSL設定

        //初期設定
        public void DefaultSet() {
            Smtp = "smtp.gamil.com";
            MailAddress = "ojsinfosys01@gmail.com";
            PassWord = "ojsInfosys2020";
            Port = 587;
            Ssl = true;
        }
    }
}