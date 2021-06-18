using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics.PerformanceData;

namespace DoodleGame
{
    public static class Controller
    {
        public static List<Platform> platforms;
        public static List<Coin> coins;
        public static int startPlatformPosY;
        public static int startCoinPosY;
        public static int money = 0;
        public static int score = 0;

        public static void AddPlatform(PointF position)
        {
            Platform platform = new Platform(position);
            platforms.Add(platform);
        }

        public static void AddCoin(PointF position)
        {
            Coin coin = new Coin(position);
            coins.Add(coin);
        }

        public static void GenerateListCoins()
        {
            Random r = new Random();
            for (int i = 0; i < 3; i++)
            {
                int x = r.Next(0, 270);
                int y = r.Next(130, 170);
                startCoinPosY -= y;
                PointF position = new PointF(x, startCoinPosY);
                Coin coin = new Coin(position);
                coins.Add(coin);

            }
        }

        public static void GenerateListPlatforms()
        {
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                int x = r.Next(0, 270);
                int y = r.Next(120, 160);
                startPlatformPosY -= y;
                PointF position = new PointF(x, startPlatformPosY);
                Platform platform = new Platform(position);
                platforms.Add(platform);
            }
        }

        public static void SpawnerCoin()
        {
            ClearCoins();
            Random r = new Random();
            int x = r.Next(0, 270);
            PointF position = new PointF(x, startCoinPosY);
            Coin coin = new Coin(position);
            coins.Add(coin);
        }

        public static void ClearCoins()
        {
            for (int i = 0; i < coins.Count; i++)
            {
                if (coins[i].transform.position.Y >= 700 | coins[i].transform.position.Y >= 4)
                    coins.RemoveAt(i);
            }
        }

        public static void SpawnerPlatform()
        {
            ClearPlatforms();
            Random r = new Random();
            int x = r.Next(0, 270);
            PointF position = new PointF(x, startPlatformPosY);
            Platform platform = new Platform(position);
            platforms.Add(platform);
        }

        public static void ClearPlatforms()
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                if (platforms[i].transform.position.Y >= 700)
                    platforms.RemoveAt(i);
            }
        }

    }
    public class Physics
    {
        public Transform transform;
        float gravity;
        float jumpSpeed;

        public float dx;
        public Physics(PointF position, Size size)
        {
            transform = new Transform(position, size);
            gravity = 0;
            jumpSpeed = 0.5f;
            dx = 0;
        }

        public void CalculatePhysics()
        {
            if (dx != 0)
            {
                transform.position.X += dx;
            }

            if (transform.position.Y < 700)
            {
                transform.position.Y += gravity;
                gravity += jumpSpeed;

                Collide();
            }
            CollideCoin();
        }

        public void Collide()
        {
            for (int i = 0; i < Controller.platforms.Count; i++)
            {
                var platform = Controller.platforms[i];
                if (transform.position.X + transform.size.Width / 2 >= platform.transform.position.X && transform.position.X + transform.size.Width / 2 <= platform.transform.position.X + platform.transform.size.Width)
                {
                    if (transform.position.Y + transform.size.Height >= platform.transform.position.Y && transform.position.Y + transform.size.Height <= platform.transform.position.Y + platform.transform.size.Height)
                    {
                        if (gravity > 0)
                        {
                            AddForce();
                            if (!platform.touchedPl)
                            {
                                Controller.score += 1;
                                Controller.SpawnerPlatform();
                                platform.touchedPl = true;
                            }
                        }
                    }
                }
            }
        }
        public void CollideCoin()
        {
            for (int i = 0; i < Controller.coins.Count; i++)
            {
                var coin = Controller.coins[i];
                if (transform.position.X + transform.size.Width / 2  >= coin.transform.position.X && transform.position.X + transform.size.Width / 2 <= coin.transform.position.X + coin.transform.size.Width)
                {
                    if (transform.position.Y + transform.size.Height  >= coin.transform.position.Y && transform.position.Y + transform.size.Height  <= coin.transform.position.Y + coin.transform.size.Height)
                    {
                            if (!coin.touchedPlCoin)
                            {
                                Controller.SpawnerCoin();
                                Controller.money += 10;
                                coin.touchedPlCoin = true;
                            }
                    }
                }
            }
        }

        public void AddForce()
        {
            gravity = -14;
        }
    }
}
