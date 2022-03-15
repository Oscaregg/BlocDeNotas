using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PruebaBlocNotas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {


            DialogResult r = MessageBox.Show("Se perderan los datos si crea un nuevo bloc de notas sin guardar antes ",
                "¿Està seguro que desea borrar este bloc de notas?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);


            if (r == DialogResult.Yes)
            {
                richTextBox1.Clear();
            }


        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Se perderan los datos si abre un bloc de notas sin guardar antes ",
                "¿Està seguro que desea abrir otro bloc de notas?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);



            if (r == DialogResult.Yes)
            {

                OpenFileDialog n1 = new OpenFileDialog();
                StreamReader n2 = null;
                n1.Filter = "Archivo de texto (txt) |*txt| Todos los archivos(*.*) |*.* ";
                n1.Title = "Abrir";
                n1.ShowDialog();
                String Directorio = n1.FileName;
                n2 = File.OpenText(Directorio);
                richTextBox1.Text = n2.ReadToEnd();

            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //Stream str;
            SaveFileDialog p1 = new SaveFileDialog();
            StreamWriter p2 = null;
            p1.Filter = "Archivo de texto (.txt) |*.txt| Todos los archivos(*.*) |*.*";
            p1.Title = "Guardar como";
            p1.ShowDialog();
            String Direct = p1.FileName;
            p2 = File.AppendText(Direct);
            p2.Write(richTextBox1.Text);
            p2.Flush();

            p2.Close();

        }

        public TreeNode arbol(DirectoryInfo DirectInfo)
        {
            TreeNode arbol2 = new TreeNode(DirectInfo.Name);
            foreach (var item in DirectInfo.GetDirectories())
            {
                arbol2.Nodes.Add(arbol(item));
            }

            foreach (var item2 in DirectInfo.GetFiles())
            {
                arbol2.Nodes.Add(new TreeNode(item2.Name));
            }

            return arbol2;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {

            String DirectRuta = "C:\\Users\\oscar\\OneDrive\\Escritorio";
            DirectoryInfo DirectInfo = new DirectoryInfo(DirectRuta);
            treeView1.Nodes.Add(arbol(DirectInfo));

            //string[] files = Directory.GetFiles(@"C:\Users\oscar\OneDrive\Escritorio", "*.txt");
            //foreach (var file in files)
            //{
            //    treeView1.Nodes.Add(file);
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult r = MessageBox.Show("Se perderan los datos si cierra el bloc de notas ",
                "¿Està seguro que desea salir?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            

            if( r == DialogResult.Yes)
            {
                Application.Exit();
            }


        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
