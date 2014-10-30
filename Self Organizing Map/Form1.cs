using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Self_Organizing_Map
{
    public partial class Form1 : Form
    {
        //used for creating random vector
        Random gen;

        //the actual web for the SOM
        NeuronWeb web;

        //holds the training data
        List<double[]> trainingSet;

        //arrays of cubes to represent data
        //visually before and after training
        Cube[] initial, trained;

        List<Cube> section;

        //holds matrices for rotation
        Matrix4 matrixProjection, matrixModelview;

        //this variable holds the center of the set of cubes
        Vector3d center, shift;

        //flag that keeps track of what to draw
        bool drawInitial = true, webTrained = false;

        //for rotating scene
        double xRot = 0, yRot = 0, zRot = 0;

        //initializes the controls on the form
        public Form1()
        {
            InitializeComponent();
        }

        /*this event gets triggered when the form has finished loading its controls*/
        private void Form1_Load(object sender, EventArgs e)
        {
            gen = new Random();
            trainingSet = new List<double[]>();
            web = new NeuronWeb(6,6,6,4, 0.5);
            web.InitializeWeights(0, 255);

            center = new Vector3d(0, 0, -25);
            shift = new Vector3d(0, 0, 0);
            initial = new Cube[web.width * web.height * web.depth];
            trained = new Cube[web.width * web.height * web.depth];
            section = new List<Cube>();

            CreateCubes(ref web, ref initial, center, 1, 0);
        }

        /*function takes the neuron web and creates cubes for rendering with appropriate colors and locations*/
        private void CreateCubes(ref NeuronWeb web, ref Cube[] cubes, Vector3d center, double size, double spacing)
        {
            int count = 0;
            for (int row = 0; row < web.width; row++)
                for (int col = 0; col < web.height; col++)
                    for (int dep = 0; dep < web.depth; dep++)
                        cubes[count++] = CreateCube(ref web, new NeuronWeb.NeuronIndex(row, col, dep), center, size, spacing);
        }

        /*this function returns a single cube at the appropriate location for the specified neuron*/
        private Cube CreateCube(ref NeuronWeb web, NeuronWeb.NeuronIndex position, Vector3d center, double size, double spacing)
        {
            Neuron n = web.web[position.X, position.Y, position.Z];
            int a, r, g, b;
            double x, y, z;

            x = n.xCoord - web.width / 2.0 + center.X + spacing * (position.X + 1) - (spacing * web.width / 2.0);
            y = n.yCoord - web.height / 2.0 + center.Y + spacing * (position.Y + 1) - (spacing * web.height / 2.0);
            z = n.zCoord - web.depth / 2.0 + center.Z + spacing * (position.Z + 1) - (spacing * web.depth / 2.0);

            a = (int)n.weights[0];
            r = (int)n.weights[1];
            g = (int)n.weights[2];
            b = (int)n.weights[3];

            return new Cube(new Vector3d(x, y, z), size, Color.FromArgb(a, r, g, b));
        }


        /*this function returns a vector of specified dimension with random numbers between min and max*/
        private double[] GenerateRandomVector(double min, double max, int dimension)
        {
            double[] result = new double[dimension];

            for (int x = 0; x < result.Length; x++)
                result[x] = gen.NextDouble() * (max - min) + min;

            return result;
        }

        /*this handler is run whenever user clicks 'create data', it fills the training set with random input*/
        private void btnCreateData_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < Convert.ToInt32(txtTrainSize.Text); x++)
                trainingSet.Add(GenerateRandomVector(0, 255, 4));
        }

        /*this handler is run whenever user clicks 'Train', it trains the network off of training set*/
        private void btnTrain_Click(object sender, EventArgs e)
        {
            web.Train(trainingSet, Convert.ToInt32(txtEpochs.Text), true);
            CreateCubes(ref web, ref trained, center + shift, 1, 0);
            webTrained = true;
            treeView1.Nodes.Clear();
            PopulateTreeView(trainingSet);
        }

        /*this handler is run whenever user clicks to display initial cubes*/
        private void btnDisplayInitial_Click(object sender, EventArgs e)
        {
            if (drawInitial && webTrained)
                btnDisplayInitial.Text = "Display Initial";
            else
                btnDisplayInitial.Text = "Display Trained";

            drawInitial = !drawInitial;
            glControl1_Paint(this, null);
            glControl2_Paint(this, null);
        }

        /*used to animate openGL*/
        private void timer1_Tick(object sender, EventArgs e)
        {
            xRot += 2;
            yRot += 1;
            zRot += 3;
            glControl1_Paint(this, null);
            glControl2_Paint(this, null);
        }

        /*toggle switch for animation*/
        private void button1_Click(object sender, EventArgs e)
        {

            if (timer1.Enabled)
            {
                timer1.Stop();
                btnRotate.Text = "Start Rotation";
                btnRotate.BackColor = Color.DarkGreen;
                timer1.Enabled = false;
            }
            else
            {
                timer1.Start();
                btnRotate.Text = "Stop Rotation";
                btnRotate.BackColor = Color.Red;
                timer1.Enabled = true;
            }

        }

        /*number changer spaces out the cubes in the scene*/
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(numericUpDown1.Value);
            shift.Z = val;
            CreateCubes(ref web, ref initial, center + shift, 1, val / 10.0);
            CreateCubes(ref web, ref trained, center + shift, 1, val / 10.0);
            glControl1_Paint(this, null);
            glControl2_Paint(this, null);
        }

        /*takes classified input vectors and places them in a tree view by node*/
        private void PopulateTreeView(List<double[]> input)
        {
            int a, r, g, b;
            string indexing;
            TreeNode node;
            TreeNode[] children, octants;
            Dictionary<NeuronWeb.NeuronIndex, List<double[]>> dict = web.ClassifyData(input);
            octants = new TreeNode[8];

            for (int x = 0; x < octants.Length; x++)
                octants[x] = new TreeNode("Octant " + (x+1));

            foreach (NeuronWeb.NeuronIndex index in dict.Keys)
            {
                indexing = index.X + " " + index.Y + " " + index.Z;
                children = new TreeNode[dict[index].Count];

                for (int i = 0; i < dict[index].Count; i++)
                {
                    a = (int)dict[index][i][0];
                    r = (int)dict[index][i][1];
                    g = (int)dict[index][i][2];
                    b = (int)dict[index][i][3];

                    children[i] = new TreeNode(VectorToString(dict[index][i]));
                    children[i].ForeColor = Color.FromArgb(a, r, g, b);
                }

                a = (int)web.web[index.X, index.Y, index.Z].weights[0];
                r = (int)web.web[index.X, index.Y, index.Z].weights[1];
                g = (int)web.web[index.X, index.Y, index.Z].weights[2];
                b = (int)web.web[index.X, index.Y, index.Z].weights[3];

                node = new TreeNode(indexing, children);
                node.ForeColor = Color.FromArgb(a, r, g, b);
                octants[GetOctant(index.X, index.Y, index.Z) - 1].Nodes.Add(node);
            }

            foreach(TreeNode myNode in octants)
                treeView1.Nodes.Add(myNode);

            treeView1.Sort();
        }

        private int GetOctant(int x, int y, int z)
        {
         
            int w = web.width/2, h = web.height/2, d = web.depth/2;
  
            if (x < w && y < h && z < d)
                return 1;
            else if (x >= w && y < h && z < d)
                return 2;
            else if (x < w && y >= h && z < d)
                return 3;
            else if (x >= w && y >= h && z < d)
                return 4;
            else if (x < w && y < h && z >= d)
                return 5;
            else if (x >= w && y < h && z >= d)
                return 6;
            else if (x < w && y >= h && z >= d)
                return 7;
            else if (x >= w && y >= h && z >= d)
                return 8;
            else
                return 0;
        }

        /* converts an array of doubles into a string of integers for examining data*/
        private string VectorToString(double[] input)
        {
            string result = "";
            foreach (double d in input)
            {
                result += Math.Round(d) + ",";
            }
            return result;
        }



        ////////////////////////////////////////////////////////////////////////////
        /*--------------------------------OpenTK Drawing---------------------------------*/
        ////////////////////////////////////////////////////////////////////////////

        private void init()
        {
            GL.ClearColor(Color.FromArgb(255,25, 25,25));
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

            matrixProjection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, glControl1.Width / (float)glControl1.Height, 1f, 100f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref matrixProjection);

            Matrix4.CreateRotationY(0, out matrixModelview);
            matrixModelview = Matrix4.LookAt(0f, 0f, 3f, 0f, 0f, 0f, 0f, 1f, 0f);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref matrixModelview);
        }

        private void rotateScene()
        {
            GL.Translate(center + shift);
            GL.Rotate(xRot, new Vector3d(1, 0, 0));
            GL.Rotate(yRot, new Vector3d(0, 1, 0));
            GL.Rotate(zRot, new Vector3d(0, 0, 1));
            GL.Translate(-(center + shift));
        }

        /*runs after glControl1 is loaded*/
        private void glControl1_Load(object sender, EventArgs e)
        {
            glControl1.MakeCurrent();
            init();
        }

        /*method that draws to the glControl*/
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            glControl1.MakeCurrent();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.PushMatrix();
            rotateScene();

            GL.Begin(BeginMode.Quads);
            if (drawInitial)
                foreach (Cube cube in initial)
                    cube.Draw();
            else
                foreach (Cube cube in trained)
                    cube.Draw();
            GL.End();

            GL.PopMatrix();

            glControl1.SwapBuffers();
        }

        private void glControl2_Load(object sender, EventArgs e)
        {
            glControl2.MakeCurrent();
            init();
        }

        private void glControl2_Paint(object sender, PaintEventArgs e)
        {
            glControl2.MakeCurrent();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.PushMatrix();
            rotateScene();

            GL.Begin(BeginMode.Quads);
            foreach (Cube cube in section)
                cube.Draw();
            GL.End();

            GL.PopMatrix();

            glControl2.SwapBuffers();
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            string[] pos;
            int x, y, z;
           
            foreach (TreeNode node in e.Node.Nodes)
            {
                pos = node.Text.Split(' ');
                if (pos.Length == 3)
                {
                    x = Convert.ToInt32(pos[0]);
                    y = Convert.ToInt32(pos[1]);
                    z = Convert.ToInt32(pos[2]);
                    shift.Z += 5;
                    section.Add(CreateCube(ref web, new NeuronWeb.NeuronIndex(x, y, z), center, 1.0, 0));
                    shift.Z -= 5;
                }
            }
            glControl2_Paint(glControl2, null);
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
          
           string[] pos;
            int x, y, z;

            foreach (TreeNode node in e.Node.Nodes)
            {
               
                pos = node.Text.Split(' ');
                x = Convert.ToInt32(pos[0]);
                y = Convert.ToInt32(pos[1]);
                z = Convert.ToInt32(pos[2]);

                for (int i = 0; i < section.Count; i++)
                {
                    Cube c = section[i];
                    c.center -= center-shift;
                    if (c.center.X == x && c.center.Y == y && c.center.Z == z)
                    {
                        section.RemoveAt(i);
                    }
                    c.center += center - shift;
                }
            }
            glControl2_Paint(glControl2, null);
        
        }


    }
}