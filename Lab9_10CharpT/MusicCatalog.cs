using System;
using System.Collections;

class MusicCatalog
{
    private Hashtable catalog = new Hashtable();

    public void AddDisk(string diskName)
    {
        if (!catalog.ContainsKey(diskName))
        {
            catalog.Add(diskName, new Hashtable());
            Console.WriteLine($"Диск '{diskName}' додано до каталогу.");
        }
        else
        {
            Console.WriteLine($"Диск з ім'ям '{diskName}' вже існує в каталозі.");
        }
    }

    public void RemoveDisk(string diskName)
    {
        if (catalog.ContainsKey(diskName))
        {
            catalog.Remove(diskName);
            Console.WriteLine($"Диск '{diskName}' видалено з каталогу.");
        }
        else
        {
            Console.WriteLine($"Диск з ім'ям '{diskName}' не знайдено в каталозі.");
        }
    }

    public void AddSong(string diskName, string artist, string songName)
    {
        if (catalog.ContainsKey(diskName))
        {
            Hashtable disk = (Hashtable)catalog[diskName];
            if (!disk.ContainsKey(artist))
            {
                disk.Add(artist, new ArrayList());
            }

            ArrayList songs = (ArrayList)disk[artist];
            songs.Add(songName);

            Console.WriteLine($"Пісню '{songName}' виконавця '{artist}' додано до диску '{diskName}'.");
        }
        else
        {
            Console.WriteLine($"Диск з ім'ям '{diskName}' не знайдено в каталозі.");
        }
    }

    public void RemoveSong(string diskName, string artist, string songName)
    {
        if (catalog.ContainsKey(diskName))
        {
            Hashtable disk = (Hashtable)catalog[diskName];
            if (disk.ContainsKey(artist))
            {
                ArrayList songs = (ArrayList)disk[artist];
                if (songs.Contains(songName))
                {
                    songs.Remove(songName);
                    Console.WriteLine($"Пісню '{songName}' виконавця '{artist}' видалено з диску '{diskName}'.");
                }
                else
                {
                    Console.WriteLine($"Пісню '{songName}' виконавця '{artist}' не знайдено на диску '{diskName}'.");
                }
            }
            else
            {
                Console.WriteLine($"Виконавця '{artist}' не знайдено на диску '{diskName}'.");
            }
        }
        else
        {
            Console.WriteLine($"Диск з ім'ям '{diskName}' не знайдено в каталозі.");
        }
    }

    public void ViewCatalog()
    {
        Console.WriteLine("Каталог:");

        foreach (DictionaryEntry disk in catalog)
        {
            string diskName = (string)disk.Key;
            Console.WriteLine($"- {diskName}");

            Hashtable diskContent = (Hashtable)disk.Value;
            foreach (DictionaryEntry artist in diskContent)
            {
                string artistName = (string)artist.Key;
                ArrayList songs = (ArrayList)artist.Value;

                Console.WriteLine($"  * {artistName}");
                foreach (string song in songs)
                {
                    Console.WriteLine($"    - {song}");
                }
            }
        }
    }

    public void SearchByArtist(string artist)
    {
        Console.WriteLine($"Результати пошуку для виконавця '{artist}':");

        foreach (DictionaryEntry disk in catalog)
        {
            string diskName = (string)disk.Key;

            Hashtable diskContent = (Hashtable)disk.Value;
            if (diskContent.ContainsKey(artist))
            {
                ArrayList songs = (ArrayList)diskContent[artist];

                Console.WriteLine($"- {diskName}");
                foreach (string song in songs)
                {
                    Console.WriteLine($"  - {song}");
                }
            }
        }
    }
}