
namespace SAPA
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
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.buttonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnRunInput = new System.Windows.Forms.Button();
            this.btnOpenInput = new System.Windows.Forms.Button();
            this.btnOpenSource = new System.Windows.Forms.Button();
            this.btnCompile = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.sourceOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.inputOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.compilerOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainTableLayoutPanel.SuspendLayout();
            this.buttonTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 3;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.mainTableLayoutPanel.Controls.Add(this.textBoxSource, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.buttonTableLayoutPanel, 2, 0);
            this.mainTableLayoutPanel.Controls.Add(this.textBoxOutput, 1, 1);
            this.mainTableLayoutPanel.Controls.Add(this.textBoxInput, 0, 1);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1418, 844);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // textBoxSource
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.textBoxSource, 2);
            this.textBoxSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSource.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSource.Location = new System.Drawing.Point(3, 3);
            this.textBoxSource.Multiline = true;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSource.Size = new System.Drawing.Size(1212, 588);
            this.textBoxSource.TabIndex = 0;
            this.textBoxSource.WordWrap = false;
            this.textBoxSource.TextChanged += new System.EventHandler(this.textBoxSource_TextChanged);
            // 
            // buttonTableLayoutPanel
            // 
            this.buttonTableLayoutPanel.ColumnCount = 1;
            this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonTableLayoutPanel.Controls.Add(this.btnSubmit, 0, 4);
            this.buttonTableLayoutPanel.Controls.Add(this.btnRunInput, 0, 3);
            this.buttonTableLayoutPanel.Controls.Add(this.btnOpenInput, 0, 1);
            this.buttonTableLayoutPanel.Controls.Add(this.btnOpenSource, 0, 0);
            this.buttonTableLayoutPanel.Controls.Add(this.btnCompile, 0, 2);
            this.buttonTableLayoutPanel.Controls.Add(this.btnAbout, 0, 5);
            this.buttonTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTableLayoutPanel.Location = new System.Drawing.Point(1221, 3);
            this.buttonTableLayoutPanel.Name = "buttonTableLayoutPanel";
            this.buttonTableLayoutPanel.RowCount = 7;
            this.mainTableLayoutPanel.SetRowSpan(this.buttonTableLayoutPanel, 2);
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonTableLayoutPanel.Size = new System.Drawing.Size(194, 838);
            this.buttonTableLayoutPanel.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSubmit.Location = new System.Drawing.Point(3, 203);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(188, 44);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.Submit);
            // 
            // btnRunInput
            // 
            this.btnRunInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRunInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRunInput.Location = new System.Drawing.Point(3, 153);
            this.btnRunInput.Name = "btnRunInput";
            this.btnRunInput.Size = new System.Drawing.Size(188, 44);
            this.btnRunInput.TabIndex = 4;
            this.btnRunInput.Text = "&Run Input";
            this.btnRunInput.UseVisualStyleBackColor = true;
            this.btnRunInput.Click += new System.EventHandler(this.RunInput);
            // 
            // btnOpenInput
            // 
            this.btnOpenInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnOpenInput.Location = new System.Drawing.Point(3, 53);
            this.btnOpenInput.Name = "btnOpenInput";
            this.btnOpenInput.Size = new System.Drawing.Size(188, 44);
            this.btnOpenInput.TabIndex = 2;
            this.btnOpenInput.Text = "Open &Input...";
            this.btnOpenInput.UseVisualStyleBackColor = true;
            this.btnOpenInput.Click += new System.EventHandler(this.OpenInputFile);
            // 
            // btnOpenSource
            // 
            this.btnOpenSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnOpenSource.Location = new System.Drawing.Point(3, 3);
            this.btnOpenSource.Name = "btnOpenSource";
            this.btnOpenSource.Size = new System.Drawing.Size(188, 44);
            this.btnOpenSource.TabIndex = 1;
            this.btnOpenSource.Text = "Open Source...";
            this.btnOpenSource.UseVisualStyleBackColor = true;
            this.btnOpenSource.Click += new System.EventHandler(this.OpenSourceFile);
            // 
            // btnCompile
            // 
            this.btnCompile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCompile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCompile.Location = new System.Drawing.Point(3, 103);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(188, 44);
            this.btnCompile.TabIndex = 3;
            this.btnCompile.Text = "&Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.Compile);
            // 
            // btnAbout
            // 
            this.btnAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAbout.Location = new System.Drawing.Point(3, 253);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(188, 44);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.Text = "&About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.ShowAbout);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutput.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutput.Location = new System.Drawing.Point(612, 597);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(603, 244);
            this.textBoxOutput.TabIndex = 8;
            this.textBoxOutput.WordWrap = false;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInput.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInput.Location = new System.Drawing.Point(3, 597);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxInput.Size = new System.Drawing.Size(603, 244);
            this.textBoxInput.TabIndex = 7;
            this.textBoxInput.WordWrap = false;
            // 
            // sourceOpenFileDialog
            // 
            this.sourceOpenFileDialog.Title = "Open Source File";
            // 
            // inputOpenFileDialog
            // 
            this.inputOpenFileDialog.Title = "Open Input File";
            // 
            // compilerOpenFileDialog
            // 
            this.compilerOpenFileDialog.Filter = "Executable file|*.exe|All files|*.*";
            this.compilerOpenFileDialog.Title = "Locate Compiler";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 844);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(720, 450);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Simple Automated Programming Assessor (SAPA)";
            this.Load += new System.EventHandler(this.Initialise);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.buttonTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Button btnOpenSource;
        private System.Windows.Forms.TableLayoutPanel buttonTableLayoutPanel;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnRunInput;
        private System.Windows.Forms.Button btnOpenInput;
        private System.Windows.Forms.OpenFileDialog sourceOpenFileDialog;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.OpenFileDialog inputOpenFileDialog;
        private System.Windows.Forms.OpenFileDialog compilerOpenFileDialog;
    }
}

