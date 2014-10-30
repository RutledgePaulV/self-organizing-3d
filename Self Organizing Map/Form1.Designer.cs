namespace Self_Organizing_Map
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnCreateData = new System.Windows.Forms.Button();
            this.txtTrainSize = new System.Windows.Forms.TextBox();
            this.txtEpochs = new System.Windows.Forms.TextBox();
            this.glControl1 = new OpenTK.GLControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLearnRate = new System.Windows.Forms.TextBox();
            this.btnDisplayInitial = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnRotate = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.glControl2 = new OpenTK.GLControl();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTrain
            // 
            this.btnTrain.BackColor = System.Drawing.Color.Black;
            this.btnTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrain.ForeColor = System.Drawing.Color.White;
            this.btnTrain.Location = new System.Drawing.Point(887, 506);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(131, 23);
            this.btnTrain.TabIndex = 4;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = false;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnCreateData
            // 
            this.btnCreateData.BackColor = System.Drawing.Color.Black;
            this.btnCreateData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateData.ForeColor = System.Drawing.Color.White;
            this.btnCreateData.Location = new System.Drawing.Point(887, 461);
            this.btnCreateData.Name = "btnCreateData";
            this.btnCreateData.Size = new System.Drawing.Size(131, 23);
            this.btnCreateData.TabIndex = 3;
            this.btnCreateData.Text = "Create Data";
            this.btnCreateData.UseVisualStyleBackColor = false;
            this.btnCreateData.Click += new System.EventHandler(this.btnCreateData_Click);
            // 
            // txtTrainSize
            // 
            this.txtTrainSize.BackColor = System.Drawing.Color.Black;
            this.txtTrainSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTrainSize.ForeColor = System.Drawing.Color.White;
            this.txtTrainSize.Location = new System.Drawing.Point(774, 510);
            this.txtTrainSize.Name = "txtTrainSize";
            this.txtTrainSize.Size = new System.Drawing.Size(50, 16);
            this.txtTrainSize.TabIndex = 1;
            this.txtTrainSize.Text = "300";
            this.txtTrainSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEpochs
            // 
            this.txtEpochs.BackColor = System.Drawing.Color.Black;
            this.txtEpochs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEpochs.ForeColor = System.Drawing.Color.White;
            this.txtEpochs.Location = new System.Drawing.Point(774, 555);
            this.txtEpochs.Name = "txtEpochs";
            this.txtEpochs.Size = new System.Drawing.Size(50, 16);
            this.txtEpochs.TabIndex = 2;
            this.txtEpochs.Text = "5000";
            this.txtEpochs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(9, 24);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(650, 650);
            this.glControl1.TabIndex = 7;
            this.glControl1.VSync = true;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(690, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Training Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(690, 555);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Epochs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(690, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Learning Rate";
            // 
            // txtLearnRate
            // 
            this.txtLearnRate.BackColor = System.Drawing.Color.Black;
            this.txtLearnRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLearnRate.ForeColor = System.Drawing.Color.White;
            this.txtLearnRate.Location = new System.Drawing.Point(774, 465);
            this.txtLearnRate.Name = "txtLearnRate";
            this.txtLearnRate.Size = new System.Drawing.Size(50, 16);
            this.txtLearnRate.TabIndex = 0;
            this.txtLearnRate.Text = "0.5";
            this.txtLearnRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDisplayInitial
            // 
            this.btnDisplayInitial.BackColor = System.Drawing.Color.Black;
            this.btnDisplayInitial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplayInitial.ForeColor = System.Drawing.Color.White;
            this.btnDisplayInitial.Location = new System.Drawing.Point(887, 551);
            this.btnDisplayInitial.Name = "btnDisplayInitial";
            this.btnDisplayInitial.Size = new System.Drawing.Size(131, 23);
            this.btnDisplayInitial.TabIndex = 5;
            this.btnDisplayInitial.Text = "Display Trained";
            this.btnDisplayInitial.UseVisualStyleBackColor = false;
            this.btnDisplayInitial.Click += new System.EventHandler(this.btnDisplayInitial_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnRotate
            // 
            this.btnRotate.BackColor = System.Drawing.Color.DarkGreen;
            this.btnRotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotate.ForeColor = System.Drawing.Color.White;
            this.btnRotate.Location = new System.Drawing.Point(887, 595);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(131, 23);
            this.btnRotate.TabIndex = 15;
            this.btnRotate.Text = "Start Rotation";
            this.btnRotate.UseVisualStyleBackColor = false;
            this.btnRotate.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.Black;
            this.numericUpDown1.ForeColor = System.Drawing.Color.White;
            this.numericUpDown1.Location = new System.Drawing.Point(774, 595);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 23);
            this.numericUpDown1.TabIndex = 16;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.ForeColor = System.Drawing.Color.Black;
            this.treeView1.Location = new System.Drawing.Point(1058, 24);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(194, 650);
            this.treeView1.TabIndex = 18;
            this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(690, 597);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Separation";
            // 
            // glControl2
            // 
            this.glControl2.BackColor = System.Drawing.Color.Black;
            this.glControl2.Location = new System.Drawing.Point(665, 24);
            this.glControl2.Name = "glControl2";
            this.glControl2.Size = new System.Drawing.Size(388, 388);
            this.glControl2.TabIndex = 19;
            this.glControl2.VSync = true;
            this.glControl2.Load += new System.EventHandler(this.glControl2_Load);
            this.glControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl2_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.glControl2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLearnRate);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnRotate);
            this.Controls.Add(this.btnDisplayInitial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.txtEpochs);
            this.Controls.Add(this.txtTrainSize);
            this.Controls.Add(this.btnCreateData);
            this.Controls.Add(this.btnTrain);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Self-Organizing Map";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnCreateData;
        private System.Windows.Forms.TextBox txtTrainSize;
        private System.Windows.Forms.TextBox txtEpochs;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLearnRate;
        private System.Windows.Forms.Button btnDisplayInitial;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label3;
        private OpenTK.GLControl glControl2;

    }
}

