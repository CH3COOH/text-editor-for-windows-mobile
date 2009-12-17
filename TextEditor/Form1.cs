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
    }
}