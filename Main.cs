/* EUcsatlakozas.txt  http://www.infojegyzet.hu/vizsgafeladatok/okj-programozas/rendszeruzemelteto-191008/
Ausztria;1995.01.01
Belgium;1958.01.01
*/
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class Eu{
    public string orszag    {get;set;}
    public string datum     {get;set;} 
    public int    ev        {get;set;}
    public int    honap     {get;set;}
    public int    nap       {get;set;}

    public Eu(string sor)
    {
        var s = sor.Trim().Split(';');
        orszag = s[0];
        datum  = s[1];
        ev     = int.Parse(s[1].Substring(0, 4));
        honap  = int.Parse(s[1].Substring(5, 2));
        nap    = int.Parse(s[1].Substring(8, 2));
    }
}

class Program{
    public static void Main (string[] args) {
        var sr = new StreamReader("EUcsatlakozas.txt", Encoding.GetEncoding("ISO-8859-1"));
        var lista = new List<Eu>();
        while(!sr.EndOfStream){
            lista.Add(new Eu(sr.ReadLine()));
        }
         
// 3.feladat: EU tagállamainak száma: ? db
   Console.WriteLine($"3.feladat: EU tagállamainak száma: {lista.Count()} db");

// 4.feladat: 2007-ben ? ország csatlakozott.
   var csatlakozas = (
       from sor in lista
       where sor.ev == 2007
       select sor
   ).Count();
    Console.WriteLine($"4.feladat: 2007-ben {csatlakozas} ország csatlakozott.");

// 5. feladat: Magyarország csatlakozásának dátuma:
  var mo = (
      from sor in lista
      where sor.orszag == "Magyarország"
      select sor
  ).Last();
      Console.WriteLine($"5. feladat: Magyarország csatlakozásának dátuma: {mo.datum}");

// 6. feladat: Májusban ? csatlakozás.
       var maj = (
           from sor in lista 
           where sor.honap == 05
           select sor
       );
        if(maj.Count() > 0){
            Console.WriteLine("6. feladat: Májusban volt csatlakozás.");       
        }
        else{
            Console.WriteLine("6. feladat: Májusban nem volt csatlakozás.");
        }
            
// 7. Utoljára csatlakozott tagállam 
   
// 8. feladat: évenkénti statisztika

   }
}
