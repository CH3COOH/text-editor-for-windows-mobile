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


        // エディットコントロールまたはコンボボックスにおいて、
        // 現在選択されているテキストがある場合には、
        // その部分のテキストをエディットコントロールから削除し、
        // そのテキストを CF_TEXT フォーマットでクリップボードにコピーします。
        int WM_CUT = 0x0300;

        // エディットコントロールまたはコンボボックスの現在選択されているテキストを
        // CF_TEXT フォーマットでクリップボードにコピーします。
        int WM_COPY = 0x0301;

        // エディットコントロールまたはコンボボックスの
        // 現在のキャレットの位置にクリップボードの内容をコピーします。
        int WM_PASTE = 0x0302;


        private void menuCut_Click(object sender, EventArgs e)
        {

            Microsoft.WindowsCE.Forms.Message msg
                = Microsoft.WindowsCE.Forms.Message.Create(textEdit.Handle,
                                                           WM_CUT,
                                                           IntPtr.Zero,
                                                           IntPtr.Zero);
            Microsoft.WindowsCE.Forms.MessageWindow.SendMessage(ref msg);
        }

        private void menuPaste_Click(object sender, EventArgs e)
        {
            Microsoft.WindowsCE.Forms.Message msg
                = Microsoft.WindowsCE.Forms.Message.Create(textEdit.Handle,
                                                           WM_PASTE,
                                                           IntPtr.Zero,
                                                           IntPtr.Zero);
            Microsoft.WindowsCE.Forms.MessageWindow.SendMessage(ref msg);
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
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
        }
    }
}