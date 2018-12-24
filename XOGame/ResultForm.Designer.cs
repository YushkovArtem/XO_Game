namespace XOGame
{
    partial class ResultForm
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
            this.dGVMain = new System.Windows.Forms.DataGridView();
            this.результатBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dGVMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.результатBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVMain
            // 
            this.dGVMain.AllowUserToAddRows = false;
            this.dGVMain.AllowUserToDeleteRows = false;
            this.dGVMain.AllowUserToResizeColumns = false;
            this.dGVMain.AllowUserToResizeRows = false;
            this.dGVMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVMain.Location = new System.Drawing.Point(0, 0);
            this.dGVMain.MultiSelect = false;
            this.dGVMain.Name = "dGVMain";
            this.dGVMain.ReadOnly = true;
            this.dGVMain.RowHeadersVisible = false;
            this.dGVMain.Size = new System.Drawing.Size(317, 401);
            this.dGVMain.TabIndex = 0;
            // 
            // результатBindingSource
            // 
            this.результатBindingSource.DataSource = typeof(XOGameCL.Code.ResultType);
            // 
            // RezultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 401);
            this.Controls.Add(this.dGVMain);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(333, 440);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(333, 440);
            this.Name = "ResultForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "\r\nResult";
            ((System.ComponentModel.ISupportInitialize)(this.dGVMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.результатBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVMain;
        private System.Windows.Forms.BindingSource результатBindingSource;
    }
}