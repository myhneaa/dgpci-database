using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DGPCI
{
    public partial class MainForm : Form
    {
        static string connectionString = "User Id=dgpci; Password=dgpci; Data Source=localhost:1521/xe";
        OracleConnection connection = new OracleConnection(connectionString);
        int indexColoanaSelectata = -1;
        public MainForm()
        {
            InitializeComponent();
        }

        private void incarcaDate(string sql)
        {
            try
            {
                OracleDataAdapter dataAdapter = new OracleDataAdapter(sql, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcarea datelor: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                indexColoanaSelectata = e.ColumnIndex;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string tabelSelectat = comboBox1.SelectedItem.ToString();
                incarcaDate(@"SELECT *
                            FROM " + tabelSelectat);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0 || comboBox1.SelectedItem == null || indexColoanaSelectata == -1)
            {
                MessageBox.Show("Celula invalida!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    string tabelSelectat = comboBox1.SelectedItem.ToString();
                    string numeColoana = dataGridView1.Columns[indexColoanaSelectata].Name;
                    string valoareVeche = dataGridView1.SelectedRows[0].Cells[indexColoanaSelectata].Value.ToString();

                    string numeColoanaID = "";
                    switch (tabelSelectat)
                    {
                        case "PERSOANA":
                            numeColoanaID = "ID_PERSOANA";
                            break;
                        case "PERMIS":
                            numeColoanaID = "ID_PERMIS";
                            break;
                        case "CATEGORIE":
                            numeColoanaID = "COD_CATEGORIE";
                            break;
                        case "SANCTIUNE":
                            numeColoanaID = "ID_SANCTIUNE";
                            break;
                        case "INMATRICULARE":
                            numeColoanaID = "ID_INMATRICULARE";
                            break;
                        case "RCA":
                            numeColoanaID = "ID_RCA";
                            break;
                        case "ITP":
                            numeColoanaID = "ID_ITP";
                            break;
                        case "DETALII_PERMIS":
                            numeColoanaID = "ID_PERMIS";
                            break;
                        case "ISTORIC_INSTRAINARE":
                            numeColoanaID = "ID_INSTRAINARE";
                            break;
                        default:
                            MessageBox.Show("Selecteaza un tabel!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }

                    string valoareID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    if(numeColoana == numeColoanaID)
                    {
                        MessageBox.Show("Nu ai voie sa modifici ID-ul (Cheia Primara).", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string valoareNoua = ShowInputDialog(
                        "Modifica " + numeColoana + " (Valoare Veche: " + valoareVeche + ")",
                        "Modificare in " + tabelSelectat,
                        valoareVeche);

                    if (valoareNoua == "" || valoareNoua == valoareVeche) return;

                    string sql = "UPDATE " + tabelSelectat + " SET " + numeColoana + " = :valoareNoua WHERE " + numeColoanaID + " = :id";

                    using (OracleCommand cmd = new OracleCommand(sql, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("valoareNoua", valoareNoua));
                        cmd.Parameters.Add(new OracleParameter("id", valoareID));

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("A fost modificat cu succes " + numeColoana + ".", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        incarcaDate("SELECT * FROM " + tabelSelectat);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 & comboBox1.SelectedItem != null)
            {
                string tabelSelectat = comboBox1.SelectedItem.ToString();
                string valoareID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string numeColoanaID = "";

                switch (tabelSelectat)
                {
                    case "PERSOANA":
                        numeColoanaID = "ID_PERSOANA";
                        break;
                    case "PERMIS":
                        numeColoanaID = "ID_PERMIS";
                        break;
                    case "CATEGORIE":
                        numeColoanaID = "COD_CATEGORIE";
                        break;
                    case "VEHICUL":
                        numeColoanaID = "SERIE_SASIU";
                        break;
                    case "SANCTIUNE":
                        numeColoanaID = "ID_SANCTIUNE";
                        break;
                    case "INMATRICULARE":
                        numeColoanaID = "ID_INMATRICULARE";
                        break;
                    case "RCA":
                        numeColoanaID = "ID_RCA";
                        break;
                    case "ITP":
                        numeColoanaID = "ID_ITP";
                        break;
                    case "DETALII_PERMIS":
                        numeColoanaID = "ID_PERMIS";
                        break;
                    case "ISTORIC_INSTRAINARE":
                        numeColoanaID = "ID_INSTRAINARE";
                        break;
                    default:
                        MessageBox.Show("Selectati un tabel valid.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                DialogResult raspuns = MessageBox.Show(
                    "Sigur stergi inregistrarea cu ID: " + valoareID + " din " + tabelSelectat + "?",
                    "Confirmare Stergere",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (raspuns == DialogResult.Yes)
                {
                    try
                    {
                        string sql = "DELETE FROM " + tabelSelectat + " WHERE " + numeColoanaID + " = :id";

                        using (OracleCommand cmd = new OracleCommand(sql, connection))
                        {
                            cmd.Parameters.Add(new OracleParameter("id", valoareID));

                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                MessageBox.Show("Linia selectata din " + tabelSelectat + " a fost stearsa cu succes.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                incarcaDate("SELECT * FROM " + tabelSelectat);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare la stergere: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } 
            }
            else
            {
                MessageBox.Show("Selecteaza un rand si asigura-te ca ai ales un tabel din meniul de sus.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                incarcaDate(@"SELECT P.NUME, P.PRENUME, P.JUDET, PC.NUMAR_PERMIS, DP.COD_CATEGORIE 
                    FROM PERSOANA P
                    JOIN PERMIS PC ON P.ID_PERSOANA = PC.ID_PERSOANA
                    JOIN DETALII_PERMIS DP ON PC.ID_PERMIS = DP.ID_PERMIS
                    WHERE lower(P.COD_PERSOANA) like '1%' and lower(DP.COD_CATEGORIE) like '%b%'");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                incarcaDate(@"SELECT MARCA, COUNT(SERIE_SASIU) NR_MASINI, ROUND(AVG(PUTERE), 2) PUTERE_MEDIE
                            FROM VEHICUL
                            GROUP BY MARCA
                            HAVING AVG(PUTERE) BETWEEN 100 AND 200
                            ORDER BY PUTERE_MEDIE DESC");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                incarcaDate(@"CREATE OR REPLACE VIEW V_SOFERI_COMPUS AS
                            SELECT P.NUME, P.PRENUME, P.COD_PERSOANA, PC.NUMAR_PERMIS, PC.DATA_EXPIRARE
                            FROM PERSOANA P LEFT JOIN PERMIS PC ON P.ID_PERSOANA = PC.ID_PERSOANA");
                incarcaDate(@"SELECT * FROM V_SOFERI_COMPUS");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                incarcaDate(@"CREATE OR REPLACE VIEW V_STATISTICA_COMBUSTIBIL_COMPLEX AS
                            SELECT COMBUSTIBIL, COUNT(*) TOTAL_FLOTA, MAX(PUTERE) PUTERE_MAXIMA, ROUND(AVG(PUTERE), 0) PUTERE_MEDIE
                            FROM VEHICUL
                            GROUP BY COMBUSTIBIL
                            ORDER BY TOTAL_FLOTA DESC");
                incarcaDate(@"SELECT * FROM V_STATISTICA_COMBUSTIBIL_COMPLEX");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            connection.Open();
        }

        public static string ShowInputDialog(string text, string titlu, string valoareDefaultString = "")
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = titlu,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 350 };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340, Text = valoareDefaultString };
            Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Top = 90, DialogResult = DialogResult.OK };

            prompt.AcceptButton = confirmation;
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
