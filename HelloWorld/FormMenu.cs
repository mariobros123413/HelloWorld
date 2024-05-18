using OpenTK;
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
        public List<Accion> accionesPendientes = new List<Accion>();
        public bool isPaused = false;

        private Game game;
        private List<Objeto> objetos;
        public FormMenu(Game game)
        {
            InitializeComponent();
            FormClosing += FormMenu_FormClosing;
            this.game = game;
            this.objetos = new List<Objeto>(); // Inicializar la lista de objetos
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            if (game != null && game.listaEscenarios != null)
            {
                foreach (var escenario in game.listaEscenarios)
                {
                    TreeNode escenarioNode = new TreeNode(escenario.Nombre);
                    escenarioNode.Tag = escenario;

                    foreach (var objeto in escenario.ObtenerObjetos())
                    {
                        TreeNode objetoNode = new TreeNode(objeto.Key);
                        objetoNode.Tag = objeto.Value; 
                        objetos.Add(objeto.Value);
                        foreach (var parte in objeto.Value.ObtenerPartes())
                        {
                            TreeNode parteNode = new TreeNode(parte.Key);
                            parteNode.Tag = parte.Value;
                            objetoNode.Nodes.Add(parteNode);
                        }

                        escenarioNode.Nodes.Add(objetoNode);
                    }
                    treeView1.Nodes.Add(escenarioNode);
                }
            }
        }

        public void accionParabola()
        {
            float angle = (float)numericUpDown_Angle_Parabola.Value;
            float vel = (float)numericUpDown_Vel_Inicial_Parabola.Value;
            accionParabolaANodos(treeView1.Nodes, angle, vel);
        }
        private void accionParabolaANodos(TreeNodeCollection nodes, float angle, float vel)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked && node.Tag is Objeto objeto)
                {
                    Accion parabola = new AccionMovimientoParabolico(objeto, objetos, angle, vel, 9.8f, 1000, 0.8f);
                    AddAccion(parabola);
                }
                accionParabolaANodos(node.Nodes, angle, vel);

            }
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
                    FormMenu_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los escenarios: " + ex.Message, "Abrir escenarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void rotationXYZ()
        {
            float angulo = (float)numericUpDown_Angle.Value;
            AplicarRotacionANodos(treeView1.Nodes, angulo);
        }
        private void AplicarRotacionANodos(TreeNodeCollection nodes, float angulo)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    if (node.Tag is Escenario escenario)
                    {
                        if (ejeXtextbox.Checked)
                        {
                            escenario.AplicarRotacion(angulo, new Vector4(1, 0, 0, 1));
                        }

                        if (ejeYtextbox.Checked)
                            escenario.AplicarRotacion(angulo, new Vector4(0, 1, 0, 1));
                        if (ejeZtextbox.Checked)
                            escenario.AplicarRotacion(angulo, new Vector4(0, 0, 1, 1));

                    }
                    else if (node.Tag is Objeto objeto)
                    {
                        if (ejeXtextbox.Checked)
                            objeto.AplicarRotacion(angulo, new Vector4(1, 0, 0, 1));
                        if (ejeYtextbox.Checked)
                            objeto.AplicarRotacion(angulo, new Vector4(0, 1, 0, 1));
                        if (ejeZtextbox.Checked)
                            objeto.AplicarRotacion(angulo, new Vector4(0, 0, 1, 1));
                    }
                    else if (node.Tag is Parte parte)
                    {
                        if (ejeXtextbox.Checked)
                            parte.AplicarRotacion(angulo, new Vector4(1, 0, 0, 1));
                        if (ejeYtextbox.Checked)
                            parte.AplicarRotacion(angulo, new Vector4(0, 1, 0, 1));
                        if (ejeZtextbox.Checked)
                            parte.AplicarRotacion(angulo, new Vector4(0, 0, 1, 1));
                    }
                }
                // Recursivamente aplicar la función a los nodos hijos
                AplicarRotacionANodos(node.Nodes, angulo);
            }
        }
        public void traslationXYZ()
        {
            float traslationX = (float)numericUpDown_Traslation_X.Value;
            float traslationY = (float)numericUpDown_Traslation_Y.Value;
            float traslationZ = (float)numericUpDown_Traslation_Z.Value;
            AplicarTraslacionANodos(treeView1.Nodes, traslationX, traslationY, traslationZ);
        }
        private void AplicarTraslacionANodos(TreeNodeCollection nodes, float traslationX, float traslationY, float traslationZ)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    if (node.Tag is Escenario escenario)
                    {
                        escenario.AplicarTraslacion(new Vector3(traslationX, traslationY, traslationZ));
                    }
                    else if (node.Tag is Objeto objeto)
                    {
                        objeto.AplicarTraslacion(new Vector3(traslationX, traslationY, traslationZ));
                        //Console.WriteLine("Objeto: " + objeto.Nombre);
                    }
                    else if (node.Tag is Parte parte)
                    {
                        parte.AplicarTraslacion(new Vector3(traslationX, traslationY, traslationZ));
                        //Console.WriteLine("Parte: " + parte.Nombre);
                    }
                }
                // Recursivamente aplicar la función a los nodos hijos
                AplicarTraslacionANodos(node.Nodes, traslationX, traslationY, traslationZ);
            }
        }
        public void escalarXYZ()
        {
            float scaleX = (float)numericUpDown_Scaling_X.Value;
            float scaleY = (float)numericUpDown_Scaling_Y.Value;
            float scaleZ = (float)numericUpDown_Scaling_Z.Value;
            AplicarEscaladoANodos(treeView1.Nodes, scaleX, scaleY, scaleZ);
        }

        private void AplicarEscaladoANodos(TreeNodeCollection nodes, float scaleX, float scaleY, float scaleZ)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    if (node.Tag is Escenario escenario)
                    {
                        escenario.AplicarEscalado(new Vector3(scaleX, scaleY, scaleZ));
                    }
                    else if (node.Tag is Objeto objeto)
                    {
                        objeto.AplicarEscalado(new Vector3(scaleX, scaleY, scaleZ));
                        //Console.WriteLine("Objeto: " + objeto.Nombre);
                    }
                    else if (node.Tag is Parte parte)
                    {
                        parte.AplicarEscalado(new Vector3(scaleX, scaleY, scaleZ));
                        //Console.WriteLine("Parte: " + parte.Nombre);
                    }
                }
                // Recursivamente aplicar la función a los nodos hijos
                AplicarEscaladoANodos(node.Nodes, scaleX, scaleY, scaleZ);
            }
        }

        public void AddAccion(Accion accion)
        {
            accionesPendientes.Add(accion);
        }
        private void numericUpDown_Scaling_X_ValueChanged(object sender, EventArgs e)
        {
            escalarXYZ();
        }
        private void numericUpDown_Scaling_Y_ValueChanged(object sender, EventArgs e)
        {
            escalarXYZ();
        }

        private void numericUpDown_Scaling_Z_ValueChanged(object sender, EventArgs e)
        {
            escalarXYZ();
        }

        private void numericUpDown_Position_X_ValueChanged(object sender, EventArgs e)
        {
            traslationXYZ();
        }

        private void numericUpDown_Position_Y_ValueChanged(object sender, EventArgs e)
        {
            traslationXYZ();
        }

        private void numericUpDown_Position_Z_ValueChanged(object sender, EventArgs e)
        {
            traslationXYZ();
        }

        private void numericUpDown_Rotation_X_ValueChanged(object sender, EventArgs e)
        {
            rotationXYZ();
        }

        private void serializacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown_Angle_Parabola_ValueChanged(object sender, EventArgs e)
        {
            accionParabola();
        }

        private void numericUpDown_Vel_Inicial_Parabola_ValueChanged(object sender, EventArgs e)
        {
            accionParabola();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isPaused = false;

        }

        private void button_Pause_Click(object sender, EventArgs e)
        {
            isPaused = true;

        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            isPaused = false;
            accionesPendientes.Clear();
            foreach (var escenario in game.listaEscenarios)
            {
                escenario.ResetearPosicion();
            }
        }
    }
}
