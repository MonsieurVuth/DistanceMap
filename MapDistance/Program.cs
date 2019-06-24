using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonLoad jason = new JsonLoad("cities.json");
            List<MapItem> item = jason.InfoMap();
            List<List<MapItem>> list = new List<List<MapItem>>();
            Random rnd = new Random();

            //Génération de liste de parcours sans doublons
            for (int iI = 0; iI < 500; iI++)
            {
                List<MapItem> index = new List<MapItem>();
                int i = 0;
                while (i < 15)
                {
                    index = item.OrderBy(key => rnd.Next()).Select(key => key).ToList();
                    if (!list.Contains(index))
                    {
                        list.Add(index);
                        i++;
                    }
                }

            }

            //Calcul des distances + récupération des villes associées
            Dictionary<String, String> listdistance = new Dictionary<String, String>();
            List<String> cities = new List<string>();
            Coordinate coor = new Coordinate();        
            foreach (List<MapItem> ilist in list)
            {            
                String villes = "";
                int index = ilist.Count;
                Double distance = 0;
                for (int j = 0; j < index; j++)
                {
                    if (j < index - 1)
                    {
                        distance += coor.GetDistance(ilist[j].lan, ilist[j].lng, ilist[j + 1].lan, ilist[j + 1].lng);
                        villes += ilist[j].city + " ";
                    }
                    else
                    {
                        break;
                    }
                }
                // dictionnaire key value (key = distance, value = list des villes)
                listdistance.Add((distance / 1000).ToString(), villes);
                
            }
            //Trier par ordre croissant le dictionnaire et récupérer les XXX distances minimales et leur chemin associé
            Dictionary<String, string> best = new Dictionary<string, string>();
            int ind = 0;
            foreach (KeyValuePair<string, string> pair in listdistance.OrderBy(key => key.Key))
            {
                //Récupération des 50 meilleures résultats
                if(ind <= 59)
                {
                    best.Add(pair.Key, pair.Value);
                    ind++;
                }
            }

            //Récupération des meilleurs fitting + Croisement
            for (int iI = 0; iI <= best.Count - 1; iI++)
            {
                //Parent1
                String[] array1 = best.ElementAt(iI).Value.Split(' ');
                int jj = 0;
                String villes = "";
                while(jj <= 6)
                {
                    villes += array1.ElementAt(jj) + " ";                    
                    jj++;
                }
                Console.WriteLine(villes);
            }
        }

            
    
    }
}

