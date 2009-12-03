namespace TextEditor
{
    partial class TextEditorForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.menuEdit = new System.Windows.Forms.MenuItem();
            this.menuOpen = new System.Windows.Forms.MenuItem();
            this.menuSave = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuUndo = new System.Windows.Forms.MenuItem();
            this.menuCopy = new System.Windows.Forms.MenuItem();
            this.menuCut = new System.Windows.Forms.MenuItem();
            this.menuPaste = new System.Windows.Forms.MenuItem();
            this.textEdit = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.menuEdit);
            // 
            // menuEdit
            // 
            this.menuEdit.MenuItems.Add(this.menuOpen);
            this.menuEdit.MenuItems.Add(this.menuSave);
            this.menuEdit.MenuItems.Add(this.menuItem3);
            this.menuEdit.MenuItems.Add(this.menuUndo);
            this.menuEdit.MenuItems.Add(this.menuCopy);
            this.menuEdit.MenuItems.Add(this.menuCut);
            this.menuEdit.MenuItems.Add(this.menuPaste);
            this.menuEdit.Text = "編集";
            // 
            // menuOpen
            // 
            this.menuOpen.Text = "開く";
            // 
            // menuSave
            // 
            this.menuSave.Text = "保存";
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "-";
            // 
            // menuUndo
            // 
            this.menuUndo.Text = "やり直し";
            this.menuUndo.Click += new System.EventHandler(this.menuUndo_Click);
            // 
            // menuCopy
            // 
            this.menuCopy.Text = "コピー";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuCut
            // 
            this.menuCut.Text = "切り取り";
            this.menuCut.Click += new System.EventHandler(this.menuCut_Click);
            // 
            // menuPaste
            // 
            this.menuPaste.Text = "貼り付け";
            this.menuPaste.Click += new System.EventHandler(this.menuPaste_Click);
            // 
            // textEdit
            // 
            this.textEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEdit.Location = new System.Drawing.Point(0, 0);
            this.textEdit.Multiline = true;
            this.textEdit.Name = "textEdit";
            this.textEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textEdit.Size = new System.Drawing.Size(240, 268);
            this.textEdit.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "テキストファイル(*.txt)|*.txt";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "テキストファイル(*.txt)|*.txt";
            // 
            // TextEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.textEdit);
            this.Menu = this.mainMenu;
            this.Name = "TextEditorForm";
            this.Text = "TextEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textEdit;
        private System.Windows.Forms.MenuItem menuEdit;
        private System.Windows.Forms.MenuItem menuOpen;
        private System.Windows.Forms.MenuItem menuSave;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuUndo;
        private System.Windows.Forms.MenuItem menuCopy;
        private System.Windows.Forms.MenuItem menuPaste;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuItem menuCut;
    }
}

