using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ModelGame;
namespace BUS
{
    public class busLevel
    {
        TrucXanhDbContext db = new TrucXanhDbContext();
        public tblLevel getFirstLevel()
        {
            return db.Levels.FirstOrDefault();
        }
        public tblLevel getLevelByID(int id)
        {
            return db.Levels.Where(x => x.levelID == id).FirstOrDefault();
        }
        public tblLevel getNextLevel(int id)
        {
            List<tblLevel> allListLevel = db.Levels.ToList();
            int flag = -1;
            for(int i=0; i < allListLevel.Count(); i++)
            {
                if (allListLevel[i].levelID == id)
                {
                    flag = i;
                }
            }
            if (flag == allListLevel.Count()-1)
                return null;
            return allListLevel[flag + 1]; ;
        }
        public tblLevel getPreLevel(int id)
        {
            List<tblLevel> allListLevel = db.Levels.ToList();
            int flag = -1;
            for (int i = 0; i < allListLevel.Count(); i++)
            {
                if (allListLevel[i].levelID == id)
                {
                    flag = i;
                }
            }
            if (flag == 0)
            {
                return allListLevel[0];
            }
            return allListLevel[flag - 1];
        }
        public int calculateScorePreLevel(int id)
        {
            tblLevel lv = getLevelByID(id);
            List<tblLevel> lstLV = db.Levels.ToList();
            int total = 0;
            foreach (var item in lstLV)
            {
                if (item.levelID != lv.levelID)
                {
                    total += item.totalScore;
                }
                else
                {
                    break;
                }
            }
            return total;
        }
    }
}
