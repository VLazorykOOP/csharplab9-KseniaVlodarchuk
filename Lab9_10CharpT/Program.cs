using Lab9_10CharpT;

class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Номер Завдання: ");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    {
                        BackspaceProcessor task1 = new BackspaceProcessor();
                        task1.Run();
                        break;
                    }
                case 2:
                    {
                        Student student = new Student();
                        student.Run();
                        break;
                    }
                case 3:
                    {
                        Student student = new Student();
                        student.RunArrayList();

                        BackspaceProcessor task2 = new BackspaceProcessor();
                        task2.RunArrayList();
                        break;
                    }
                case 4:
                    {
                        MusicCatalog catalog = new MusicCatalog();

                        catalog.AddDisk("Disk1");
                        catalog.AddDisk("Disk2");

                        catalog.AddSong("Disk1", "Artist1", "Song1");
                        catalog.AddSong("Disk1", "Artist1", "Song2");
                        catalog.AddSong("Disk1", "Artist2", "Song3");
                        catalog.AddSong("Disk2", "Artist2", "Song4");

                        catalog.ViewCatalog();

                        catalog.SearchByArtist("Artist1");

                        catalog.RemoveDisk("Disk1");
                        catalog.ViewCatalog();
                        break;
                    }
            }
            
           
        }

    }
}