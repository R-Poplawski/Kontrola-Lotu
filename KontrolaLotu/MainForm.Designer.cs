namespace KontrolaLotu
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.wysokoscTextBox = new System.Windows.Forms.TextBox();
            this.predkoscTextBox = new System.Windows.Forms.TextBox();
            this.predkoscDocelowaTextBox = new System.Windows.Forms.TextBox();
            this.wysokoscDocelowaTextBox = new System.Windows.Forms.TextBox();
            this.predkoscDocelowaLabel = new System.Windows.Forms.Label();
            this.wysokoscDocelowaLabel = new System.Windows.Forms.Label();
            this.kierunekTextBox = new System.Windows.Forms.TextBox();
            this.kierunekLabel = new System.Windows.Forms.Label();
            this.predkoscLabel = new System.Windows.Forms.Label();
            this.wysokoscLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.plusButton = new System.Windows.Forms.Button();
            this.skalaLabel = new System.Windows.Forms.Label();
            this.skalaTextBox = new System.Windows.Forms.TextBox();
            this.minusButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(667, 544);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(687, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Usuń Obiekt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.xTextBox);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.yTextBox);
            this.panel1.Controls.Add(this.wysokoscTextBox);
            this.panel1.Controls.Add(this.predkoscTextBox);
            this.panel1.Controls.Add(this.predkoscDocelowaTextBox);
            this.panel1.Controls.Add(this.wysokoscDocelowaTextBox);
            this.panel1.Controls.Add(this.predkoscDocelowaLabel);
            this.panel1.Controls.Add(this.wysokoscDocelowaLabel);
            this.panel1.Controls.Add(this.kierunekTextBox);
            this.panel1.Controls.Add(this.kierunekLabel);
            this.panel1.Controls.Add(this.predkoscLabel);
            this.panel1.Controls.Add(this.wysokoscLabel);
            this.panel1.Controls.Add(this.yLabel);
            this.panel1.Controls.Add(this.xLabel);
            this.panel1.Location = new System.Drawing.Point(684, 177);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 223);
            this.panel1.TabIndex = 6;
            // 
            // xTextBox
            // 
            this.xTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xTextBox.Location = new System.Drawing.Point(67, 27);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.ReadOnly = true;
            this.xTextBox.Size = new System.Drawing.Size(79, 20);
            this.xTextBox.TabIndex = 2;
            this.xTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xTextBox.Visible = false;
            // 
            // yTextBox
            // 
            this.yTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yTextBox.Location = new System.Drawing.Point(67, 53);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.ReadOnly = true;
            this.yTextBox.Size = new System.Drawing.Size(79, 20);
            this.yTextBox.TabIndex = 4;
            this.yTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.yTextBox.Visible = false;
            // 
            // wysokoscTextBox
            // 
            this.wysokoscTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wysokoscTextBox.Location = new System.Drawing.Point(67, 79);
            this.wysokoscTextBox.Name = "wysokoscTextBox";
            this.wysokoscTextBox.ReadOnly = true;
            this.wysokoscTextBox.Size = new System.Drawing.Size(79, 20);
            this.wysokoscTextBox.TabIndex = 6;
            this.wysokoscTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.wysokoscTextBox.Visible = false;
            // 
            // predkoscTextBox
            // 
            this.predkoscTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.predkoscTextBox.Location = new System.Drawing.Point(67, 105);
            this.predkoscTextBox.Name = "predkoscTextBox";
            this.predkoscTextBox.ReadOnly = true;
            this.predkoscTextBox.Size = new System.Drawing.Size(79, 20);
            this.predkoscTextBox.TabIndex = 8;
            this.predkoscTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.predkoscTextBox.Visible = false;
            // 
            // predkoscDocelowaTextBox
            // 
            this.predkoscDocelowaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.predkoscDocelowaTextBox.Location = new System.Drawing.Point(67, 192);
            this.predkoscDocelowaTextBox.Name = "predkoscDocelowaTextBox";
            this.predkoscDocelowaTextBox.Size = new System.Drawing.Size(79, 20);
            this.predkoscDocelowaTextBox.TabIndex = 14;
            this.predkoscDocelowaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.predkoscDocelowaTextBox.Visible = false;
            this.predkoscDocelowaTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.predkoscDocelowaTextBox_KeyDown);
            this.predkoscDocelowaTextBox.Leave += new System.EventHandler(this.predkoscDocelowaTextBox_Leave);
            // 
            // wysokoscDocelowaTextBox
            // 
            this.wysokoscDocelowaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wysokoscDocelowaTextBox.Location = new System.Drawing.Point(67, 161);
            this.wysokoscDocelowaTextBox.Name = "wysokoscDocelowaTextBox";
            this.wysokoscDocelowaTextBox.Size = new System.Drawing.Size(79, 20);
            this.wysokoscDocelowaTextBox.TabIndex = 12;
            this.wysokoscDocelowaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.wysokoscDocelowaTextBox.Visible = false;
            this.wysokoscDocelowaTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.wysokoscDocelowaTextBox_KeyDown);
            this.wysokoscDocelowaTextBox.Leave += new System.EventHandler(this.wysokoscDocelowaTextBox_Leave);
            // 
            // predkoscDocelowaLabel
            // 
            this.predkoscDocelowaLabel.AutoSize = true;
            this.predkoscDocelowaLabel.Location = new System.Drawing.Point(3, 189);
            this.predkoscDocelowaLabel.Margin = new System.Windows.Forms.Padding(3);
            this.predkoscDocelowaLabel.Name = "predkoscDocelowaLabel";
            this.predkoscDocelowaLabel.Size = new System.Drawing.Size(58, 26);
            this.predkoscDocelowaLabel.TabIndex = 13;
            this.predkoscDocelowaLabel.Text = "Prędkość\nDocelowa:";
            this.predkoscDocelowaLabel.Visible = false;
            // 
            // wysokoscDocelowaLabel
            // 
            this.wysokoscDocelowaLabel.AutoSize = true;
            this.wysokoscDocelowaLabel.Location = new System.Drawing.Point(2, 157);
            this.wysokoscDocelowaLabel.Margin = new System.Windows.Forms.Padding(3);
            this.wysokoscDocelowaLabel.Name = "wysokoscDocelowaLabel";
            this.wysokoscDocelowaLabel.Size = new System.Drawing.Size(58, 26);
            this.wysokoscDocelowaLabel.TabIndex = 11;
            this.wysokoscDocelowaLabel.Text = "Wysokość\nDocelowa:";
            this.wysokoscDocelowaLabel.Visible = false;
            // 
            // kierunekTextBox
            // 
            this.kierunekTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kierunekTextBox.Location = new System.Drawing.Point(67, 131);
            this.kierunekTextBox.Name = "kierunekTextBox";
            this.kierunekTextBox.Size = new System.Drawing.Size(79, 20);
            this.kierunekTextBox.TabIndex = 10;
            this.kierunekTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.kierunekTextBox.Visible = false;
            this.kierunekTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kierunekTextBox_KeyDown);
            this.kierunekTextBox.Leave += new System.EventHandler(this.kierunekTextBox_Leave);
            // 
            // kierunekLabel
            // 
            this.kierunekLabel.AutoSize = true;
            this.kierunekLabel.Location = new System.Drawing.Point(2, 134);
            this.kierunekLabel.Margin = new System.Windows.Forms.Padding(3);
            this.kierunekLabel.Name = "kierunekLabel";
            this.kierunekLabel.Size = new System.Drawing.Size(52, 13);
            this.kierunekLabel.TabIndex = 9;
            this.kierunekLabel.Text = "Kierunek:";
            this.kierunekLabel.Visible = false;
            // 
            // predkoscLabel
            // 
            this.predkoscLabel.AutoSize = true;
            this.predkoscLabel.Location = new System.Drawing.Point(2, 108);
            this.predkoscLabel.Margin = new System.Windows.Forms.Padding(3);
            this.predkoscLabel.Name = "predkoscLabel";
            this.predkoscLabel.Size = new System.Drawing.Size(58, 13);
            this.predkoscLabel.TabIndex = 7;
            this.predkoscLabel.Text = "Prędkość: ";
            this.predkoscLabel.Visible = false;
            // 
            // wysokoscLabel
            // 
            this.wysokoscLabel.AutoSize = true;
            this.wysokoscLabel.Location = new System.Drawing.Point(2, 82);
            this.wysokoscLabel.Margin = new System.Windows.Forms.Padding(3);
            this.wysokoscLabel.Name = "wysokoscLabel";
            this.wysokoscLabel.Size = new System.Drawing.Size(63, 13);
            this.wysokoscLabel.TabIndex = 5;
            this.wysokoscLabel.Text = "Wysokość: ";
            this.wysokoscLabel.Visible = false;
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(2, 56);
            this.yLabel.Margin = new System.Windows.Forms.Padding(3);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(20, 13);
            this.yLabel.TabIndex = 3;
            this.yLabel.Text = "Y: ";
            this.yLabel.Visible = false;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(2, 30);
            this.xLabel.Margin = new System.Windows.Forms.Padding(3);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(20, 13);
            this.xLabel.TabIndex = 1;
            this.xLabel.Text = "X: ";
            this.xLabel.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(687, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Dodaj Obiekt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(667, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 544);
            this.vScrollBar1.TabIndex = 8;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.Location = new System.Drawing.Point(0, 544);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(667, 17);
            this.hScrollBar1.TabIndex = 9;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // plusButton
            // 
            this.plusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.plusButton.Location = new System.Drawing.Point(778, 526);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(23, 23);
            this.plusButton.TabIndex = 8;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // skalaLabel
            // 
            this.skalaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.skalaLabel.AutoSize = true;
            this.skalaLabel.Location = new System.Drawing.Point(689, 531);
            this.skalaLabel.Name = "skalaLabel";
            this.skalaLabel.Size = new System.Drawing.Size(37, 13);
            this.skalaLabel.TabIndex = 6;
            this.skalaLabel.Text = "Skala:";
            // 
            // skalaTextBox
            // 
            this.skalaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.skalaTextBox.Location = new System.Drawing.Point(732, 528);
            this.skalaTextBox.Name = "skalaTextBox";
            this.skalaTextBox.Size = new System.Drawing.Size(40, 20);
            this.skalaTextBox.TabIndex = 7;
            this.skalaTextBox.Text = "100%";
            this.skalaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.skalaTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.skalaTextBox_KeyDown);
            this.skalaTextBox.Leave += new System.EventHandler(this.skalaTextBox_Leave);
            // 
            // minusButton
            // 
            this.minusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.minusButton.Location = new System.Drawing.Point(807, 526);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(23, 23);
            this.minusButton.TabIndex = 9;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(687, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Otwórz Plik";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(687, 35);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(143, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "ZapiszPlik";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(687, 64);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(143, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Wyczyść Mapę";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(687, 151);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(143, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Przesuń Obiekt";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.skalaTextBox);
            this.Controls.Add(this.skalaLabel);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainForm";
            this.Text = "Kontrola Lotu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label kierunekLabel;
        private System.Windows.Forms.Label predkoscLabel;
        private System.Windows.Forms.Label wysokoscLabel;
        private System.Windows.Forms.TextBox kierunekTextBox;
        private System.Windows.Forms.TextBox predkoscDocelowaTextBox;
        private System.Windows.Forms.TextBox wysokoscDocelowaTextBox;
        private System.Windows.Forms.Label predkoscDocelowaLabel;
        private System.Windows.Forms.Label wysokoscDocelowaLabel;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox wysokoscTextBox;
        private System.Windows.Forms.TextBox predkoscTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Label skalaLabel;
        private System.Windows.Forms.TextBox skalaTextBox;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

