using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    internal class Game
    {

        public Keys Direction { get; set; }

        public Keys Arrow { get; set; }

        public Timer Frame { get; set; }

        public Label lbpontuacao { get; set; }

        public Panel PnTela { get; set; }

        private int Pontos = 0;

        private Food food;

        private Snake Snake;

        private Bitmap offScreenBitmap;

        private Graphics bitmapGraph;

        private Graphics screenGraph;

        public Game(ref Timer timer, ref Label lebel, ref Panel panel)
        {
            PnTela = panel;

            Frame = timer;

            lbpontuacao = lebel;
            offScreenBitmap = new Bitmap(428, 428);
            Snake = new Snake();
            food = new Food();
            Direction = Keys.Left;
            Arrow = Direction;
        }
        public void StartGame()
        {
            Snake.reset();
            food.CreateFood();
            Direction = Keys.Left;
            bitmapGraph = Graphics.FromImage(offScreenBitmap);
            screenGraph = PnTela.CreateGraphics();
            Frame.Enabled = true;
        }
        public void tick()
        {
            if (((Arrow == Keys.Left) && (Direction != Keys.Right)) ||
            ((Arrow == Keys.Right) && (Direction != Keys.Left)) ||
            ((Arrow == Keys.Up) && (Direction != Keys.Down)) ||
            ((Arrow == Keys.Down) && (Direction != Keys.Up)))
            {

                Direction = Arrow;
            }

            switch (Direction)
            {
                case Keys.Left:
                    Snake.Left();
                    break;
                case Keys.Right:
                    Snake.Rigth();
                    break;
                case Keys.Up:
                    Snake.Up();
                    break;
                case Keys.Down:
                    Snake.Down();
                    break;
            }

            bitmapGraph.Clear(Color.White);

            bitmapGraph.DrawImage(Properties.Resources.food2,(food.location.X *15),(food.location.Y *15),15,15);

            bool gamerOver = false;

            for(int i=0; i< Snake.length; i++){
                if (i == 0){
                    bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#000000")), (Snake.location[i].X * 15), (Snake.location[i].Y * 15), 15, 15);
                }
                else{
                    bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#4f4f4f")), (Snake.location[i].X * 15), (Snake.location[i].Y * 15), 15, 15);
                }

                if ((Snake.location[i] == Snake.location[0]) && (i< 0)){
                    gamerOver = true;
                                    
                }

                screenGraph.DrawImage(offScreenBitmap, 0, 0);
                ckeckcollision();
                if (gamerOver){
                    GameOver();               
                }

            }
        }


        public void ckeckcollision(){
            if (Snake.location[0] == food.location){
                Snake.Eat();
                food.CreateFood();
                Pontos += 9;
                lbpontuacao.Text = "Pontos" + Pontos;
            }
                        
        }
        public void GameOver(){
            Frame.Enabled = false;
            bitmapGraph.Dispose();
            screenGraph.Dispose();
            lbpontuacao.Text = "Pontos";
            MessageBox.Show("Gamer Over :) ");
        }
    }
}
