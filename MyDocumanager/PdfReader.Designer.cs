namespace MyDocumanager
{
  partial class PdfReader
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfReader));
      this.pdfDisplay = new AxAcroPDFLib.AxAcroPDF();
      ((System.ComponentModel.ISupportInitialize)(this.pdfDisplay)).BeginInit();
      this.SuspendLayout();
      // 
      // pdfDisplay
      // 
      this.pdfDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pdfDisplay.Enabled = true;
      this.pdfDisplay.Location = new System.Drawing.Point(0, 0);
      this.pdfDisplay.Name = "pdfDisplay";
      this.pdfDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfDisplay.OcxState")));
      this.pdfDisplay.Size = new System.Drawing.Size(783, 561);
      this.pdfDisplay.TabIndex = 0;
      // 
      // PdfReader
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 561);
      this.Controls.Add(this.pdfDisplay);
      this.Name = "PdfReader";
      this.ShowInTaskbar = false;
      this.Text = "PdfReader";
      ((System.ComponentModel.ISupportInitialize)(this.pdfDisplay)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private AxAcroPDFLib.AxAcroPDF pdfDisplay;
  }
}