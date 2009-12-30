using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace TextEditor
{
    public partial class TextEditorForm : Form
    {
        public TextEditorForm()
        {
            InitializeComponent();
        }

        private void menuUndo_Click(object sender, EventArgs e)
        {
            // アンドゥ(元に戻す)が可能か
            if (textEdit.CanUndo)
            {
                // 元に戻せるのであれば戻す
                textEdit.Undo();
            }
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            if (textEdit.SelectedText != "")
            {
                // 選択している文字列をクリップボードに格納
                Clipboard.SetDataObject((object)textEdit.SelectedText);            
            }
        }

        private void CopyEx()
        {
            // エディットコントロール現在選択されているテキストを
            // CF_TEXT フォーマットでクリップボードにコピー
            int WM_COPY = 0x0301;

            // メッセージの送信先になるtextEditのメッセージウィンドウの
            // ハンドルに対して、WM_COPYの識別子を持つWindows メッセージの作成
            Microsoft.WindowsCE.Forms.Message msg
                = Microsoft.WindowsCE.Forms.Message.Create(textEdit.Handle,
                                                           WM_COPY,
                                                           IntPtr.Zero,
                                                           IntPtr.Zero);

            // メッセージをパッシングしてメッセージを処理するまで待機
            Microsoft.WindowsCE.Forms.MessageWindow.SendMessage(ref msg);
        }

        private void menuCut_Click(object sender, EventArgs e)
        {
            // エディットコントロールでテキストを現在選択されていれば
            // その部分のテキストをエディットコントロールから削除し、
            // CF_TEXT フォーマットでクリップボードにコピー
            int WM_CUT = 0x0300;

            Microsoft.WindowsCE.Forms.Message msg
                = Microsoft.WindowsCE.Forms.Message.Create(textEdit.Handle,
                                                           WM_CUT,
                                                           IntPtr.Zero,
                                                           IntPtr.Zero);
            Microsoft.WindowsCE.Forms.MessageWindow.SendMessage(ref msg);
        }

        private void menuPaste_Click(object sender, EventArgs e)
        {
            // エディットコントロールまたはコンボボックスの
            // 現在のキャレットの位置にクリップボードの内容をコピーします。
            int WM_PASTE = 0x0302;

            Microsoft.WindowsCE.Forms.Message msg
                = Microsoft.WindowsCE.Forms.Message.Create(textEdit.Handle,
                                                           WM_PASTE,
                                                           IntPtr.Zero,
                                                           IntPtr.Zero);
            Microsoft.WindowsCE.Forms.MessageWindow.SendMessage(ref msg);
        }

        /// <summary>
        /// 現在のテキストが保存済みか判定用フラグ
        /// </summary>
        bool _isSavedFile = true;
        bool isSavedFile
        { 
            get { return _isSavedFile; }
            set { _isSavedFile = value; } 
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            // ファイルを保存する為のダイアログを表示する
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
              return;
            }

            // TextBoxに表示しているテキストを
            // ユーザーが指定したファイルパスに書き出す
            using (StreamWriter strm = new StreamWriter(saveFileDialog.FileName))
            {
              strm.Write(textEdit.Text);
            }

            // 保存が完了したのでフラグにtrueを設定する
            this.isSavedFile = true;
        }


        private void textEdit_TextChanged(object sender, EventArgs e)
        {
            // テキストが変更されたのでフラグにfalseを設定する
            this.isSavedFile = false;
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            // ファイルを保存済みか
            if (!this.isSavedFile)
            {
                // 上書きの確認用の文言
                System.Text.StringBuilder sb = new StringBuilder();
                sb.Append("現在編集中のテキストが存在しています。\n");
                sb.Append("現在のテキストを破棄して、新しく開きますか？");

                // メッセージボックスの表示
                DialogResult result = DialogResult.None;
                result = MessageBox.Show(sb.ToString(),
                                         "caption", 
                                         MessageBoxButtons.YesNo, 
                                         MessageBoxIcon.Asterisk, 
                                         MessageBoxDefaultButton.Button2);

                // 
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            // ファイルを開く為のダイアログを表示する
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // ユーザーが指定したファイルパスから
            // テキストを読み込みTextBoxに表示させる
            using (StreamReader strm = new StreamReader(openFileDialog.FileName))
            {
                textEdit.Text = strm.ReadToEnd();
            }
        }

        private void inputPanel1_EnabledChanged(object sender, EventArgs e)
        {
            // 現在のテキストボックスの高さを取得
            int newHeight = textEdit.Height;

            if (inputPanel1.Enabled)
            {
                // ソフトキーボードが表示されている

                // テキストボックスの高さを設定するために
                // Dockプロパティを上辺にのみ揃える
                textEdit.Dock = DockStyle.Top;

                // ソフトキーボードの高さを考慮して、
                // 残った部分をテキストボックスの高さとする
                newHeight = newHeight - inputPanel1.Bounds.Height;
            }
            else
            {
                // ソフトキーボードが表示されていない

                // ソフトキーボードの事は考慮する必要がないので
                // フォームの全ての辺とドッキングさせる。
                textEdit.Dock = DockStyle.Fill;
            }

            // テキストボックスの高さを更新する
            textEdit.Height = newHeight;
        }

    }
}