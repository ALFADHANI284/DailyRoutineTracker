using System;
using System.Collections.Generic;
using System.ComponentModel;   // BindingList
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace DailyRoutineTracker
{
    public partial class home : Form
    {
        // ========= Model =========
        public class RoutineItem
        {
            public Guid Id { get; set; } = Guid.NewGuid();
            public DateTime Date { get; set; } = DateTime.Today;
            public int Hour { get; set; }
            public int Minute { get; set; }
            public string Activity { get; set; } = "";

            public DateTime At => new DateTime(Date.Year, Date.Month, Date.Day, Hour, Minute, 0);
            public string Tanggal => At.ToString("dd MMM yyyy");
            public string Waktu => At.ToString("HH:mm");
        }

        // ========= State & path =========
        private BindingList<RoutineItem> _items = new BindingList<RoutineItem>();
        private readonly BindingSource _bs = new BindingSource();

        private readonly string _folder =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                         "DailyRoutineTracker");
        private string FilePath => Path.Combine(_folder, "routines.json");

        public home()
        {
            InitializeComponent();
            // Jangan daftar event di sini untuk menghindari duplikasi.
            // Semua event dihubungkan lewat Designer (Properties → Events).
        }

        // ========= FORM LOAD =========
        private void Form1_Load(object sender, EventArgs e)
        {
            // Setup Date / Time picker
            dtpdate.Format = DateTimePickerFormat.Short;

            dtptime.Format = DateTimePickerFormat.Custom;
            dtptime.CustomFormat = "HH:mm";
            dtptime.ShowUpDown = true; // spin-box, tanpa kalender

            // DataGridView setup (tanpa ID, tambah tombol Hapus)
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;  // hilangkan baris kosong
            dgv.RowHeadersVisible = false;  // hilangkan header kiri
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            dgv.Columns.Clear();
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTanggal",
                HeaderText = "Tanggal",
                DataPropertyName = "Tanggal",
                Width = 120
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colWaktu",
                HeaderText = "Waktu",
                DataPropertyName = "Waktu",
                Width = 80
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colActivity",
                HeaderText = "Kegiatan",
                DataPropertyName = "Activity",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgv.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colDel",
                HeaderText = "",
                Text = "Hapus",
                UseColumnTextForButtonValue = true,
                Width = 70
            });

            // Binding
            _bs.DataSource = _items;
            dgv.DataSource = _bs;

            // Load JSON
            Directory.CreateDirectory(_folder);
            var loaded = LoadFromDisk();
            _items = new BindingList<RoutineItem>(loaded.OrderBy(i => i.At).ToList());
            _bs.DataSource = _items;
            dgv.DataSource = _bs;

            // Default input
            dtpdate.Value = DateTime.Today;
            dtptime.Value = DateTime.Today.AddHours(8);
        }

        // ========= FORM CLOSING =========
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToDisk();
        }

        // ========= TAMBAH / SIMPAN =========
        private void btntambah_Click(object sender, EventArgs e)
        {
            var activity = GetActivityText(); // validasi bersih

            if (string.IsNullOrEmpty(activity))
            {
                MessageBox.Show("Isi 'Kegiatan' dulu ya.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = new RoutineItem
            {
                Date = dtpdate.Value.Date,
                Hour = dtptime.Value.Hour,
                Minute = dtptime.Value.Minute,
                Activity = activity
            };

            _items.Add(item);
            Resort();
            SaveToDisk();
            ClearInputs();
        }

        // ========= HAPUS (tombol umum) =========
        private void btnhps_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is RoutineItem sel)
            {
                if (ConfirmDelete(sel))
                {
                    _items.Remove(sel);
                    SaveToDisk();
                }
            }
            else
            {
                MessageBox.Show("Pilih item pada daftar dulu.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ========= HAPUS (tombol per baris di kanan) =========
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgv.Columns[e.ColumnIndex].Name != "colDel") return;

            if (dgv.Rows[e.RowIndex].DataBoundItem is RoutineItem sel && ConfirmDelete(sel))
            {
                _items.Remove(sel);
                SaveToDisk();
            }
        }

        private bool ConfirmDelete(RoutineItem sel)
        {
            var ok = MessageBox.Show(
                $"Hapus '{sel.Activity}' ({sel.At:dd MMM yyyy HH:mm})?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return ok == DialogResult.Yes;
        }

        // ========= EXPORT JSON (btnjson) =========
        private void btnjson_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                FileName = $"Routine_{DateTime.Now:yyyyMMdd_HHmm}.json"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var list = _items.OrderBy(i => i.At).ToList();
                    var json = JsonSerializer.Serialize(list,
                        new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(sfd.FileName, json);
                    MessageBox.Show("Berhasil diexport.", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal export: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ========= SAVE / LOAD =========
        private void SaveToDisk()
        {
            try
            {
                Directory.CreateDirectory(_folder);
                var json = JsonSerializer.Serialize(_items.ToList(),
                    new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menyimpan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<RoutineItem> LoadFromDisk()
        {
            try
            {
                if (!File.Exists(FilePath)) return new List<RoutineItem>();
                var json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<RoutineItem>>(json) ?? new List<RoutineItem>();
            }
            catch
            {
                return new List<RoutineItem>();
            }
        }

        // ========= Helper =========
        private void Resort()
        {
            var ordered = _items.OrderBy(i => i.At).ToList();
            _items = new BindingList<RoutineItem>(ordered);
            _bs.DataSource = _items;
            dgv.DataSource = _bs;
        }

        private void ClearInputs()
        {
            dtpdate.Value = DateTime.Today;
            dtptime.Value = DateTime.Today.AddHours(8);
            txtbactivity.Text = "";
        }

        private string GetActivityText()
        {
            var s = txtbactivity.Text ?? "";
            s = s.Replace("\u200B", "")    // zero-width space
                 .Replace("\u00A0", " ");  // non-breaking space
            return s.Trim();
        }

        // ========= Handler kosong yang kamu miliki (tetap dipertahankan) =========
        private void button1_Click(object sender, EventArgs e) { }        // tidak dipakai
        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void lbltngl_Click(object sender, EventArgs e) { }
        private void lblwkt_Click(object sender, EventArgs e) { }
        private void dtptime_ValueChanged(object sender, EventArgs e) { }
        private void tlpLeft_Paint(object sender, PaintEventArgs e) { }
        private void pright_Paint(object sender, PaintEventArgs e) { }
        private void txtbactivity_TextChanged(object sender, EventArgs e) { }
        private void dtpdate_ValueChanged(object sender, EventArgs e) { }

        private void pleft_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
