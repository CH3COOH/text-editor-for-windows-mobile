using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TextEditor
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new TextEditorForm());
        }
    }
}