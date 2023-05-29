
namespace INV_SYS.Formularios
{
    partial class frmImpresionDocumento
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
            this.rptDocumento = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rptDocumento
            // 
            this.rptDocumento.ActiveViewIndex = -1;
            this.rptDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptDocumento.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptDocumento.Location = new System.Drawing.Point(0, 0);
            this.rptDocumento.Margin = new System.Windows.Forms.Padding(5);
            this.rptDocumento.Name = "rptDocumento";
            this.rptDocumento.Size = new System.Drawing.Size(800, 450);
            this.rptDocumento.TabIndex = 2;
            this.rptDocumento.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmImpresionDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptDocumento);
            this.Name = "frmImpresionDocumento";
            this.Text = "Impresión";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptDocumento;
    }
}