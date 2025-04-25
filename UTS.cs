// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library("Perpustakaan Umum", "Jl. Pusat Kota");
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEM MANAJEMEN PERPUSTAKAAN ===");
                Console.WriteLine("1. Tambah Buku");
                Console.WriteLine("2. Lihat Semua Buku");
                Console.WriteLine("3. Cari Buku Berdasarkan ID");
                Console.WriteLine("4. Cari Buku Berdasarkan Judul");
                Console.WriteLine("5. Perbarui Informasi Buku");
                Console.WriteLine("6. Hapus Buku");
                Console.WriteLine("7. Keluar");
                Console.Write("Pilih menu: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook(library);
                        break;
                    case "2":
                        library.DisplayAllBooks();
                        break;
                    case "3":
                        SearchBookById(library);
                        break;
                    case "4":
                        SearchBookByTitle(library);
                        break;
                    case "5":
                        UpdateBook(library);
                        break;
                    case "6":
                        RemoveBook(library);
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                        break;
                }

                Console.WriteLine("\nTekan Enter untuk melanjutkan...");
                Console.ReadLine();
            }
        }

        static void AddBook(Library library)
        {
            Console.WriteLine("Masukkan data buku:");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Judul: ");
            string title = Console.ReadLine();
            Console.Write("Penulis: ");
            string author = Console.ReadLine();
            Console.Write("Tahun Terbit: ");
            int yearPublished = int.Parse(Console.ReadLine());
            Console.Write("Status (tersedia/dipinjam): ");
            string status = Console.ReadLine();

            Book book = new Book(id, title, author, yearPublished, status);
            library.AddBook(book);
        }

        static void SearchBookById(Library library)
        {
            Console.Write("Masukkan ID buku: ");
            int id = int.Parse(Console.ReadLine());
            Book book = library.FindBookById(id);

            if (book != null)
            {
                Console.WriteLine(book);
            }
            else
            {
                Console.WriteLine("Buku tidak ditemukan.");
            }
        }

        static void SearchBookByTitle(Library library)
        {
            Console.Write("Masukkan kata kunci judul: ");
            string keyword = Console.ReadLine();
            List<Book> books = library.FindBooksByTitle(keyword);

            if (books.Count > 0)
            {
                Console.WriteLine("Hasil pencarian:");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine("Tidak ada buku yang ditemukan.");
            }
        }

        static void UpdateBook(Library library)
        {
            Console.Write("Masukkan ID buku yang ingin diperbarui: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Masukkan informasi baru:");
            Console.Write("Judul: ");
            string title = Console.ReadLine();
            Console.Write("Penulis: ");
            string author = Console.ReadLine();
            Console.Write("Tahun Terbit: ");
            int yearPublished = int.Parse(Console.ReadLine());
            Console.Write("Status (tersedia/dipinjam): ");
            string status = Console.ReadLine();

            library.UpdateBook(id, title, author, yearPublished, status);
        }

        static void RemoveBook(Library library)
        {
            Console.Write("Masukkan ID buku yang ingin dihapus: ");
            int id = int.Parse(Console.ReadLine());
            library.RemoveBook(id);
        }
    }

    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }
        public string Status { get; set; }

        public Book(int id, string title, string author, int yearPublished, string status)
        {
            Id = id;
            Title = title;
            Author = author;
            YearPublished = yearPublished;
            Status = status;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Judul: {Title}, Penulis: {Author}, Tahun: {YearPublished}, Status: {Status}";
        }
    }

    class Library
    {
        public string Name { get; set; }
        public string Address { get; set; }
        private List<Book> books;

        public Library(string name, string address)
        {
            Name = name;
            Address = address;
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("Buku berhasil ditambahkan.");
        }

        public void DisplayAllBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Belum ada buku di perpustakaan.");
                return;
            }

            Console.WriteLine("Daftar Buku:");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        public Book FindBookById(int id)
        {
            return books.Find(b => b.Id == id);
        }

        public List<Book> FindBooksByTitle(string keyword)
        {
            return books.FindAll(b => b.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public void UpdateBook(int id, string title, string author, int yearPublished, string status)
        {
            Book book = FindBookById(id);
            if (book != null)
            {
                book.Title = title;
                book.Author = author;
                book.YearPublished = yearPublished;
                book.Status = status;
                Console.WriteLine("Buku berhasil diperbarui.");
            }
            else
            {
                Console.WriteLine("Buku tidak ditemukan.");
            }
        }

        public void RemoveBook(int id)
        {
            Book book = FindBookById(id);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Buku berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Buku tidak ditemukan.");
            }
        }
    }
}
