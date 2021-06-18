﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DoodleGame
{
    public static class Controller
    {
        public static List<Platform> platforms;
        public static List<Coin> coins;
        public static int startPlatformPosY = 400;
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
            for (int i = 0; i < 5; i++)
            {
                int x = r.Next(0, 270);
                int y = r.Next(30, 40);
                startPlatformPosY -= y;
                PointF position = new PointF(x, startPlatformPosY);
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
            ClearPlatforms();
            Random r = new Random();
            int x = r.Next(0, 270);
            PointF position = new PointF(x, startPlatformPosY);
            Coin coin = new Coin(position);
            coins.Add(coin);
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

        public void ApplyPhysics()
        {
            CalculatePhysics();
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

        public void AddForce()
        {
            gravity = -12;
        }
    }
}
