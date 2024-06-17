using System.Numerics;
using System.Runtime.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpaceEngerersSimularer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Vector3 gravitaton = new Vector3(0, -9.82f, 0);
        
        public double[,] Fysikhanterare(FysikObjekt[] fysikObjekts)
        {
            double[,] positioner = new double[2, 100];
            foreach (FysikObjekt t in fysikObjekts)
            {
                Vector3 q = new Vector3(0,0,0);
                for (int i = 0; q.Y >=0; i++)
                {
                     q = t.Updatterar(gravitaton * t.massa);
                    positioner[0, i] =q.X;
                    positioner[1, i] = q.Y;

                }
            }

            return positioner;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            FysikObjekt objekt = new FysikObjekt(new Vector3(1, 100, 0), (new  Vector3(0f, 0f, 0f)), 10);
            FysikObjekt[] atta = { objekt };

            double[,]värden = Fysikhanterare(atta);

            //en ike elegant metod för att komvatera arrays
            double[] xs= new double[100];
            for(int i = 0; i < 100; i++)
            {
                xs[i]=värden[0,i];
            }
            double[] ys = new double[100];
            for (int i = 0; i < 100; i++)
            {
                ys[i] = värden[1, i];
            }



            //plotar dattan
            formsPlot1.Plot.Add.Scatter(xs, ys);
            formsPlot1.Refresh();

        }
    }
}
