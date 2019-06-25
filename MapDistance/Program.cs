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
            for (int iI = 0; iI < 2000; iI++)
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

            //Calcul coordonées
            Dictionary<Double, List<MapItem>> DicMap = new Dictionary<double, List<MapItem>>();
            foreach(List<MapItem>LesVilles in list)
            {
                Double distance = 0;
                Coordinate coor = new Coordinate();
                int index = LesVilles.Count;
                for (int j = 0; j < index - 1; j++)
                {
                    if (j < index - 1)
                    {
                        distance += coor.GetDistance(LesVilles[j].lan, LesVilles[j].lng, LesVilles[j + 1].lan, LesVilles[j + 1].lng);
                    }
                    else
                    {
                        break;
                    }
                }
                DicMap.Add(distance, LesVilles);
            }

            //Trier par ordre croissant le dictionnaire et récupérer les 60 plus petites distances
            int ind = 0;
            foreach (KeyValuePair<double, List<MapItem>> pair in DicMap.OrderBy(key => key.Key))
            {
                if (ind <= 59)
                {
                    String ville = " ";
                    Random random = new Random();
                    int unrand = random.Next(0, 14);
                    List<MapItem> Parent1 = pair.Value;                    
                    foreach (MapItem valcity in pair.Value)
                    {
                        //List<MapItem> Parent2 = pair.Value.ElementAt(1);
                        //List<MapItem> Parent1 = new List<MapItem>();
                        //Console.WriteLine(Parent1.Count);

                        //List<MapItem> Parent2 = new List<MapItem>();
                        //Random rand = new Random();
                        //int alea = rand.Next(0, pair.Value.Count - 1);
                        //List<MapItem> cities = new List<MapItem>();
                        ville += valcity.city + " ";
                    }
                    ind++;
                    Console.WriteLine(pair.Key + " " + ville);
                }              
            }           
                }
            }               
        }



        //Récupération des meilleurs fitting + Croisement
        //for (int iI = 0; iI <= best.Count -1; iI++)
        //{
        //    if(iI < best.Count - 1)
        //    {
        //        List<String> ListOfCities = new List<string>();
        //        //Parent1
        //        String[] array1 = best.ElementAt(iI).Value.Split(' ');                   
        //        int jj = 0;                   
        //        String villes = "";
        //        while (jj <= 7)
        //        {
        //            villes += array1.ElementAt(jj) + " ";
        //            jj++;
        //        }

        //        // Checker que le parent 1 ne possède pas déjà la ville
        //        //Parent2
        //        String[] array2 = best.ElementAt(iI + 1).Value.Split(' ');
        //        int kk = 7;
        //        while(kk <= 14)
        //        {
        //            villes += array2.ElementAt(kk) + " ";
        //            kk++;
        //        }
        //        if (!best.Values.Contains(villes))
        //        {
        //            ListOfCities.Add(villes);
        //        }
        //        //Récupération lat long -> ToDo
        //        foreach(String test in ListOfCities)
        //        {
        //            Console.WriteLine(test);
        //        }


