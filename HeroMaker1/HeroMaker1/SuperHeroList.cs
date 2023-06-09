using System;
using System.Collections.Generic;
using System.Text;


namespace HeroMaker1
{
    public class SuperHeroList
    {
        private List<SuperHero> heroList;

        public SuperHeroList()
        {
            heroList = new List<SuperHero>();
        }

        public List<SuperHero> HeroList
        {
            get { return heroList; }
        }
    }
}
