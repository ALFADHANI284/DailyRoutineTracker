namespace DailyRoutineTracker
{
    partial class home
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
            dataGridView1 = new DataGridView();
            btntambah = new Button();
            judul = new Label();
            pleft = new Panel();
            dtptimes = new DateTimePicker();
            label2 = new Label();
            txtbactivity = new TextBox();
            lblkegiatan = new Label();
            dtptime = new DateTimePicker();
            lblwkt = new Label();
            dtpdate = new DateTimePicker();
            lbltngl = new Label();
            pright = new Panel();
            btntxt = new Button();
            dgv = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pleft.SuspendLayout();
            pright.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(462, 84);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(0, 0);
            dataGridView1.TabIndex = 3;
            // 
            // btntambah
            // 
            btntambah.BackColor = Color.Red;
            btntambah.FlatAppearance.BorderSize = 0;
            btntambah.FlatStyle = FlatStyle.Flat;
            btntambah.ForeColor = Color.White;
            btntambah.Location = new Point(4, 173);
            btntambah.Name = "btntambah";
            btntambah.Size = new Size(110, 34);
            btntambah.TabIndex = 4;
            btntambah.Text = "Tambah";
            btntambah.UseVisualStyleBackColor = false;
            btntambah.Click += btntambah_Click;
            // 
            // judul
            // 
            judul.AutoSize = true;
            judul.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            judul.Location = new Point(288, 22);
            judul.Name = "judul";
            judul.Size = new Size(335, 41);
            judul.TabIndex = 5;
            judul.Text = "Daily Routine Tracker  ";
            judul.Click += label1_Click;
            // 
            // pleft
            // 
            pleft.BorderStyle = BorderStyle.FixedSingle;
            pleft.Controls.Add(dtptimes);
            pleft.Controls.Add(label2);
            pleft.Controls.Add(btntambah);
            pleft.Controls.Add(txtbactivity);
            pleft.Controls.Add(lblkegiatan);
            pleft.Controls.Add(dtptime);
            pleft.Controls.Add(lblwkt);
            pleft.Controls.Add(dtpdate);
            pleft.Controls.Add(lbltngl);
            pleft.ForeColor = Color.Black;
            pleft.ImeMode = ImeMode.NoControl;
            pleft.Location = new Point(20, 84);
            pleft.Name = "pleft";
            pleft.Size = new Size(344, 221);
            pleft.TabIndex = 11;
            pleft.Paint += pleft_Paint;
            // 
            // dtptimes
            // 
            dtptimes.CustomFormat = "HH : mm";
            dtptimes.Format = DateTimePickerFormat.Custom;
            dtptimes.Location = new Point(218, 36);
            dtptimes.Name = "dtptimes";
            dtptimes.ShowUpDown = true;
            dtptimes.Size = new Size(102, 27);
            dtptimes.TabIndex = 19;
            dtptimes.ValueChanged += dateTimePicker1_ValueChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(170, 34);
            label2.Name = "label2";
            label2.Size = new Size(42, 28);
            label2.TabIndex = 18;
            label2.Text = "-->";
            label2.Click += label2_Click;
            // 
            // txtbactivity
            // 
            txtbactivity.BorderStyle = BorderStyle.FixedSingle;
            txtbactivity.Location = new Point(70, 72);
            txtbactivity.Multiline = true;
            txtbactivity.Name = "txtbactivity";
            txtbactivity.Size = new Size(251, 95);
            txtbactivity.TabIndex = 13;
            // 
            // lblkegiatan
            // 
            lblkegiatan.AutoSize = true;
            lblkegiatan.Location = new Point(4, 72);
            lblkegiatan.Name = "lblkegiatan";
            lblkegiatan.Size = new Size(60, 20);
            lblkegiatan.TabIndex = 16;
            lblkegiatan.Text = "Kegitan";
            // 
            // dtptime
            // 
            dtptime.CustomFormat = "HH : mm";
            dtptime.Format = DateTimePickerFormat.Custom;
            dtptime.Location = new Point(70, 34);
            dtptime.Name = "dtptime";
            dtptime.ShowUpDown = true;
            dtptime.Size = new Size(94, 27);
            dtptime.TabIndex = 15;
            dtptime.ValueChanged += dtptime_ValueChanged;
            // 
            // lblwkt
            // 
            lblwkt.AutoSize = true;
            lblwkt.Location = new Point(3, 34);
            lblwkt.Name = "lblwkt";
            lblwkt.Size = new Size(50, 20);
            lblwkt.TabIndex = 14;
            lblwkt.Text = "Waktu";
            lblwkt.Click += lblwkt_Click;
            // 
            // dtpdate
            // 
            dtpdate.Location = new Point(70, 3);
            dtpdate.Name = "dtpdate";
            dtpdate.Size = new Size(250, 27);
            dtpdate.TabIndex = 13;
            // 
            // lbltngl
            // 
            lbltngl.AutoSize = true;
            lbltngl.Location = new Point(3, 3);
            lbltngl.Name = "lbltngl";
            lbltngl.Size = new Size(61, 20);
            lbltngl.TabIndex = 13;
            lbltngl.Text = "Tanggal";
            lbltngl.Click += lbltngl_Click;
            // 
            // pright
            // 
            pright.BorderStyle = BorderStyle.FixedSingle;
            pright.Controls.Add(btntxt);
            pright.Controls.Add(dgv);
            pright.Location = new Point(504, 84);
            pright.Name = "pright";
            pright.Size = new Size(423, 366);
            pright.TabIndex = 12;
            pright.Paint += pright_Paint;
            // 
            // btntxt
            // 
            btntxt.BackColor = Color.Red;
            btntxt.ForeColor = Color.Transparent;
            btntxt.Location = new Point(12, 408);
            btntxt.Name = "btntxt";
            btntxt.Size = new Size(142, 29);
            btntxt.TabIndex = 1;
            btntxt.Text = "Export Text";
            btntxt.UseVisualStyleBackColor = false;
            btntxt.Click += btntxt_Click_1;
            // 
            // dgv
            // 
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(-1, -1);
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 51;
            dgv.Size = new Size(423, 366);
            dgv.TabIndex = 13;
            // 
            // home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(926, 450);
            Controls.Add(pright);
            Controls.Add(pleft);
            Controls.Add(judul);
            Controls.Add(dataGridView1);
            Name = "home";
            Text = "Home";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pleft.ResumeLayout(false);
            pleft.PerformLayout();
            pright.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button btntambah;
        private Label judul;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel pleft;
        private Label lbltngl;
        private DateTimePicker dtpdate;
        private Label lblwkt;
        private DateTimePicker dtptime;
        private Label lblkegiatan;
        private TextBox txtbactivity;
        private Panel pright;
        private DataGridView dgv;
        private Button button1;
        private Button btntxt;
        private DateTimePicker dtptimes;
    }
}
