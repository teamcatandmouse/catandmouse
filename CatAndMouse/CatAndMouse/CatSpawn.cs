using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CatAndMouse
{
    public class CatSpawn
    {
        MainGame game = null;
        ContentManager content = null;

        float spawnTimer = 0f;
        float defaultSpawnTimer = 3f;

        public ArrayList spawnedCats = new ArrayList();

        int currentScoreLevel = 100;
        float spawnTimerChange = 0.2f;
        float maxSpawnRate = 0.2f;

       public void Load(ContentManager theContent, MainGame theGame)
        {
            spawnTimer = defaultSpawnTimer;
            game = theGame;
            content = theContent;
        }

       public void Update(float deltaTime)
        {
            spawnTimer -= deltaTime;

            if (spawnTimer <= 0)
            {

                Cat newCat = new Cat();

                newCat.Load(content, game);

                spawnedCats.Add(newCat);

                if (game.score > currentScoreLevel)
                {

                    defaultSpawnTimer -= spawnTimerChange;
                    currentScoreLevel += currentScoreLevel * 2;

                    if (defaultSpawnTimer < maxSpawnRate)
                    {
                        spawnTimerChange = maxSpawnRate;
                    }

                   
                }

                spawnTimer = defaultSpawnTimer;


            }
        }
    }
}
