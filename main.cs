//   EUcsatlakozas.txt
//Ausztria;1995.01.01
//Belgium;1958.01.01
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class Eu{
    public string orszag {get; private set;}
    public string datum  {get; private set;}
    public string ev     {get; private set;}
    public string honap  {get; private set;}

    public Eu(string sor){
        var s = sor.Split(';');
        this.orszag = s[0];
        this.datum  = s[1];
        this.ev     = s[1].Substring(0,4);
        this.honap  = s[1].Substring(5,2);

    }
}

class Program{
    public static void Main (string[] args) {

// 2.
    var lista = new List<Eu>();
    var f = new StreamReader("EUcsatlakozas.txt", Encoding.GetEncoding("iso-8859-1"));
    while(!f.EndOfStream){
       lista.Add(new  Eu(f.ReadLine()) );
    }

// 3.feladat: EU tagállamainak száma: ? db
    Console.WriteLine($"3. feladat: EU tagállamainak száma: {lista.Count} db");
    
// 4.feladat: 2007-ben ? ország csatlakozott.
    var darab = (from sor in lista where sor.ev == "2007" select sor).Count();
    Console.WriteLine($"4. feladat: 2007-ben {darab} ország csatlakozott.");

// 5. feladat: Magyarország csatlakozásának dátuma:
    var mo = (from sor in lista where sor.orszag == "Magyarország" select sor.datum).Last();
    Console.WriteLine($"5. feladat: Magyarország csatlakozásának dátuma: {mo}");

// 6. feladat: Májusban ? csatlakozás.
    var csatlakozas05 = (from sor in lista where sor.honap == "05" select sor); 
    if (csatlakozas05.Any()){
        Console.WriteLine($"6. feladat: Májusban volt csatlakozás.");
    }
    else{
        Console.WriteLine($"6. feladat: Májusban nem volt csatlakozás.");
    }
    
// 7. Utoljára csatlakozott tagállam 
    var utolso_csatlakozas = (from sor in lista orderby sor.datum select sor).Last();
    Console.WriteLine($"7. feladat: Legutoljára csatlakozott ország: {utolso_csatlakozas.orszag}");

// 8. feladat: évenkénti statisztika

    var statisztika = from sor in lista group sor by sor.ev;
    Console.WriteLine($"8. feladat: Statisztika");
    foreach(var q in statisztika){
        Console.WriteLine($"        {q.Key} - {q.Count()} ország");
    }
   }
}
