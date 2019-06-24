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

            //Calcul des distances
            Coordinate coor = new Coordinate();
            Dictionary<String, String> listdistance = new Dictionary<String, String>();
            List<String> cities = new List<string>();
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
                        villes += ilist[j].city + "--";
                    }
                    else
                    {
                        break;
                    }
                }
                //Faire un dictionnaire key value (key = distance, value = list des villes)
                listdistance.Add((distance / 1000).ToString(), villes);
            }

            // Loop over pairs with foreach.
            foreach (KeyValuePair<string, string> pair in listdistance.OrderBy(key => key.Key))
            {
                Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
            }
        }

            //Trier par ordre croissant le dictionnaire et récupérer les XXX distances minimales et leur chemin associé
            //Faire un croisement entre ces chemins (exemple : prendre les 7 premiers d'un chemin et les 8 derniers d'un autre)


            ////Affichage des distances
            //var sortedlist = listdistance.OrderBy(d => d);
            //Console.WriteLine("Distance min : " + sortedlist.First());
            /*foreach (String dist in sortedlist)
            {
                Console.WriteLine(dist);
            }*/
        }
    }

