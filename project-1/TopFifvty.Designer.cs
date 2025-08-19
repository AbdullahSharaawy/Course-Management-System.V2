namespace project_1
{
    partial class TopFifve
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
            this.dgTopFifvty = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgTopFifvty)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTopFifvty
            // 
            this.dgTopFifvty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTopFifvty.Location = new System.Drawing.Point(1, 2);
            this.dgTopFifvty.Name = "dgTopFifvty";
            this.dgTopFifvty.Size = new System.Drawing.Size(800, 640);
            this.dgTopFifvty.TabIndex = 0;
            // 
            // TopFifve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 641);
            this.Controls.Add(this.dgTopFifvty);
            this.Name = "TopFifve";
            this.Text = "TopFifvty";
            ((System.ComponentModel.ISupportInitialize)(this.dgTopFifvty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTopFifvty;
    }
}