namespace Project01
{
    partial class PrimeForm
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
            this.limitInput = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.quantityofprimenum = new System.Windows.Forms.Label();
            this.resultsBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.algorithm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.logsBox = new System.Windows.Forms.ListBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // limitInput
            // 
            this.limitInput.Location = new System.Drawing.Point(186, 96);
            this.limitInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.limitInput.Name = "limitInput";
            this.limitInput.Size = new System.Drawing.Size(168, 31);
            this.limitInput.TabIndex = 1;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(443, 93);
            this.startBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(112, 36);
            this.startBtn.TabIndex = 4;
            this.startBtn.Text = "Run";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startButton_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(1062, 638);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(112, 36);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // quantityofprimenum
            // 
            this.quantityofprimenum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quantityofprimenum.Location = new System.Drawing.Point(563, 184);
            this.quantityofprimenum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.quantityofprimenum.Name = "quantityofprimenum";
            this.quantityofprimenum.Size = new System.Drawing.Size(96, 35);
            this.quantityofprimenum.TabIndex = 7;
            this.quantityofprimenum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resultsBox
            // 
            this.resultsBox.FormattingEnabled = true;
            this.resultsBox.ItemHeight = 25;
            this.resultsBox.Location = new System.Drawing.Point(186, 168);
            this.resultsBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.Size = new System.Drawing.Size(178, 479);
            this.resultsBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(623, 99);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Algorithm:";
            // 
            // algorithm
            // 
            this.algorithm.FormattingEnabled = true;
            this.algorithm.Items.AddRange(new object[] {
            "Simple",
            "Eratosthenes",
            "Atkin\'s"});
            this.algorithm.Location = new System.Drawing.Point(757, 96);
            this.algorithm.Name = "algorithm";
            this.algorithm.Size = new System.Drawing.Size(227, 33);
            this.algorithm.TabIndex = 10;
            this.algorithm.Text = "Simple";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 168);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 60);
            this.label1.TabIndex = 13;
            this.label1.Tag = "";
            this.label1.Text = "Results:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 60);
            this.label2.TabIndex = 14;
            this.label2.Tag = "";
            this.label2.Text = "Limit:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(412, 168);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 60);
            this.label5.TabIndex = 15;
            this.label5.Tag = "";
            this.label5.Text = "Quantity:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(412, 275);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 60);
            this.label6.TabIndex = 16;
            this.label6.Tag = "";
            this.label6.Text = "Logs:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logsBox
            // 
            this.logsBox.FormattingEnabled = true;
            this.logsBox.ItemHeight = 25;
            this.logsBox.Location = new System.Drawing.Point(563, 268);
            this.logsBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logsBox.Name = "logsBox";
            this.logsBox.Size = new System.Drawing.Size(421, 379);
            this.logsBox.TabIndex = 17;
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(1062, 572);
            this.resetBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(112, 36);
            this.resetBtn.TabIndex = 18;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // PrimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.logsBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.algorithm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resultsBox);
            this.Controls.Add(this.quantityofprimenum);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.limitInput);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PrimeForm";
            this.Text = "PrimeNumber";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox limitInput;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Label quantityofprimenum;
        private System.Windows.Forms.ListBox resultsBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox algorithm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox logsBox;
        private System.Windows.Forms.Button resetBtn;
    }
}

