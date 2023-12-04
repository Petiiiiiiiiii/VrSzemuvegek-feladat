using CA231204;

static void Beolvasas(List<VrSzemuveg> lista) 
{
    StreamReader reader = new(@"..\..\..\src\Vrszemuvegek.txt");
    _ = reader.ReadLine();
    while (!reader.EndOfStream) lista.Add(new VrSzemuveg(reader.ReadLine()));
    reader.Close();
}
static void Feladat6(List<VrSzemuveg> lista) 
{
    lista.ForEach(a => Console.WriteLine(a));
}
static List<VrSzemuveg> Feladat7Function(List<VrSzemuveg> lista) 
{
    return lista
        .Where(sz => sz.Latomezo > 100 && sz.KapcsolatTipus == "USB-C")
        .ToList();
}
static void Feladat7(List<VrSzemuveg> lista) 
{
    Console.WriteLine($"7.feladat: \n\t{lista.Count} db");
}
static void Feladat8(List<VrSzemuveg> lista) 
{
    List<VrSzemuveg> feladat8 = lista
        .Where(sz => sz.Suly < lista.Average(sz => sz.Suly))
        .ToList();

    Console.WriteLine("8.feladat:");
    feladat8.ForEach(a => Console.WriteLine(a));
    Console.WriteLine($"{feladat8.Count} db, az átlag pedig: {lista.Average(sz => sz.Suly)}");
}
static void Feladat10(List<VrSzemuveg> lista) 
{
    var feladat10 = lista
        .SelectMany(sz => sz.Erzekelok, (sz, e) => new { Sorszama = sz.Kod, Érzékelő = e })
        .Where(e => e.Érzékelő.Contains("gyorsulásmérő"))
        .ToList();

    Console.WriteLine("\n10.feladat:");

    feladat10.ForEach(a => Console.WriteLine($"\tSorszáma: {a.Sorszama}, Pixelek száma: {lista.Where(sz => sz.Kod == a.Sorszama).Select(sz => sz.LathatoPixelek()).First()}\n"));
}
static List<string> Feladat11(List<VrSzemuveg> lista) 
{
    var feladat11 = lista
        .SelectMany(sz => sz.Erzekelok, (sz, e) => new { Azonosito = sz.Kod, Érzékelő = e })
        .DistinctBy(sz => sz.Érzékelő)
        .Select(sz => sz.Érzékelő)
        .ToList();

    for (int i = 0; i < feladat11.Count; i++)
    {
        if (feladat11[i] == "laser") feladat11[i] = "lézer";
        else if (feladat11[i] == "infravoros") feladat11.RemoveAt(i);
    }

    return feladat11.Order().ToList();
}
static List<int> Feladat12Function(List<VrSzemuveg> lista) 
{
    return lista
        .Where(sz => sz.Suly == lista.Min(sz => sz.Suly))
        .Select(sz => sz.Kod)
        .ToList();
}
static void Feladat12(List<int> lista) 
{
    Console.WriteLine("12.feladat:");
    if (lista.Count == 1) Console.WriteLine("\tNincs 1-nél több legkönnyebb!");
    else foreach (int i in lista) Console.Write($"{i}, ");
}
static void Kiiras(List<VrSzemuveg> lista) 
{
    StreamWriter writer = new(@"..\..\..\src\ujfile.txt");
    var feladatKiiras = lista
        .Where(sz => sz.KapcsolatTipus == "Wireless")
        .ToList();
    try
    {
        for (int i = 0; i < 5; i++) writer.WriteLine(feladatKiiras[i]);
        Console.WriteLine("\n\n13.feladat: \n\tSikeres kiírás!");
    }
    catch
    {
        foreach (var item in feladatKiiras)
        {
            writer.WriteLine(item);
        }
        Console.WriteLine($"13. feladat: \n\t{feladatKiiras.Count} db volt csak, ezért az mind ki lett írva, sikeresen!");
    }
    writer.Close();
}


List<VrSzemuveg> szemuvegek = new();
try
{
    Beolvasas(szemuvegek);
    Console.WriteLine("Sikeres beolvasás!");
}
catch
{
    Console.WriteLine("Hiba a fájl beolvasás során!");
}

//6.feladat
Feladat6(szemuvegek);

//7.feladat
List<VrSzemuveg> feladat7 = Feladat7Function(szemuvegek);
Feladat7(feladat7);

//8.feladat
Feladat8(szemuvegek);

//9.feladat (kész az osztályban)

//10.feladat
Feladat10(szemuvegek);

//11.feladat (Feladat11 function adja vissza a kértet!)

//12.feladat
List<int> feladat12 = Feladat12Function(szemuvegek);
Feladat12(feladat12);

//13.feladat
Kiiras(szemuvegek);
