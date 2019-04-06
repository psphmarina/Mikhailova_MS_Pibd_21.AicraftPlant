namespace AircraftBuildingPlantView
{
    partial class FormCustomerOrders
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.buttonSform = new System.Windows.Forms.Button();
            this.buttonPdf = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "С";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(36, 4);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(114, 20);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "по";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(212, 7);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(104, 20);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // buttonSform
            // 
            this.buttonSform.Location = new System.Drawing.Point(351, 7);
            this.buttonSform.Name = "buttonSform";
            this.buttonSform.Size = new System.Drawing.Size(108, 30);
            this.buttonSform.TabIndex = 4;
            this.buttonSform.Text = "Сформировать";
            this.buttonSform.UseVisualStyleBackColor = true;
            this.buttonSform.Click += new System.EventHandler(this.buttonSform_Click);
            // 
            // buttonPdf
            // 
            this.buttonPdf.Location = new System.Drawing.Point(539, 9);
            this.buttonPdf.Name = "buttonPdf";
            this.buttonPdf.Size = new System.Drawing.Size(70, 28);
            this.buttonPdf.TabIndex = 5;
            this.buttonPdf.Text = "В pdf";
            this.buttonPdf.UseVisualStyleBackColor = true;
            this.buttonPdf.Click += new System.EventHandler(this.buttonPdf_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "AircraftBuildingPlantView.Report.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(13, 43);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(756, 327);
            this.reportViewer.TabIndex = 6;
            // 
            // FormCustomerOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonPdf);
            this.Controls.Add(this.buttonSform);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.label1);
            this.Name = "FormCustomerOrders";
            this.Text = "Заказы клиентов";
            this.Load += new System.EventHandler(this.FormCustomerOrders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Button buttonSform;
        private System.Windows.Forms.Button buttonPdf;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}