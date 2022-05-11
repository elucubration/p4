using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p4
{
    public partial class Form1 : Form
    {
        Class1 joueurT = new Class1();
        Settings set = new Settings();
        string[][] salut = new string[7][];
        int[] jeton = new int[7]{0,1,2,3,4,5,6};
        List<int> jton = new List<int>();
        public Form1()
        {
            InitializeComponent();
            Debut();
        }
        public void Debut()
        {
            int compt = 0;
            for (int i = 50; i < pictureBox1.Height; i += 50)
            {//hauteur
                compt += 50;
            }
            int compt1 = (int)compt / 50;
            set.nbHaut = compt1;
            int intervalleH = (pictureBox1.Height - compt) / (compt1);
            set.InterH = intervalleH;
            compt = 0;
            for (int i = 50; i < pictureBox1.Width; i += 50)
            { //largeur
                compt += 50;
            }
            set.nbLarg = (int)compt / 50;
            int intervalleW = (pictureBox1.Width - compt) / ((int)compt / 50);
            set.InterL = intervalleW;
            //initialisation du tableau 
            for (int i = 0; i <salut.Length;i++)
            {
                salut[i]=new string[] { "n", "n", "n", "n", "n", "n"};
            }
            //dépend du tour joueur
            joueurT.tour = true;//true->joueur rouge , false-> joueur bleu
            salut[0][0] = "r";
            tour.Text = "joueur rouge";
            //
            jton=jeton.ToList();
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public Boolean Verif(int c, int l,string j)//j == r ou b
        {
            List<int[]> coord = new List<int[]>();         
            List<string> puiss = new List<string>();
            for (int y = -1; y <= 1; y++)
            {
                for (int u = -1; u <= 1; u++)
                { 
                    if ((y == 0 && u== 0)||(u == 0 && y == -1))
                    {
                        continue;
                    }
                    else
                    {
                        if (0 <= (c + u) && (c + u) <= 6 && 0 <= (l + y) && (l + y) <= 5)
                        {
                            if (salut[c + u][l + y] == j)
                            {
                                coord.Add(new int[] { c + u, l + y });
                                
                            }
                        }
                        
                    }
                }
            }
            if (coord.Count!=0) {
                for (int h=0;h<coord.Count;h++)
                {
                    if (Math.Abs(c-coord[h][0])==1 && Math.Abs(l-coord[h][1])==1)//diag
                    {
                        if (l-coord[h][1]==-1)
                        {
                            if (c-coord[h][0]==-1)
                            {
                                for (int y = 1; y <= 2; y++)
                                {
                                    if (0<=(coord[h][0] + y) && (coord[h][0] + y)<=6 && 0<=(coord[h][1] + y) && (coord[h][1] + y)<=5) {                                      
                                        if (salut[coord[h][0] + y][coord[h][1] + y] == j)
                                        {
                                            puiss.Add(j);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                        
                                    }                                   
                                }
                                if (puiss.Count == 1) { if (coord.Any(o=>o.SequenceEqual(new int[] { c-1,l-1}))) { return true; } }
                                
                            }
                            else
                            {
                                for (int y = 1; y <= 2; y++)
                                {
                                    if (0<=(coord[h][0] - y)&& (coord[h][0] - y)<=6&& 0<=(coord[h][1] + y)&& (coord[h][1] + y)<=5) {
                                        if (salut[coord[h][0] - y][coord[h][1] + y] == j)
                                        {
                                            puiss.Add(j);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                                                                                       
                                }
                                if (puiss.Count == 1) {//contains only checks reference not as obj
                                    var es = new int[] {c+1,l-1};
                                    if (coord.Any(o=>o.SequenceEqual(new int[] { c + 1, l - 1 })))
                                    {                                                                               
                                        return true;
                                    }                                                                                                                                               
                                }

                            }
                            
                        }
                        else
                        {
                            if (c - coord[h][0] == -1)
                            {
                                for (int y = 1; y <= 2; y++)
                                {
                                    if (0<=(coord[h][0] + y)&&( coord[h][0] + y)<=6&& 0<=(coord[h][1] - y)&& (coord[h][1] - y)<=5) {
                                        if (salut[coord[h][0] + y][coord[h][1] - y] == j)
                                        {
                                            puiss.Add(j);                                          
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }                                                                      
                                }
                                if (puiss.Count == 1) { if (coord.Any(o=>o.SequenceEqual(new int[] { c - 1, l + 1 }))) { return true; }  }
                            }
                            else
                            {
                                for (int y = 1; y <= 2; y++)
                                {
                                    if (0<=(coord[h][0] - y)&& (coord[h][0] - y)<=6&& 0<=(coord[h][1] - y)&& (coord[h][1] - y)<=5) {
                                        if (salut[coord[h][0] - y][coord[h][1] - y] == j)
                                        {
                                            puiss.Add(j);                                          
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }                                    
                                }
                                if (puiss.Count == 1) { if (coord.Any(o=>o.SequenceEqual(new int[] { c + 1, l + 1 })) == true) { return true; } }
                            }

                        } 
                        
                        if (puiss.Count == 2) { return true; }                                                
                    }
                    

                    if (Math.Abs(c-coord[h][0])==0 && Math.Abs(l-coord[h][1])==1)//colonne
                    {
                        for (int y=1;y<=2;y++)
                        {
                            if(coord[h][1] + y<=5)
                            {
                                if (salut[coord[h][0]][coord[h][1]  + y] == j)
                                {
                                    puiss.Add(j);
                                }
                                else
                                {
                                   
                                    break;
                                }
                            }                           
                        }                      
                        if (puiss.Count==2) { return true; }
                    }


                    if (Math.Abs(c-coord[h][0])==1&&Math.Abs(l-coord[h][1])==0)//ligne
                    {
                        if (c - coord[h][0] == -1)
                        {
                            for (int mp=1;mp<=2;mp++)
                            {
                                if(coord[h][0] + mp<=6){
                                    if (salut[coord[h][0] + mp][coord[h][1]] == j)
                                    {
                                        puiss.Add(j);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }                                
                            }
                            if (puiss.Count == 1) { if (coord.Any(o=>o.SequenceEqual(new int[] { c - 1, l }))) { return true; }}
                            
                        }
                        else {
                            for (int mp = 1; mp <= 2; mp++)
                            {
                                if (0<=coord[h][0] - mp )
                                {
                                    if (salut[coord[h][0] - mp][coord[h][1]] == j)
                                    {
                                        puiss.Add(j);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }                                
                            }
                            if (puiss.Count == 1) { if (coord.Any(o=>o.SequenceEqual(new int[] { c + 1, l }))) { return true; }}                           
                        }
                        if (puiss.Count == 2) { return true; }
                    }
                    puiss.Clear(); 
                }
                
            }
            else
            {
                return false;
            }
            return false;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {         
            Rectangle p = new Rectangle(0, 0, 50, 50);
            e.Graphics.FillEllipse(Brushes.Black, p);
            
            
            for (int j = 0; j <set.nbLarg ; j++)
            {
                for (int i = 0; i < set.nbHaut; i++)
                {
                    if (salut[j][i] == "n") {

                        Rectangle po = new Rectangle((50 + set.InterL) * j, (50 + set.InterH) * i, 50, 50);
                        e.Graphics.FillEllipse(Brushes.Black, po);
                    }
                    if (salut[j][i] == "r") {

                        Rectangle po = new Rectangle((50 + set.InterL) * j, (50 + set.InterH) * i, 50, 50);
                        e.Graphics.FillEllipse(Brushes.Red, po);
                    }
                    if (salut[j][i]=="b")
                    {
                        Rectangle po = new Rectangle((50 + set.InterL) * j, (50 + set.InterH) * i, 50, 50);
                        e.Graphics.FillEllipse(Brushes.Blue, po);
                    }

                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Left)) {
                
                for (int i=0;i<jton.Count;i++)
                {
                    if (joueurT.tour == true)
                    {
                        if (Array.IndexOf(salut[jton[i]], "r", 0) == 0)
                        {
                            if (jton[i] != jton.Min())
                            {
                                salut[jton[i]][0] = "n";
                                salut[jton[i - 1]][0] = "r";
                            }
                            break;
                        }

                    }
                    else {
                        if (Array.IndexOf(salut[jton[i]], "b", 0) == 0)
                        {
                            if (jton[i] != jton.Min())
                            {
                                salut[jton[i]][0] = "n";
                                salut[jton[i - 1]][0] = "b";
                            }
                            break;
                        }

                    }
                    
                }
                
            }
            if (e.KeyCode.Equals(Keys.Right)) {
    
                for (int i = 0; i < jton.Count; i++)
                {
                    if (joueurT.tour == true)
                    {
                        if (Array.IndexOf(salut[jton[i]], "r", 0) == 0)
                        {
                            if (jton[i] != jton.Max())
                            {
                                salut[jton[i]][0] = "n";
                                salut[jton[i + 1]][0] = "r";
                            }

                            break;
                        }
                    }
                    else
                    {
                        if (Array.IndexOf(salut[jton[i]], "b", 0) == 0)
                        {
                            if (jton[i] != jton.Max())
                            {
                                salut[jton[i]][0] = "n";
                                salut[jton[i + 1]][0] = "b";
                            }

                            break;
                        }

                    }
                    
                }
            }
            if (e.KeyCode.Equals(Keys.Space)) {
                for (int i = 0; i < jton.Count;i++) 
                {
                    if (joueurT.tour == true)
                    {
                        if (Array.IndexOf(salut[jton[i]], "r", 0) == 0)
                        {
                            int ind = 5;
                            
                            salut[jton[i]][0] = "n";
                            while (Array.IndexOf(salut[jton[i]], "n", ind) == -1)
                            {
                                ind--;
                                if (ind == -1)
                                {//possible error plateau full
                                    int index = 0;
                                    jton.RemoveAt(i);
                                    salut[jton[index]][0] = "b";
                                    joueurT.tour = false;
                                    tour.Text = "joueur bleu";
                                    break;
                                }
                                else
                                {
                                    salut[jton[i]][0] = "r";// revoir

                                    if (Verif(jton[i], ind, "r") == true && ind==0)
                                    {
                                        gagnant.Text = "gagné red !31423" + jton[i].ToString() + ind.ToString();
                                    }
                                }
                            }
                            
                            if (ind > -1)
                            {
                                salut[jton[i]][ind] = "r";                              
                                salut[jton[i]][0] = "n";
                                if (Verif(jton[i], ind, "r") == true)
                                {
                                    gagnant.Text = "gagné red !"+jton[i].ToString()+ind.ToString();
                                }
                                salut[jton[0]][0] = "b";
                                joueurT.tour = false;
                                tour.Text = "joueur bleu";
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (Array.IndexOf(salut[jton[i]], "b", 0) == 0)
                        {
                            int ind = 5;
                           
                            while (Array.IndexOf(salut[jton[i]], "n", ind) == -1)
                            {
                                ind--;
                                if (ind == -1)
                                {//possible error plateau full
                                    int index = 0;
                                    jton.RemoveAt(i);
                                    salut[jton[index]][0] = "r";
                                    joueurT.tour = true;
                                    tour.Text = "joueur rouge";
                                    break;
                                }
                                else
                                {
                                    salut[jton[i]][0] = "b";
                                    if (Verif(jton[i], ind, "b") == true && ind == 0)
                                    {
                                        gagnant.Text = "gagné blue !";
                                    }
                                }
                            }

                            if (ind >-1)
                            {
                                salut[jton[i]][ind] = "b";
                                salut[jton[i]][0] = "n";
                                if (Verif(jton[i], ind, "b") == true)
                                {
                                    gagnant.Text = "gagné blue !";
                                }
                                salut[jton[0]][0] = "r";
                                joueurT.tour = true;
                                tour.Text = "joueur rouge";
                            }
                            break;
                        }

                    }
                   
                    
                }
            }
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < salut.Length; i++)
            {
                salut[i] = new string[] { "n", "n", "n", "n", "n", "n" };
            }
            pictureBox1.Invalidate();
        }
    }
}
