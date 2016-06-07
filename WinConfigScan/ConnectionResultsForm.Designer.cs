namespace WinConfigChecker
{
    partial class ConnectionResultsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionResultsForm));
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.OrdinalIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConnectionErrorText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.connectionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.connectionStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testStatusDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.connectionTestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionTestBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToOrderColumns = true;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrdinalIndex,
            this.connectionNameDataGridViewTextBoxColumn,
            this.connectionStringDataGridViewTextBoxColumn,
            this.testStatusDescriptionDataGridViewTextBoxColumn,
            this.ConnectionErrorText,
            this.sourceDataGridViewTextBoxColumn});
            this.dataGrid.DataSource = this.connectionTestBindingSource;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(3, 23);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowTemplate.Height = 24;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid.Size = new System.Drawing.Size(895, 519);
            this.dataGrid.TabIndex = 1;
            this.dataGrid.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGrid_RowPrePaint);
            // 
            // OrdinalIndex
            // 
            this.OrdinalIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrdinalIndex.DataPropertyName = "OrdinalIndex";
            this.OrdinalIndex.FillWeight = 50.76142F;
            this.OrdinalIndex.Frozen = true;
            this.OrdinalIndex.HeaderText = "#";
            this.OrdinalIndex.Name = "OrdinalIndex";
            this.OrdinalIndex.ReadOnly = true;
            this.OrdinalIndex.Width = 30;
            // 
            // ConnectionErrorText
            // 
            this.ConnectionErrorText.DataPropertyName = "ConnectionErrorText";
            this.ConnectionErrorText.FillWeight = 112.3096F;
            this.ConnectionErrorText.HeaderText = "Error";
            this.ConnectionErrorText.Name = "ConnectionErrorText";
            this.ConnectionErrorText.ReadOnly = true;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(895, 14);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.progressBar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGrid, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(901, 545);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // connectionNameDataGridViewTextBoxColumn
            // 
            this.connectionNameDataGridViewTextBoxColumn.DataPropertyName = "ConnectionName";
            this.connectionNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.connectionNameDataGridViewTextBoxColumn.Name = "connectionNameDataGridViewTextBoxColumn";
            this.connectionNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // connectionStringDataGridViewTextBoxColumn
            // 
            this.connectionStringDataGridViewTextBoxColumn.DataPropertyName = "ConnectionString";
            this.connectionStringDataGridViewTextBoxColumn.HeaderText = "Connection String";
            this.connectionStringDataGridViewTextBoxColumn.Name = "connectionStringDataGridViewTextBoxColumn";
            this.connectionStringDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // testStatusDescriptionDataGridViewTextBoxColumn
            // 
            this.testStatusDescriptionDataGridViewTextBoxColumn.DataPropertyName = "TestStatusDescription";
            this.testStatusDescriptionDataGridViewTextBoxColumn.HeaderText = "Test Status";
            this.testStatusDescriptionDataGridViewTextBoxColumn.Name = "testStatusDescriptionDataGridViewTextBoxColumn";
            this.testStatusDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sourceDataGridViewTextBoxColumn
            // 
            this.sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
            this.sourceDataGridViewTextBoxColumn.HeaderText = "Source";
            this.sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
            this.sourceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // connectionTestBindingSource
            // 
            this.connectionTestBindingSource.DataMember = "DatabaseConnectionTestDetails";
            this.connectionTestBindingSource.DataSource = typeof(TeeBee.ConfigScan.Common.DatabaseConnectionTestDetailsDataSet);
            // 
            // ConnectionResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 545);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConnectionResultsForm";
            this.Text = "Connection Test Results";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionResultsForm_FormClosing);
            this.Load += new System.EventHandler(this.ConnectionResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.connectionTestBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;        
        private System.Windows.Forms.BindingSource connectionTestBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdinalIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn connectionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn connectionStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testStatusDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConnectionErrorText;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
 

    }
}