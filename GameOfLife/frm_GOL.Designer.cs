namespace GameOfLife
{
    partial class frm_GameOfLife
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_GameOfLife));
            this.pb_Display = new System.Windows.Forms.PictureBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Step = new System.Windows.Forms.Button();
            this.cb_Edge = new System.Windows.Forms.CheckBox();
            this.btn_Negative = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Default = new System.Windows.Forms.Button();
            this.btn_Random = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.lbl_Side = new System.Windows.Forms.Label();
            this.lbl_Horizontal = new System.Windows.Forms.Label();
            this.lbl_Vertical = new System.Windows.Forms.Label();
            this.lbl_Population_lbl = new System.Windows.Forms.Label();
            this.lbl_Generation_lbl = new System.Windows.Forms.Label();
            this.nud_Time = new System.Windows.Forms.NumericUpDown();
            this.nud_Side = new System.Windows.Forms.NumericUpDown();
            this.nud_Horizontal = new System.Windows.Forms.NumericUpDown();
            this.nud_Vertical = new System.Windows.Forms.NumericUpDown();
            this.nud_Gap = new System.Windows.Forms.NumericUpDown();
            this.lbl_Gap = new System.Windows.Forms.Label();
            this.cb_Border = new System.Windows.Forms.CheckBox();
            this.lbl_Population = new System.Windows.Forms.Label();
            this.lbl_Generation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Side)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Horizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Vertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Gap)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Display
            // 
            this.pb_Display.Location = new System.Drawing.Point(5, 60);
            this.pb_Display.Name = "pb_Display";
            this.pb_Display.Size = new System.Drawing.Size(34, 34);
            this.pb_Display.TabIndex = 0;
            this.pb_Display.TabStop = false;
            this.pb_Display.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_Display_MouseUp);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(5, 5);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(60, 22);
            this.btn_Reset.TabIndex = 1;
            this.btn_Reset.Text = "&Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Step
            // 
            this.btn_Step.Location = new System.Drawing.Point(5, 30);
            this.btn_Step.Name = "btn_Step";
            this.btn_Step.Size = new System.Drawing.Size(60, 22);
            this.btn_Step.TabIndex = 2;
            this.btn_Step.Text = "S&tep";
            this.btn_Step.UseVisualStyleBackColor = true;
            this.btn_Step.Click += new System.EventHandler(this.btn_Step_Click);
            // 
            // cb_Edge
            // 
            this.cb_Edge.AutoSize = true;
            this.cb_Edge.Checked = true;
            this.cb_Edge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Edge.Location = new System.Drawing.Point(339, 42);
            this.cb_Edge.Name = "cb_Edge";
            this.cb_Edge.Size = new System.Drawing.Size(51, 17);
            this.cb_Edge.TabIndex = 3;
            this.cb_Edge.Text = "&Edge";
            this.cb_Edge.UseVisualStyleBackColor = true;
            this.cb_Edge.CheckedChanged += new System.EventHandler(this.cb_Edge_CheckedChanged);
            // 
            // btn_Negative
            // 
            this.btn_Negative.Location = new System.Drawing.Point(70, 5);
            this.btn_Negative.Name = "btn_Negative";
            this.btn_Negative.Size = new System.Drawing.Size(60, 22);
            this.btn_Negative.TabIndex = 5;
            this.btn_Negative.Text = "&Negative";
            this.btn_Negative.UseVisualStyleBackColor = true;
            this.btn_Negative.Click += new System.EventHandler(this.btn_Negative_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(70, 30);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(60, 22);
            this.btn_Start.TabIndex = 4;
            this.btn_Start.Text = "&Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Default
            // 
            this.btn_Default.Location = new System.Drawing.Point(135, 5);
            this.btn_Default.Name = "btn_Default";
            this.btn_Default.Size = new System.Drawing.Size(60, 22);
            this.btn_Default.TabIndex = 7;
            this.btn_Default.Text = "&Default";
            this.btn_Default.UseVisualStyleBackColor = true;
            this.btn_Default.Click += new System.EventHandler(this.btn_Default_Click);
            // 
            // btn_Random
            // 
            this.btn_Random.Location = new System.Drawing.Point(135, 30);
            this.btn_Random.Name = "btn_Random";
            this.btn_Random.Size = new System.Drawing.Size(60, 22);
            this.btn_Random.TabIndex = 6;
            this.btn_Random.Text = "R&andom";
            this.btn_Random.UseVisualStyleBackColor = true;
            this.btn_Random.Click += new System.EventHandler(this.btn_Random_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(465, 5);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(60, 22);
            this.btn_Save.TabIndex = 9;
            this.btn_Save.Text = "&Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(465, 30);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(60, 22);
            this.btn_Load.TabIndex = 8;
            this.btn_Load.Text = "&Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Location = new System.Drawing.Point(312, 5);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(30, 13);
            this.lbl_Time.TabIndex = 10;
            this.lbl_Time.Text = "Ti&me";
            // 
            // lbl_Side
            // 
            this.lbl_Side.AutoSize = true;
            this.lbl_Side.Location = new System.Drawing.Point(362, 5);
            this.lbl_Side.Name = "lbl_Side";
            this.lbl_Side.Size = new System.Drawing.Size(28, 13);
            this.lbl_Side.TabIndex = 11;
            this.lbl_Side.Text = "S&ide";
            // 
            // lbl_Horizontal
            // 
            this.lbl_Horizontal.AutoSize = true;
            this.lbl_Horizontal.Location = new System.Drawing.Point(202, 5);
            this.lbl_Horizontal.Name = "lbl_Horizontal";
            this.lbl_Horizontal.Size = new System.Drawing.Size(54, 13);
            this.lbl_Horizontal.TabIndex = 12;
            this.lbl_Horizontal.Text = "&Horizontal";
            // 
            // lbl_Vertical
            // 
            this.lbl_Vertical.AutoSize = true;
            this.lbl_Vertical.Location = new System.Drawing.Point(257, 5);
            this.lbl_Vertical.Name = "lbl_Vertical";
            this.lbl_Vertical.Size = new System.Drawing.Size(42, 13);
            this.lbl_Vertical.TabIndex = 13;
            this.lbl_Vertical.Text = "&Vertical";
            // 
            // lbl_Population_lbl
            // 
            this.lbl_Population_lbl.AutoSize = true;
            this.lbl_Population_lbl.Location = new System.Drawing.Point(202, 42);
            this.lbl_Population_lbl.Name = "lbl_Population_lbl";
            this.lbl_Population_lbl.Size = new System.Drawing.Size(17, 13);
            this.lbl_Population_lbl.TabIndex = 14;
            this.lbl_Population_lbl.Text = "P:";
            // 
            // lbl_Generation_lbl
            // 
            this.lbl_Generation_lbl.AutoSize = true;
            this.lbl_Generation_lbl.Location = new System.Drawing.Point(257, 42);
            this.lbl_Generation_lbl.Name = "lbl_Generation_lbl";
            this.lbl_Generation_lbl.Size = new System.Drawing.Size(18, 13);
            this.lbl_Generation_lbl.TabIndex = 15;
            this.lbl_Generation_lbl.Text = "G:";
            // 
            // nud_Time
            // 
            this.nud_Time.Location = new System.Drawing.Point(315, 20);
            this.nud_Time.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_Time.Name = "nud_Time";
            this.nud_Time.Size = new System.Drawing.Size(40, 20);
            this.nud_Time.TabIndex = 16;
            this.nud_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Time.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nud_Time.ValueChanged += new System.EventHandler(this.nud_Time_ValueChanged);
            // 
            // nud_Side
            // 
            this.nud_Side.Location = new System.Drawing.Point(365, 20);
            this.nud_Side.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_Side.Name = "nud_Side";
            this.nud_Side.Size = new System.Drawing.Size(40, 20);
            this.nud_Side.TabIndex = 17;
            this.nud_Side.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Side.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nud_Side.ValueChanged += new System.EventHandler(this.nud_Side_ValueChanged);
            // 
            // nud_Horizontal
            // 
            this.nud_Horizontal.Location = new System.Drawing.Point(205, 20);
            this.nud_Horizontal.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nud_Horizontal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Horizontal.Name = "nud_Horizontal";
            this.nud_Horizontal.Size = new System.Drawing.Size(45, 20);
            this.nud_Horizontal.TabIndex = 18;
            this.nud_Horizontal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Horizontal.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nud_Horizontal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Horizontal.ValueChanged += new System.EventHandler(this.nud_Horizontal_ValueChanged);
            // 
            // nud_Vertical
            // 
            this.nud_Vertical.Location = new System.Drawing.Point(260, 20);
            this.nud_Vertical.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nud_Vertical.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Vertical.Name = "nud_Vertical";
            this.nud_Vertical.Size = new System.Drawing.Size(45, 20);
            this.nud_Vertical.TabIndex = 19;
            this.nud_Vertical.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Vertical.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nud_Vertical.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Vertical.ValueChanged += new System.EventHandler(this.nud_Vertical_ValueChanged);
            // 
            // nud_Gap
            // 
            this.nud_Gap.Location = new System.Drawing.Point(415, 20);
            this.nud_Gap.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_Gap.Name = "nud_Gap";
            this.nud_Gap.Size = new System.Drawing.Size(40, 20);
            this.nud_Gap.TabIndex = 20;
            this.nud_Gap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Gap.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nud_Gap.ValueChanged += new System.EventHandler(this.nud_Gap_ValueChanged);
            // 
            // lbl_Gap
            // 
            this.lbl_Gap.AutoSize = true;
            this.lbl_Gap.Location = new System.Drawing.Point(412, 5);
            this.lbl_Gap.Name = "lbl_Gap";
            this.lbl_Gap.Size = new System.Drawing.Size(27, 13);
            this.lbl_Gap.TabIndex = 21;
            this.lbl_Gap.Text = "&Gap";
            // 
            // cb_Border
            // 
            this.cb_Border.AutoSize = true;
            this.cb_Border.Checked = true;
            this.cb_Border.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Border.Location = new System.Drawing.Point(398, 42);
            this.cb_Border.Name = "cb_Border";
            this.cb_Border.Size = new System.Drawing.Size(57, 17);
            this.cb_Border.TabIndex = 22;
            this.cb_Border.Text = "&Border";
            this.cb_Border.UseVisualStyleBackColor = true;
            this.cb_Border.CheckedChanged += new System.EventHandler(this.cb_Border_CheckedChanged);
            // 
            // lbl_Population
            // 
            this.lbl_Population.AutoSize = true;
            this.lbl_Population.Location = new System.Drawing.Point(220, 42);
            this.lbl_Population.MinimumSize = new System.Drawing.Size(10, 0);
            this.lbl_Population.Name = "lbl_Population";
            this.lbl_Population.Size = new System.Drawing.Size(10, 13);
            this.lbl_Population.TabIndex = 23;
            this.lbl_Population.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_Generation
            // 
            this.lbl_Generation.AutoSize = true;
            this.lbl_Generation.Location = new System.Drawing.Point(275, 42);
            this.lbl_Generation.MinimumSize = new System.Drawing.Size(10, 0);
            this.lbl_Generation.Name = "lbl_Generation";
            this.lbl_Generation.Size = new System.Drawing.Size(10, 13);
            this.lbl_Generation.TabIndex = 24;
            this.lbl_Generation.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frm_GameOfLife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(638, 509);
            this.Controls.Add(this.lbl_Generation);
            this.Controls.Add(this.lbl_Population);
            this.Controls.Add(this.cb_Border);
            this.Controls.Add(this.lbl_Gap);
            this.Controls.Add(this.nud_Gap);
            this.Controls.Add(this.nud_Vertical);
            this.Controls.Add(this.nud_Horizontal);
            this.Controls.Add(this.nud_Side);
            this.Controls.Add(this.nud_Time);
            this.Controls.Add(this.lbl_Generation_lbl);
            this.Controls.Add(this.lbl_Population_lbl);
            this.Controls.Add(this.lbl_Vertical);
            this.Controls.Add(this.lbl_Horizontal);
            this.Controls.Add(this.lbl_Side);
            this.Controls.Add(this.lbl_Time);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btn_Default);
            this.Controls.Add(this.btn_Random);
            this.Controls.Add(this.btn_Negative);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.cb_Edge);
            this.Controls.Add(this.btn_Step);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.pb_Display);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_GameOfLife";
            this.Text = "Game Of Life";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_GameOfLife_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_GameOfLife_KeyUp);
            this.Load += new System.EventHandler(this.frm_GameOfLife_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Side)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Horizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Vertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Gap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Display;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Step;
        private System.Windows.Forms.CheckBox cb_Edge;
        private System.Windows.Forms.Button btn_Negative;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Default;
        private System.Windows.Forms.Button btn_Random;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Label lbl_Side;
        private System.Windows.Forms.Label lbl_Horizontal;
        private System.Windows.Forms.Label lbl_Vertical;
        private System.Windows.Forms.Label lbl_Population_lbl;
        private System.Windows.Forms.Label lbl_Generation_lbl;
        private System.Windows.Forms.NumericUpDown nud_Time;
        private System.Windows.Forms.NumericUpDown nud_Side;
        private System.Windows.Forms.NumericUpDown nud_Horizontal;
        private System.Windows.Forms.NumericUpDown nud_Vertical;
        private System.Windows.Forms.NumericUpDown nud_Gap;
        private System.Windows.Forms.Label lbl_Gap;
        private System.Windows.Forms.CheckBox cb_Border;
        private System.Windows.Forms.Label lbl_Population;
        private System.Windows.Forms.Label lbl_Generation;
    }
}

