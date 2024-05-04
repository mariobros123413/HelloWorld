﻿namespace HelloWorld
{
    partial class FormMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serializacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.numericUpDown_Traslation_X = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Traslation_Y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Traslation_Z = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Angle = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Scaling_X = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Scaling_Y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Scaling_Z = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ejeXtextbox = new System.Windows.Forms.CheckBox();
            this.ejeYtextbox = new System.Windows.Forms.CheckBox();
            this.ejeZtextbox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Traslation_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Traslation_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Traslation_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Scaling_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Scaling_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Scaling_Z)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serializacionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serializacionToolStripMenuItem
            // 
            this.serializacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripMenuItem,
            this.abrirToolStripMenuItem});
            this.serializacionToolStripMenuItem.Name = "serializacionToolStripMenuItem";
            this.serializacionToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.serializacionToolStripMenuItem.Text = "Serializacion";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(104, 65);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(176, 303);
            this.treeView1.TabIndex = 1;
            // 
            // numericUpDown_Traslation_X
            // 
            this.numericUpDown_Traslation_X.DecimalPlaces = 1;
            this.numericUpDown_Traslation_X.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_Traslation_X.Location = new System.Drawing.Point(355, 78);
            this.numericUpDown_Traslation_X.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_Traslation_X.Name = "numericUpDown_Traslation_X";
            this.numericUpDown_Traslation_X.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Traslation_X.TabIndex = 2;
            this.numericUpDown_Traslation_X.ValueChanged += new System.EventHandler(this.numericUpDown_Position_X_ValueChanged);
            // 
            // numericUpDown_Traslation_Y
            // 
            this.numericUpDown_Traslation_Y.DecimalPlaces = 1;
            this.numericUpDown_Traslation_Y.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_Traslation_Y.Location = new System.Drawing.Point(355, 104);
            this.numericUpDown_Traslation_Y.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_Traslation_Y.Name = "numericUpDown_Traslation_Y";
            this.numericUpDown_Traslation_Y.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Traslation_Y.TabIndex = 3;
            this.numericUpDown_Traslation_Y.ValueChanged += new System.EventHandler(this.numericUpDown_Position_Y_ValueChanged);
            // 
            // numericUpDown_Traslation_Z
            // 
            this.numericUpDown_Traslation_Z.DecimalPlaces = 1;
            this.numericUpDown_Traslation_Z.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_Traslation_Z.Location = new System.Drawing.Point(355, 130);
            this.numericUpDown_Traslation_Z.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_Traslation_Z.Name = "numericUpDown_Traslation_Z";
            this.numericUpDown_Traslation_Z.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Traslation_Z.TabIndex = 4;
            this.numericUpDown_Traslation_Z.ValueChanged += new System.EventHandler(this.numericUpDown_Position_Z_ValueChanged);
            // 
            // numericUpDown_Angle
            // 
            this.numericUpDown_Angle.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Angle.Location = new System.Drawing.Point(399, 180);
            this.numericUpDown_Angle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown_Angle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDown_Angle.Name = "numericUpDown_Angle";
            this.numericUpDown_Angle.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Angle.TabIndex = 5;
            this.numericUpDown_Angle.ValueChanged += new System.EventHandler(this.numericUpDown_Rotation_X_ValueChanged);
            // 
            // numericUpDown_Scaling_X
            // 
            this.numericUpDown_Scaling_X.DecimalPlaces = 2;
            this.numericUpDown_Scaling_X.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Scaling_X.Location = new System.Drawing.Point(355, 274);
            this.numericUpDown_Scaling_X.Name = "numericUpDown_Scaling_X";
            this.numericUpDown_Scaling_X.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_Scaling_X.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Scaling_X.TabIndex = 8;
            this.numericUpDown_Scaling_X.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Scaling_X.ValueChanged += new System.EventHandler(this.numericUpDown_Scaling_X_ValueChanged);
            // 
            // numericUpDown_Scaling_Y
            // 
            this.numericUpDown_Scaling_Y.DecimalPlaces = 2;
            this.numericUpDown_Scaling_Y.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Scaling_Y.Location = new System.Drawing.Point(355, 300);
            this.numericUpDown_Scaling_Y.Name = "numericUpDown_Scaling_Y";
            this.numericUpDown_Scaling_Y.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Scaling_Y.TabIndex = 9;
            this.numericUpDown_Scaling_Y.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Scaling_Y.ValueChanged += new System.EventHandler(this.numericUpDown_Scaling_Y_ValueChanged);
            // 
            // numericUpDown_Scaling_Z
            // 
            this.numericUpDown_Scaling_Z.DecimalPlaces = 2;
            this.numericUpDown_Scaling_Z.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Scaling_Z.Location = new System.Drawing.Point(355, 326);
            this.numericUpDown_Scaling_Z.Name = "numericUpDown_Scaling_Z";
            this.numericUpDown_Scaling_Z.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Scaling_Z.TabIndex = 10;
            this.numericUpDown_Scaling_Z.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Scaling_Z.ValueChanged += new System.EventHandler(this.numericUpDown_Scaling_Z_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Traslación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Escalación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Rotación";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Grados";
            // 
            // ejeXtextbox
            // 
            this.ejeXtextbox.AutoSize = true;
            this.ejeXtextbox.Location = new System.Drawing.Point(355, 206);
            this.ejeXtextbox.Name = "ejeXtextbox";
            this.ejeXtextbox.Size = new System.Drawing.Size(51, 17);
            this.ejeXtextbox.TabIndex = 16;
            this.ejeXtextbox.Text = "Eje X";
            this.ejeXtextbox.UseVisualStyleBackColor = true;
            // 
            // ejeYtextbox
            // 
            this.ejeYtextbox.AutoSize = true;
            this.ejeYtextbox.Location = new System.Drawing.Point(424, 206);
            this.ejeYtextbox.Name = "ejeYtextbox";
            this.ejeYtextbox.Size = new System.Drawing.Size(51, 17);
            this.ejeYtextbox.TabIndex = 17;
            this.ejeYtextbox.Text = "Eje Y";
            this.ejeYtextbox.UseVisualStyleBackColor = true;
            // 
            // ejeZtextbox
            // 
            this.ejeZtextbox.AutoSize = true;
            this.ejeZtextbox.Location = new System.Drawing.Point(496, 206);
            this.ejeZtextbox.Name = "ejeZtextbox";
            this.ejeZtextbox.Size = new System.Drawing.Size(51, 17);
            this.ejeZtextbox.TabIndex = 18;
            this.ejeZtextbox.Text = "Eje Z";
            this.ejeZtextbox.UseVisualStyleBackColor = true;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ejeZtextbox);
            this.Controls.Add(this.ejeYtextbox);
            this.Controls.Add(this.ejeXtextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_Scaling_Z);
            this.Controls.Add(this.numericUpDown_Scaling_Y);
            this.Controls.Add(this.numericUpDown_Scaling_X);
            this.Controls.Add(this.numericUpDown_Angle);
            this.Controls.Add(this.numericUpDown_Traslation_Z);
            this.Controls.Add(this.numericUpDown_Traslation_Y);
            this.Controls.Add(this.numericUpDown_Traslation_X);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Traslation_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Traslation_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Traslation_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Scaling_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Scaling_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Scaling_Z)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serializacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Traslation_X;
        private System.Windows.Forms.NumericUpDown numericUpDown_Traslation_Y;
        private System.Windows.Forms.NumericUpDown numericUpDown_Traslation_Z;
        private System.Windows.Forms.NumericUpDown numericUpDown_Angle;
        private System.Windows.Forms.NumericUpDown numericUpDown_Scaling_X;
        private System.Windows.Forms.NumericUpDown numericUpDown_Scaling_Y;
        private System.Windows.Forms.NumericUpDown numericUpDown_Scaling_Z;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ejeXtextbox;
        private System.Windows.Forms.CheckBox ejeYtextbox;
        private System.Windows.Forms.CheckBox ejeZtextbox;
    }
}