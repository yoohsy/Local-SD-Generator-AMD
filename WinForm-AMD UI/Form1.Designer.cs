namespace Работа
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtPrompt = new TextBox();
            txtNegative = new TextBox();
            numSteps = new NumericUpDown();
            numCfg = new NumericUpDown();
            txtPose = new TextBox();
            btnGenerate = new Button();
            picResult = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            btnBrowseLora = new Button();
            chkUseLora = new CheckBox();
            lblStatus = new Label();
            btnBrowseModel = new Button();
            numHeight = new NumericUpDown();
            label3 = new Label();
            numWidth = new NumericUpDown();
            label4 = new Label();
            numSeed = new NumericUpDown();
            label5 = new Label();
            btnBrowseOutput = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            numLoraWeight = new NumericUpDown();
            lblLoraStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)numSteps).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCfg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picResult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLoraWeight).BeginInit();
            SuspendLayout();
            // 
            // txtPrompt
            // 
            txtPrompt.Location = new Point(567, 83);
            txtPrompt.Multiline = true;
            txtPrompt.Name = "txtPrompt";
            txtPrompt.Size = new Size(157, 23);
            txtPrompt.TabIndex = 0;
            // 
            // txtNegative
            // 
            txtNegative.Location = new Point(567, 132);
            txtNegative.Name = "txtNegative";
            txtNegative.Size = new Size(157, 23);
            txtNegative.TabIndex = 1;
            // 
            // numSteps
            // 
            numSteps.Location = new Point(140, 58);
            numSteps.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numSteps.Minimum = new decimal(new int[] { 25, 0, 0, 0 });
            numSteps.Name = "numSteps";
            numSteps.Size = new Size(50, 23);
            numSteps.TabIndex = 2;
            numSteps.Tag = "";
            numSteps.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // numCfg
            // 
            numCfg.DecimalPlaces = 1;
            numCfg.Location = new Point(140, 99);
            numCfg.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numCfg.Name = "numCfg";
            numCfg.Size = new Size(50, 23);
            numCfg.TabIndex = 3;
            numCfg.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // txtPose
            // 
            txtPose.Location = new Point(575, 172);
            txtPose.Name = "txtPose";
            txtPose.Size = new Size(100, 23);
            txtPose.TabIndex = 4;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(557, 199);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(136, 54);
            btnGenerate.TabIndex = 5;
            btnGenerate.Text = "Сгенерировать";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // picResult
            // 
            picResult.Location = new Point(233, 103);
            picResult.Name = "picResult";
            picResult.Size = new Size(239, 242);
            picResult.SizeMode = PictureBoxSizeMode.Zoom;
            picResult.TabIndex = 6;
            picResult.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 61);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 7;
            label1.Text = "для шагов";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 102);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 8;
            label2.Text = "для CFG";
            // 
            // btnBrowseLora
            // 
            btnBrowseLora.Location = new Point(567, 325);
            btnBrowseLora.Name = "btnBrowseLora";
            btnBrowseLora.Size = new Size(108, 46);
            btnBrowseLora.TabIndex = 11;
            btnBrowseLora.Text = "Лора";
            btnBrowseLora.UseVisualStyleBackColor = true;
            btnBrowseLora.Click += btnBrowseLora_Click;
            // 
            // chkUseLora
            // 
            chkUseLora.AutoSize = true;
            chkUseLora.Location = new Point(557, 300);
            chkUseLora.Name = "chkUseLora";
            chkUseLora.Size = new Size(134, 19);
            chkUseLora.TabIndex = 12;
            chkUseLora.Text = "Использовать LoRA";
            chkUseLora.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(308, 23);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(41, 15);
            lblStatus.TabIndex = 13;
            lblStatus.Text = "статус";
            // 
            // btnBrowseModel
            // 
            btnBrowseModel.Location = new Point(567, 271);
            btnBrowseModel.Name = "btnBrowseModel";
            btnBrowseModel.Size = new Size(119, 23);
            btnBrowseModel.TabIndex = 14;
            btnBrowseModel.Text = "выбор модели";
            btnBrowseModel.UseVisualStyleBackColor = true;
            btnBrowseModel.Click += btnBrowseModel_Click;
            // 
            // numHeight
            // 
            numHeight.Location = new Point(140, 138);
            numHeight.Maximum = new decimal(new int[] { 2048, 0, 0, 0 });
            numHeight.Minimum = new decimal(new int[] { 768, 0, 0, 0 });
            numHeight.Name = "numHeight";
            numHeight.Size = new Size(50, 23);
            numHeight.TabIndex = 15;
            numHeight.Value = new decimal(new int[] { 768, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 140);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 16;
            label3.Text = "Высота";
            // 
            // numWidth
            // 
            numWidth.Location = new Point(140, 178);
            numWidth.Maximum = new decimal(new int[] { 2048, 0, 0, 0 });
            numWidth.Minimum = new decimal(new int[] { 512, 0, 0, 0 });
            numWidth.Name = "numWidth";
            numWidth.Size = new Size(50, 23);
            numWidth.TabIndex = 17;
            numWidth.Value = new decimal(new int[] { 768, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 180);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 18;
            label4.Text = "Ширина";
            // 
            // numSeed
            // 
            numSeed.Location = new Point(140, 217);
            numSeed.Name = "numSeed";
            numSeed.Size = new Size(50, 23);
            numSeed.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 219);
            label5.Name = "label5";
            label5.Size = new Size(105, 15);
            label5.TabIndex = 20;
            label5.Text = "Сид(по желанию)";
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.Location = new Point(92, 287);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new Size(98, 42);
            btnBrowseOutput.TabIndex = 21;
            btnBrowseOutput.Text = "Папка сохранения";
            btnBrowseOutput.UseVisualStyleBackColor = true;
            btnBrowseOutput.Click += btnBrowseOutput_Click_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(730, 140);
            label6.Name = "label6";
            label6.Size = new Size(148, 15);
            label6.TabIndex = 22;
            label6.Text = "для негативного промпта";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(730, 86);
            label7.Name = "label7";
            label7.Size = new Size(150, 15);
            label7.TabIndex = 23;
            label7.Text = "для позитивного промпта";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(686, 175);
            label8.Name = "label8";
            label8.Size = new Size(57, 15);
            label8.TabIndex = 24;
            label8.Text = "для позы";
            // 
            // numLoraWeight
            // 
            numLoraWeight.DecimalPlaces = 2;
            numLoraWeight.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numLoraWeight.Location = new Point(693, 338);
            numLoraWeight.Maximum = new decimal(new int[] { 15, 0, 0, 65536 });
            numLoraWeight.Name = "numLoraWeight";
            numLoraWeight.Size = new Size(74, 23);
            numLoraWeight.TabIndex = 25;
            numLoraWeight.Value = new decimal(new int[] { 65, 0, 0, 131072 });
            numLoraWeight.ValueChanged += numLoraWeight_ValueChanged;
            // 
            // lblLoraStatus
            // 
            lblLoraStatus.AutoSize = true;
            lblLoraStatus.Location = new Point(576, 28);
            lblLoraStatus.Name = "lblLoraStatus";
            lblLoraStatus.Size = new Size(102, 15);
            lblLoraStatus.TabIndex = 26;
            lblLoraStatus.Text = "Лора не выбрана";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 490);
            Controls.Add(lblLoraStatus);
            Controls.Add(numLoraWeight);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btnBrowseOutput);
            Controls.Add(label5);
            Controls.Add(numSeed);
            Controls.Add(label4);
            Controls.Add(numWidth);
            Controls.Add(label3);
            Controls.Add(numHeight);
            Controls.Add(btnBrowseModel);
            Controls.Add(lblStatus);
            Controls.Add(chkUseLora);
            Controls.Add(btnBrowseLora);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(picResult);
            Controls.Add(btnGenerate);
            Controls.Add(txtPose);
            Controls.Add(numCfg);
            Controls.Add(numSteps);
            Controls.Add(txtNegative);
            Controls.Add(txtPrompt);
            Name = "Form1";
            Text = "Local SD Generator";
            ((System.ComponentModel.ISupportInitialize)numSteps).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCfg).EndInit();
            ((System.ComponentModel.ISupportInitialize)picResult).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLoraWeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPrompt;
        private TextBox txtNegative;
        private NumericUpDown numSteps;
        private NumericUpDown numCfg;
        private TextBox txtPose;
        private Button btnGenerate;
        private PictureBox picResult;
        private Label label1;
        private Label label2;

        public TextBox txtModelPath { get; private set; }

        private TextBox textBox1;
        private Button btnBrowseLora;
        private CheckBox chkUseLora;
        private Label lblStatus;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button btnBrowseModel;
        private NumericUpDown numHeight;
        private Label label3;
        private NumericUpDown numWidth;
        private Label label4;
        private NumericUpDown numSeed;
        private Label label5;
        private Button btnBrowseOutput;
        private Label label6;
        private Label label7;
        private Label label8;
        private NumericUpDown numLoraWeight;
        private Label lblLoraStatus;
    }
}
