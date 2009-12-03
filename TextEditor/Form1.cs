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
    }
}