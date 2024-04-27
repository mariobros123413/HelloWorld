using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class FormMenu : Form
    {
        private Game game;

        public FormMenu(Game game)
        {
            InitializeComponent();
            FormClosing += FormMenu_FormClosing;
            this.game = game;

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }
        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Archivos JSON (*.json)|*.json";
            saveFileDialog.Title = "Guardar escenarios";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    Serializador serializador = new Serializador();
                    serializador.Serializar(filePath, game.listaEscenarios);

                    MessageBox.Show("Escenarios guardados correctamente.", "Guardar escenarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar los escenarios: " + ex.Message, "Guardar escenarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos JSON (*.json)|*.json";
            openFileDialog.Title = "Abrir escenarios";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    Serializador serializador = new Serializador();
                    List<Escenario> escenarios = serializador.Deserializar<List<Escenario>>(filePath);

                    MessageBox.Show("Escenarios cargados correctamente.", "Abrir escenarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (game != null)
                    {
                        game.listaEscenarios = escenarios;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los escenarios: " + ex.Message, "Abrir escenarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
