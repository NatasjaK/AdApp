using AdApp.Models;
using Microsoft.Data.SqlClient;
using System.Xml.Linq;


namespace AdApp
{

    public partial class Form1 : Form
    {
        private User? LoggedInUser;
        private int? editingAdId = null;
        private int? editingAdOwnerId = null;
        private bool _initializing = false;

        private void UpdateAuthUI()
        {
            bool loggedIn = LoggedInUser != null;

            btnSaveAd.Visible = loggedIn;
            btnDeleteAd.Visible = loggedIn;
            btnLogout.Visible = loggedIn;
            btnLogin.Visible = !loggedIn; // göm "Logga in" när man är inloggad

            txtTitle.Enabled = loggedIn;
            txtDescription.Enabled = loggedIn;
            txtPrice.Enabled = loggedIn;
            cmbCategory.Enabled = loggedIn;

            lblLoggedInUser.Text = loggedIn
                ? $"Inloggad som: {LoggedInUser!.Username}"
                : "Ej inloggad";
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Shown(object? sender, EventArgs e)
        {
            txtSearchTitle.Text = "";
            cmbSearchCategory.SelectedIndex = 0; 
            cmbSort.SelectedIndex = 0;           
            LoadAds("", null);                   
        }


        private void LoadAds(string titleFilter = "", int? categoryId = null)
        {
            dgvAds.Rows.Clear();

            string orderBy = "a.CreatedAt DESC";
            string sortChoice = cmbSort?.SelectedItem?.ToString() ?? "Datum (nyast först)";
            switch (sortChoice)
            {
                case "Datum (äldst först)": orderBy = "a.CreatedAt ASC"; break;
                case "Pris (stigande)": orderBy = "a.Price ASC"; break;
                case "Pris (fallande)": orderBy = "a.Price DESC"; break;
                    // default = nyast först
            }

            string sql = $@"
SELECT a.Id, a.UserId, a.Title, a.Description, a.Price, c.Name AS Category, u.Username, a.CreatedAt
FROM Ads a
JOIN Categories c ON a.CategoryId = c.Id
JOIN Users u ON a.UserId = u.Id
WHERE (@title = '' OR a.Title LIKE '%' + @title + '%')
  AND (@catId IS NULL OR a.CategoryId = @catId)
ORDER BY {orderBy};";

            using var conn = new Database().GetConnection();
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@title", titleFilter ?? "");
            cmd.Parameters.AddWithValue("@catId", (object?)categoryId ?? DBNull.Value);

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                dgvAds.Rows.Add(
                    r["Id"], r["UserId"], r["Title"], r["Description"],
                    r["Price"], r["Category"], r["Username"],
                    Convert.ToDateTime(r["CreatedAt"]).ToString("yyyy-MM-dd HH:mm")
                );
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _initializing = true;
            LoggedInUser = null;   
            UpdateAuthUI();

            dgvAds.Columns.Clear();
            dgvAds.AutoGenerateColumns = false;
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "AdId", HeaderText = "Id", Visible = false });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "OwnerId", HeaderText = "OwnerId", Visible = false });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "Title", HeaderText = "Title", Width = 200 });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Description", Width = 250 });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Price" });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "Category" });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "User", HeaderText = "User" });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", HeaderText = "Date" });

            cmbCategory.Items.Clear();
            cmbSearchCategory.Items.Clear();

            using (var conn = new Database().GetConnection())
            {
                conn.Open();
                using var cmd = new SqlCommand("SELECT Id, Name FROM Categories", conn);
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var item = new ComboBoxItem { Text = r["Name"].ToString(), Value = (int)r["Id"] };
                    cmbCategory.Items.Add(item);
                    cmbSearchCategory.Items.Add(new ComboBoxItem { Text = item.Text, Value = item.Value });
                }
            }

            cmbSearchCategory.Items.Insert(0, new ComboBoxItem { Text = "Alla", Value = 0 });
            cmbSearchCategory.SelectedIndex = 0;

            cmbSort.Items.Clear();
            cmbSort.Items.Add("Datum (nyast först)");
            cmbSort.Items.Add("Datum (äldst först)");
            cmbSort.Items.Add("Pris (stigande)");
            cmbSort.Items.Add("Pris (fallande)");
            cmbSort.SelectedIndex = 0;

            _initializing = false;

            LoadAds(txtSearchTitle.Text.Trim(), null);
            dgvAds.ReadOnly = true;
            dgvAds.RowHeadersVisible = false;
            dgvAds.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAds.MultiSelect = false;
            dgvAds.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAds.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAds.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvAds.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 250); 
            dgvAds.ColumnHeadersDefaultCellStyle.Font = new Font(dgvAds.Font, FontStyle.Bold);

            dgvAds.Columns["Price"].DefaultCellStyle.Format = "C2";
            dgvAds.Columns["Price"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("sv-SE");

        }


        /*private void Form1_Load(object sender, EventArgs e)
        {

            btnSaveAd.Visible = false;
            btnDeleteAd.Visible = false;
            btnLogout.Visible = false;


            dgvAds.Columns.Clear();
            dgvAds.AutoGenerateColumns = false;

            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "AdId", HeaderText = "Id", Visible = false });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "OwnerId", HeaderText = "OwnerId", Visible = false });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "Title", HeaderText = "Title", Width = 200 });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Description", Width = 250 });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Price" });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "Category" });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "User", HeaderText = "User" });
            dgvAds.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", HeaderText = "Date" });


            cmbCategory.Items.Clear();
            cmbSearchCategory.Items.Clear();
            Database db = new Database();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id, Name FROM Categories", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbCategory.Items.Add(new ComboBoxItem
                    {
                        Text = reader["Name"].ToString(),
                        Value = (int)reader["Id"]
                    });
                }
            }
        }*/


        private void btnTestConnection_Click_1(object sender, EventArgs e)
        {
            Database db = new Database();
            using (SqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Anslutningen lyckades!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fel: " + ex.Message);
                }
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveAd_Click(object sender, EventArgs e)
        {
            if (LoggedInUser == null)
            {
                MessageBox.Show("Du måste vara inloggad för att skapa/uppdatera annons.");
                return;
            }

            var title = txtTitle.Text.Trim();
            var description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Titel krävs.");
                return;
            }
            if (!decimal.TryParse(txtPrice.Text, out var price))
            {
                MessageBox.Show("Ogiltigt pris.");
                return;
            }
            if (cmbCategory.SelectedItem is not ComboBoxItem categoryItem)
            {
                MessageBox.Show("Välj en kategori.");
                return;
            }
            int categoryId = categoryItem.Value;

            using var conn = new Database().GetConnection();
            conn.Open();

            if (editingAdId == null)
            {
                var sql = @"INSERT INTO Ads (Title, Description, Price, CategoryId, UserId)
                    VALUES (@title, @desc, @price, @catId, @userId)";
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@desc", (object)description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@catId", categoryId);
                cmd.Parameters.AddWithValue("@userId", LoggedInUser.Id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Annons sparad!");
            }
            else
            {
                if (editingAdOwnerId != LoggedInUser.Id)
                {
                    MessageBox.Show("Du kan bara uppdatera dina egna annonser.");
                    return;
                }

                var sql = @"UPDATE Ads
                    SET Title=@title, Description=@desc, Price=@price, CategoryId=@catId
                    WHERE Id=@id AND UserId=@userId";
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@desc", (object)description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@catId", categoryId);
                cmd.Parameters.AddWithValue("@id", editingAdId.Value);
                cmd.Parameters.AddWithValue("@userId", LoggedInUser.Id);
                int rows = cmd.ExecuteNonQuery();

                MessageBox.Show(rows > 0 ? "Annons uppdaterad!" : "Inget uppdaterades (saknar behörighet?).");
            }

            editingAdId = null;
            editingAdOwnerId = null;
            txtTitle.Clear(); txtDescription.Clear(); txtPrice.Clear(); cmbCategory.SelectedIndex = -1;
            LoadAds(txtSearchTitle.Text.Trim(), (cmbSearchCategory.SelectedItem as ComboBoxItem)?.Value);
        }



        private void txtSearchTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvAds_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvAds.Rows[e.RowIndex];

            editingAdId = Convert.ToInt32(row.Cells["AdId"].Value);
            editingAdOwnerId = Convert.ToInt32(row.Cells["OwnerId"].Value);

            txtTitle.Text = row.Cells["Title"].Value?.ToString() ?? "";
            txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
            txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "";

            string catName = row.Cells["Category"].Value?.ToString();
            for (int i = 0; i < cmbCategory.Items.Count; i++)
            {
                if (((ComboBoxItem)cmbCategory.Items[i]).Text == catName)
                {
                    cmbCategory.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string title = txtSearchTitle.Text.Trim();
            var selected = cmbSearchCategory.SelectedItem as ComboBoxItem;
            int? catId = (selected != null && selected.Value != 0) ? selected.Value : (int?)null;
            LoadAds(txtSearchTitle.Text.Trim(), catId);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                LoggedInUser = loginForm.LoggedInUser;
                UpdateAuthUI();
            }
            else
            {
                MessageBox.Show("Inloggning avbruten.");
            }
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initializing) return;
            var sel = cmbSearchCategory.SelectedItem as ComboBoxItem;
            int? catId = sel?.Value;
            LoadAds(txtSearchTitle.Text.Trim(), catId);
        }

        private void btnDeleteAd_Click(object sender, EventArgs e)
        {
            if (LoggedInUser == null) { MessageBox.Show("Du måste vara inloggad."); return; }
            if (editingAdId == null) { MessageBox.Show("Välj en annons i listan först."); return; }
            if (editingAdOwnerId != LoggedInUser.Id)
            {
                MessageBox.Show("Du kan bara ta bort dina egna annonser.");
                return;
            }
            if (MessageBox.Show("Ta bort annonsen?", "Bekräfta", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            using var conn = new Database().GetConnection();
            conn.Open();
            using var cmd = new SqlCommand("DELETE FROM Ads WHERE Id=@id AND UserId=@userId", conn);
            cmd.Parameters.AddWithValue("@id", editingAdId.Value);
            cmd.Parameters.AddWithValue("@userId", LoggedInUser.Id);
            int rows = cmd.ExecuteNonQuery();

            MessageBox.Show(rows > 0 ? "Annons borttagen." : "Kunde inte ta bort (saknar behörighet?).");

            editingAdId = null;
            editingAdOwnerId = null;
            txtTitle.Clear(); txtDescription.Clear(); txtPrice.Clear(); cmbCategory.SelectedIndex = -1;
            LoadAds(txtSearchTitle.Text.Trim(), (cmbSearchCategory.SelectedItem as ComboBoxItem)?.Value);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using var registerForm = new RegisterForm();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Registrering klar. Logga in via 'Logga in'.");
            }
        }

        private void lblLoggedInUser_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoggedInUser = null;
            UpdateAuthUI();
            MessageBox.Show("Du är nu utloggad.");
        }

    }
}

